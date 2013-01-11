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
		public List<Corridor> Corridors { get; private set; }

		public Level()
		{
			Rooms = new List<Room>();
			Corridors = new List<Corridor>();
			Rooms.Add(new Room(new Rectangle(5, 8, 50, 30)));
			Rooms.Add(new Room(new Rectangle(60, 10, 20, 40)));
			Rooms.Add(new Room(new Rectangle(2, 60, 20, 10)));

			Corridors.Add(new Corridor(new Point(54, 20), new Point(61, 20)));
			Corridors.Add(new Corridor(new Point(12, 37), new Point(12, 61)));
		}

		public void Draw(WorldCanvas canvas)
		{
			Rooms.ForEach(r => r.Draw(canvas));
			Corridors.ForEach(c => c.Draw(canvas));
		}
	}
}
