using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMRU.Core.Common.Implementations;
using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoreTests.Common
{
    [TestClass]
    public class MRUItemFileStorageTests
    {
        [TestMethod]
        public void ShouldCreateStorageWithValidPath()
        {
            MRUItemFileStorage fileStorage = new MRUItemFileStorage(path);
            Assert.IsNotNull(fileStorage);
        }

        [TestMethod]
        public void ShouldNotCreateStorageWithInvalidExtension()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                string path = ".mrustorage.pdf";
                MRUItemFileStorage fileStorage = new MRUItemFileStorage(path);
            }, "Storage created with invalid file extension");
        }

        [TestMethod]
        public void ShouldNotCreateStorageWithInvalidPath()
        {
            Assert.ThrowsException<ArgumentException>(() => {
                string path = null;
                MRUItemFileStorage fileStorage = new MRUItemFileStorage(path);
            }, "Storage created with invalid file path");
        }

        [TestMethod]
        public void ShouldReturnEmptyListFromEmptyStorageFile()
        {
            MRUItemFileStorage fileStorage = new MRUItemFileStorage(path);
            List<MRUItem> items = fileStorage.ReadMRUItems() as List<MRUItem>;
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count == 0);
        }

        [TestMethod]
        public void ShouldSaveAndReadMRUItems()
        {
            MRUItemFileStorage fileStorage = new MRUItemFileStorage(path);
            List<MRUItem> items = CreateItems();
            fileStorage.SaveMRUItems(items);

            List<MRUItem> readedItems = fileStorage.ReadMRUItems() as List<MRUItem>;
            Assert.IsNotNull(readedItems);
            Assert.IsTrue(readedItems.Count == 2);
            Assert.IsTrue(readedItems[0].FilePath == "path1");
            Assert.IsTrue(readedItems[0].Pinned);
        }



        [TestCleanup]
        public void TearDown()
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        readonly string path = "mrustorage.xml";

        private List<MRUItem> CreateItems()
        {
            List<MRUItem> items = new List<MRUItem>();

            MRUItem item1 = new MRUItem
            {
                FilePath = "path1",
                Pinned = true,
                SelectedCount = 1
            };
            MRUItem item2 = new MRUItem
            {
                FilePath = "path2",
                Pinned = false,
                SelectedCount = 3
            };
            items.Add(item1);
            items.Add(item2);

            return items;
        }
    }
}
