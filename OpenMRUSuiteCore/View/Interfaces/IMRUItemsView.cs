using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;
using System;
using System.Collections.Generic;

namespace OpenMRU.Core.View.Interfaces
{
    public interface IMRUItemsView
    {
        event Action ClearMRUItemsRequested;
        bool IsActionAllowed(string actionDescription);
        void Initialize(IMRUManager manager, MRUGuiLocalization localization);
        void ShowMRUItems(List<MRUItemsContainer> containers);
        List<IMRUItemView> ItemViews { get; }
    }
}
