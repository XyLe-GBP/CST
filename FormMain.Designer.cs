namespace chusongtool
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip_Main = new MenuStrip();
            fileFToolStripMenuItem = new ToolStripMenuItem();
            exitXToolStripMenuItem = new ToolStripMenuItem();
            helpHToolStripMenuItem = new ToolStripMenuItem();
            aboutAToolStripMenuItem = new ToolStripMenuItem();
            button_unpack_acb = new Button();
            groupBox_step1 = new GroupBox();
            groupBox_step2 = new GroupBox();
            button_edit_audio = new Button();
            button_make_hca = new Button();
            groupBox_step3 = new GroupBox();
            button_hca_encrypt = new Button();
            groupBox_step4 = new GroupBox();
            button_make_final = new Button();
            label_status = new Label();
            menuStrip_Main.SuspendLayout();
            groupBox_step1.SuspendLayout();
            groupBox_step2.SuspendLayout();
            groupBox_step3.SuspendLayout();
            groupBox_step4.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip_Main
            // 
            menuStrip_Main.Items.AddRange(new ToolStripItem[] { fileFToolStripMenuItem, helpHToolStripMenuItem });
            menuStrip_Main.Location = new Point(0, 0);
            menuStrip_Main.Name = "menuStrip_Main";
            menuStrip_Main.Size = new Size(372, 24);
            menuStrip_Main.TabIndex = 0;
            menuStrip_Main.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            fileFToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitXToolStripMenuItem });
            fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            fileFToolStripMenuItem.Size = new Size(54, 20);
            fileFToolStripMenuItem.Text = "File (&F)";
            // 
            // exitXToolStripMenuItem
            // 
            exitXToolStripMenuItem.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            exitXToolStripMenuItem.ForeColor = Color.Red;
            exitXToolStripMenuItem.Name = "exitXToolStripMenuItem";
            exitXToolStripMenuItem.Size = new Size(111, 22);
            exitXToolStripMenuItem.Text = "Exit (&X)";
            exitXToolStripMenuItem.Click += ExitXToolStripMenuItem_Click;
            // 
            // helpHToolStripMenuItem
            // 
            helpHToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            helpHToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutAToolStripMenuItem });
            helpHToolStripMenuItem.Name = "helpHToolStripMenuItem";
            helpHToolStripMenuItem.Size = new Size(64, 20);
            helpHToolStripMenuItem.Text = "Help (&H)";
            // 
            // aboutAToolStripMenuItem
            // 
            aboutAToolStripMenuItem.Name = "aboutAToolStripMenuItem";
            aboutAToolStripMenuItem.Size = new Size(126, 22);
            aboutAToolStripMenuItem.Text = "About (&A)";
            aboutAToolStripMenuItem.Click += AboutAToolStripMenuItem_Click;
            // 
            // button_unpack_acb
            // 
            button_unpack_acb.Location = new Point(6, 22);
            button_unpack_acb.Name = "button_unpack_acb";
            button_unpack_acb.Size = new Size(336, 23);
            button_unpack_acb.TabIndex = 1;
            button_unpack_acb.Text = "Unpack ACB";
            button_unpack_acb.UseVisualStyleBackColor = true;
            button_unpack_acb.Click += Button_unpack_acb_Click;
            // 
            // groupBox_step1
            // 
            groupBox_step1.Controls.Add(button_unpack_acb);
            groupBox_step1.Location = new Point(12, 27);
            groupBox_step1.Name = "groupBox_step1";
            groupBox_step1.Size = new Size(348, 60);
            groupBox_step1.TabIndex = 2;
            groupBox_step1.TabStop = false;
            groupBox_step1.Text = "Step 1 - Unpack ACB Audio";
            // 
            // groupBox_step2
            // 
            groupBox_step2.Controls.Add(button_edit_audio);
            groupBox_step2.Controls.Add(button_make_hca);
            groupBox_step2.Enabled = false;
            groupBox_step2.Location = new Point(12, 93);
            groupBox_step2.Name = "groupBox_step2";
            groupBox_step2.Size = new Size(348, 77);
            groupBox_step2.TabIndex = 3;
            groupBox_step2.TabStop = false;
            groupBox_step2.Text = "Step 2 - Audio Editing + Synchronization + Make HCA Audio";
            // 
            // button_edit_audio
            // 
            button_edit_audio.Enabled = false;
            button_edit_audio.Location = new Point(6, 22);
            button_edit_audio.Name = "button_edit_audio";
            button_edit_audio.Size = new Size(336, 23);
            button_edit_audio.TabIndex = 4;
            button_edit_audio.Text = "Audio Edit";
            button_edit_audio.UseVisualStyleBackColor = true;
            button_edit_audio.Click += Button_edit_audio_Click;
            // 
            // button_make_hca
            // 
            button_make_hca.Enabled = false;
            button_make_hca.Location = new Point(6, 48);
            button_make_hca.Name = "button_make_hca";
            button_make_hca.Size = new Size(336, 23);
            button_make_hca.TabIndex = 4;
            button_make_hca.Text = "Make";
            button_make_hca.UseVisualStyleBackColor = true;
            button_make_hca.Click += Button_make_hca_Click;
            // 
            // groupBox_step3
            // 
            groupBox_step3.Controls.Add(button_hca_encrypt);
            groupBox_step3.Enabled = false;
            groupBox_step3.Location = new Point(12, 176);
            groupBox_step3.Name = "groupBox_step3";
            groupBox_step3.Size = new Size(348, 61);
            groupBox_step3.TabIndex = 4;
            groupBox_step3.TabStop = false;
            groupBox_step3.Text = "Step 3 - HCA Encrypting";
            // 
            // button_hca_encrypt
            // 
            button_hca_encrypt.Enabled = false;
            button_hca_encrypt.Location = new Point(6, 22);
            button_hca_encrypt.Name = "button_hca_encrypt";
            button_hca_encrypt.Size = new Size(336, 23);
            button_hca_encrypt.TabIndex = 0;
            button_hca_encrypt.Text = "Encrypt";
            button_hca_encrypt.UseVisualStyleBackColor = true;
            button_hca_encrypt.Click += Button_hca_encrypt_Click;
            // 
            // groupBox_step4
            // 
            groupBox_step4.Controls.Add(button_make_final);
            groupBox_step4.Enabled = false;
            groupBox_step4.Location = new Point(12, 243);
            groupBox_step4.Name = "groupBox_step4";
            groupBox_step4.Size = new Size(348, 60);
            groupBox_step4.TabIndex = 5;
            groupBox_step4.TabStop = false;
            groupBox_step4.Text = "Step 4 - Make ACB + AWB File";
            // 
            // button_make_final
            // 
            button_make_final.Enabled = false;
            button_make_final.Location = new Point(6, 22);
            button_make_final.Name = "button_make_final";
            button_make_final.Size = new Size(336, 23);
            button_make_final.TabIndex = 0;
            button_make_final.Text = "Make";
            button_make_final.UseVisualStyleBackColor = true;
            button_make_final.Click += Button_make_final_Click;
            // 
            // label_status
            // 
            label_status.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label_status.Location = new Point(12, 304);
            label_status.Name = "label_status";
            label_status.Size = new Size(348, 52);
            label_status.TabIndex = 6;
            label_status.Text = "Done.";
            label_status.TextAlign = ContentAlignment.TopCenter;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 351);
            ControlBox = false;
            Controls.Add(label_status);
            Controls.Add(groupBox_step4);
            Controls.Add(groupBox_step3);
            Controls.Add(groupBox_step2);
            Controls.Add(groupBox_step1);
            Controls.Add(menuStrip_Main);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip_Main;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChuSongTool (CST)";
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            menuStrip_Main.ResumeLayout(false);
            menuStrip_Main.PerformLayout();
            groupBox_step1.ResumeLayout(false);
            groupBox_step2.ResumeLayout(false);
            groupBox_step3.ResumeLayout(false);
            groupBox_step4.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip_Main;
        private ToolStripMenuItem fileFToolStripMenuItem;
        private ToolStripMenuItem exitXToolStripMenuItem;
        private ToolStripMenuItem helpHToolStripMenuItem;
        private ToolStripMenuItem aboutAToolStripMenuItem;
        private Button button_unpack_acb;
        private GroupBox groupBox_step1;
        private GroupBox groupBox_step2;
        private Button button_edit_audio;
        private Button button_make_hca;
        private GroupBox groupBox_step3;
        private Button button_hca_encrypt;
        private GroupBox groupBox_step4;
        private Button button_make_final;
        private Label label_status;
    }
}
