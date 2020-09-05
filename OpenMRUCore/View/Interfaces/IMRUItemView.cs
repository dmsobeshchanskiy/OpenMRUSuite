using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;
using System;

namespace OpenMRU.Core.View.Interfaces
{
    public interface IMRUItemView
    {
        event Action<string> PinItemRequested;
        event Action<string> DeleteItemRequested;
        event Action<string> ItemSelected;
        void Initialize(MRUItem item, MRUGuiItemLocalization localization);
        void Initialize(MRUItem item, MRUGuiItemLocalization localization, string imagePathForItem);
    }
}
