using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRUCommonInterfaces.Manager;
using MRUCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ShouldAddMRUItem()
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
            manager.SelectFile("path1");
            Assert.IsTrue(manager.MRUItems.Count == 2);
            Assert.IsTrue(itemsFromEvent.Count == 2);
            Assert.IsTrue(itemsFromEvent[0].FilePath == "path1");
            Assert.IsTrue(itemsFromEvent[0].Pinned);
            Assert.IsTrue(itemsFromEvent[0].SelectedCount == 2);
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
