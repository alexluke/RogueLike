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

		public void Draw(Rectangle viewableArea, float zoomLevel = 1.0f)
		{
			var gameArea = new Rectangle();
			var adjustedTileSize = (int)(tileSize * zoomLevel);

			if (adjustedTileSize <= 0)
				throw new ArgumentOutOfRangeException("zoomLevel");

			gameArea.Width = viewableArea.Width / adjustedTileSize;
			gameArea.Height = viewableArea.Height / adjustedTileSize;
			gameArea.X = viewableArea.X / adjustedTileSize;
			gameArea.Y = viewableArea.Y / adjustedTileSize;

			for (int x = gameArea.Left; x <= gameArea.Right; x++)
			{
				for (int y = gameArea.Top; y <= gameArea.Bottom; y++)
				{
					var key = x * maxCanvasWidth + y;
					if (canvas.ContainsKey(key))
					{
						var texture = textures[canvas[key]];
						var dest = new Rectangle();
						dest.X= x * adjustedTileSize - viewableArea.Left;
						dest.Y = y * adjustedTileSize - viewableArea.Top;
						dest.Width = adjustedTileSize;
						dest.Height = adjustedTileSize;

						this.spriteBatch.Draw(texture, dest, Color.White);
					}
				}
			}
		}
	}
}
