using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class Grid
	{
		public GameCell[,] Cells { get; set; }
        public int Rows { get; set; }
        public int Col { get; set; }

        public Grid(int rows, int col, string path)
        {
            Rows = rows; Col = col;
            Cells = new GameCell[rows, col];
            loadMaze(path);
        }

		// get cell
		public GameCell getCell(int x, int y)
		{
			return Cells[y, x];
		}

		protected void loadMaze(string path)
        {
			if (File.Exists(path))
			{
				StreamReader file = new StreamReader(path);
				string line;
				int y = 0;
				while ((line = file.ReadLine()) != null)
				{
					for (int x = 0; x < line.Count(); x++)
					{
						GameCell cell = new GameCell(x, y, this);
						cell.setGameObject(new GameObject(GameObject.getAppropriateType(line[x]), GameAssets.getObjectImage(line[x])));
						Cells[y, x] = cell;
					}
					y++;
				}
				file.Close();
			}
		}

    }
}
