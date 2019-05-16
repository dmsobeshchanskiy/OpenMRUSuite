using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MRUGuiCore.ViewInterfaces;
using MRUCore.Interfaces;
using MRUGuiCore;

namespace MRUGuiWin
{
    public partial class MRUItemsControl : UserControl, IMRUItemsView
    {
        public event Action ClearMRUItemsRequested;

        public List<IMRUItemView> ItemViews { get; private set; }


        public void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            this.localization = localization;
            MRUGuiLogic logic = new MRUGuiLogic(this, manager, localization);
        }

        public void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            ItemViews = new List<IMRUItemView>();
            panelItems.Controls.Clear();
            int currentTopPosition = 0;

            foreach(MRUItemsContainer container in containers)
            {
                Label groupCaption = new Label
                {
                    Text = container.ContainerCaption,
                    Left = 1,
                    Top = currentTopPosition,
                    AutoSize = true
                };
                panelItems.Controls.Add(groupCaption);
                currentTopPosition += TextRenderer.MeasureText(groupCaption.Text, groupCaption.Font).Height + 3;
                foreach (IMRUItem item in container.Items)
                {
                    MRUItemControl mruControl = new MRUItemControl();
                    mruControl.Initialize(item, localization.ItemLocalization);
                    panelItems.Controls.Add(mruControl);
                    mruControl.Width = panelItems.Width - 2;
                    mruControl.Top = currentTopPosition;
                    mruControl.Left = 1;
                    mruControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                    ItemViews.Add(mruControl);
                    currentTopPosition += mruControl.Height;
                }
            }
        }

        public bool IsActionAllowed(string actionDescription)
        {
            return MessageBox.Show(actionDescription, localization.ConfirmActionDialogCaption, MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        public MRUItemsControl()
        {
            InitializeComponent();
        }

        private MRUGuiLocalization localization;

        private void LinkLabelClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearMRUItemsRequested?.Invoke();
        }
    }
}
