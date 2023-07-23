using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;

namespace Gun_Mayhem.GL
{
	internal abstract class Game
	{
		public Player player;
		public Grid grid;
		public Form gameForm;
		public List<Bullet> bullets;
		public bool gameRunning;
		public ProgressBar playerBar;
		

		public Game(Form gameForm, string path)
        {
            this.gameForm = gameForm;
			grid = new Grid(19, 70, path);

			Image playerImage = GameAssets.getObjectImage('1');
			player = new Player(grid.getCell(10, 2), playerImage);
			player.Direction = GameObjectDirection.Right;
			playerBar = makeProgressBar(player, playerBar, 100, 10);

			makeMap();
			bullets = new List<Bullet>();
			gameRunning = true;
		}

		private void makeMap()
		{
			for (int y = 0; y < grid.Rows; y++)
			{
				for (int x = 0; x < grid.Col; x++)
				{
					GameCell cell = grid.getCell(x, y);
					gameForm.Controls.Add(cell.Sprite);
				}

			}
		}
		
		// make progress bar
		public ProgressBar makeProgressBar(Player p, ProgressBar bar, int x, int y)
		{
			bar = new ProgressBar();
			bar.ForeColor = Color.Green;
			bar.Maximum = 100;
			bar.Minimum = 0;
			bar.Value = p.Health;
			bar.Top = y;
			bar.Left = x;
			gameForm.Controls.Add(bar);
			return bar;
		}

		// check for game over
		public virtual bool GameOver()
		{
			if (player.Health <= 0)
			{
				return true;
			}
			return false;
		}
		
		// check if player is alive
		public bool isAlive(Player p)
		{
            if ( p.Health > 0)
            {
				return true;
            }
			return false;
        }
		

		public Player GetFirstPlayer()
		{
			return player;
		}

		
		// player movement 
		public void movePlayer(Player obj, char number, ref int jump, Key right, Key left, Key up, Key fire)
		{
			GameCell next = obj.CurrentCell;
			GameCell currentCell = next;

			if (Keyboard.IsKeyPressed(right))
			{
				next = obj.CurrentCell.nextCell(GameObjectDirection.Right);
				obj.Image = GameAssets.getPlayerImage(number, GameObjectDirection.Right);
				obj.Direction = GameObjectDirection.Right;
			}
			if (Keyboard.IsKeyPressed(left))
			{
				next = obj.currentCell.nextCell(GameObjectDirection.Left);
				obj.Image = GameAssets.getPlayerImage(number, GameObjectDirection.Left);
				obj.Direction = GameObjectDirection.Left;
			}
			if (Keyboard.IsKeyPressed(up) && jump == 0 && CollisionDetection.isTouchingPlatform(obj, GameObjectDirection.Down))
			{
				jump = 6;
			}
			
			if (Keyboard.IsKeyPressed(fire))
			{
				bullets.Add(new Bullet(obj.currentCell.nextCell(obj.Direction), GameAssets.getBulletImage(), obj.Direction));
			}

			currentCell.setGameObject(GameAssets.GetNullObject());
			obj.movePlayer(next);

			Jump(obj, ref jump);

		}


		// move bullets
		public virtual void moveBullets()
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
						bullet.Active = false;
						
					}
					bullet.MoveBullet(bullet.nextCell());
				}
			}
		}

		// removing inactive bullets from list
		public void removeBullets()
		{
			for (int i = 0; i < bullets.Count; i++)
			{
				if (!bullets[i].Active)
				{
					bullets.RemoveAt(i);
				}
			}
		}

		public void Jump(Player obj, ref int jump)
		{
			GameCell next = obj.currentCell;
			GameCell currentCell = next;

			if (jump > 3)
			{
				if (CollisionDetection.isTouchingPlatform(obj, GameObjectDirection.Up))
				{
					jump = 3;
				}
				else
				{
					next = obj.currentCell.nextCell(GameObjectDirection.Up);
					jump--;
				}
			}

			if (!CollisionDetection.isTouchingPlatform(obj, GameObjectDirection.Down) && jump <= 3)
			{
				next = obj.currentCell.nextCell(GameObjectDirection.Down);
				if (jump > 0)
				{
					jump--;
				}
			}
			else if (jump <= 3)
			{
				jump = 0;
			}

			currentCell.setGameObject(GameAssets.GetNullObject());
			obj.movePlayer(next);
		}

	}
}
