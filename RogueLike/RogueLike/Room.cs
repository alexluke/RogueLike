using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
	public class Room : IDrawable
	{
		public Rectangle Area { get; set; }

		public Room(Rectangle area)
		{
			Area = area;
		}

		public void Draw(WorldCanvas canvas)
		{
			for (var h = 0; h < Area.Height; h++)
			{
				for (var w = 0; w < Area.Width; w++)
				{
					if (h == 0 || h == Area.Height - 1 || w == 0 || w == Area.Width - 1)
					{
						canvas.PlaceTile(WorldCanvas.Tile.Wall, w + Area.Left, h + Area.Top);
					}
				}
			}
		}
	}
}
