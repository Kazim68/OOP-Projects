using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem.GL
{
	internal class EndlessSurvival : Game
	{
        public List<MeleeBot> Bots;
		public int bot2AttackCounter = 0;

		public EndlessSurvival(Form gameForm, string path) : base(gameForm, path)
		{
            Bots = new List<MeleeBot>();
        }

        // move bots
        public void moveBots(Player player)
        {
            foreach (MeleeBot bot in Bots)
            {
                if (bot.alive())
                {
					if (bot2AttackCounter == 2)
					{
						if (CollisionDetection.detectMeleeBotWithPlayer(bot, player) && player.Health > 0)
						{
							player.Health -= 10;
							playerBar.Value = player.Health;
						}
						else
						{
							bot.moveBot(bot.nextCell());
						}
						bot2AttackCounter = 0;
					}
					if (!CollisionDetection.isTouchingPlatform(bot, GameObjectDirection.Down))
					{
						bot.moveBot(gravity(bot));
					}
					bot2AttackCounter++;
				}
            }
        }

		// bot gravity fall
		public GameCell gravity(GameObject bot)
		{
			GameCell currentCell = bot.currentCell;
			GameCell next = bot.currentCell.nextCell(GameObjectDirection.Down);

			currentCell.setGameObject(GameAssets.GetNullObject());
			return next;
		}

		// create a melee bot at random position
		public MeleeBot CreateBot()
		{
			GameCell cell = getRandomCell();
			return new MeleeBot(cell, GameAssets.getPlayerImage('2', GameObjectDirection.Left), base.player);
		}

		// get random x position for bot
		public GameCell getRandomCell()
		{
			Random num = new Random();
			int x = num.Next(10, 50);
			return grid.getCell(x, 3);
		}

		// check bullet collision with bot
		public void bulletHitBot(Bullet bullet)
		{
			foreach (MeleeBot bot in Bots)
			{
				if (CollisionDetection.detectBulletCollisionWithBot(bullet, bot))
				{
					bot.Health -= 50;
					base.player.Score += 10;

				}
			}
		}

		// remove dead bots
		public void deadBot()
		{
			foreach (MeleeBot bot in Bots)
			{
				if (!bot.alive())
				{
					bot.currentCell.setGameObject(GameAssets.GetNullObject());
				}
			}
		}

		// remove dead bots from list
		public void removedeadBots()
		{
			for (int i = 0; i < Bots.Count; i++)
			{
				if (!Bots[i].alive())
				{
					Bots.RemoveAt(i);
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

					if (CollisionDetection.detectBulletCollision(bullet))
					{

						bulletHitBot(bullet);

						bullet.Active = false;

					}
					bullet.MoveBullet(bullet.nextCell());

					deadBot();
				}
			}
		}
	}
}
