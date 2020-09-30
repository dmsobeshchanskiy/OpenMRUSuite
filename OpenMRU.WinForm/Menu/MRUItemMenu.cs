using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using System;
using System.IO;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    public class MRUItemMenu : ToolStripMenuItem, IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        /// <summary>
        /// string that represent appearance
        /// available placeholders:
        /// %FileName% - just file name (w/o path)
        /// %Path% - path to file (excluding file name)
        /// %FullFileName% - path to file + file name
        /// %AccessDate% - last access date of MRU item
        /// default is: %FullFileName%
        /// </summary>
        public string Appearance
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    return;
                }
                appearance = value;
                UpdateAppearance();
            }
        }

        private MRUItem item;
        private string appearance = "%FullFileName%";

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            Initialize(item, localization, null);
        }

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization, string imagePathForItem)
        {
            this.item = item;
            UpdateAppearance();
            // subscribe to events
            this.Click += MRUItemMenu_Click;
        }

        private void UpdateAppearance()
        {
            FileInfo fi = new FileInfo(item.FilePath);
            string textAppearance = appearance.Replace("%FileName%", fi.Name)
                                        .Replace("%Path%", fi.DirectoryName)
                                        .Replace("%FullFileName%", fi.FullName)
                                        .Replace("%AccessDate%", item.LastAccessedDate.ToString("dd/MM/yyyy"));
            this.Text = textAppearance;
        }

        private void MRUItemMenu_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(item.FilePath);
        }
    }
}
