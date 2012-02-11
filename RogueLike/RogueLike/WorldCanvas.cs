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
			Floor,
		}

		Dictionary<Tile, Texture2D> textures;
		SpriteBatch spriteBatch;
		Dictionary<int, Tile> canvas;
		int maxCanvasWidth = 46000;
		int tileSize = 10;

		public WorldCanvas(SpriteBatch spriteBatch)
		{
			this.textures = new Dictionary<Tile, Texture2D>();
			this.spriteBatch = spriteBatch;
			this.canvas = new Dictionary<int, Tile>();
			var graphicsDevice = spriteBatch.GraphicsDevice;

			var wall = new Texture2D(graphicsDevice, tileSize, tileSize);
			var colorData = new Color[wall.Width * wall.Height];
			for (var i = 0; i < colorData.Length; i++)
				colorData[i] = Color.SaddleBrown;
			wall.SetData<Color>(colorData);
			textures[Tile.Wall] = wall;

			var player = new Texture2D(graphicsDevice, tileSize, tileSize);
			for (var i = 0; i < colorData.Length; i++)
				colorData[i] = Color.White;
			player.SetData<Color>(colorData);
			textures[Tile.Player] = player;

			var floor = new Texture2D(graphicsDevice, tileSize, tileSize);
			for (var i = 0; i < colorData.Length; i++)
				colorData[i] = Color.Black;
			floor.SetData<Color>(colorData);
			textures[Tile.Floor] = floor;
		}

		public void PlaceTile(Tile tile, int x, int y)
		{
			canvas[x * maxCanvasWidth + y] = tile;
		}

		public void Draw(Rectangle viewableArea)
		{
			var gameArea = new Rectangle();

			gameArea.Width = viewableArea.Width / tileSize;
			gameArea.Height = viewableArea.Height / tileSize;
			gameArea.X = viewableArea.X / tileSize;
			gameArea.Y = viewableArea.Y / tileSize;

			for (int x = gameArea.Left; x <= gameArea.Right; x++)
			{
				for (int y = gameArea.Top; y <= gameArea.Bottom; y++)
				{
					var key = x * maxCanvasWidth + y;
					if (canvas.ContainsKey(key))
					{
						var texture = textures[canvas[key]];
						var spot = new Vector2(x * tileSize - viewableArea.Left, y * tileSize - viewableArea.Top);
						this.spriteBatch.Draw(texture, spot, Color.White);
					}
				}
			}
		}
	}
}
