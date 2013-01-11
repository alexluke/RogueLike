using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class Corridor
	{
		public Point Start { get; set; }
		public Point End { get; set; }

		public Corridor(Point start, Point end)
		{
			Start = start;
			End = end;
		}

		public void Draw(WorldCanvas canvas)
		{
			if (Start.X == End.X)
			{
				// vertical line
				var x = Start.X;
				for (var y = Start.Y; y < End.Y; y++)
				{
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x - 1, y);
					canvas.PlaceTile(WorldCanvas.Tile.Floor, x, y);
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x + 1, y);
				}
			}
			else if (Start.Y == End.Y)
			{
				// horrizontal line
				var y = Start.Y;
				for (var x = Start.X; x < End.X; x++)
				{
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x, y - 1);
					canvas.PlaceTile(WorldCanvas.Tile.Floor, x, y);
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x, y + 1);
				}
			}
			else
			{
				throw new ArgumentOutOfRangeException("Corridor not in a straight line.");
			}
		}
	}
}
