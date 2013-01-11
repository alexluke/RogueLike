using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class Player
	{
		protected Point Location { get; set; }

		public Player(Room startingRoom)
		{
			this.Location = startingRoom.Area.Center;
		}

		public void Draw(WorldCanvas canvas)
		{
			canvas.PlaceTile(WorldCanvas.Tile.Player, Location.X, Location.Y);
		}
	}
}
