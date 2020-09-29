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

        public void AttachToMenu(ToolStripMenuItem menuItem)
        {
            this.menuItem = menuItem;
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
                menuItem.DropDownItems.Add(itemView as ToolStripMenuItem);
            });
            
        }
        
    }
}
