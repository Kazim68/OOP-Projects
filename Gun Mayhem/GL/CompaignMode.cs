using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem.GL
{
	internal class CompaignMode : Game
	{
		VerticalBot bot1;
		MeleeBot bot2;

		ProgressBar bot1Bar;
		ProgressBar bot2Bar;

		int bot2AttackCounter = 0;


        public CompaignMode(Form gameForm, string path) : base(gameForm, path)
		{
			Image botImage = GameAssets.getObjectImage('2');
			bot1 = new VerticalBot(grid.getCell(65, 4), botImage);
			bot2 = new MeleeBot(grid.getCell(20, 9), botImage, base.player);

			bot1Bar = makeProgressBar(bot1, bot1Bar, 1100, 10);
			bot2Bar = makeProgressBar(bot2, bot2Bar, 1100, 40);
		}

		// make progress bar
		public ProgressBar makeProgressBar(Bots bot, ProgressBar bar, int x, int y)
		{
			bar = new ProgressBar();
			bar.ForeColor = Color.Green;
			bar.Maximum = 100;
			bar.Minimum = 0;
			bar.Value = bot.Health;
			bar.Top = y;
			bar.Left = x;
			gameForm.Controls.Add(bar);
			return bar;
		}

		// check for game over
		public override bool GameOver()
		{
			if (base.player.Health <= 0 || CollisionDetection.atDoor(base.player))
			{
				return true;
			}
			return false;
		}

		public void moveBots(Player player)
		{
            if (bot1.alive())
            {
				bot1.moveBot(bot1.nextCell());
				botFire(bot1, player);
            }

			if (bot2.alive())
			{
				if (bot2AttackCounter == 2)
				{
					if (CollisionDetection.detectMeleeBotWithPlayer(bot2, player) && player.Health > 0)
					{
						player.Health -= 10;
						if (player.Health < 0)
						{
							playerBar.Value = 0;
						}
						else
						{
							playerBar.Value = player.Health;
						}
					}
					else
					{
						bot2.moveBot(bot2.nextCell());
					}
					bot2AttackCounter = 0;
				}
				bot2AttackCounter++;
			}
        }

		// bot fire 
		public void botFire(GameObject bot, GameObject player)
		{
			if (bot.currentCell.Y == player.currentCell.Y)
			{
				if (player.currentCell.X >= bot.currentCell.X)
				{
					bot.Image = GameAssets.getPlayerImage('2', GameObjectDirection.Right);
					bullets.Add(new Bullet(bot.currentCell.nextCell(GameObjectDirection.Right), GameAssets.getBulletImage(), GameObjectDirection.Right));
				}
				else
				{
					bot.Image = GameAssets.getPlayerImage('2', GameObjectDirection.Left);
					bullets.Add(new Bullet(bot.currentCell.nextCell(GameObjectDirection.Left), GameAssets.getBulletImage(), GameObjectDirection.Left));
				}
			}
		}

		// move bullets
		public override void moveBullets()
		{
			foreach (Bullet bullet in bullets)
			{
				if (bullet.Active)
				{
					// bullet collision with objects
					if (CollisionDetection.detectBulletCollision(bullet))
					{
						if (CollisionDetection.detectBulletCollisionWithPlayer(bullet, player))
						{
							player.Health -= bullet.Damage;
							playerBar.Value = player.Health;
						}
						else if (CollisionDetection.detectBulletCollisionWithBot(bullet, bot1))
						{
							bot1.Health -= bullet.Damage;
							bot1Bar.Value = bot1.Health;
						}
						else if (CollisionDetection.detectBulletCollisionWithBot(bullet, bot2))
						{
							bot2.Health -= bullet.Damage;
							bot2Bar.Value = bot2.Health;
							checkSecretDoorOpen();
						}

						bullet.Active = false;

					}
					bullet.MoveBullet(bullet.nextCell());
				}
			}
		}

		// if bot2 dies, a secret door is opened 
		public void checkSecretDoorOpen()
		{
			if (!bot2.alive())
			{
				for (int i =2; i <= 6; i++)
				{
					grid.getCell(i, 10).setGameObject(GameAssets.GetNullObject());
				}
			}
		}
	}
}
