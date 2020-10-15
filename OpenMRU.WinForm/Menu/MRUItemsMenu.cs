using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.WinForm.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    /// <summary>
    /// WinForm UI control to display MRU items as ToolStripMenu items
    /// </summary>
    public class MRUItemsMenu : MRUItemsBase
    {
        private ToolStripMenuItem menuItem;
        private string menuItemAppearance = "";

        /// <summary>
        /// Set parent menu item. MRU menu items will be attached to it as children (dropdown)
        /// </summary>
        /// <param name="menuItem">ToolStripMenuItem instance</param>
        public void AttachToMenu(ToolStripMenuItem menuItem)
        {
            AttachToMenu(menuItem, string.Empty);
        }

        /// <summary>
        /// Set parent menu item. MRU menu items will be attached to it as children (dropdown)
        /// </summary>
        /// <param name="menuItem">ToolStripMenuItem instance</param>
        /// <param name="menuItemAppearance">Menu item appearance. Recognized patterns are:
        /// <list type="bullet">
        /// <item>%FileName% - just file name (w/o path)</item>
        /// <item>%Path% - path to file (excluding file name)</item>
        /// <item>%FullFileName% - path to file + file name</item>
        /// <item>%AccessDate% - last access date of MRU item</item>
        /// </list>
        /// default is: %FullFileName% (if empty or null)
        /// </param>
        public void AttachToMenu(ToolStripMenuItem menuItem, string menuItemAppearance)
        {
            this.menuItem = menuItem;
            this.menuItemAppearance = menuItemAppearance;
            AttachMenuItems();
        }

        /// <summary>
        /// Display MRU item containers
        /// </summary>
        /// <param name="containers">MRU containers to display</param>
        public override void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            if (ItemViews != null)
            {
                ItemViews.Clear();
            }
            ItemViews = new List<IMRUItemView>();
            containers.ForEach(container =>
            {
                container.Items.ToList().ForEach(item =>
                {
                    var mruItemMenu = new MRUItemMenu();
                    mruItemMenu.Initialize(item, localization.ItemLocalization);
                    ItemViews.Add(mruItemMenu);
                });
            });
            AttachMenuItems();
        }

        private void AttachMenuItems()
        {
            if (menuItem == null)
            {
                return;
            }
            menuItem.DropDownItems.Clear();
            
            if (ItemViews != null && ItemViews.Count() > 0)
            {
                menuItem.Enabled = true;
                ItemViews.ForEach(itemView =>
                {
                    (itemView as MRUItemMenu).Appearance = menuItemAppearance;
                    menuItem.DropDownItems.Add(itemView as ToolStripMenuItem);
                });
                menuItem.DropDownItems.Add(new ToolStripSeparator());
                menuItem.DropDownItems.Add(CreateClearAllMenu());
            } else
            {
                menuItem.Enabled = false;
            }
        }

        private ToolStripMenuItem CreateClearAllMenu()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = localization.ClearAllLabel;
            item.Click += Item_ClearAll_Click;

            return item;
        }

        private void Item_ClearAll_Click(object sender, EventArgs e)
        {
            InvokeMRUItemsClearing();
        }
    }
}
