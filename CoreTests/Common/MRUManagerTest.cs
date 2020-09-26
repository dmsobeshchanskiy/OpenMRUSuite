using CoreTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMRU.Core.Common.Implementations;
using OpenMRU.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreTests.Common
{
    [TestClass]
    public class MRUManagerTest
    {
        [TestMethod]
        public void ShouldReadMRUItemsOnInitialization()
        {
            Initialize();
            Assert.IsTrue(manager.MRUItems.Count == 4);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1", "wrong item 0");
            Assert.IsTrue(manager.MRUItems[0].Pinned, "item 0 not pinned");
            Assert.IsTrue(manager.MRUItems[1].FilePath == "path2", "wrong item 1");
            Assert.IsTrue(manager.MRUItems[2].FilePath == "path3", "wrong item 2");
            Assert.IsTrue(manager.MRUItems[3].FilePath == "path4", "wrong item 3");
        }

        [TestMethod]
        public void ShouldAddNewMRUItem()
        {
            Initialize();
            manager.AddFile("path6"); // added item should be on top, but under pinned item4
            Assert.IsTrue(manager.MRUItems.Count == 5, "wrong items count");
            Assert.IsTrue(listChangedWasInvoked, "event was not invoked");
            Assert.IsTrue(manager.MRUItems[1].FilePath == "path6");
            Assert.IsFalse(manager.MRUItems[1].Pinned);
            Assert.IsTrue(manager.MRUItems[1].SelectedCount == 1);
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
            Assert.IsTrue(manager.MRUItems.Count == 4);
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
            Assert.IsTrue(manager.MRUItems.Count == 3, "wrong items count");
            Assert.IsTrue(listChangedWasInvoked, "event was not invoked");
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path2", "wrong item 0");
            Assert.IsFalse(manager.MRUItems[0].Pinned, "item 0 not pinned");
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
            Assert.IsTrue(manager.MRUItems.Count == 4);
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
            Assert.IsTrue(manager.MRUItems.Count == 4);
            Assert.IsTrue(listChangedWasInvoked);
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1");
            Assert.IsTrue(manager.MRUItems[0].Pinned);
            Assert.IsTrue(manager.MRUItems[0].SelectedCount == 2);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Year == targetDt.Year);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Month == targetDt.Month);
            Assert.IsTrue(manager.MRUItems[0].LastAccessedDate.Day == targetDt.Day);
            Assert.IsTrue(itemSelectedWasInvoked, "Item selected was not invoked on selection");
        }

        [TestMethod]
        public void ShouldUpdateItemsOnMaxAmountChanged()
        {
            Initialize();
            manager.SetItemsCountToTrack(3);
            Assert.IsTrue(manager.MRUItems.Count == 3, "wrong mru items count");
            Assert.IsTrue(listChangedWasInvoked, "change event was not called");
            Assert.IsTrue(manager.MRUItems[0].FilePath == "path1", "wrong mru items at 0");
            Assert.IsTrue(manager.MRUItems[0].Pinned, "first item not pinned");
            Assert.IsTrue(manager.MRUItems[1].FilePath == "path2", "wrong mru items at 1");
            Assert.IsTrue(manager.MRUItems[2].FilePath == "path3", "wrong mru items at 2");
        }

        [TestMethod]
        public void ShouldUpdateItemsOnMaxAmountExceeded()
        {
            Initialize();
            manager.SetItemsCountToTrack(4);

            manager.AddFile("path6");

            Assert.IsTrue(manager.MRUItems.Count == 4, "wrong items count");
            Assert.IsTrue(listChangedWasInvoked, "change event was not called");

            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path1") != null, "no path1");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path2") != null, "no path2");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path3") != null, "no path3");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path6") != null, "no path6");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path4") == null, "with path4");
        }

        [TestMethod]
        public void ShouldUpdateItemsOnMaxAmountExceeded_PinnedShouldRemain()
        {
            Initialize();
            manager.ChangePinStateForFile("path1");
            manager.ChangePinStateForFile("path4");
            manager.SetItemsCountToTrack(4);

            manager.AddFile("path6");

            Assert.IsTrue(manager.MRUItems.Count == 4, "wrong items count");
            Assert.IsTrue(listChangedWasInvoked, "change event was not called");

            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path1") != null, "no path1");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path2") != null, "no path2");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path4") != null, "no path4");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path6") != null, "no path6");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path3") == null, "with path3");
        }

        [TestMethod]
        public void ShouldNotUpdateItemsOnMaxAmountExceeded_AllExisteArePinned()
        {
            Initialize();
            manager.ChangePinStateForFile("path2");
            manager.ChangePinStateForFile("path3");
            manager.ChangePinStateForFile("path4");
            manager.SetItemsCountToTrack(4);

            manager.AddFile("path6");

            Assert.IsTrue(manager.MRUItems.Count == 4, "wrong items count");
            Assert.IsTrue(listChangedWasInvoked, "change event was not called");

            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path1") != null, "no path1");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path2") != null, "no path2");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path3") != null, "no path3");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path4") != null, "no path4");
            Assert.IsTrue(manager.MRUItems.FirstOrDefault(i => i.FilePath == "path6") == null, "with path6");
        }


        private MRUManager manager;
        private List<MRUItem> mruItems;

        private void Initialize()
        {
            listChangedWasInvoked = false;
            itemSelectedWasInvoked = false;
            mruItems = CreateItems();
            InMemoryMRUStorage storage = new InMemoryMRUStorage(mruItems);
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
            MRUItem item3 = new MRUItem
            {
                FilePath = "path3",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = new System.DateTime(2019, 4, 25)
            };
            MRUItem item4 = new MRUItem
            {
                FilePath = "path4",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = new System.DateTime(2019, 4, 24)
            };
            items.Add(item1);
            items.Add(item4);
            items.Add(item3);
            items.Add(item2);
           
            return items;
        }
    }
}
