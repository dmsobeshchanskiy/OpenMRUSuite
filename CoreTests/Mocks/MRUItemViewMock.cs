using OpenMRUSuiteCore.Common.Interfaces;
using OpenMRUSuiteCore.View.Interfaces;
using OpenMRUSuiteCore.View.Localization;
using System;

namespace CoreTests.Mocks
{
    public class MRUItemViewMock : IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        public void Initialize(IMRUItem item, MRUGuiItemLocalization localization)
        {
            Initialize(item, localization, null);
        }

        public void Initialize(IMRUItem item, MRUGuiItemLocalization localization, string itemImagePath)
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

        private IMRUItem item;
    }
}
