using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class Button : Control {
        public override event EventHandler Activated;

        public Button(string textID) {
            _textID = textID;
            UpdateFont(null, null);
        }

        public override void Update(GameTime gameTime, Command cmd) {
            if (cmd == Command.OK && IsSelected) {
                Activated?.Invoke(null, null);
            }
        }
    }
}
