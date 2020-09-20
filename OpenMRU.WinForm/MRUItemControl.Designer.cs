namespace OpenMRU.WinForm
{
    partial class MRUItemControl
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
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.pictureBoxPin = new System.Windows.Forms.PictureBox();
            this.pictureBoxRemove = new System.Windows.Forms.PictureBox();
            this.pictureBoxFileIco = new System.Windows.Forms.PictureBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.panelActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFileIco)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.AutoEllipsis = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileName.Location = new System.Drawing.Point(54, 4);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(294, 28);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "File name g";
            this.labelFileName.Click += new System.EventHandler(this.MRUItemControl_Click);
            this.labelFileName.MouseEnter += new System.EventHandler(this.MRUItemControl_MouseEnter);
            this.labelFileName.MouseLeave += new System.EventHandler(this.MRUItemControl_MouseLeave);
            // 
            // labelPath
            // 
            this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPath.AutoEllipsis = true;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath.Location = new System.Drawing.Point(55, 32);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(220, 16);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Full path to file";
            this.labelPath.Click += new System.EventHandler(this.MRUItemControl_Click);
            this.labelPath.MouseEnter += new System.EventHandler(this.MRUItemControl_MouseEnter);
            this.labelPath.MouseLeave += new System.EventHandler(this.MRUItemControl_MouseLeave);
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.Controls.Add(this.pictureBoxPin);
            this.panelActions.Controls.Add(this.pictureBoxRemove);
            this.panelActions.Location = new System.Drawing.Point(303, 3);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(46, 20);
            this.panelActions.TabIndex = 3;
            this.panelActions.Visible = false;
            this.panelActions.MouseLeave += new System.EventHandler(this.MRUItemControl_MouseLeave);
            // 
            // pictureBoxPin
            // 
            this.pictureBoxPin.Image = global::OpenMRU.WinForm.Properties.Resources.iconfinder_pin_blue_43904;
            this.pictureBoxPin.Location = new System.Drawing.Point(26, 2);
            this.pictureBoxPin.Name = "pictureBoxPin";
            this.pictureBoxPin.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxPin.TabIndex = 1;
            this.pictureBoxPin.TabStop = false;
            this.pictureBoxPin.Click += new System.EventHandler(this.PictureBoxPin_Click);
            // 
            // pictureBoxRemove
            // 
            this.pictureBoxRemove.Image = global::OpenMRU.WinForm.Properties.Resources.iconfinder_Delete_27842;
            this.pictureBoxRemove.Location = new System.Drawing.Point(3, 2);
            this.pictureBoxRemove.Name = "pictureBoxRemove";
            this.pictureBoxRemove.Size = new System.Drawing.Size(17, 17);
            this.pictureBoxRemove.TabIndex = 0;
            this.pictureBoxRemove.TabStop = false;
            this.pictureBoxRemove.Click += new System.EventHandler(this.PictureBoxRemove_Click);
            // 
            // pictureBoxFileIco
            // 
            this.pictureBoxFileIco.Image = global::OpenMRU.WinForm.Properties.Resources.icons8_file_64;
            this.pictureBoxFileIco.Location = new System.Drawing.Point(1, 3);
            this.pictureBoxFileIco.Name = "pictureBoxFileIco";
            this.pictureBoxFileIco.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxFileIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFileIco.TabIndex = 0;
            this.pictureBoxFileIco.TabStop = false;
            this.pictureBoxFileIco.Click += new System.EventHandler(this.MRUItemControl_Click);
            this.pictureBoxFileIco.MouseEnter += new System.EventHandler(this.MRUItemControl_MouseEnter);
            this.pictureBoxFileIco.MouseLeave += new System.EventHandler(this.MRUItemControl_MouseLeave);
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Location = new System.Drawing.Point(280, 34);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(65, 13);
            this.labelDate.TabIndex = 4;
            this.labelDate.Text = "2020/04/25";
            // 
            // MRUItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.pictureBoxFileIco);
            this.Name = "MRUItemControl";
            this.Size = new System.Drawing.Size(352, 54);
            this.Click += new System.EventHandler(this.MRUItemControl_Click);
            this.MouseEnter += new System.EventHandler(this.MRUItemControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.MRUItemControl_MouseLeave);
            this.panelActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRemove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFileIco)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFileIco;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.PictureBox pictureBoxRemove;
        private System.Windows.Forms.PictureBox pictureBoxPin;
        private System.Windows.Forms.Label labelDate;
    }
}
