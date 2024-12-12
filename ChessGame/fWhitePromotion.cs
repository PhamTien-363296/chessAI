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
    public partial class fWhitePromotion : Form
    {
        public Type SelectedType { get; private set; }
        public fWhitePromotion()
        {
            InitializeComponent();
        }

        private void btnQueen_Click(object sender, EventArgs e)
        {
            SelectedType = Type.wQueen;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnRook_Click(object sender, EventArgs e)
        {
            SelectedType = Type.wRook;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnKnight_Click(object sender, EventArgs e)
        {
            SelectedType = Type.wKnight;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBishop_Click(object sender, EventArgs e)
        {
            SelectedType = Type.wBishop;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
