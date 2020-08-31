using OpenMRUSuiteCore.Common.Interfaces;
using OpenMRUSuiteCore.Common.Models;
using OpenMRUSuiteCore.View.Localization;
using System;
using System.Collections.Generic;

namespace OpenMRUSuiteCore.View.Interfaces
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
