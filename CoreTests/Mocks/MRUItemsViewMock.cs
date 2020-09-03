using OpenMRUSuiteCore.Common.Interfaces;
using OpenMRUSuiteCore.Common.Models;
using OpenMRUSuiteCore.View.Interfaces;
using OpenMRUSuiteCore.View.Localization;
using OpenMRUSuiteCore.View.Logic;
using System;
using System.Collections.Generic;

namespace CoreTests.Mocks
{
    public class MRUItemsViewMock : IMRUItemsView
    {
        public List<IMRUItemView> ItemViews { get; private set; }

        public event Action ClearMRUItemsRequested;

        public void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            _ = new MRUGuiLogic(this, manager, localization);
        }

        public bool IsActionAllowed(string actionDescription)
        {
            return IsActionAllowedResponse;
        }

        public void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            ShowedContainers = containers;
            ItemViews = new List<IMRUItemView>();
            foreach (MRUItemsContainer container in containers)
            {
                foreach (IMRUItem item in container.Items)
                {
                    MRUItemViewMock view = new MRUItemViewMock();
                    view.Initialize(item, new MRUGuiItemLocalization());
                    ItemViews.Add(view);
                }
            }
        }

        // mock specific properties / methods

        public List<MRUItemsContainer> ShowedContainers { get; private set; }
        public bool IsActionAllowedResponse { get; set; }

        public void InvokeClearMRUItemsRequested()
        {
            ClearMRUItemsRequested.Invoke();
        }

    }
}
