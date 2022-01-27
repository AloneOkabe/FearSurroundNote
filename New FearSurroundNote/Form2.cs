using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace New_FearSurroundNote
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("moyung0924@gmail.com");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtube.com/playlist?list=PLbTx5HXS6b9S6D35jyWsOMyGjPou_SUHM");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/cdclub");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("moyung0924@gmail.com");
        }
    }
}
