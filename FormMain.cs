using System.Diagnostics;

namespace chusongtool
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Text = "Chunithm Song Tool (CST) - " + Common.Generic.Version.FileVersion;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Common.Generic.CurrentDir + @"\temp");
            Directory.CreateDirectory(Common.Generic.CurrentDir + @"\temp\adx2");
            SetNormalLabel("Ready.");
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Common.Utils.DeleteDirectory(Common.Generic.TempDir);
        }

        private void Button_unpack_acb_Click(object sender, EventArgs e)
        {
            SetNormalLabel("Ready.");
            try
            {
                OpenFileDialog ofd = new()
                {
                    Filter = "CRI Atom Cuesheet Binary (*.acb)|*.acb",
                    FilterIndex = 0,
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new(ofd.FileName);
                    if (!File.Exists(fi.FullName.ToUpper().Replace(fi.Extension, ".AWB")))
                    {
                        MessageBox.Show("There is no AWB Audio file in the specified ACB file path '" + fi.FullName.ToUpper().Replace(fi.Extension, ".AWB") + "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetErrorLabel("An error occured.");
                        return;
                    }
                    SetNormalLabel("Unpacking...");

                    File.Copy(ofd.FileName, Common.Generic.CRI_ADX2Dir + fi.Name);
                    File.Copy(ofd.FileName, Common.Generic.TempDir + @"\" + fi.Name);
                    File.Copy(ofd.FileName.Replace(fi.Extension, ".awb"), Common.Generic.CRI_ADX2Dir + fi.Name.Replace(fi.Extension, ".awb"));

                    Process ps = new();
                    ProcessStartInfo psi = new()
                    {
                        FileName = Common.Generic.CurrentDir + @"\res\sat\acbeditor",
                        WorkingDirectory = Common.Generic.CRI_ADX2Dir,
                        Arguments = fi.Name,
                        UseShellExecute = true,
                        RedirectStandardOutput = false,
                        CreateNoWindow = true
                    };
                    ps.StartInfo = psi;
                    ps.Start();
                    ps.WaitForExit();

                    Common.Generic.StreamDir = Common.Generic.CRI_ADX2Dir + fi.Name.Replace(fi.Extension, "");
                    Common.Generic.StreamDirName = fi.Name.Replace(fi.Extension, "");

                    if (!Directory.Exists(Common.Generic.StreamDir))
                    {
                        MessageBox.Show("There is no directory '" + Common.Generic.StreamDir + "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetErrorLabel("An error occured.");
                        return;
                    }

                    Process ps1 = new();
                    ProcessStartInfo psi1 = new()
                    {
                        FileName = Common.Generic.CurrentDir + @"\res\dt\release\hca2wav",
                        WorkingDirectory = Common.Generic.StreamDir,
                        Arguments = @"00000_streaming.hca -a CE264700 -b 0074FF1F -o 00000_streaming.wav",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    };
                    ps1.StartInfo = psi1;
                    ps1.Start();
                    ps1.WaitForExit();

                    if (!File.Exists(Common.Generic.StreamDir + @"\00000_streaming.wav"))
                    {
                        MessageBox.Show("There is no file '" + Common.Generic.StreamDir + @"\00000_streaming.wav" + "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SetErrorLabel("An error occured.");
                        return;
                    }

                    File.Move(Common.Generic.StreamDir + @"\00000_streaming.wav", Common.Generic.TempDir + @"\00000_streaming.wav");
                    Common.Utils.DeleteDirectory(Common.Generic.CRI_ADX2Dir);

                    groupBox_step1.Enabled = false;
                    groupBox_step2.Enabled = true;
                    button_unpack_acb.Enabled = false;
                    button_edit_audio.Enabled = true;
                    button_make_hca.Enabled = true;

                    SetSuccessLabel("Unpacking completed.");
                }
                else
                {
                    SetWarningLabel("Cancelled.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetErrorLabel("An error occured.");
                return;
            }
        }

        private void Button_edit_audio_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@"C:\Program Files (x86)\Audacity\audacity.exe"))
                {
                    OpenFileDialog ofd = new()
                    {
                        Filter = "MPEG Audio Layer 3 (*.mp3)|*.mp3|RIFF Wave Audio (*.wav)|*.wav|Ogg Vorbis (*.ogg)|*.ogg)",
                        FilterIndex = 0,
                    };
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        Process ps1 = new();
                        ProcessStartInfo psi1 = new()
                        {
                            FileName = @"C:\Program Files (x86)\Audacity\audacity.exe",
                            WorkingDirectory = Common.Generic.TempDir,
                            Arguments = Common.Generic.TempDir + @"\00000_streaming.wav " + ofd.FileName,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        };
                        ps1.StartInfo = psi1;
                        ps1.Start();
                        SetNormalLabel("Editing audio...");
                        ps1.WaitForExit();
                        SetInformationLabel("Audio editing completed.");
                        return;
                    }
                    else
                    {
                        Process ps1 = new();
                        ProcessStartInfo psi1 = new()
                        {
                            FileName = @"C:\Program Files (x86)\Audacity\audacity.exe",
                            WorkingDirectory = Common.Generic.TempDir,
                            Arguments = Common.Generic.TempDir + @"\00000_streaming.wav",
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            CreateNoWindow = true
                        };
                        ps1.StartInfo = psi1;
                        ps1.Start();
                        SetNormalLabel("Editing audio...");
                        ps1.WaitForExit();
                        SetInformationLabel("Audio editing completed.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Audacity is not installed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    SetWarningLabel("File not found.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetErrorLabel("An error occured.");
                return;
            }
        }

        private void Button_make_hca_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Common.Generic.TempDir + @"\00000_streaming.wav"))
                {
                    MessageBox.Show("File not found '" + Common.Generic.TempDir + @"\00000_streaming.wav'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetErrorLabel("File not found.");
                    return;
                }
                SetNormalLabel("Making HCA...");

                Process ps = new();
                ProcessStartInfo psi = new()
                {
                    FileName = Common.Generic.CurrentDir + @"\res\dt\release\hcaenc",
                    WorkingDirectory = Common.Generic.TempDir,
                    Arguments = @"00000_streaming.wav 00000_streaming.hca -q 3",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                ps.StartInfo = psi;
                ps.Start();
                ps.WaitForExit();

                if (!File.Exists(Common.Generic.TempDir + @"\00000_streaming.hca"))
                {
                    MessageBox.Show("File not found '" + Common.Generic.TempDir + @"\00000_streaming.hca'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetErrorLabel("File not found.");
                    return;
                }

                File.Delete(Common.Generic.TempDir + @"\00000_streaming.wav");
                Common.Generic.StreamDir = Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName;
                Directory.CreateDirectory(Common.Generic.StreamDir);
                File.Move(Common.Generic.TempDir + @"\00000_streaming.hca", Common.Generic.StreamDir + @"\00000_streaming.hca");

                groupBox_step2.Enabled = false;
                groupBox_step3.Enabled = true;
                button_edit_audio.Enabled = false;
                button_make_hca.Enabled = false;
                button_hca_encrypt.Enabled = true;

                SetSuccessLabel("HCA making completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetErrorLabel("An error occured.");
                return;
            }
        }

        private void Button_hca_encrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Common.Generic.StreamDir + @"\00000_streaming.hca"))
                {
                    MessageBox.Show("File not found '" + Common.Generic.StreamDir + @"\00000_streaming.hca'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetErrorLabel("File not found.");
                    return;
                }
                SetNormalLabel("Encrypting HCA...");

                Process ps = new();
                ProcessStartInfo psi = new()
                {
                    FileName = Common.Generic.CurrentDir + @"\res\dt\release\hcacc",
                    WorkingDirectory = Common.Generic.StreamDir,
                    Arguments = @"00000_streaming.hca 00000_streaming_cc.hca -ot 56 -o1 CE264700 -o2 0074FF1F",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                ps.StartInfo = psi;
                ps.Start();
                ps.WaitForExit();

                if (!File.Exists(Common.Generic.StreamDir + @"\00000_streaming_cc.hca"))
                {
                    MessageBox.Show("File not found '" + Common.Generic.StreamDir + @"\00000_streaming_cc.hca'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetErrorLabel("File not found.");
                    return;
                }

                File.Move(Common.Generic.StreamDir + @"\00000_streaming_cc.hca", Common.Generic.StreamDir + @"\00000_streaming.hca", true);

                groupBox_step3.Enabled = false;
                groupBox_step4.Enabled = true;
                button_hca_encrypt.Enabled = false;
                button_make_final.Enabled = true;
                SetSuccessLabel("Encrypted HCA.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetErrorLabel("An error occured.");
                return;
            }
        }

        private void Button_make_final_Click(object sender, EventArgs e)
        {
            try
            {
                SetNormalLabel("Making ACB and AWB...");
                Process ps = new();
                ProcessStartInfo psi = new()
                {
                    FileName = Common.Generic.CurrentDir + @"\res\sat\acbeditor",
                    WorkingDirectory = Common.Generic.TempDir,
                    Arguments = Common.Generic.StreamDir,
                    UseShellExecute = true,
                    RedirectStandardOutput = false,
                    CreateNoWindow = true
                };
                ps.StartInfo = psi;
                ps.Start();
                ps.WaitForExit();

                string spath = string.Empty;
                if (File.Exists(Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".acb") && File.Exists(Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".awb"))
                {
                    SaveFileDialog sfd = new()
                    {
                        FileName = Common.Generic.StreamDirName,
                        Filter = "CRI Atom Cuesheet Binary (*.acb)|*.acb",
                        FilterIndex = 0,
                    };
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        spath = sfd.FileName;//.Replace(sfd.FileName[sfd.FileName.LastIndexOf('\\')..], @"\");
                        File.Move(Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".acb", sfd.FileName, true);
                        File.Move(Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".awb", sfd.FileName.Replace(sfd.FileName[sfd.FileName.LastIndexOf('.')..], ".awb"), true);
                    }
                    else
                    {
                        SetWarningLabel("Cancelled.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("File not found '" + Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".acb' or '" + Common.Generic.TempDir + @"\" + Common.Generic.StreamDirName + ".awb'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetErrorLabel("File not found.");
                    return;
                }

                groupBox_step4.Enabled = false;
                groupBox_step1.Enabled = true;
                button_unpack_acb.Enabled = true;
                button_make_final.Enabled = false;
                Common.Utils.DeleteDirectory(Common.Generic.TempDir);
                Directory.CreateDirectory(Common.Generic.TempDir);
                SetSuccessLabel("All Done.");
                Common.Utils.ShowFolder(spath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetErrorLabel("An error occured.");
                return;
            }
        }

        private void SetSuccessLabel(string text)
        {
            label_status.ForeColor = Color.Green;
            label_status.Text = text;
        }

        private void SetInformationLabel(string text)
        {
            label_status.ForeColor = Color.Blue;
            label_status.Text = text;
        }

        private void SetNormalLabel(string text)
        {
            label_status.ForeColor = Color.Black;
            label_status.Text = text;
        }

        private void SetWarningLabel(string text)
        {
            label_status.ForeColor = Color.YellowGreen;
            label_status.Text = text;
        }

        private void SetErrorLabel(string text)
        {
            label_status.ForeColor = Color.Red;
            label_status.Text = text;
        }

        private void ExitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetNormalLabel("Exiting...");
            Close();
        }

        private void AboutAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fa = new();
            fa.ShowDialog();
        }
    }
}
