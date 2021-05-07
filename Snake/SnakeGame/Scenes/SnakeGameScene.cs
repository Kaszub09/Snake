using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.GameSceneObjects;

namespace Snake
{


    class SnakeGameScene : Scene
    {
        Field[,] _board;
        GameState _gameState;

        Rectangle _rectSceneBg;
        Rectangle _rectBoard;
        Rectangle _rectStatus;
        Rectangle _rectGameScreen;

        Fruit _fruit;
        Snake _snake;
        StatisticsInfo _stats;

        public SnakeGameScene()
        {
            _rectSceneBg = new Rectangle(new Point(0, 0), Settings.WindowEnd);

            var borderSize = Settings.PixelPerPoint / 8 > 0 ? Settings.PixelPerPoint / 8 : 1;
            var statisticsWidth = Settings.FontSize == 12 ?180 : 360;

            //Game screen size and rectangle
            var size = new Point(Settings.BoardX * Settings.PixelPerPoint + statisticsWidth + borderSize * 3, Settings.BoardY * Settings.PixelPerPoint + borderSize * 2);
            _rectGameScreen = new Rectangle((Settings.WindowEnd.X - size.X) / 2, (Settings.WindowEnd.Y - size.Y) / 2, size.X, size.Y);

            //Board size and rectangle
            size = new Point(Settings.BoardX * Settings.PixelPerPoint, Settings.BoardY * Settings.PixelPerPoint);
            _rectBoard = new Rectangle(_rectGameScreen.X + borderSize, _rectGameScreen.Y + borderSize, size.X, size.Y);

            //Statistics size and rectangle
            size = new Point(statisticsWidth, Settings.BoardY * Settings.PixelPerPoint);
            _rectStatus = new Rectangle(_rectBoard.X + _rectBoard.Width + borderSize, _rectBoard.Y, size.X, size.Y);

            _stats = new StatisticsInfo(ref _rectStatus);
            StartNewGame();
        }

        private void StartNewGame() {
            _board = new Field[Settings.BoardX, Settings.BoardY];
            _gameState = GameState.Prepared;
           
            _snake = new Snake(ref _rectBoard, ref _board);
            _fruit = new Fruit(ref _rectBoard, ref _board);

            _snake.AppleEaten += (sender, e) => _fruit.ChangePosition();  
        }


        public void Update(GameTime gameTime, Command cmd) {

            if(_gameState == GameState.Running) {
                _snake.Update(gameTime, cmd);
                if (_snake.IsMoving == false)
                    _gameState = GameState.Finished;
            } else if (_gameState == GameState.Prepared) {
                if (cmd != Command.None) {
                    _gameState = GameState.Running;
                    _snake.StartMoving();
                }
            } else {
                if (cmd != Command.None) {
                    StartNewGame();
                }
            }

            _stats.Update(gameTime, _gameState,_snake.EatenApples);
        }

        public void Draw(SpriteBatch spriteBatch) {
            
            spriteBatch.Draw(Assets.Textures.Pixel, _rectSceneBg,Assets.Colors.GlobalBG);
            spriteBatch.Draw(Assets.Textures.Pixel, _rectGameScreen, Assets.Colors.GameScene.Border);
            spriteBatch.Draw(Assets.Textures.Pixel, _rectBoard, Assets.Colors.GameScene.FieldBg);
            spriteBatch.Draw(Assets.Textures.Pixel, _rectStatus, Assets.Colors.GameScene.StatisticsBg);

            _fruit.Draw(spriteBatch);
            _snake.Draw(spriteBatch);
            _stats.Draw(spriteBatch);

        }

    }
}
