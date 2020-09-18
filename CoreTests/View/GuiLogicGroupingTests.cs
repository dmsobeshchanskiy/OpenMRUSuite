using CoreTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMRU.Core.Common.Implementations;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreTests.View
{
    [TestClass]
    public class GuiLogicGroupingTests
    {
        // for monday
        [TestMethod]
        public void ShouldDisplayContainersFor_AllRanges_Monday()
        {
            DateTime today = new DateTime(2020, 9, 16, 10, 8, 17);
            InitializeWithItems(CreateAllRangeItems(today), today, DayOfWeek.Monday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 5, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisWeekItemsLabel, "Wrong container 3 caption");
            Assert.IsTrue(viewMock.ShowedContainers[4].ContainerCaption == localization.ThisMonthItemsLabel, "Wrong container 4 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }

        [TestMethod]
        public void ShouldDisplayContainersFor_YesterdayThisWeekOverlapping_Monday()
        {
            DateTime today = new DateTime(2020, 9, 15, 10, 8, 17);
            InitializeWithItems(CreateAllRangeItems(today), today, DayOfWeek.Monday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 4, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisMonthItemsLabel, "Wrong container 3 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }

        [TestMethod]
        public void ShouldDisplayContainersFor_OtherContainerForItemsOlderThanThisMonth_Monday()
        {
            DateTime today = new DateTime(2020, 9, 16, 10, 8, 17);
            var items = CreateAllRangeItems(today);
            var lastItem = items.Last();
            lastItem.LastAccessedDate = today.AddDays(-45);
            InitializeWithItems(items, today, DayOfWeek.Monday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 5, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisWeekItemsLabel, "Wrong container 3 caption");
            Assert.IsTrue(viewMock.ShowedContainers[4].ContainerCaption == localization.OtherItemsLabel, "Wrong container 4 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }

        // for sunday
         
        [TestMethod]
        public void ShouldDisplayContainersFor_AllRanges_Sunday()
        {
            DateTime today = new DateTime(2020, 9, 15, 10, 8, 17);
            InitializeWithItems(CreateAllRangeItems(today), today, DayOfWeek.Sunday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 5, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisWeekItemsLabel, "Wrong container 3 caption");
            Assert.IsTrue(viewMock.ShowedContainers[4].ContainerCaption == localization.ThisMonthItemsLabel, "Wrong container 4 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }

        [TestMethod]
        public void ShouldDisplayContainersFor_YesterdayThisWeekOverlapping_Sunday()
        {
            DateTime today = new DateTime(2020, 9, 14, 10, 8, 17);
            InitializeWithItems(CreateAllRangeItems(today), today, DayOfWeek.Sunday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 4, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisMonthItemsLabel, "Wrong container 3 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }

        [TestMethod]
        public void ShouldDisplayContainersFor_OtherContainerForItemsOlderThanThisMonth_Sunday()
        {
            DateTime today = new DateTime(2020, 9, 15, 10, 8, 17);
            var items = CreateAllRangeItems(today);
            var lastItem = items.Last();
            lastItem.LastAccessedDate = today.AddDays(-45);
            InitializeWithItems(items, today, DayOfWeek.Sunday);
            var localization = new MRUGuiLocalization();
            Assert.IsTrue(viewMock.ShowedContainers.Count == 5, "Wrong containers count");

            Assert.IsTrue(viewMock.ShowedContainers[0].ContainerCaption == localization.PinnedItemsLabel, "Wrong container 0 caption");
            Assert.IsTrue(viewMock.ShowedContainers[1].ContainerCaption == localization.TodayItemsLabel, "Wrong container 1 caption");
            Assert.IsTrue(viewMock.ShowedContainers[2].ContainerCaption == localization.YesterdayItemsLabel, "Wrong container 2 caption");
            Assert.IsTrue(viewMock.ShowedContainers[3].ContainerCaption == localization.ThisWeekItemsLabel, "Wrong container 3 caption");
            Assert.IsTrue(viewMock.ShowedContainers[4].ContainerCaption == localization.OtherItemsLabel, "Wrong container 4 caption");

            Assert.IsTrue(viewMock.ItemViews.Count == 5, "Wrong items count");
        }



        private InMemoryMRUStorage storage;
        private MRUManager manager;
        private MRUItemsViewMock viewMock;

        private void InitializeWithItems(List<MRUItem> items, DateTime today, DayOfWeek firstDay)
        {
            storage = new InMemoryMRUStorage(items);
            manager = new MRUManager();
            manager.Initialize(storage);
            viewMock = new MRUItemsViewMock();
            viewMock.Initialize(manager, new MRUGuiLocalization());
            viewMock.SetDateProvider(new MockDateProvider(today, firstDay));
        }

        private List<MRUItem> CreateAllRangeItems(DateTime today)
        {
            List<MRUItem> items = new List<MRUItem>();
            
            // pinned item
            MRUItem item1 = new MRUItem
            {
                FilePath = "path1",
                Pinned = true,
                SelectedCount = 1,
                LastAccessedDate = today
            };

            // today's not pinned item
            MRUItem item2 = new MRUItem
            {
                FilePath = "path2",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = today
            };

            // yesterday's not pinned item
            MRUItem item3 = new MRUItem
            {
                FilePath = "path3",
                Pinned = false,
                SelectedCount = 3,
                LastAccessedDate = today.AddDays(-1)
            };

            // this week not pinned item
            MRUItem item4 = new MRUItem
            {
                FilePath = "path4",
                Pinned = false,
                SelectedCount = 4,
                LastAccessedDate = today.AddDays(-2)
            };

            // this month not pinned item
            MRUItem item5 = new MRUItem
            {
                FilePath = "path5",
                Pinned = false,
                SelectedCount = 5,
                LastAccessedDate = today.AddDays(-8)
            };

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            items.Add(item4);
            items.Add(item5);

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
