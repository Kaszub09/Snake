using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class Label:Control {
        public override event EventHandler Activated;

        public Label(string textID) {
            _textID = textID;
            UpdateFont(null, null);
        }

        public override void Update(GameTime gameTime, Command cmd) {
        }

    }
}
