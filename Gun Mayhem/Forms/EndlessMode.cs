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
	public partial class EndlessMode : Form
	{
		EndlessSurvival game;
		int pjump = 0;
		int bulletCounter = 0;
		Label Score;
		int botCounter = 0;

		int playerCount = 0;
		int botCreateCount = 0;
		int createBotTime = 50;
		public EndlessMode(string path)
		{
			InitializeComponent();
			game = new EndlessSurvival(this, path);
			game.player.Score = 0;

			// making the score label 
			Score = new Label();
			Score.Location = new System.Drawing.Point(600, 10);
			Score.Text = "Score: " + game.player.Score;
			Score.ForeColor = System.Drawing.Color.Green;
			Score.BackColor = System.Drawing.Color.Transparent;
			Score.Font = new Font("Arial", 12);
			Score.Visible = true;

			this.Controls.Add(Score);
		}

		private void EndlessMode_Load(object sender, EventArgs e)
		{

		}

		// player loop
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (playerCount == 2)
			{
				// move players
				game.movePlayer(game.GetFirstPlayer(), '1', ref pjump, Key.RightArrow, Key.LeftArrow, Key.UpArrow, Key.Space);

				// move bots
				game.moveBots(game.GetFirstPlayer());

				// game over checker
				if (game.GameOver())
				{
					PlayerLoop.Stop();
					BulletTimer.Stop();
					BotTimer.Stop();

					MessageBox.Show("Your Score is " + game.player.Score + "!");

					this.Hide();
				}

				// if escape key pressed 
				if (Keyboard.IsKeyPressed(Key.Escape))
				{
					this.Hide();
				}

				if (botCounter == 100)
				{
					game.removedeadBots();
					botCounter = 0;
				}
				botCounter++;

				playerCount = 0;
			}
			playerCount++;

			// bullet
			game.moveBullets();
			if (bulletCounter == 100)
			{
				game.removeBullets();
				bulletCounter = 0;
			}
			bulletCounter++;

			Score.Text = "Score: " + game.player.Score;

			if (botCreateCount == createBotTime)
			{
				// create bot
				game.Bots.Add(game.CreateBot());

				if (createBotTime > 5)
				{
					createBotTime -= 1;
				}

				botCreateCount = 0;
			}
			botCreateCount+=1;

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

			Score.Text = "Score: " + game.player.Score;
		}

		private void BotTimer_Tick(object sender, EventArgs e)
		{
			// create bot
			game.Bots.Add(game.CreateBot());

			if (BotTimer.Interval > 300)
			{
				BotTimer.Interval -= 1;
			}
		}

		private void EndlessMode_FormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
		}
	}
}
