using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RogueLike
{
	interface IDrawable
	{
		void Draw(WorldCanvas canvas);
	}
}
