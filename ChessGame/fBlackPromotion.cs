using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame
{
    public partial class fBlackPromotion : Form
    {
        public Type SelectedType { get; private set; }
        public fBlackPromotion()
        {
            InitializeComponent();
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            SelectedType = Type.bQueen;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            SelectedType = Type.bRook;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            SelectedType = Type.bKnight;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            SelectedType = Type.bBishop;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
