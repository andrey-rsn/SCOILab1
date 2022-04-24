namespace SCOILaba1
{
    partial class Filtering
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
            this.mainImagePictureBox = new System.Windows.Forms.PictureBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.M22 = new System.Windows.Forms.TextBox();
            this.M21 = new System.Windows.Forms.TextBox();
            this.M20 = new System.Windows.Forms.TextBox();
            this.M12 = new System.Windows.Forms.TextBox();
            this.M11 = new System.Windows.Forms.TextBox();
            this.M10 = new System.Windows.Forms.TextBox();
            this.M02 = new System.Windows.Forms.TextBox();
            this.M01 = new System.Windows.Forms.TextBox();
            this.M00 = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.filterType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainImagePictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainImagePictureBox
            // 
            this.mainImagePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.mainImagePictureBox.Name = "mainImagePictureBox";
            this.mainImagePictureBox.Size = new System.Drawing.Size(668, 665);
            this.mainImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainImagePictureBox.TabIndex = 0;
            this.mainImagePictureBox.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(686, 12);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(192, 35);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.M22);
            this.panel1.Controls.Add(this.M21);
            this.panel1.Controls.Add(this.M20);
            this.panel1.Controls.Add(this.M12);
            this.panel1.Controls.Add(this.M11);
            this.panel1.Controls.Add(this.M10);
            this.panel1.Controls.Add(this.M02);
            this.panel1.Controls.Add(this.M01);
            this.panel1.Controls.Add(this.M00);
            this.panel1.Location = new System.Drawing.Point(981, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 146);
            this.panel1.TabIndex = 2;
            // 
            // M22
            // 
            this.M22.Location = new System.Drawing.Point(109, 120);
            this.M22.Name = "M22";
            this.M22.Size = new System.Drawing.Size(24, 20);
            this.M22.TabIndex = 13;
            this.M22.Text = "0";
            // 
            // M21
            // 
            this.M21.Location = new System.Drawing.Point(54, 120);
            this.M21.Name = "M21";
            this.M21.Size = new System.Drawing.Size(24, 20);
            this.M21.TabIndex = 12;
            this.M21.Text = "0";
            // 
            // M20
            // 
            this.M20.Location = new System.Drawing.Point(3, 120);
            this.M20.Name = "M20";
            this.M20.Size = new System.Drawing.Size(24, 20);
            this.M20.TabIndex = 11;
            this.M20.Text = "0";
            // 
            // M12
            // 
            this.M12.Location = new System.Drawing.Point(109, 58);
            this.M12.Name = "M12";
            this.M12.Size = new System.Drawing.Size(24, 20);
            this.M12.TabIndex = 9;
            this.M12.Text = "0";
            // 
            // M11
            // 
            this.M11.Location = new System.Drawing.Point(54, 58);
            this.M11.Name = "M11";
            this.M11.Size = new System.Drawing.Size(24, 20);
            this.M11.TabIndex = 8;
            this.M11.Text = "0";
            // 
            // M10
            // 
            this.M10.Location = new System.Drawing.Point(3, 58);
            this.M10.Name = "M10";
            this.M10.Size = new System.Drawing.Size(24, 20);
            this.M10.TabIndex = 7;
            this.M10.Text = "0";
            // 
            // M02
            // 
            this.M02.Location = new System.Drawing.Point(109, 3);
            this.M02.Name = "M02";
            this.M02.Size = new System.Drawing.Size(24, 20);
            this.M02.TabIndex = 5;
            this.M02.Text = "0";
            // 
            // M01
            // 
            this.M01.Location = new System.Drawing.Point(54, 3);
            this.M01.Name = "M01";
            this.M01.Size = new System.Drawing.Size(24, 20);
            this.M01.TabIndex = 4;
            this.M01.Text = "0";
            // 
            // M00
            // 
            this.M00.Location = new System.Drawing.Point(3, 3);
            this.M00.Name = "M00";
            this.M00.Size = new System.Drawing.Size(24, 20);
            this.M00.TabIndex = 3;
            this.M00.Text = "0";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(686, 643);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(192, 34);
            this.backButton.TabIndex = 3;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // filterType
            // 
            this.filterType.FormattingEnabled = true;
            this.filterType.Location = new System.Drawing.Point(686, 53);
            this.filterType.Name = "filterType";
            this.filterType.Size = new System.Drawing.Size(192, 21);
            this.filterType.TabIndex = 4;
            // 
            // Filtering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 689);
            this.Controls.Add(this.filterType);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.mainImagePictureBox);
            this.Name = "Filtering";
            this.Text = "Filtering";
            ((System.ComponentModel.ISupportInitialize)(this.mainImagePictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mainImagePictureBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox M22;
        private System.Windows.Forms.TextBox M21;
        private System.Windows.Forms.TextBox M20;
        private System.Windows.Forms.TextBox M12;
        private System.Windows.Forms.TextBox M11;
        private System.Windows.Forms.TextBox M10;
        private System.Windows.Forms.TextBox M02;
        private System.Windows.Forms.TextBox M01;
        private System.Windows.Forms.TextBox M00;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox filterType;
    }
}