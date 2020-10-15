using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;

namespace OpenMRU.WinForm
{
    /// <summary>
    /// WinForm control for to display MRU item
    /// </summary>
    public partial class MRUItemControl : UserControl, IMRUItemView
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
        /// Init control with given MRU item
        /// </summary>
        /// <param name="item">MRU item to show on control</param>
        /// <param name="localization">localization instance</param>
        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            this.Initialize(item, localization, "");
        }

        /// <summary>
        /// Init control with given MRU item
        /// </summary>
        /// <param name="item">MRU item to show on control</param>
        /// <param name="localization">localization instance</param>
        /// <param name="imagePath">image for menu item (currently not supported)</param>
        public void Initialize(MRUItem item, MRUGuiItemLocalization localization, string imagePath)
        {
            Image itemImage = ImageResolver.GetImageForItem(item, imagePath);
            this.Initialize(item, localization, itemImage);
        }

        private Color normalColor = SystemColors.Control;
        private readonly Color hoveredColor = SystemColors.ControlDark;

        /// <summary>
        /// Default ctor
        /// </summary>
        public MRUItemControl()
        {
            InitializeComponent();
        }

        private MRUItem item;

        private void Initialize(MRUItem item, MRUGuiItemLocalization localization, Image itemImage)
        {
            this.item = item;
            pictureBoxFileIco.Image = itemImage;
            FileInfo fileInfo = new FileInfo(item.FilePath);
            labelFileName.Text = fileInfo.Name;
            labelPath.Text = fileInfo.DirectoryName;
            labelDate.Text = item.LastAccessedDate.ToString("dd/MM/yyyy");
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pictureBoxRemove, localization.DeleteItemLabel);
            if (item.Pinned)
            {
                tt.SetToolTip(this.pictureBoxPin, localization.UnpinItemLabel);
            }
            else
            {
                tt.SetToolTip(this.pictureBoxPin, localization.PinItemLabel);
            }
            if (this.Parent != null)
            {
                normalColor = this.Parent.BackColor;
            }
            BackColor = normalColor;
        }

        private void MRUItemControl_Click(object sender, EventArgs e)
        {
            ItemSelected?.Invoke(item.FilePath);
        }

        private void PictureBoxRemove_Click(object sender, EventArgs e)
        {
            DeleteItemRequested?.Invoke(item.FilePath);
        }

        private void PictureBoxPin_Click(object sender, EventArgs e)
        {
            PinItemRequested?.Invoke(item.FilePath);
        }


        private void MRUItemControl_MouseEnter(object sender, EventArgs e)
        {
            ApplySelection();
        }

        private void MRUItemControl_MouseLeave(object sender, EventArgs e)
        {
            DiscardSelection();
        }

        private void ApplySelection()
        {
            if (!panelActions.Visible)
            {
                this.BackColor = hoveredColor;
                panelActions.Visible = true;
                timerCheckSelection.Enabled = true;
                timerCheckSelection.Start();
            }
        }

        private void DiscardSelection()
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                this.BackColor = normalColor;
                panelActions.Visible = false;
                timerCheckSelection.Stop();
                timerCheckSelection.Enabled = false;
            }
        }

        private void timerCheckSelection_Tick(object sender, EventArgs e)
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                DiscardSelection();
            }
        }
    }
}
