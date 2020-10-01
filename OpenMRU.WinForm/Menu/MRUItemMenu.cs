using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.View.Localization;
using System;
using System.IO;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    /// <summary>
    /// WinFrom control for to display MRU item as ToolStripMenuItem
    /// </summary>
    public class MRUItemMenu : ToolStripMenuItem, IMRUItemView
    {
        /// <summary>
        /// Fires when pin item requested
        /// </summary>
        public event Action<string> PinItemRequested;
        /// <summary>
        /// Fires when delete item requested
        /// </summary>
        public event Action<string> DeleteItemRequested;
        /// <summary>
        /// Fires when item selected
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="localization"></param>
        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            Initialize(item, localization, null);
        }

        /// <summary>
        /// Init control with given MRU item
        /// </summary>
        /// <param name="item">MRU item to show on control</param>
        /// <param name="localization">localization instance</param>
        /// <param name="imagePathForItem">image for menu item (currently not supported)</param>
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
