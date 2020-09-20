using CoreTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMRU.Core.Common.Implementations;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreTests.View
{
    [TestClass]
    public class GuiLogicTests
    {
        [TestMethod]
        public void ShouldDisplayMRUContainersOnControlInitialization()
        {
            Initialize();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2, "Wrong containers count");
            Assert.IsTrue(viewMock.ItemViews.Count == 2, "Wrong items count");
        }

        [TestMethod]
        public void ShouldUpdateMRUContainersOnItemPinChanged()
        {
            Initialize();

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokePinItemRequested();
            MRUGuiLocalization localization = new MRUGuiLocalization();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 1, "Wrong containers count");
            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.TodayItemsLabel, "Wrong container caption");
            Assert.IsTrue(viewMock.ItemViews.Count == 2, "Wrong items count");
        }

        [TestMethod]
        public void ShouldUpdateMRUItemSelectedCountOnItemSelected()
        {
            Initialize();

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeItemSelected();

            MRUItem item = manager.MRUItems.FirstOrDefault(m => m.FilePath == "path1");
            Assert.IsTrue(item.SelectedCount == 2, "Wrong 'selected count' attribute");
        }

        [TestMethod]
        public void ShouldPreventMRUItemFromDeletionIfNotConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = false;

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeDeleteItemRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 2, "Wrong containers count");
            Assert.IsTrue(viewMock.ItemViews.Count == 2, "Wrong items count");
        }

        [TestMethod]
        public void ShouldDeleteMRUItemIfConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;

            MRUItemViewMock itemView = GetMockItemViewForPath("path1");
            itemView.InvokeDeleteItemRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 1, "Wrong containers count");
            Assert.IsTrue(viewMock.ItemViews.Count == 1, "Wrong items count");
        }

        [TestMethod]
        public void ShouldPreventMRUItemsFromClearingIfNotConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = false;
            viewMock.InvokeClearMRUItemsRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 2, "Wrong containers count");
            Assert.IsTrue(viewMock.ItemViews.Count == 2, "Wrong items count");
        }

        [TestMethod]
        public void ShouldClearMRUItemsIfConfirmed()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;
            viewMock.InvokeClearMRUItemsRequested();

            Assert.IsTrue(viewMock.ShowedContainers.Count == 0, "Wrong containers count");
            Assert.IsTrue(viewMock.ItemViews.Count == 0, "Wrong items count");
        }

        [TestMethod]
        public void ShouldWorkWithNewMRUItemThatAddedWithManager()
        {
            Initialize();
            viewMock.IsActionAllowedResponse = true;

            // add new item
            manager.AddFile("path3");
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2, "Wrong containers count on adding");
            Assert.IsTrue(viewMock.ItemViews.Count == 3, "Wrong items count on adding");

            // pin it
            MRUItemViewMock itemView = GetMockItemViewForPath("path3");
            itemView.InvokePinItemRequested();
            // container with pinned items always goes first
            Assert.IsTrue(viewMock.ShowedContainers[0].Items.Count() == 2, "Wrong items count in pinned group");
            Assert.IsTrue(viewMock.ItemViews.Count == 3, "Wrong items count on pin");

            // select it
            itemView.InvokeItemSelected();
            MRUItem mruItem = manager.MRUItems.FirstOrDefault(m => m.FilePath == "path3");
            Assert.IsTrue(mruItem.SelectedCount == 2, "Wrong 'selected count' attribute");

            // delete it
            itemView.InvokeDeleteItemRequested();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 2, "Wrong containers count on deletion");
            Assert.IsTrue(viewMock.ItemViews.Count == 2, "Wrong items count on deletion");
        }



        private InMemoryMRUStorage storage;
        private MRUManager manager;
        private MRUItemsViewMock viewMock;

        private void Initialize()
        {
            var today = new DateTime(2020, 9, 20, 10, 15, 8);
            storage = new InMemoryMRUStorage(CreateItems(today));
            manager = new MRUManager();
            manager.Initialize(storage);
            viewMock = new MRUItemsViewMock();
            viewMock.Initialize(manager, new MRUGuiLocalization());
            viewMock.SetDateProvider(new MockDateProvider(today, DayOfWeek.Monday));
        }

        private List<MRUItem> CreateItems(DateTime today)
        {
            List<MRUItem> items = new List<MRUItem>();

            MRUItem item1 = new MRUItem
            {
                FilePath = "path1",
                Pinned = true,
                SelectedCount = 1,
                LastAccessedDate = today
            };
            MRUItem item2 = new MRUItem
            {
                FilePath = "path2",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = today
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
