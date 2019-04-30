﻿using System;
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
            this.manager = manager;
            this.localization = localization;
        }

        public void ShowMRUItems(List<IMRUItem> items)
        {
            ItemViews = new List<IMRUItemView>();
            int currentTopPosition = 0;
            foreach(IMRUItem item in items)
            {
                MRUItemControl mruControl = new MRUItemControl();
                mruControl.Initialize(item);
                panelItems.Controls.Add(mruControl);
                mruControl.Width = panelItems.Width - 2;
                mruControl.Top = currentTopPosition;
                mruControl.Left = 1;
                mruControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                ItemViews.Add(mruControl);
                currentTopPosition += mruControl.Height;
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
        private IMRUManager manager;

        private void LinkLabelClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearMRUItemsRequested?.Invoke();
        }
    }
}
