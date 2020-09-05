using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.View.Localization;
using System;

namespace OpenMRU.Core.View.Interfaces
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
