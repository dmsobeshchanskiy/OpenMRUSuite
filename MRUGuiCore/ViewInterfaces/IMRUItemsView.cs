﻿using MRUCore.Interfaces;
using System;
using System.Collections.Generic;

namespace MRUGuiCore.ViewInterfaces
{
    public interface IMRUItemsView
    {
        event Action ClearMRUItemsRequested;
        bool IsActionAllowed(string actionDescription);
        void Initialize(IMRUManager manager, MRUGuiLocalization localization);
        void ShowMRUItems(List<IMRUItem> items);
        List<IMRUItemView> ItemViews { get; }
    }
}
