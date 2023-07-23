using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem.Forms
{
	public partial class MapSelectionFrm : Form
	{
		public MapSelectionFrm()
		{
			InitializeComponent();
		}

		private void Map1Btn_Click(object sender, EventArgs e)
		{
			Map1 form = new Map1("Map1.txt", Properties.Resources.Map1BG);
			form.ShowDialog();
		}

		private void Map2Btn_Click(object sender, EventArgs e)
		{
			Map1 form = new Map1("Map2.txt", Properties.Resources.Map2BG);
			form.ShowDialog();
		}

		private void Map3Btn_Click(object sender, EventArgs e)
		{
			Map1 form = new Map1("Map3.txt", Properties.Resources.Map3BG);
			form.ShowDialog();
		}

		private void Map4Btn_Click(object sender, EventArgs e)
		{
			Map1 form = new Map1("Map4.txt", Properties.Resources.Map4BG);
			form.ShowDialog();
		}

		private void Map5Btn_Click(object sender, EventArgs e)
		{
			Map1 form = new Map1("Map5.txt", Properties.Resources.Map5BG);
			form.ShowDialog();
		}

		private void MapSelectionFrm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void BackBtn_Click(object sender, EventArgs e)
		{
			this.Hide();
		}
	}
}
