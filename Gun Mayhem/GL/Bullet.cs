using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class Bullet : GameObject
	{
		protected int damage = 5;
        public bool Active { get; set; }

        public Bullet(GameCell currentCell, Image image, GameObjectDirection direction) : base(GameObjectType.BULLET, image)
        {
            this.currentCell = currentCell;
            this.Active = true;
            base.Direction = direction;
        }

        public int Damage { get { return damage; } set {  damage = value; } }

        // get next cell
        public GameCell nextCell()
        {
            GameCell cell = base.currentCell;
            GameCell next = base.currentCell.nextCell(Direction);

            if (cell != next)
            {
                cell.setGameObject(GameAssets.GetNullObject());
                cell = next;
                cell.setGameObject(this);
            }

            return cell;
        }

        // move bullet
        public void MoveBullet(GameCell cell)
        {
            if (base.currentCell != null)
            {
                base.currentCell.setGameObject(GameAssets.GetNullObject());
            }
            base.currentCell = cell;
        }
    }
}
