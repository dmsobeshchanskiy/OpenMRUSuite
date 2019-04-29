using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRUCore;
using MRUCore.Manager;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MRUManagerTest
    {
        [TestMethod]
        public void ShouldReadMRUItemsOnInitialization ()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(itemsFromEvent.Count == 2);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path1");
            Assert.IsTrue(itemsFromEvent[0].Pinned);
        }

        [TestMethod]
        public void ShouldAddNewMRUItem()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            manager.AddFile("path3");
            Assert.IsTrue(manager.MRUItems.Count == 3);
            Assert.IsTrue(itemsFromEvent.Count == 3);
            Assert.IsTrue(itemsFromEvent[2].FilePath == "path3");
            Assert.IsFalse(itemsFromEvent[2].Pinned);
            Assert.IsTrue(itemsFromEvent[2].SelectedCount == 1);
        }

        [TestMethod]
        public void ShouldAddExistedMRUItem()
        {
            // in this case, existed item should be updated
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            // TODO: can fail in certain situatioin :-)
            DateTime targetDt = new DateTime();
            manager.AddFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(itemsFromEvent.Count == 2);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path1");
            Assert.IsTrue(itemsFromEvent[0].Pinned);
            Assert.IsTrue(itemsFromEvent[0].SelectedCount == 2);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Year == targetDt.Year);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Month == targetDt.Month);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Day == targetDt.Day);
        }

        [TestMethod]
        public void ShouldRemoveMRUItem()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            manager.RemoveFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 1);
            Assert.IsTrue(itemsFromEvent.Count == 1);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path2");
            Assert.IsFalse(itemsFromEvent[0].Pinned);
        }

        [TestMethod]
        public void ShouldClearMRUItems()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            manager.ClearMRUItems();
            Assert.IsTrue(manager.MRUItems.Count == 0);
            Assert.IsTrue(itemsFromEvent.Count == 0);
        }

        [TestMethod]
        public void ShouldChangePinnedStateForMRUItem()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            manager.ChangePinStateForFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(itemsFromEvent.Count == 2);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path1");
            Assert.IsFalse(itemsFromEvent[0].Pinned);
        }

        [TestMethod]
        public void ShouldHandleSelectionOfMRUItem()
        {
            itemsFromEvent = new List<MRUItem>();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(CreateItems());
            MRUManager manager = new MRUManager();
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            manager.Initialize(storage);
            // TODO: can fail in certain situatioin :-)
            DateTime targetDt = new DateTime();
            manager.SelectFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(itemsFromEvent.Count == 2);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path1");
            Assert.IsTrue(itemsFromEvent[0].Pinned);
            Assert.IsTrue(itemsFromEvent[0].SelectedCount == 2);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Year == targetDt.Year);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Month == targetDt.Month);
            Assert.IsTrue(itemsFromEvent[0].LastAccessedDate.Day == targetDt.Day);
        }


        private void Manager_MRUItemsListChanged(List<MRUItem> items)
        {
            itemsFromEvent = items;
        }

        private List<MRUItem> itemsFromEvent;

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
