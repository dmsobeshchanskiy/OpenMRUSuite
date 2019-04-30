namespace MRUGuiWin
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
            this.SuspendLayout();
            // 
            // labelCaption
            // 
            this.labelCaption.AutoSize = true;
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
            this.panelItems.Location = new System.Drawing.Point(3, 33);
            this.panelItems.Name = "panelItems";
            this.panelItems.Size = new System.Drawing.Size(237, 228);
            this.panelItems.TabIndex = 1;
            // 
            // linkLabelClearAll
            // 
            this.linkLabelClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelClearAll.AutoSize = true;
            this.linkLabelClearAll.Location = new System.Drawing.Point(189, 10);
            this.linkLabelClearAll.Name = "linkLabelClearAll";
            this.linkLabelClearAll.Size = new System.Drawing.Size(45, 13);
            this.linkLabelClearAll.TabIndex = 2;
            this.linkLabelClearAll.TabStop = true;
            this.linkLabelClearAll.Text = "Clear All";
            this.linkLabelClearAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelClearAll_LinkClicked);
            // 
            // MRUItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabelClearAll);
            this.Controls.Add(this.panelItems);
            this.Controls.Add(this.labelCaption);
            this.MinimumSize = new System.Drawing.Size(160, 200);
            this.Name = "MRUItemsControl";
            this.Size = new System.Drawing.Size(243, 264);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCaption;
        private System.Windows.Forms.Panel panelItems;
        private System.Windows.Forms.LinkLabel linkLabelClearAll;
    }
}
