using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenMRU.Core.View.Logic
{
    public class MRUGuiLogic
    {
        internal void SetDateProvider (IDateProvider provider)
        {
            dateProvider = provider;
            ShowItemsOnView();
        }

        public MRUGuiLogic(IMRUItemsView view, IMRUManager manager, MRUGuiLocalization localization)
        {
            this.view = view;
            this.manager = manager;
            this.localization = localization;
            PerformInitialize();
        }


        private readonly IMRUManager manager;
        private readonly MRUGuiLocalization localization;
        private readonly IMRUItemsView view;
        private IDateProvider dateProvider = new DateProvider();

        private void PerformInitialize()
        {
            manager.MRUItemsListChanged += Manager_MRUItemsListChanged;
            view.ClearMRUItemsRequested += View_ClearMRUItemsRequested;
            ShowItemsOnView();
        }

        private void ItemView_PinItemRequested(string path)
        {
            manager.ChangePinStateForFile(path);
        }

        private void ItemView_ItemSelected(string path)
        {
            manager.SelectFile(path);
        }

        private void ItemView_DeleteItemRequested(string path)
        {
            if (view.IsActionAllowed(localization.Messages.AllowDeleteItem))
            {
                manager.RemoveFile(path);
            }
        }

        private void View_ClearMRUItemsRequested()
        {
            if (view.IsActionAllowed(localization.Messages.AllowClearList))
            {
                manager.ClearMRUItems();
            }
        }

        private void Manager_MRUItemsListChanged()
        {
            ShowItemsOnView();
        }


        private void ShowItemsOnView()
        {
            var containers = GroupByContainer(manager.MRUItems);

            view.ShowMRUItems(containers);

            foreach (IMRUItemView itemView in view.ItemViews)
            {
                itemView.DeleteItemRequested += ItemView_DeleteItemRequested;
                itemView.ItemSelected += ItemView_ItemSelected;
                itemView.PinItemRequested += ItemView_PinItemRequested;
            }
        }

        private List<MRUItemsContainer> GroupByContainer(IEnumerable<MRUItem> items)
        {
            List<MRUItemsContainer> containers = new List<MRUItemsContainer>();
            DateTime today = dateProvider.Now;
            DateTime yesterday = today.AddDays(-1);
            DateTime weekBeginDate = today.AddDays((int)dateProvider.FirstDayOfWeek - (int)today.DayOfWeek);
            DateTime monthBeginDate = new DateTime(today.Year, today.Month, 1);

            // get pinned items
            IEnumerable<MRUItem> pinnedItems = items.Where(item => item.Pinned)
                                                               .OrderByDescending(item => item.LastAccessedDate);
            MRUItemsContainer pinnedContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.PinnedItemsLabel,
                Items = pinnedItems
            };

            // get today's not pinned items
            IEnumerable<MRUItem> todayItems = items.Where(item => !item.Pinned && IsTheSameDay(item.LastAccessedDate, today));
            MRUItemsContainer todayContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.TodayItemsLabel,
                Items = todayItems
            };

            // get yesterday's not pinned items
            IEnumerable<MRUItem> yesterdayItems = items.Where(item => !item.Pinned && IsTheSameDay(item.LastAccessedDate, yesterday));
            MRUItemsContainer yesterdayContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.YesterdayItemsLabel,
                Items = yesterdayItems
            };

            // get this week not pinned items
            IEnumerable<MRUItem> weekItems = items.Where(item => !item.Pinned && item.LastAccessedDate < yesterday && item.LastAccessedDate >= weekBeginDate);
            MRUItemsContainer weekContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.ThisWeekItemsLabel,
                Items = weekItems
            };

            // get this month not pinned items
            IEnumerable<MRUItem> monthItems = items.Where(item => !item.Pinned && item.LastAccessedDate < weekBeginDate && item.LastAccessedDate >= monthBeginDate);
            MRUItemsContainer monthContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.ThisMonthItemsLabel,
                Items = monthItems
            };

            // get other items
            IEnumerable<MRUItem> otherItems = items.Where(item => !item.Pinned && item.LastAccessedDate < monthBeginDate);
            MRUItemsContainer otherContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.OtherItemsLabel,
                Items = otherItems
            };

            containers.Add(pinnedContainer);
            containers.Add(todayContainer);
            containers.Add(yesterdayContainer);
            containers.Add(weekContainer);
            containers.Add(monthContainer);
            containers.Add(otherContainer);
            containers = containers.Where(c => c.Items.Count() > 0).ToList();

            return containers;
        }
    
        private bool IsTheSameDay (DateTime date1, DateTime date2)
        {
            return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
        }
    }
}
