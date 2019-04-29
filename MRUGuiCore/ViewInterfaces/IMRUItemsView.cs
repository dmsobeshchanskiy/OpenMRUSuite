using MRUCore.Interfaces;
using System;
using System.Collections.Generic;

namespace MRUGuiCore.ViewInterfaces
{
    public interface IMRUItemsView
    {
        event Action ClearMRUItemsRequested;
        void Initialize(IMRUManager manager);
        void ShowMRUItems(List<IMRUItem> items);
        List<IMRUItemsView> ItemViews { get; }
    }
}
