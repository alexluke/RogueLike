using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class Corridor
	{
		public Vector2 Start { get; set; }
		public Vector2 End { get; set; }

		public Corridor(Vector2 start, Vector2 end)
		{
			Start = start;
			End = end;
		}

		public void Draw(WorldCanvas canvas)
		{
			if (Start.X == End.X)
			{
				// vertical line
				var x = (int)Start.X;
				for (var y = (int)Start.Y; y < (int)End.Y; y++)
				{
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x - 1, y);
					canvas.PlaceTile(WorldCanvas.Tile.Floor, x, y);
					canvas.PlaceTile(WorldCanvas.Tile.Wall, x + 1, y);
				}
			}
			else if (Start.Y == End.Y)
			{
				// horrizontal line
				var y = (int)Start.Y;
				for (var x = (int)Start.X; x < (int)End.X; x++)
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
