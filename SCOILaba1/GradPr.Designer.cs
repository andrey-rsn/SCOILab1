namespace SCOILaba1
{
    partial class GradPr
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
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.gradPicture = new System.Windows.Forms.PictureBox();
            this.HistPictureBox = new System.Windows.Forms.PictureBox();
            this.BackButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // picture1
            // 
            this.picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture1.Location = new System.Drawing.Point(12, 12);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(589, 510);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picture1.TabIndex = 0;
            this.picture1.TabStop = false;
            // 
            // gradPicture
            // 
            this.gradPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradPicture.Location = new System.Drawing.Point(628, 12);
            this.gradPicture.Name = "gradPicture";
            this.gradPicture.Size = new System.Drawing.Size(510, 510);
            this.gradPicture.TabIndex = 1;
            this.gradPicture.TabStop = false;
            // 
            // HistPictureBox
            // 
            this.HistPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HistPictureBox.Location = new System.Drawing.Point(12, 539);
            this.HistPictureBox.Name = "HistPictureBox";
            this.HistPictureBox.Size = new System.Drawing.Size(589, 162);
            this.HistPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HistPictureBox.TabIndex = 2;
            this.HistPictureBox.TabStop = false;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(1012, 668);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(126, 33);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1000, 539);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(941, 543);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Функция";
            // 
            // GradPr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 717);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.HistPictureBox);
            this.Controls.Add(this.gradPicture);
            this.Controls.Add(this.picture1);
            this.Name = "GradPr";
            this.Text = "GradPr";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HistPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.PictureBox gradPicture;
        private System.Windows.Forms.PictureBox HistPictureBox;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}