using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RogueLike
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		WorldCanvas worldCanvas;

		Texture2D pixelTexture;

		Level level;
		Player player;
		Vector2 camera;
		float zoomLevel = 1.0f;
		GamePadState previousState;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.SynchronizeWithVerticalRetrace = false;
			this.IsFixedTimeStep = false;

			Content.RootDirectory = "Content";
			Components.Add(new FrameRateCounter(this));
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			worldCanvas = new WorldCanvas(spriteBatch);

			pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
			pixelTexture.SetData<Color>(new Color[] { Color.White });

			level = new Level();
			camera = new Vector2(0, 0);
			player = new Player(level.Rooms.First());
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			var padState = GamePad.GetState(PlayerIndex.One);
			// Allows the game to exit
			if (padState.Buttons.Back == ButtonState.Pressed)
				this.Exit();

			var frameTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			var leftStick = padState.ThumbSticks.Left;
			if (leftStick.Length() > 0)
			{
				leftStick.Normalize();

				var speed = 200;
				camera.X += leftStick.X * frameTime * speed;
				camera.Y -= leftStick.Y * frameTime * speed;
			}

			var rightStick = padState.ThumbSticks.Right;
			if (rightStick.Length() > 0)
			{
				rightStick.Normalize();

				rightStick.X *= frameTime;
				rightStick.Y *= frameTime;

				player.Move(rightStick);
			}


			if (padState.Triggers.Right == 1 && previousState.Triggers.Right != 1)
				zoomLevel += 0.1f;
			else if (padState.Triggers.Left == 1 && previousState.Triggers.Left != 1)
				zoomLevel -= 0.1f;
			if (zoomLevel < 0.1f)
				zoomLevel = 0.1f;

			previousState = padState;
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			level.Draw(worldCanvas);
			player.Draw(worldCanvas);
			GraphicsDevice.Clear(Color.CornflowerBlue);

			var viewport = new Rectangle();
			viewport.Width = graphics.PreferredBackBufferWidth;
			viewport.Height = graphics.PreferredBackBufferHeight;
			viewport.X = (int)(camera.X - viewport.Width / 2);
			viewport.Y = (int)(camera.Y - viewport.Width / 2);

			spriteBatch.Begin();
			worldCanvas.Draw(viewport, zoomLevel);
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
