using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.AllAssets;

namespace Snake
{
    public static class Assets
    {
        public static Textures Textures;
        public static Fonts Fonts;
        public static Sounds Sounds;
        public static Colors Colors;

        static Assets() {

        }


        public static void Load(ContentManager content) {
            Textures = new Textures(content);
            Fonts = new Fonts(content);
            Sounds = new Sounds();
            Colors = new Colors();
        }

    }
}
