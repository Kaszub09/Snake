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
        public static Game Game;

        public static void Initialise()
        {
            _currentScene = new MenuScene();
            _currentScene.UpdatePosition(Settings.WindowEnd);
        }


        public static void Update(GameTime gameTime, Command cmd)
        {
            _currentScene.Update(gameTime, cmd);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            _currentScene.Draw(spriteBatch);
        }

        public static void NewGameScene() {
            _currentScene = new SnakeGameScene();
            _currentScene.UpdatePosition(Settings.WindowEnd);
        }

        public static void NewMenuScene() {
            _currentScene = new MenuScene();
            _currentScene.UpdatePosition(Settings.WindowEnd);
        }

        public static void ExitGame() {
            Game.Exit();
        }
    }
}
