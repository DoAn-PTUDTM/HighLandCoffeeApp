namespace CustomUserControl
{
    partial class ProductControl
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
            this.photoProduct = new System.Windows.Forms.PictureBox();
            this.lblNameProduct = new System.Windows.Forms.Label();
            this.btnS = new System.Windows.Forms.Button();
            this.btnL = new System.Windows.Forms.Button();
            this.btnM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.photoProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // photoProduct
            // 
            this.photoProduct.Location = new System.Drawing.Point(0, 0);
            this.photoProduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.photoProduct.Name = "photoProduct";
            this.photoProduct.Size = new System.Drawing.Size(286, 245);
            this.photoProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoProduct.TabIndex = 1;
            this.photoProduct.TabStop = false;
            // 
            // lblNameProduct
            // 
            this.lblNameProduct.AutoSize = true;
            this.lblNameProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameProduct.Location = new System.Drawing.Point(2, 249);
            this.lblNameProduct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameProduct.Name = "lblNameProduct";
            this.lblNameProduct.Size = new System.Drawing.Size(233, 20);
            this.lblNameProduct.TabIndex = 2;
            this.lblNameProduct.Text = "Trà Xanh Espresso Marble";
            // 
            // btnS
            // 
            this.btnS.Location = new System.Drawing.Point(200, 143);
            this.btnS.Name = "btnS";
            this.btnS.Size = new System.Drawing.Size(57, 29);
            this.btnS.TabIndex = 3;
            this.btnS.Text = "S";
            this.btnS.UseVisualStyleBackColor = true;
            this.btnS.Click += new System.EventHandler(this.btnS_Click);
            // 
            // btnL
            // 
            this.btnL.Location = new System.Drawing.Point(200, 217);
            this.btnL.Name = "btnL";
            this.btnL.Size = new System.Drawing.Size(57, 29);
            this.btnL.TabIndex = 4;
            this.btnL.Text = "L";
            this.btnL.UseVisualStyleBackColor = true;
            // 
            // btnM
            // 
            this.btnM.Location = new System.Drawing.Point(200, 180);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(57, 29);
            this.btnM.TabIndex = 5;
            this.btnM.Text = "M";
            this.btnM.UseVisualStyleBackColor = true;
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnM);
            this.Controls.Add(this.btnL);
            this.Controls.Add(this.btnS);
            this.Controls.Add(this.lblNameProduct);
            this.Controls.Add(this.photoProduct);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(294, 278);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.photoProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox photoProduct;
        private System.Windows.Forms.Label lblNameProduct;
        private System.Windows.Forms.Button btnS;
        private System.Windows.Forms.Button btnL;
        private System.Windows.Forms.Button btnM;
    }
}
