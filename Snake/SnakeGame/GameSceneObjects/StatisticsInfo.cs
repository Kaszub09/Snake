using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace Snake.GameSceneObjects {
    class StatisticsInfo {

        public bool ShowFrametime;

        private GameState _gameState;
        private Rectangle _rectParent;
        private SpriteFont _font;
        private Vector2 _position;

        private TimeSpan _maxFrameTime;
        private TimeSpan _timeElapsed;
        private int _eatenApples;
        private StringBuilder _displayText;

        public StatisticsInfo(ref Rectangle rectParent) {
            _rectParent = rectParent;
            _font = Settings.FontSize==12?  Fonts.Statistics_12 :  Fonts.Statistics_24;
            ShowFrametime = true;
            _maxFrameTime = new TimeSpan(0);
            _displayText = new StringBuilder() ;
        }


        public void Update(GameTime gameTime, GameState gameState, int eatenApples) {
            _position = new Vector2(_rectParent.X, _rectParent.Y);

            _gameState = gameState;
            _eatenApples = eatenApples;
            if (gameTime.ElapsedGameTime > _maxFrameTime)
                _maxFrameTime = gameTime.ElapsedGameTime;

            if (_gameState == GameState.Running) {
                _timeElapsed = _timeElapsed.Add(gameTime.ElapsedGameTime);
            } else if (_gameState == GameState.Prepared) {
                _timeElapsed = new TimeSpan(0);
                eatenApples = 0;
            }

            _displayText = new StringBuilder();
            _displayText.AppendLine("Elapsed time: " + _timeElapsed.ToString(@"mm\:ss\:ff"));
            _displayText.AppendLine($"Eaten apples: {_eatenApples}");
            
            if (ShowFrametime) {
                _displayText.AppendLine();
                _displayText.Append("Updated ago: ");
                _displayText.Append(gameTime.ElapsedGameTime.TotalMilliseconds.ToString());
                _displayText.AppendLine(" ms");
                _displayText.Append("Max update time: ");
                _displayText.Append(_maxFrameTime.TotalMilliseconds.ToString());
                _displayText.AppendLine(" ms");
                _displayText.AppendLine();
            }

            _displayText.AppendLine(_gameState == GameState.Finished ? "Game over" : "");
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(_font, _displayText, _position,  Colors.GameScene.StatisticsFont);
        }

    }
}
