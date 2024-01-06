namespace chusongtool
{
    partial class FormAbout
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
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            buttonOK = new Button();
            linkLabel1 = new LinkLabel();
            linkLabel2 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(386, 40);
            label1.TabIndex = 0;
            label1.Text = "CHUNITHM Song Tool (CST)";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 76);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += PictureBox1_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 49);
            label2.Name = "label2";
            label2.Size = new Size(366, 15);
            label2.TabIndex = 2;
            label2.Text = "Utility tool for CRI HCA audio and makeing custom CRI ADX2 audios.";
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(327, 191);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "Done";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += ButtonOK_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(227, 110);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(75, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "GitHub Repo";
            linkLabel1.LinkClicked += LinkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(240, 155);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(49, 15);
            linkLabel2.TabIndex = 5;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Website";
            linkLabel2.LinkClicked += LinkLabel2_LinkClicked;
            // 
            // FormAbout
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 226);
            ControlBox = false;
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(buttonOK);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About CST";
            Load += FormAbout_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox pictureBox1;
        private Label label2;
        private Button buttonOK;
        private LinkLabel linkLabel1;
        private LinkLabel linkLabel2;
    }
}