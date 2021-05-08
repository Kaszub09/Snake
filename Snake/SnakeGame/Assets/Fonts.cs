using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    public static class Fonts {
        static public SpriteFont Statistics_12 { get; private set; }
        static public SpriteFont Statistics_24 { get; private set; }

        static public void Load(ContentManager content) {
            Statistics_12 = content.Load<SpriteFont>("Fonts/Statistics_12");
            Statistics_24 = content.Load<SpriteFont>("Fonts/Statistics_24");

        }
    }
}
