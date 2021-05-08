using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    abstract class  Control {

        public Color Color;
        public bool IsSelected;

        protected string _textID;
        protected string _text;
        protected Vector2 _center;
        protected SpriteFont _font;

        public abstract event EventHandler Activated;

        public Control() {
            Settings.FontChanged += UpdateFont;
            Settings.LanguageChanged += UpdateText;
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            var origin = _font.MeasureString(_text) /2;
            spriteBatch.DrawString(_font, _text, _center, Color,0F, origin, IsSelected?1.5F:1F, SpriteEffects.None,1);
        }
        public virtual void UpdatePosition(Rectangle position) {
            _center = position.Center.ToVector2();
        }

        public abstract void Update(GameTime gameTime, Command cmd);

        protected void UpdateText(object sender, EventArgs e) {
            var text = Subtitles.Text[_textID].ToCharArray();
            for(int i = 0; i < text.Length; i++) {
                if (!_font.Characters.Contains(text[i]))
                    text[i] = ' ';
            }
            _text = new String(text);
        }

        protected void UpdateFont(object sender, EventArgs e) {
            //////////////////TO DO
            _font = Fonts.Statistics_24;

            UpdateText(sender, e);
        }

        ~Control() {
            Settings.FontChanged -= UpdateFont;
            Settings.LanguageChanged -= UpdateText;
        }
    }
}
