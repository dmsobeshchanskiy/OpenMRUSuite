﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OpenMRU.Core.View.Interfaces;
using OpenMRU.Core.Common.Interfaces;
using OpenMRU.Core.View.Localization;
using OpenMRU.Core.Common.Models;
using OpenMRU.WinForm.Base;

namespace OpenMRU.WinForm
{
    /// <summary>
    /// WinForm control for to show MRU items
    /// </summary>
    public partial class MRUItemsControl : MRUItemsBase, IMRUItemsView
    {
        /// <summary>
        /// Init control: reads MRU items and shows them on 'view'
        /// </summary>
        /// <param name="manager">IMRUManager implementation instance</param>
        /// <param name="localization">localization instance</param>
        public override void Initialize(IMRUManager manager, MRUGuiLocalization localization)
        {
            Initialize(manager, localization, string.Empty);
        }

        /// <summary>
        /// Init control: reads MRU items and shows them on 'view'
        /// </summary>
        /// <param name="manager">IMRUManager implementation instance</param>
        /// <param name="localization">localization instance</param>
        /// <param name="imageForItem">image for to use with given MRU item</param>
        public void Initialize(IMRUManager manager, MRUGuiLocalization localization, string imageForItem)
        {
            base.Initialize(manager, localization);
            this.imageForItem = imageForItem;
            this.labelCaption.Text = localization.Caption;
            this.linkLabelClearAll.Text = localization.ClearAllLabel;
            RepositionHeader();
        }

        /// <summary>
        /// Display MRU item containers
        /// </summary>
        /// <param name="containers">MRU containers to display</param>
        public override void ShowMRUItems(List<MRUItemsContainer> containers)
        {
            panelItems.SuspendLayout();
            ItemViews = new List<IMRUItemView>();
            panelItems.Controls.Clear();
            linkLabelClearAll.Visible = containers.Count > 0;
            if (containers.Count > 0)
            {
                DisplayContainers(containers);
            } else
            {
                Label noItemsCaption = new Label
                {
                    Text = localization.NoRecentItemsLabel,
                    Left = 1,
                    Top = 1,
                    AutoSize = true
                };
                panelItems.Controls.Add(noItemsCaption);
            }
            buttonClearFilter.Enabled = containers.Count > 0;
            textBoxFilter.Enabled = containers.Count > 0;
            panelItems.ResumeLayout();
        }

        /// <summary>
        /// default ctor
        /// </summary>
        public MRUItemsControl()
        {
            InitializeComponent();
        }

        private string imageForItem;
        private readonly int leftMargin = 4;
        private readonly int rightMargin = 4;
        private readonly int spaceBetween = 2;
        private int currentTopPosition = 0;

        private void DisplayContainers(List<MRUItemsContainer> containers)
        {
            int scrollPosition = panelItems.VerticalScroll.Value;
            panelItems.VerticalScroll.Value = 0;
            currentTopPosition = 0;
            foreach (MRUItemsContainer container in containers)
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
                foreach (MRUItem item in container.Items)
                {
                    MRUItemControl mruControl = new MRUItemControl();
                    panelItems.Controls.Add(mruControl);
                    mruControl.Initialize(item, localization.ItemLocalization, imageForItem);
                    mruControl.Top = currentTopPosition;
                    mruControl.Left = 1;
                    ItemViews.Add(mruControl);
                    currentTopPosition += mruControl.Height;
                }
            }
            CorrectWidthForItems();
            panelItems.VerticalScroll.Value = scrollPosition;
        }

        private void LinkLabelClearAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InvokeMRUItemsClearing();
        }
    
        private void RepositionHeader()
        {
            int captionWidth = TextRenderer.MeasureText(labelCaption.Text, labelCaption.Font).Width;
            int linkWidth = TextRenderer.MeasureText(linkLabelClearAll.Text, linkLabelClearAll.Font).Width;
            double captionPart = (double)captionWidth / (captionWidth + linkWidth);

            int availableSpace = this.Width - leftMargin - rightMargin - spaceBetween;
            labelCaption.Width = (int)(availableSpace * captionPart);

            int availableForLink = availableSpace - labelCaption.Width;

            if (availableForLink >= linkWidth)
            {
                linkLabelClearAll.Width = linkWidth;
                linkLabelClearAll.Left = availableSpace - linkWidth;
            } else
            {
                linkLabelClearAll.Left = labelCaption.Width + spaceBetween;
                linkLabelClearAll.Width = availableForLink;
            }
            
        }

        private void CorrectWidthForItems()
        {
            if (ItemViews == null || ItemViews.Count == 0)
            {
                return;
            }
            int width = panelItems.Width - 2;
            if (currentTopPosition > this.panelItems.Height)
            {
                width = panelItems.Width - 18;
            }
            ItemViews.ForEach((IMRUItemView item) =>
            {
                Control itemControl = item as Control;
                itemControl.Width = width;
                // itemControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            });
        }

        private void MRUItemsControl_SizeChanged(object sender, EventArgs e)
        {
            RepositionHeader();
            CorrectWidthForItems();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFilter.Text))
            {
                return;
            }
            textBoxFilter.Text = string.Empty;
            logic.SetFileNameFilter(textBoxFilter.Text);
        }

        private void textBoxFilter_KeyUp(object sender, KeyEventArgs e)
        {
            logic.SetFileNameFilter(textBoxFilter.Text);
        }
    }
}
