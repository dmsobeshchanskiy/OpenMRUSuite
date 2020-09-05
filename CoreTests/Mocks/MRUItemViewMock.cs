using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using System;

namespace CoreTests.Mocks
{
    public class MRUItemViewMock : IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            Initialize(item, localization, null);
        }

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization, string itemImagePath)
        {
            this.item = item;
        }

        // mock specific properties / methods

        public string BindedFilePath => item.FilePath;

        public void InvokePinItemRequested()
        {
            PinItemRequested.Invoke(item.FilePath);
        }
        public void InvokeDeleteItemRequested()
        {
            DeleteItemRequested.Invoke(item.FilePath);
        }
        public void InvokeItemSelected()
        {
            ItemSelected.Invoke(item.FilePath);
        }

        private MRUItem item;
    }
}
