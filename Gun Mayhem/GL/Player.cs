using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class Player : GameObject
	{
        public int Health { get; set; } = 100;
        public int Score { get; set; }

        public Player(GameCell currentCell, Image sprite) : base (GameObjectType.PLAYER, sprite)
        {
            this.CurrentCell = currentCell;
        }

        public void movePlayer(GameCell Cell)
        {
            base.CurrentCell = Cell;
            base.CurrentCell.setGameObject(this);
        }
    }
}
