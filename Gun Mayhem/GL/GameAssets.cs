using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class GameAssets
	{
		// bullet sprite image
		public static Image getBulletImage()
		{
			return Properties.Resources.Bullet_horizontal1;
		}

		// player 1 sprite image right side
		public static Image getPlayerRightImage()
		{
			return Properties.Resources.Green_Right1;
		}

		// player 1 sprite image left side
		public static Image getPlayerLeftImage()
		{
			return Properties.Resources.Green_Left1;
		}

		// player 2 sprite image right side
		public static Image getSecondPlayerRightImage()
		{
			return Properties.Resources.Red_Right1;
		}

		// player 2 sprite image left side

		public static Image getSecondPlayerLeftImage()
		{
			return Properties.Resources.Red_Left1;
		}

		// get sprite image based on character
		public static Image getObjectImage(char character)
		{
			if (character == '#' || character == '_' || character == '-')
			{
				return Properties.Resources.Tile;
			}
			else if (character == '%')
			{
				return Properties.Resources.Spikes;
			}
			else if (character == 'D')
			{
				return Properties.Resources.Door;
			}
			else if (character == '1')
			{
				return Properties.Resources.Green_Right1;
			}
			else if (character == '2')
			{
				return Properties.Resources.Red_Left1;
			}
			return null;
		}

		// returns a player image based on direction and player number
		public static Image getPlayerImage(char number, GameObjectDirection direction)
		{
			if (number == '1')
			{
				if (direction == GameObjectDirection.Left)
				{
					return getPlayerLeftImage();
				}
				return getPlayerRightImage();
			}
			else if (direction == GameObjectDirection.Left)
			{
				return getSecondPlayerLeftImage();
			}
			return getSecondPlayerRightImage();
		}

		// returns a null object 
		public static GameObject GetNullObject()
		{
			return new GameObject(GameObjectType.NONE, null);
		}
	}
}
