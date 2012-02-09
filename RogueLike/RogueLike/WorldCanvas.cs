using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace RogueLike
{
	public class WorldCanvas
	{
		public enum Tile
		{
			Wall,
			Player,
		}

		Dictionary<Tile, Texture2D> textures;
		SpriteBatch spriteBatch;

		public WorldCanvas(SpriteBatch spriteBatch)
		{
			this.textures = new Dictionary<Tile, Texture2D>();
			this.spriteBatch = spriteBatch;
			var graphicsDevice = spriteBatch.GraphicsDevice;

			var wall = new Texture2D(graphicsDevice, 10, 10);
			var colorData = new Color[wall.Width * wall.Height];
			for (var i = 0; i < colorData.Length; i++)
				colorData[i] = Color.SaddleBrown;
			wall.SetData<Color>(colorData);
			textures[Tile.Wall] = wall;

			var player = new Texture2D(graphicsDevice, 10, 10);
			for (var i = 0; i < colorData.Length; i++)
				colorData[i] = Color.White;
			player.SetData<Color>(colorData);
			textures[Tile.Player] = player;
		}

		public void Draw(Tile tile, int x, int y)
		{
			var texture = textures[tile];

			this.spriteBatch.Draw(textures[tile], new Vector2(x * texture.Width, y * texture.Height), Color.White);
		}
	}
}
