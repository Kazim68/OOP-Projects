using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class VerticalBot : Bots, BotMovement
	{
		public VerticalBot(GameCell currentCell, Image sprite) : base(currentCell, sprite)
		{
			Direction = GameObjectDirection.Up;
		}


		public GameCell nextCell()
		{
			GameCell gameCell = base.CurrentCell;
			GameCell gameCell2 = base.CurrentCell.nextCell(Direction);
			if (gameCell2 == gameCell)
			{
				if (Direction == GameObjectDirection.Up)
				{
					Direction = GameObjectDirection.Down;
				}
				else if (Direction == GameObjectDirection.Down)
				{
					Direction = GameObjectDirection.Up;
				}
			}
			else
			{
				gameCell = gameCell2;
			}

			return gameCell;
		}

	}
}
