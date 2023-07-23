using Gun_Mayhem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem
{
	public partial class StartScreen : Form
	{
		public StartScreen()
		{
			InitializeComponent();
		}

		private void StartScreen_Load(object sender, EventArgs e)
		{

		}

		private void CampainBtn_Click(object sender, EventArgs e)
		{
			// display campaing mode
			Compaign form = new Compaign("Level1.txt");
			form.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// display multiplayer
			MapSelectionFrm form = new MapSelectionFrm();
			form.ShowDialog();
		}

		private void StartScreen_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}

		private void EndlessSurvivalBtn_Click(object sender, EventArgs e)
		{
			// endless survival
			EndlessMode form = new EndlessMode("Endless.txt");
			form.ShowDialog();
		}
	}
}
