namespace SCOILaba1
{
    partial class FreqFiltering
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
            this.mainImage = new System.Windows.Forms.PictureBox();
            this.FurierImage = new System.Windows.Forms.PictureBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.outImage = new System.Windows.Forms.PictureBox();
            this.lowFilter = new System.Windows.Forms.RadioButton();
            this.highFilter = new System.Windows.Forms.RadioButton();
            this.X = new System.Windows.Forms.TextBox();
            this.Y = new System.Windows.Forms.TextBox();
            this.R = new System.Windows.Forms.TextBox();
            this.bright = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FurierImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outImage)).BeginInit();
            this.SuspendLayout();
            // 
            // mainImage
            // 
            this.mainImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainImage.Location = new System.Drawing.Point(12, 12);
            this.mainImage.Name = "mainImage";
            this.mainImage.Size = new System.Drawing.Size(533, 428);
            this.mainImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainImage.TabIndex = 0;
            this.mainImage.TabStop = false;
            // 
            // FurierImage
            // 
            this.FurierImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FurierImage.Cursor = System.Windows.Forms.Cursors.Default;
            this.FurierImage.Location = new System.Drawing.Point(551, 12);
            this.FurierImage.Name = "FurierImage";
            this.FurierImage.Size = new System.Drawing.Size(332, 268);
            this.FurierImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FurierImage.TabIndex = 1;
            this.FurierImage.TabStop = false;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(551, 296);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(332, 27);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // outImage
            // 
            this.outImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outImage.Location = new System.Drawing.Point(12, 446);
            this.outImage.Name = "outImage";
            this.outImage.Size = new System.Drawing.Size(533, 439);
            this.outImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outImage.TabIndex = 3;
            this.outImage.TabStop = false;
            // 
            // lowFilter
            // 
            this.lowFilter.AutoSize = true;
            this.lowFilter.Location = new System.Drawing.Point(551, 329);
            this.lowFilter.Name = "lowFilter";
            this.lowFilter.Size = new System.Drawing.Size(172, 17);
            this.lowFilter.TabIndex = 4;
            this.lowFilter.TabStop = true;
            this.lowFilter.Text = "Низкочастотная фильтрация";
            this.lowFilter.UseVisualStyleBackColor = true;
            // 
            // highFilter
            // 
            this.highFilter.AutoSize = true;
            this.highFilter.Location = new System.Drawing.Point(551, 352);
            this.highFilter.Name = "highFilter";
            this.highFilter.Size = new System.Drawing.Size(179, 17);
            this.highFilter.TabIndex = 5;
            this.highFilter.TabStop = true;
            this.highFilter.Text = "Высокочастотная фильтрация";
            this.highFilter.UseVisualStyleBackColor = true;
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(608, 385);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(79, 20);
            this.X.TabIndex = 6;
            // 
            // Y
            // 
            this.Y.Location = new System.Drawing.Point(608, 411);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(79, 20);
            this.Y.TabIndex = 6;
            // 
            // R
            // 
            this.R.Location = new System.Drawing.Point(608, 437);
            this.R.Name = "R";
            this.R.Size = new System.Drawing.Size(79, 20);
            this.R.TabIndex = 6;
            // 
            // bright
            // 
            this.bright.Location = new System.Drawing.Point(608, 463);
            this.bright.Name = "bright";
            this.bright.Size = new System.Drawing.Size(79, 20);
            this.bright.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(551, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(551, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(551, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Яркость";
            // 
            // FreqFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 897);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bright);
            this.Controls.Add(this.R);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.highFilter);
            this.Controls.Add(this.lowFilter);
            this.Controls.Add(this.outImage);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.FurierImage);
            this.Controls.Add(this.mainImage);
            this.Name = "FreqFiltering";
            this.Text = "FreqFiltering";
            ((System.ComponentModel.ISupportInitialize)(this.mainImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FurierImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainImage;
        private System.Windows.Forms.PictureBox FurierImage;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.PictureBox outImage;
        private System.Windows.Forms.RadioButton lowFilter;
        private System.Windows.Forms.RadioButton highFilter;
        private System.Windows.Forms.TextBox X;
        private System.Windows.Forms.TextBox Y;
        private System.Windows.Forms.TextBox R;
        private System.Windows.Forms.TextBox bright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}