using Microsoft.VisualStudio.TestTools.UnitTesting;
using MRUCore;
using MRUCore.Manager;
using MRUGuiCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.GuiLogicTests
{
    [TestClass]
    public class GuiLogicTests
    {
        [TestMethod]
        public void ShouldDisplayMRUContainersOnControlInitialization ()
        {
            Initialize();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 2);
        }

        [TestMethod]
        public void ShouldUpdateMRUContainersOnItemPinChanged()
        {
            Initialize();

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokePinItemRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 1);
            Assert.IsTrue(viewMock.ItemViews.Count == 2);
        }

        [TestMethod]
        public void ShouldUpdateMRUItemSelectedCountOnItemSelected()
        {
            Initialize();

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeItemSelected();

            MRUItem item = manager.MRUItems.FirstOrDefault(m => m.FilePath == "path1");
            Assert.IsTrue(item.SelectedCount == 2);
        }

        [TestMethod]
        public void ShouldPreventMRUItemFromDeletionIfNotConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = false;

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeDeleteItemRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 2);
        }

        [TestMethod]
        public void ShouldDeleteMRUItemIfConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeDeleteItemRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 1);
            Assert.IsTrue(viewMock.ItemViews.Count == 1);
        }

        [TestMethod]
        public void ShouldPreventMRUItemsFromClearingIfNotConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = false;
            viewMock.InvokeClearMRUItemsRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 2);
        }

        [TestMethod]
        public void ShouldClearMRUItemsIfConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;
            viewMock.InvokeClearMRUItemsRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 0);
            Assert.IsTrue(viewMock.ItemViews.Count == 0);
        }

        [TestMethod]
        public void ShouldWorkWithNewMRUItemThatAddedWithManager()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;

            // add new item
            manager.AddFile("path3");
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 3);

            // pin it
            MRUItemViewMock itemView = GetMockItemViewForPath("path3");
            itemView.InvokePinItemRequested();
            // container with pinned items always goes first
            Assert.IsTrue(viewMock.ShowedContainers[0].Items.Count() == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 3);

            // select it
            itemView.InvokeItemSelected();
            MRUItem mruItem = manager.MRUItems.FirstOrDefault(m => m.FilePath == "path3");
            Assert.IsTrue(mruItem.SelectedCount == 2);

            // delete it
            itemView.InvokeDeleteItemRequested();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2);
            Assert.IsTrue(viewMock.ItemViews.Count == 2);
        }



        private InMemoryMRUStorage storage;
        private MRUManager manager;
        private MRUItemsViewMock viewMock;

        private void Initialize ()
        {
            storage = new InMemoryMRUStorage(CreateItems());
            manager = new MRUManager();
            manager.Initialize(storage);
            viewMock = new MRUItemsViewMock();
            viewMock.Initialize(manager, new MRUGuiLocalization());
        }

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

        private MRUItemViewMock GetMockItemViewForPath(string path)
        {
            IEnumerable<MRUItemViewMock> childMocks = viewMock.ItemViews.Cast<MRUItemViewMock>();
            MRUItemViewMock mockItem = childMocks.FirstOrDefault(m => m.BindedFilePath == path);
            return mockItem;
        }
    }

}
