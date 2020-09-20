namespace OpenMRU.WinForm
{
    partial class MRUItemsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCaption = new System.Windows.Forms.Label();
            this.panelItems = new System.Windows.Forms.Panel();
            this.linkLabelClearAll = new System.Windows.Forms.LinkLabel();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelCaption
            // 
            this.labelCaption.AutoEllipsis = true;
            this.labelCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCaption.Location = new System.Drawing.Point(4, 4);
            this.labelCaption.Name = "labelCaption";
            this.labelCaption.Size = new System.Drawing.Size(86, 25);
            this.labelCaption.TabIndex = 0;
            this.labelCaption.Text = "Recent";
            // 
            // panelItems
            // 
            this.panelItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelItems.AutoScroll = true;
            this.panelItems.Location = new System.Drawing.Point(3, 59);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(251, 185);
            this.panelItems.TabIndex = 1;
            // 
            // linkLabelClearAll
            // 
            this.linkLabelClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelClearAll.AutoEllipsis = true;
            this.linkLabelClearAll.Location = new System.Drawing.Point(203, 10);
            this.linkLabelClearAll.Name = "linkLabelClearAll";
            this.linkLabelClearAll.Size = new System.Drawing.Size(45, 13);
            this.linkLabelClearAll.TabIndex = 2;
            this.linkLabelClearAll.TabStop = true;
            this.linkLabelClearAll.Text = "Clear All items";
            this.linkLabelClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClearAll_LinkClicked);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFilter.Location = new System.Drawing.Point(4, 33);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(222, 20);
            this.textBoxFilter.TabIndex = 3;
            this.textBoxFilter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFilter_KeyUp);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFilter.Location = new System.Drawing.Point(229, 32);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(25, 22);
            this.buttonClearFilter.TabIndex = 4;
            this.buttonClearFilter.Text = "X";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // MRUItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClearFilter);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.linkLabelClearAll);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.labelCaption);
            this.MinimumSize = new System.Drawing.Size(160, 200);
            this.Name = "MRUItemsControl";
            this.Size = new System.Drawing.Size(257, 247);
            this.SizeChanged += new System.EventHandler(this.MRUItemsControl_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.LinkLabel linkLabelClearAll;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Button buttonClearFilter;
    }
}
