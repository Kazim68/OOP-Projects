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
	public partial class Map1 : Form
	{
		private MultiPlayer game;
		private int bulletCounter = 0;
		private int pjump = 0;
		private int ejump = 0;
		public Map1(string path, Image bgImage)
		{
			InitializeComponent();
			game = new MultiPlayer(this, path);
			BackgroundImage = bgImage;
		}

		

		private void Map1_Load(object sender, EventArgs e)
		{

		}

		private void PlayerLoop_Tick(object sender, EventArgs e)
		{
			// move players
			game.movePlayer(game.GetFirstPlayer(), '1', ref pjump, Key.RightArrow, Key.LeftArrow, Key.UpArrow, Key.Space);
			game.movePlayer(game.GetSecondPlayer(), '2', ref ejump, Key.D, Key.A, Key.W, Key.F);
			
			// pit fall checker
			if (CollisionDetection.detectDeath(game.GetFirstPlayer()))
			{
				game.GetFirstPlayer().Health = 0;
			}
			else if (CollisionDetection.detectDeath(game.GetSecondPlayer()))
			{
				game.GetSecondPlayer().Health = 0;
			}

			// game over checker
			if (game.GameOver())
			{
				PlayerLoop.Stop();
				BulletsTimer.Stop();
				if (game.isAlive(game.GetFirstPlayer()))
				{
					MessageBox.Show("Player 1 wins!");
				}
				else
				{
					MessageBox.Show("Player 2 wins!");
				}
				this.Hide();
			}

			if (Keyboard.IsKeyPressed(Key.Escape))
			{
				PlayerLoop.Stop();
				BulletsTimer.Stop();
				this.Hide();
			}
		}

		private void BulletsTimer_Tick(object sender, EventArgs e)
		{
			game.moveBullets();
			if (bulletCounter == 100)
			{
				game.removeBullets();
				bulletCounter = 0;
			}
			bulletCounter++;
		}

		private void Map1_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
