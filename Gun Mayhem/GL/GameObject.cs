using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gun_Mayhem.GL
{
	internal class GameObject
	{
		public char Character { get; set; }
		public GameObjectType Type { get; set; }

		public GameCell currentCell;
		public Image image;
		public GameObjectDirection Direction { get; set; }


		// constructors
        public GameObject(char character, GameObjectType type)
        {
            Character = character;
			Type = type;
        }

        public GameObject(GameObjectType type, Image image)
        {
            this.Type = type;
			this.Image = image;
        }

		public GameCell CurrentCell
		{
			get { return currentCell; }
			set
			{
				currentCell = value;
				currentCell.setGameObject(this);
			}
		}

		public Image Image
		{
			get
			{
				return image;
			}
			set
			{
				image = value;
			}
		}

		public static GameObjectType getAppropriateType(char character)
		{
			if (character == '#')
			{
				return GameObjectType.PLATFORM;
			}
			else if (character =='%')
			{
				return GameObjectType.SPIKE;
			}
			else if (character == '_')
			{
				return GameObjectType.TEMP;
			}
			else if (character == 'D')
			{
				return GameObjectType.DOOR;
			}
			return GameObjectType.NONE;
		}
	}
}
