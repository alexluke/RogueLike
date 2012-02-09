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
	public class FrameRateCounter : DrawableGameComponent
	{
		SpriteBatch spriteBatch;
		SpriteFont font;

		int frameRate = 0;
		int frameCounter = 0;
		TimeSpan elapsedTime = TimeSpan.Zero;

		public FrameRateCounter(Game game)
			: base(game)
		{
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			font = Game.Content.Load<SpriteFont>("FpsFont");
		}

		public override void Update(GameTime gameTime)
		{
			elapsedTime += gameTime.ElapsedGameTime;

			if (elapsedTime > TimeSpan.FromSeconds(1))
			{
				elapsedTime -= TimeSpan.FromSeconds(1);
				frameRate = frameCounter;
				frameCounter = 0;
			}
		}

		public override void Draw(GameTime gameTime)
		{
			frameCounter++;

			string fps = String.Format("fps: {0}", frameRate);

			spriteBatch.Begin();

			spriteBatch.DrawString(font, fps, new Vector2(33, 33), Color.Black);
			spriteBatch.DrawString(font, fps, new Vector2(32, 32), Color.White);

			spriteBatch.End();
		}
	}
}
