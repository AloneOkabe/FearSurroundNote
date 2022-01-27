using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace New_FearSurroundNote
{
    public partial class Form1 : Form
    {
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		public Form1()
        {
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;

			var Baselabels = new List<Label> { Num0, Num1, Num2, Num3, Num4, Num5, Num6, Num7, Num8, Num9, Num10, Num11, Num12, Num13, Num14, Attack1, Attack2, Attack3, Attack4, Shield1, Shield2, Shield3, Shield4 };
			foreach (var label in Baselabels)
			{
				Helper.ControlMover.Init(label);
				label.Parent = groupBox5;
				label.BackColor = Color.Transparent;
			}
			var Alabels = new List<Label> { ANum0, ANum1, ANum2, ANum3, ANum4, ANum5, ANum6, ANum7, ANum8, ANum9, ANum10, ANum11, ANum12, ANum13, ANum14, ADead1, ADead2, ADead3, ADead4, ADead5, ADead6};
			foreach (var label in Alabels)
			{
				Helper.ControlMover.Init(label);
				label.Parent = PG1;
				label.BackColor = Color.Transparent;
			}

			Helper.ControlMover.Init(IDK);
			IDK.Parent = PG1;
			IDK.BackColor = Color.Transparent;

			Helper.ControlMover.Init(百變怪A);
			百變怪A.Parent = PG1;
			百變怪A.BackColor = Color.Transparent;
			

			var Blabels = new List<Label> { BNum0, BNum1, BNum2, BNum3, BNum4, BNum5, BNum6, BNum7, BNum8, BNum9, BNum10, BNum11, BNum12, BNum13, BNum14, BDead1, BDead2, BDead3, BDead4, BDead5, BDead6 };
			foreach (var label in Blabels)
			{
				Helper.ControlMover.Init(label);
				label.Parent = PG2;
				label.BackColor = Color.Transparent;
			}
			Helper.ControlMover.Init(IDK2);
			IDK2.Parent = PG2;
			IDK2.BackColor = Color.Transparent;

			Helper.ControlMover.Init(百變怪B);
			百變怪B.Parent = PG2;
			百變怪B.BackColor = Color.Transparent;
			var Clabels = new List<Label> { CNum0, CNum1, CNum2, CNum3, CNum4, CNum5, CNum6, CNum7, CNum8, CNum9, CNum10, CNum11, CNum12, CNum13, CNum14, CDead1, CDead2, CDead3, CDead4, CDead5, CDead6 };
			foreach (var label in Clabels)
			{
				Helper.ControlMover.Init(label);
				label.Parent = PG3;
				label.BackColor = Color.Transparent;
			}

			Helper.ControlMover.Init(IDK3);
			IDK3.Parent = PG3;
			IDK3.BackColor = Color.Transparent;

			Helper.ControlMover.Init(百變怪C);
			百變怪C.Parent = PG3;
			百變怪C.BackColor = Color.Transparent;

			var Dlabels = new List<Label> { DNum0, DNum1, DNum2, DNum3, DNum4, DNum5, DNum6, DNum7, DNum8, DNum9, DNum10, DNum11, DNum12, DNum13, DNum14, DDead1, DDead2, DDead3, DDead4, DDead5, DDead6 };
			foreach (var label in Dlabels)
			{
				Helper.ControlMover.Init(label);
				label.Parent = PG4;
				label.BackColor = Color.Transparent;
			}

			Helper.ControlMover.Init(IDK4);
			IDK4.Parent = PG4;
			IDK4.BackColor = Color.Transparent;

			Helper.ControlMover.Init(百變怪D);
			百變怪D.Parent = PG4;
			百變怪D.BackColor = Color.Transparent;

		}

        private void Form1_Load(object sender, EventArgs e)
        {
			fillFLP0(FLP0, 107, 62, 33);
		}

        #region FLP	
        Label mvLabel = null;
		private IEnumerable<Control> controls;

		void fillFLP0(FlowLayoutPanel FLP, int aa, int bb, int cc)
		{
			for (int i = 0; i < 15; i++)
			{
				Label l = new Label();
				l.AutoSize = false;
				l.Text = "   " + i.ToString("00") + "   ";				
				l.BackColor = Color.FromArgb(255, aa + 8 * (i/3) , bb + 7 * (i/3), cc + 6 * (i/3));
				FLP.Controls.Add(l);
				l.MouseDown += l_MouseDown;
				l.MouseMove += l_MouseMove;
				l.MouseUp += l_MouseUp;
			}
		}

		void l_MouseDown(object sender, MouseEventArgs e)
		{
			mvLabel = (Label)sender;
		}

		void l_MouseMove(object sender, MouseEventArgs e)
		{
			if (mvLabel != null)
			{
				Point mvPoint = this.PointToClient(Control.MousePosition);
				if (mvLabel.Parent != this)
				{
					mvLabel.Parent = this;
					mvLabel.Location = mvPoint;
					mvLabel.BringToFront();
				}
				else
				{
					mvLabel.Location = mvPoint;
				}
			}
		}

		void l_MouseUp(object sender, MouseEventArgs e)
		{
			Point MP = Control.MousePosition;
			FlowLayoutPanel FLP = null;

			Point mLoc0 = FLP0.PointToClient(MP);
			Point mLoc1 = FLP1.PointToClient(MP);
			Point mLoc2 = FLP2.PointToClient(MP);
			Point mLoc3 = FLP3.PointToClient(MP);

			if (FLP0.ClientRectangle.Contains(mLoc0)) FLP = FLP0;
			else if (FLP1.ClientRectangle.Contains(mLoc1)) FLP = FLP1;
			else if (FLP2.ClientRectangle.Contains(mLoc2)) FLP = FLP2;
			else if (FLP3.ClientRectangle.Contains(mLoc3)) FLP = FLP3;
			else return;
			mvLabel.SendToBack();
			Control cc = FLP.GetChildAtPoint(FLP.PointToClient(MP));
			int mvIndex = FLP.Controls.Count;
			if (cc != null) mvIndex = FLP.Controls.IndexOf(cc);
			FLP.Controls.Add(mvLabel);
			FLP.Controls.SetChildIndex(mvLabel, mvIndex);
			mvLabel = null;
		}
		#endregion	

        #region Button
        private void villa_Click(object sender, EventArgs e)
        {
			var villaPG = new List<PictureBox> { PG1, PG2, PG3, PG4 };
			foreach (var PictureBox in villaPG)
			{
				PictureBox.Image = Properties.Resources.別墅;
			}
		}

        private void Jail_Click(object sender, EventArgs e)
        {
			var JailPG = new List<PictureBox> { PG1, PG2, PG3, PG4 };
			foreach (var PictureBox in JailPG)
			{
				PictureBox.Image = Properties.Resources.監獄;
			}
		}

		private void School_Click(object sender, EventArgs e)
		{
			var SchoolPG = new List<PictureBox> { PG1, PG2, PG3, PG4 };
			foreach (var PictureBox in SchoolPG)
			{
				PictureBox.Image = Properties.Resources.學校;
			}
		}

		private void NewHospital_Click(object sender, EventArgs e)
		{
			var SchoolPG = new List<PictureBox> { PG1, PG2, PG3, PG4 };
			foreach (var PictureBox in SchoolPG)
			{
				PictureBox.Image = Properties.Resources.新醫院;
			}
		}

		private void OldHospital_Click(object sender, EventArgs e)
		{
			var SchoolPG = new List<PictureBox> { PG1, PG2, PG3, PG4 };
			foreach (var PictureBox in SchoolPG)
			{
				PictureBox.Image = Properties.Resources.舊醫院;
			}
		}

		private void GGRE_Click(object sender, EventArgs e)
		{
			Application.Restart();
		}
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
		{
			const int nChars = 25;
			IntPtr handle;
			StringBuilder Buff = new StringBuilder(nChars);
			handle = GetForegroundWindow();
			if (GetWindowText(handle, Buff, nChars) > 0)
			{
				Action.Text = (Buff.ToString());
			}

			if (Action.Text == "FearSurround  ")
			{
				this.Visible = false;
				//this.Hide();
				this.Text = "FearSurrounds-Notes By: Alone (Hide)";
				Size = new Size(0, 0);
			}
			else
			{
				this.Visible = true;
				//this.Show();
				Right.Location = new Point(-2, -3);
				Size = new Size(640, 545);
				this.Text = "FearSurrounds-Notes By: Alone";

			}
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
			if (checkBox1.Checked)
			{
				timer1.Enabled = true;
				checkBox1.Enabled = false;
			}
			else
			{
				timer1.Enabled = false;
			}
		}

        private void pictureBox11_Click(object sender, EventArgs e)
        {
			Form2 myForm = new Form2();
			myForm.ShowDialog();
		}

        private void label1_Click(object sender, EventArgs e)
        {
			Form2 myForm = new Form2();
			myForm.ShowDialog();
		}

        private void PG1_Click(object sender, EventArgs e)
        {

        }
    }
}
