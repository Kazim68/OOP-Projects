using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class CollisionDetection
	{
		// detect bullet collision
		public static bool detectBulletCollision(Bullet bullet)
		{
			if (bullet.currentCell.nextCell(bullet.Direction).Object.Type != GameObjectType.NONE)
			{
				return true;
			}
			return false;
		}

		// fall detector
		public static bool detectDeath(Player player)
		{
			if (player.currentCell.nextCellCheck(GameObjectDirection.Down).Object.Type == GameObjectType.SPIKE)
			{
				return true;
			}
			return false;
		}

		// detect collision of bullet with player
		public static bool detectBulletCollisionWithPlayer(Bullet bullet, Player player)
		{
			if (bullet.currentCell.nextCell(bullet.Direction).Object.Type == GameObjectType.PLAYER && bullet.currentCell.nextCell(bullet.Direction) == player.currentCell)
			{
				return true;
			}
			return false;
		}

		// detect collision of bullet with bot
		public static bool detectBulletCollisionWithBot(Bullet bullet, Bots bot)
		{
			if (bullet.currentCell.nextCell(bullet.Direction).Object.Type == GameObjectType.BOT && bullet.currentCell.nextCell(bullet.Direction) == bot.currentCell)
			{
				return true;
			}
			return false;
		}

		// detect collision of melee bot with player
		public static bool detectMeleeBotWithPlayer(Bots bot, GameObject player)
		{
			if (bot.currentCell.nextCell(bot.Direction).Object.Type == GameObjectType.PLAYER && bot.currentCell.nextCell(bot.Direction) == player.currentCell)
			{
				return true;
			}
			return false;
		}

		// detect collision with platform of object
		public static bool isTouchingPlatform(GameObject obj, GameObjectDirection direction)
		{
			if (obj.currentCell.nextCell(direction) == obj.currentCell)
			{
				return true;
			}
			return false;
		}

		// detect player collision with door
		public static bool atDoor(GameObject obj)
		{
			if (obj.currentCell.nextCell(GameObjectDirection.Down).Object.Type == GameObjectType.DOOR)
			{
				return true;
			}
			else if (obj.currentCell.nextCell(GameObjectDirection.Up).Object.Type == GameObjectType.DOOR)
			{
				return true;
			}
			else if (obj.currentCell.nextCell(GameObjectDirection.Right).Object.Type == GameObjectType.DOOR)
			{
				return true;
			}
			else if (obj.currentCell.nextCell(GameObjectDirection.Left).Object.Type == GameObjectType.DOOR)
			{
				return true;
			}
			return false;
		}
	}
}
