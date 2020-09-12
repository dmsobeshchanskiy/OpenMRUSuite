using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.Common.Models;
using OpenMRU.Core.View.Localization;

namespace OpenMRU.WinForm
{
    public partial class MRUItemControl : UserControl, IMRUItemView
    {
        public event Action<string> PinItemRequested;
        public event Action<string> DeleteItemRequested;
        public event Action<string> ItemSelected;

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization)
        {
            this.Initialize(item, localization, Properties.Resources.icons8_file_64);
        }

        public void Initialize(MRUItem item, MRUGuiItemLocalization localization, string imagePath)
        {
            Image itemImage = Properties.Resources.icons8_file_64;
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    itemImage = Image.FromFile(imagePath);
                }
            } 
            catch (Exception)
            {
                // TODO: provide some kind of notification or similar
            }
            this.Initialize(item, localization, itemImage);
        }

        private Color normalColor = SystemColors.Control;
        private readonly Color hoveredColor = SystemColors.ControlDark;

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
            }
        }

        private void DiscardSelection()
        {
            if (!this.ClientRectangle.Contains(this.PointToClient(Cursor.Position)))
            {
                this.BackColor = normalColor;
                panelActions.Visible = false;
            }
        }

    }
}
