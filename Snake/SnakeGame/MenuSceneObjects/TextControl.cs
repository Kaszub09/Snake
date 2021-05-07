using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class TextControl:Control {

        public TextControl(string text, Vector2 centerPos,Color color,SpriteFont font) {
            _text = text;
            _color = color;
            _centerPos = centerPos;
            _font = font;
        }
        public void UpdateCenter(Vector2 centerPos) {
            _centerPos = centerPos;
        }
    }
}
