using CoreTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMRUSuiteCore.Common.Implementations;
using OpenMRUSuiteCore.Common.Models;
using System;
using System.Collections.Generic;

namespace CoreTests.Common
{
    [TestClass]
    public class MRUManagerTest
    {
        [TestMethod]
        public void ShouldReadMRUItemsOnInitialization()
        {
            Initialize();
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1");
            Assert.IsTrue(manager.MRUItems[0].Pinned);
        }

        [TestMethod]
        public void ShouldAddNewMRUItem()
        {
            Initialize();
            manager.AddFile("path3");
            Assert.IsTrue(manager.MRUItems.Count == 3);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[2].FilePath == "path3");
            Assert.IsFalse(manager.MRUItems[2].Pinned);
            Assert.IsTrue(manager.MRUItems[2].SelectedCount == 1);
            Assert.IsFalse(itemSelectedWasInvoked, "Item selected was invoked on adding");
        }

        [TestMethod]
        public void ShouldAddExistedMRUItem()
        {
            Initialize();
            // in this case, existed item should be updated
            // TODO: can fail in certain situatioin :-)
            DateTime targetDt = DateTime.Now;
            manager.AddFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1");
            Assert.IsTrue(manager.MRUItems[0].Pinned);
            Assert.IsTrue(manager.MRUItems[0].SelectedCount == 2);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Year == targetDt.Year);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Month == targetDt.Month);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Day == targetDt.Day);
            Assert.IsFalse(itemSelectedWasInvoked, "Item selected was invoked on exsisted item adding");
        }

        [TestMethod]
        public void ShouldRemoveMRUItem()
        {
            Initialize();
            manager.RemoveFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 1);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path2");
            Assert.IsFalse(manager.MRUItems[0].Pinned);
        }

        [TestMethod]
        public void ShouldClearMRUItems()
        {
            Initialize();
            manager.ClearMRUItems();
            Assert.IsTrue(manager.MRUItems.Count == 0);
            Assert.IsTrue(listChangedWasInvoked);
        }

        [TestMethod]
        public void ShouldChangePinnedStateForMRUItem()
        {
            Initialize();
            manager.ChangePinStateForFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1");
            Assert.IsFalse(manager.MRUItems[0].Pinned);
        }

        [TestMethod]
        public void ShouldHandleSelectionOfMRUItem()
        {
            Initialize();
            // TODO: can fail in certain situatioin :-)
            DateTime targetDt = DateTime.Now;
            manager.SelectFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1");
            Assert.IsTrue(manager.MRUItems[0].Pinned);
            Assert.IsTrue(manager.MRUItems[0].SelectedCount == 2);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Year == targetDt.Year);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Month == targetDt.Month);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Day == targetDt.Day);
            Assert.IsTrue(itemSelectedWasInvoked, "Item selected was not invoked on selection");
        }


        private MRUManager manager;

        private void Initialize()
        {
            listChangedWasInvoked = false;
            itemSelectedWasInvoked = false;
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.MRUItemSelected += Manager_MRUItemSelected;
            manager.Initialize(storage);
        }

        private void Manager_MRUItemSelected(string obj)
        {
            itemSelectedWasInvoked = true;
        }
        private void Manager_MRUItemsListChanged()
        {
            listChangedWasInvoked = true;
        }

        private bool listChangedWasInvoked;
        private bool itemSelectedWasInvoked;

        private List<MRUItem> CreateItems()
        {
            List<MRUItem> items = new List<MRUItem>();

            MRUItem item1 = new MRUItem
            {
                FilePath = "path1",
                Pinned = true,
                SelectedCount = 1,
                LastAccessedDate = new DateTime(2019, 4, 27)
            };
            MRUItem item2 = new MRUItem
            {
                FilePath = "path2",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = new System.DateTime(2019, 4, 26)
            };
            items.Add(item1);
            items.Add(item2);

            return items;
        }
    }
}
