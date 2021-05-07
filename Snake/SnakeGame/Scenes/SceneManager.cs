using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snake;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public static class SceneManager
    {
        private static Scene _currentScene;

        public static void Initialise()
        {
            _currentScene = new SnakeGameScene();
            //_currentScene = new MenuScene();
        }

        public static void Update(GameTime gameTime, Command cmd)
        {
            _currentScene.Update(gameTime, cmd);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            _currentScene.Draw(spriteBatch);
        }
    }
}
