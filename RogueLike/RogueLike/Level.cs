using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class Level
	{
		public List<Room> Rooms { get; private set; }

		public Level()
		{
			Rooms = new List<Room>();
			Rooms.Add(new Room(new Rectangle(5, 8, 50, 30)));
			Rooms.Add(new Room(new Rectangle(60, 10, 20, 40)));
		}

		public void Draw(WorldCanvas canvas)
		{
			Rooms.ForEach(r => r.Draw(canvas));
		}
	}
}
