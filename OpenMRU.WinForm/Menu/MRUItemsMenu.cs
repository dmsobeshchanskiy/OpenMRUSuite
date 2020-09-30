using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    public class MRUItemsMenu : MRUItemsBase
    {
        private ToolStripMenuItem menuItem;
        private string menuItemAppearance = "";

        public void AttachToMenu(ToolStripMenuItem menuItem)
        {
            AttachToMenu(menuItem, string.Empty);
        }

        public void AttachToMenu(ToolStripMenuItem menuItem, string menuItemAppearance)
        {
            this.menuItem = menuItem;
            this.menuItemAppearance = menuItemAppearance;
            AttachMenuItems();
        }

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
            ItemViews.ForEach(itemView =>
            {
                (itemView as MRUItemMenu).Appearance = menuItemAppearance;
                menuItem.DropDownItems.Add(itemView as ToolStripMenuItem);
            });
            
        }
        
    }
}
