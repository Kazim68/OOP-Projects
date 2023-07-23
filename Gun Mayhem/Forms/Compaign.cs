using EZInput;
using Gun_Mayhem.GL;
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
	public partial class Compaign : Form
	{
		private CompaignMode game;
		private int pjump = 0;
		private int bulletCounter = 0;
		public Compaign(string path)
		{
			InitializeComponent();
			game = new CompaignMode(this, path);
		}

		private void Compaign_Load(object sender, EventArgs e)
		{

		}

		private void PlayerLoop_Tick(object sender, EventArgs e)
		{

			// move players
			game.movePlayer(game.GetFirstPlayer(), '1', ref pjump, Key.RightArrow, Key.LeftArrow, Key.UpArrow, Key.Space);

			// pit fall checker
			if (CollisionDetection.detectDeath(game.GetFirstPlayer()))
			{
				game.GetFirstPlayer().Health = 0;
			}

			// move bots
			game.moveBots(game.GetFirstPlayer());

			// game over checker
			if (game.GameOver())
			{
				PlayerLoop.Stop();
				BulletTimer.Stop();
				if (game.isAlive(game.GetFirstPlayer()))
				{
					MessageBox.Show("You Won!");
				}
				else
				{
					MessageBox.Show("You Died!");
				}
				this.Hide();
			}

			// if escape key pressed 
			if (Keyboard.IsKeyPressed(Key.Escape))
			{
				PlayerLoop.Stop();
				BulletTimer.Stop();
				this.Hide();
			}
		}

		private void BulletTimer_Tick(object sender, EventArgs e)
		{
			game.moveBullets();
			if (bulletCounter == 100)
			{
				game.removeBullets();
				bulletCounter = 0;
			}
			bulletCounter++;
		}

		private void Compaign_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
