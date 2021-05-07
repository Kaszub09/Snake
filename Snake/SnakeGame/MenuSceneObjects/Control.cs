using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    abstract class  Control {

        protected Color _color = Color.White;
        protected string _text;
        protected Vector2  _centerPos;
        public bool IsSelected;
        protected SpriteFont _font;

        public virtual void Draw(SpriteBatch spriteBatch) {
            var size = _font.MeasureString(_text);
            spriteBatch.DrawString(_font,_text, new Vector2(_centerPos.X-size.X/2, _centerPos.Y - size.Y / 2), _color);
        }
        public void UpdateCenter(Vector2 centerPos) {
            _centerPos = centerPos;
        }
    }
}
