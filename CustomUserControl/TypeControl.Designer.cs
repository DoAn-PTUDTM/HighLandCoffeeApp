namespace CustomUserControl
{
    partial class TypeControl
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
            this.lblNameType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNameType
            // 
            this.lblNameType.AutoSize = true;
            this.lblNameType.Location = new System.Drawing.Point(17, 32);
            this.lblNameType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameType.Name = "lblNameType";
            this.lblNameType.Size = new System.Drawing.Size(127, 20);
            this.lblNameType.TabIndex = 1;
            this.lblNameType.Text = "Cà Phê Highlight";
            // 
            // TypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.lblNameType);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TypeControl";
            this.Size = new System.Drawing.Size(178, 121);
            this.Load += new System.EventHandler(this.TypeControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNameType;
    }
}
