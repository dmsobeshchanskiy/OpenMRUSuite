using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using System;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    public class MRUItemMenu : ToolStripMenuItem, IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        private MRUItem item;

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            Initialize(item, localization, null);
        }

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization, string imagePathForItem)
        {
            this.Text = item.FilePath;
            this.item = item;

            // subscribe to events
            this.Click += MRUItemMenu_Click;
        }

        private void MRUItemMenu_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(item.FilePath);
        }
    }
}
