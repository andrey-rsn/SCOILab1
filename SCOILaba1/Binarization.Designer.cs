namespace SCOILaba1
{
    partial class Binarization
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
            this.InputPictureBox = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // InputPictureBox
            // 
            this.InputPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPictureBox.Location = new System.Drawing.Point(12, 12);
            this.InputPictureBox.Name = "InputPictureBox";
            this.InputPictureBox.Size = new System.Drawing.Size(637, 660);
            this.InputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InputPictureBox.TabIndex = 0;
            this.InputPictureBox.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(655, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(672, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Тип бинаризации";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(655, 55);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(139, 24);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "Применить";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(655, 644);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(139, 28);
            this.BackButton.TabIndex = 4;
            this.BackButton.Text = "Назад";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // Binarization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 684);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.InputPictureBox);
            this.Name = "Binarization";
            this.Text = "Binarization";
            ((System.ComponentModel.ISupportInitialize)(this.InputPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox InputPictureBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button BackButton;
    }
}