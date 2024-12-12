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
    public partial class fColorSettings : Form
    {
        private Color whiteSquareColor;
        private Color blackSquareColor;
        private Color formBackgroundColor;

        public Color WhiteSquareColor { get; private set; }
        public Color BlackSquareColor { get; private set; }
        public Color FormBackgroundColor { get; private set; }

        public fColorSettings(Color initialWhiteColor, Color initialBlackColor, Color initialBackgroundColor)
        {
            InitializeComponent();

            whiteSquareColor = initialWhiteColor;
            blackSquareColor = initialBlackColor;
            formBackgroundColor = initialBackgroundColor;

            WhiteSquareColor = initialWhiteColor;
            BlackSquareColor = initialBlackColor;
            FormBackgroundColor = initialBackgroundColor;

            btnChangeWhiteColor.BackColor = whiteSquareColor;
            btnChangeBlackColor.BackColor = blackSquareColor;
            btnChangeBackgroundColor.BackColor = formBackgroundColor;
        }

        private void btnChangeWhiteColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = whiteSquareColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    whiteSquareColor = colorDialog.Color;
                    WhiteSquareColor = colorDialog.Color;

                    btnChangeWhiteColor.BackColor = whiteSquareColor;
                }
            }
        }

        private void btnChangeBlackColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = blackSquareColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    blackSquareColor = colorDialog.Color;
                    BlackSquareColor = colorDialog.Color;

                    btnChangeBlackColor.BackColor = blackSquareColor;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnChangeBackgroundColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = formBackgroundColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    formBackgroundColor = colorDialog.Color;
                    FormBackgroundColor = colorDialog.Color;

                    btnChangeBackgroundColor.BackColor = formBackgroundColor;
                }
            }
        }
    }
}

