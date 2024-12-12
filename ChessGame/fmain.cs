namespace ChessGame
{
    public partial class fmain : Form
    {
        public fmain()
        {
            InitializeComponent();
        }

        private void btnAi_Click(object sender, EventArgs e)
        {
            if (Utility.IsOpeningForm("fgameAi"))
                return;
            fgameAi f = new fgameAi();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btnNg_Click(object sender, EventArgs e)
        {
            if (Utility.IsOpeningForm("fgame"))
                return;
            fgame f = new fgame();
            f.MdiParent = this.MdiParent;
            f.Show();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            Close();   
        }
    }
}
