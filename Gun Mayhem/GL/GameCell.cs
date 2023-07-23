using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gun_Mayhem.GL
{
	internal class GameCell
	{
		public int MarginX { get; set; } = 100;
		public int MarginY { get; set; } = 100;
		public int X {  get; set; }
		public int Y { get; set; }	
		public PictureBox Sprite { get; set; }
		public int Width { get; set; } = 15;
		public int Height { get; set; } = 15;
		public Grid Grid { get; set; }
		public GameObject Object { get; set; }

        public GameCell()
        {
            
        }

        public GameCell(int x, int y, Grid grid)
		{
			X = x;
			Y = y;
			makePB(MarginX, MarginY);
			Grid = grid;
		}

		public void setGameObject(GameObject Object)
		{
			this.Object = Object;
			Sprite.Image = Object.Image;
		}

		// returns next cell without any checks 
		public GameCell nextCellCheck(GameObjectDirection direction)
		{
			GameCell cell = new GameCell();

			if (direction == GameObjectDirection.Left)
			{
				cell = Grid.Cells[Y, X - 1];
			}
			else if (direction == GameObjectDirection.Right)
			{
				cell = Grid.Cells[Y, X + 1];
			}
			else if (direction == GameObjectDirection.Up)
			{
				cell = Grid.Cells[Y - 1, X];
			}
			else if (direction == GameObjectDirection.Down)
			{
				cell = Grid.Cells[Y + 1, X];
			}

			return cell;
		}

		// return next cell
		public GameCell nextCell(GameObjectDirection direction)
		{
			GameCell cell = new GameCell();

			if (direction == GameObjectDirection.Left)
			{
				cell = Grid.Cells[Y, X - 1];
			}
			else if (direction == GameObjectDirection.Right)
			{
				cell = Grid.Cells[Y, X + 1];
			}
			else if (direction == GameObjectDirection.Up)
			{
				cell = Grid.Cells[Y - 1, X];
			}
			else if (direction == GameObjectDirection.Down)
			{
				cell = Grid.Cells[Y + 1, X];
			}

			if (okToMove(cell))
			{
				return cell;
			}

			return this;
		}

		// is ok to move for player
		public bool okToMove(GameCell cell)
		{
			if (cell.Object.Type != GameObjectType.PLATFORM && cell.Object.Type != GameObjectType.SPIKE)
			{
				return true;
			}
			return false;
		}

		// make picture box and return it
		public PictureBox makePB(int x, int y)
		{
			PictureBox pb = new PictureBox();
			pb.Left = (X * Width) + x;
			pb.Top = (Y * Height) + y;
			pb.Size = new Size(Width, Height);
			pb.SizeMode = PictureBoxSizeMode.Zoom;
			pb.BackColor = Color.Transparent;

			Sprite = pb;
			return pb;
		}

	}
}
