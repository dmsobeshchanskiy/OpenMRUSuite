using MRUCore.Interfaces;
using System;
using System.Drawing;

namespace MRUGuiCore.ViewInterfaces
{
    public interface IMRUItemView
    {
        event Action<string> PinItemRequested;
        event Action<string> DeleteItemRequested;
        event Action<string> ItemSelected;
        void Initialize(IMRUItem item, MRUGuiItemLocalization localization);
        void Initialize(IMRUItem item, MRUGuiItemLocalization localization, Image imageForItem);
    }
}
