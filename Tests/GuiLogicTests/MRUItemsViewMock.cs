﻿using MRUCore.Interfaces;
using MRUGuiCore;
using MRUGuiCore.ViewInterfaces;
using System;
using System.Collections.Generic;

namespace Tests.GuiLogicTests
{
    public class MRUItemsViewMock : IMRUItemsView
    {
        public List<IMRUItemView> ItemViews { get; private set; }

        public event Action ClearMRUItemsRequested;

        public void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            MRUGuiLogic logic = new MRUGuiLogic(this, manager, localization);
        }

        public bool IsActionAllowed(string actionDescription)
        {
            return IsActionAllowedResponse;
        }

        public void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            ShowedContainersCount = containers.Count;
            foreach (MRUItemsContainer container in containers)
            {
                foreach(IMRUItem item in container.Items)
                {
                    MRUItemViewMock view = new MRUItemViewMock();
                    view.Initialize(item);
                    ItemViews.Add(view);
                }
            }
        }

        // mock specific properties / methods

        public int ShowedContainersCount { get; private set; }
        public bool IsActionAllowedResponse { get; set; }

        public void InvokeClearMRUItemsRequested ()
        {
            ClearMRUItemsRequested.Invoke();
        }

    }
}