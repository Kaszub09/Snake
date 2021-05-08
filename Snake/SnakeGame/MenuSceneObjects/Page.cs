using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class Page {

        private Rectangle _space;
        private List<ControlsRow> _controlRows;
        private int  _currentRow;

        public Page() : this(Rectangle.Empty) { }

        public Page(Rectangle space) : this(Rectangle.Empty, new List<ControlsRow>()) { }

        public Page(Rectangle space, List<ControlsRow> controlsRow) {
            _space = space;
            _controlRows = controlsRow;
            _currentRow = controlsRow.Count==0?-1:0;
            if (_currentRow > -1) {
                _controlRows[_currentRow].IsSelected = true;
            }
        }

        public void AddRow(ControlsRow row) {
            _controlRows.Add(row);
            UpdateRowsPosition();
            _currentRow = 0;
        }

        public void RemoveRow(ControlsRow row) {
            _controlRows.Remove(row);
            UpdateRowsPosition();
            _currentRow = _controlRows.Count==0?-1:0;
        }

        public void UpdatePosition(Rectangle space) {
            _space = space;
            UpdateRowsPosition();
        }

        private void UpdateRowsPosition() {
            if (_controlRows.Count > 0) {
                var rowHeight = _space.Height / _controlRows.Count;
                for (int i = 0; i < _controlRows.Count; i++) {
                    _controlRows[i].UpdatePosition(new Rectangle(_space.X, _space.Y + rowHeight * i, _space.Width, rowHeight));
                }
            }
            
        }


        public void Update(GameTime gameTime, Command cmd) {
            if ((cmd == Command.KeyUp || cmd == Command.KeyDown) && _currentRow > -1 ) {
                _controlRows[_currentRow].IsSelected = false;
                _currentRow += cmd == Command.KeyDown?1: (_controlRows.Count-1) ;
                _currentRow %= _controlRows.Count;
                _controlRows[_currentRow].IsSelected = true;
            }
            
            foreach (var item in _controlRows) {
                item.Update(gameTime, cmd);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(var item in _controlRows) {
                item.Draw(spriteBatch);
            }
        }
    }
}
