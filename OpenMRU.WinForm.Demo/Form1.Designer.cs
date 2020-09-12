namespace OpenMRU.WinForm.Demo
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.mruItemsControl1 = new OpenMRU.WinForm.MRUItemsControl();
            this.SuspendLayout();
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(499, 35);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(99, 23);
            this.ButtonOpen.TabIndex = 1;
            this.ButtonOpen.Text = "OPEN FILE";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // mruItemsControl1
            // 
            this.mruItemsControl1.Location = new System.Drawing.Point(21, 12);
            this.mruItemsControl1.MinimumSize = new System.Drawing.Size(160, 200);
            this.mruItemsControl1.Name = "mruItemsControl1";
            this.mruItemsControl1.Size = new System.Drawing.Size(350, 360);
            this.mruItemsControl1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mruItemsControl1);
            this.Controls.Add(this.ButtonOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ButtonOpen;
        private MRUItemsControl mruItemsControl1;
    }
}

