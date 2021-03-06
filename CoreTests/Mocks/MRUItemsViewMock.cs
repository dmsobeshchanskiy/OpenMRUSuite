﻿using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using OpenMRU.Core.View.Logic;
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
            logic = new MRUGuiLogic(this, manager, localization);
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
                foreach (MRUItem item in container.Items)
                {
                    MRUItemViewMock view = new MRUItemViewMock();
                    view.Initialize(item, new MRUGuiItemLocalization());
                    ItemViews.Add(view);
                }
            }
        }

        // mock specific properties / methods

        private MRUGuiLogic logic;

        public List<MRUItemsContainer> ShowedContainers { get; private set; }
        public bool IsActionAllowedResponse { get; set; }

        public void InvokeClearMRUItemsRequested()
        {
            ClearMRUItemsRequested.Invoke();
        }

        public void SetFilterValue(string filter)
        {
            logic.SetFileNameFilter(filter);
        }

        internal void SetDateProvider (IDateProvider provider)
        {
            logic.SetDateProvider(provider);
        }

    }
}
