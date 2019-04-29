using MRUCore.Interfaces;
using System;
using System.Collections.Generic;

namespace MRUGuiCore.ViewInterfaces
{
    public interface IMRUItemsView
    {
        event Action ClearMRUItemsRequested;
        void Initialize(IMRUManager manager, MRUGuiLocalization localization);
        void ShowMRUItems(List<IMRUItem> items);
        List<IMRUItemsView> ItemViews { get; }
    }
}
