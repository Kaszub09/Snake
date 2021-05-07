using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.AllAssets {
    public class Fonts {
        public SpriteFont Statistics_12 { get; private set; }
        public SpriteFont Statistics_24 { get; private set; }

        public Fonts(ContentManager content) {
            Load(content);
        }

        public void Load(ContentManager content) {
            Statistics_12 = content.Load<SpriteFont>("Fonts/Statistics_12");
            Statistics_24 = content.Load<SpriteFont>("Fonts/Statistics_24");

        }
    }
}
