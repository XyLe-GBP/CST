using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;

namespace chusongtool
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                pictureBox1.ImageLocation = "https://avatars.githubusercontent.com/u/59692068?v=4";
            }
            else
            {
                pictureBox1.Image = res.Resource.f089e80b819fe6da7d36bea8bf647d04_t;
            }
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Common.Utils.OpenURI("https://github.com/XyLe-GBP");
            return;
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Common.Utils.OpenURI("https://xyle-official.com");
            return;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
            return;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);
                Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(canvas);
                GraphicsPath gp = new();
                gp.AddEllipse(g.VisibleClipBounds);
                Region rgn = new(gp);
                pictureBox1.Region = rgn;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
        }
    }
}
