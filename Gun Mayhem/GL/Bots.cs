using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal abstract class Bots : GameObject
	{
		public int Health { get; set; } = 100;

		public Bots(GameCell currentCell, Image sprite) : base(GameObjectType.BOT, sprite)
		{
			this.CurrentCell = currentCell;
		}

		public bool alive()
		{
			if (Health > 0) { return true; }
			return false;
		}

		public void moveBot(GameCell Cell)
		{
			if (base.CurrentCell != null)
			{
				base.CurrentCell.setGameObject(GameAssets.GetNullObject());
			}

			base.CurrentCell = Cell;
			base.CurrentCell.setGameObject(this);
		}
	}
}
