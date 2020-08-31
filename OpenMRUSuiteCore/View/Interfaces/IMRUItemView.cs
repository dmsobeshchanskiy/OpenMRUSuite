using OpenMRUSuiteCore.Common.Interfaces;
using OpenMRUSuiteCore.View.Localization;
using System;

namespace OpenMRUSuiteCore.View.Interfaces
{
    public interface IMRUItemView
    {
        event Action<string> PinItemRequested;
        event Action<string> DeleteItemRequested;
        event Action<string> ItemSelected;
        void Initialize(IMRUItem item, MRUGuiItemLocalization localization);
        void Initialize(IMRUItem item, MRUGuiItemLocalization localization, string imagePathForItem);
    }
}
