using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class Player
	{
		protected int Speed;
		protected Point Location;
		protected Room CurrentRoom;
		private Vector2 internalMovement;

		public Player(Room startingRoom)
		{
			this.CurrentRoom = startingRoom;
			this.Location = startingRoom.Area.Center;
			this.Speed = 5;
			this.internalMovement = Vector2.Zero;
		}

		public void Move(Vector2 direction)
		{
			this.internalMovement += direction * this.Speed;
			if (this.internalMovement.Length() >= 1)
			{
				var previousLocation = this.Location;
				if (Math.Abs(direction.X) > Math.Abs(direction.Y))
					if (direction.X < 0)
						this.Location.X -= 1;
					else
						this.Location.X += 1;
				else
					if (direction.Y < 0)
						this.Location.Y += 1;
					else
						this.Location.Y -= 1;

				if (!CurrentRoom.Contains(this.Location))
					this.Location = previousLocation;

				this.internalMovement = Vector2.Zero;
			}
		}

		public void Draw(WorldCanvas canvas)
		{
			canvas.PlaceTile(WorldCanvas.Tile.Player, Location.X, Location.Y);
		}
	}
}
