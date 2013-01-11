using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
	public class Room
	{
		public Rectangle Area { get; set; }

		public Room(Rectangle area)
		{
			Area = area;
		}

		public void Draw(WorldCanvas canvas)
		{
			WorldCanvas.Tile tile;
			for (var h = 0; h < Area.Height; h++)
			{
				for (var w = 0; w < Area.Width; w++)
				{
					if (h == 0 || h == Area.Height - 1 || w == 0 || w == Area.Width - 1)
						tile = WorldCanvas.Tile.Wall;
					else
						tile = WorldCanvas.Tile.Floor;
					canvas.PlaceTile(tile, w + Area.Left, h + Area.Top);
				}
			}
		}

		public bool Contains(Point point)
		{
			var roomInterior = this.Area;
			roomInterior.Inflate(-1, -1);
			return roomInterior.Contains(point);
		}
	}
}
