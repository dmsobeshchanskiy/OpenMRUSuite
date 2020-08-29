using MRUCore.Interfaces;
using MRUGuiCore.ViewInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace MRUGuiCore
{
    public class MRUGuiLogic
    {

        public MRUGuiLogic (IMRUItemsView view, IMRUManager manager, MRUGuiLocalization localization)
        {
            this.view = view;
            this.manager = manager;
            this.localization = localization;
            PerformInitialize();
        }


        private readonly IMRUManager manager;
        private readonly MRUGuiLocalization localization;
        private readonly IMRUItemsView view;

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
            if (view.IsActionAllowed(localization.Messages.AllowDeleteItem)) {
                manager.RemoveFile(path);
            }
        }

        private void View_ClearMRUItemsRequested()
        {
            if (view.IsActionAllowed(localization.Messages.AllowClearList)) {
                manager.ClearMRUItems();
            }
        }

        private void Manager_MRUItemsListChanged()
        {
            ShowItemsOnView();
        }


        private void ShowItemsOnView()
        {
            List<MRUItemsContainer> containers = new List<MRUItemsContainer>();

            IEnumerable<IMRUItem> pinnedItems = manager.MRUItems.Where(item => item.Pinned)
                                                                .OrderByDescending(item => item.LastAccessedDate);
            MRUItemsContainer pinnedContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.PinnedItemsLabel,
                Items = pinnedItems
            };
                
            IEnumerable<IMRUItem> otherItems = manager.MRUItems.Where(item => !item.Pinned)
                                                               .OrderByDescending(item => item.LastAccessedDate);
            MRUItemsContainer otherContainer = new MRUItemsContainer
            {
                ContainerCaption = localization.OtherItemsLabel,
                Items = otherItems
            };

            containers.Add(pinnedContainer);
            containers.Add(otherContainer);
            containers = containers.Where(c => c.Items.Count() > 0).ToList();
            if (containers.Count() == 1)
            {
                containers[0].ContainerCaption = string.Empty;
            }

            view.ShowMRUItems(containers);

            foreach (IMRUItemView itemView in view.ItemViews)
            {
                itemView.DeleteItemRequested += ItemView_DeleteItemRequested;
                itemView.ItemSelected += ItemView_ItemSelected;
                itemView.PinItemRequested += ItemView_PinItemRequested;
            }
        }
    }
}
