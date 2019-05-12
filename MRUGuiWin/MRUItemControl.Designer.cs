namespace MRUGuiWin
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
            this.pictureBoxFileIco = new System.Windows.Forms.PictureBox();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelPath = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFileIco)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFileIco
            // 
            this.pictureBoxFileIco.Image = global::MRUGuiWin.Properties.Resources.icons8_file_64;
            this.pictureBoxFileIco.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxFileIco.Name = "pictureBoxFileIco";
            this.pictureBoxFileIco.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxFileIco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFileIco.TabIndex = 0;
            this.pictureBoxFileIco.TabStop = false;
            this.pictureBoxFileIco.Click += new System.EventHandler(this.MRUItemControl_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.AutoEllipsis = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFileName.Location = new System.Drawing.Point(54, 2);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(226, 23);
            this.labelFileName.TabIndex = 1;
            this.labelFileName.Text = "File name";
            this.labelFileName.Click += new System.EventHandler(this.MRUItemControl_Click);
            // 
            // labelPath
            // 
            this.labelPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPath.AutoEllipsis = true;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath.Location = new System.Drawing.Point(55, 30);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(226, 16);
            this.labelPath.TabIndex = 2;
            this.labelPath.Text = "Full path to file";
            this.labelPath.Click += new System.EventHandler(this.MRUItemControl_Click);
            // 
            // MRUItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.pictureBoxFileIco);
            this.Name = "MRUItemControl";
            this.Size = new System.Drawing.Size(284, 50);
            this.Click += new System.EventHandler(this.MRUItemControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFileIco)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFileIco;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelPath;
    }
}
