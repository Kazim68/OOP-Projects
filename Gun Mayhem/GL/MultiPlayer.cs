using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem.GL
{
	internal class MultiPlayer : Game
	{
		public Player enemy;
		public ProgressBar enemyBar;

		public MultiPlayer(Form gameForm, string path) : base(gameForm, path)
        {
			Image enemyImage = GameAssets.getObjectImage('2');
			enemy = new Player(grid.getCell(60, 2), enemyImage);
			enemy.Direction = GameObjectDirection.Left;
			enemyBar = base.makeProgressBar(enemy, enemyBar, 1050, 10);
		}

		// check for game over
		public override bool GameOver()
		{
			if (base.player.Health <= 0 || enemy.Health <= 0)
			{
				return true;
			}
			return false;
		}

		public Player GetSecondPlayer()
		{
			return enemy;
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
						if (CollisionDetection.detectBulletCollisionWithPlayer(bullet, player))
						{
							player.Health -= bullet.Damage;
							playerBar.Value = player.Health;
						}
						else if (CollisionDetection.detectBulletCollisionWithPlayer(bullet, enemy))
						{
							enemy.Health -= bullet.Damage;
							enemyBar.Value = enemy.Health;
						}
						bullet.Active = false;

					}
					bullet.MoveBullet(bullet.nextCell());
				}
			}
		}
	}
}
