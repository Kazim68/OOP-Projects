using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class MeleeBot : Bots, BotMovement
	{
		// this bot follows the player and attacks a melee attack after 
		// a certain time span. It does not fire

		public GameObject player;

		public MeleeBot(GameCell currentCell, Image sprite, GameObject player) : base(currentCell, sprite)
		{
			Direction = GameObjectDirection.Right;
			this.player = player;
		}

		public GameCell nextCell()
		{
			setDirection();

			GameCell gameCell = base.CurrentCell;
			GameCell gameCell2 = base.CurrentCell.nextCell(Direction);

			if (gameCell2 == gameCell)
			{
				
			}
			else
			{
				if (gameCell2.Object.Type == GameObjectType.NONE)
				{
					gameCell = gameCell2;
				}
			}

			return gameCell;
		}

		public void setDirection()
		{
			if (this.currentCell.X >= player.currentCell.X)
			{
				Direction = GameObjectDirection.Left;
				Image = GameAssets.getPlayerImage('2', GameObjectDirection.Left);
			}
			else if (this.currentCell.X < player.currentCell.X)
			{
				Direction = GameObjectDirection.Right;
				Image = GameAssets.getPlayerImage('2', GameObjectDirection.Right);
			}
		}
	}
}
