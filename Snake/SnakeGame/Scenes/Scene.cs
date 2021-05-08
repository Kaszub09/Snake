using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{


    interface Scene
    {
        public void UpdatePosition(Point windowEndpoint) { }
        public void Update(GameTime gameTime, Command cmd) { }
        public void Draw(SpriteBatch spriteBatch) { }

    }
}
