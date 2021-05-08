using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    static public class Textures {

        static public Texture2D SnakeHead { get; private set; }
        static public Texture2D SnakeBody { get; private set; }
        static public Texture2D SnakeTail { get; private set; }
        static public Texture2D Fruit { get; private set; }
        static public Texture2D Pixel { get; private set; }


        static public void Load(ContentManager content) {
            SnakeHead = content.Load<Texture2D>("Textures/Snake/Head");
            SnakeBody = content.Load<Texture2D>("Textures/Snake/Body");
            SnakeTail = content.Load<Texture2D>("Textures/Snake/Tail");
            Fruit = content.Load<Texture2D>("Textures/Fruit");

            Pixel = new Texture2D(SnakeHead.GraphicsDevice, 1, 1);
            Pixel.SetData(new[] { Color.White });
        }
    }
}
