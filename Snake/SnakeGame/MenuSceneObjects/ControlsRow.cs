using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Snake.SnakeGame.MenuSceneObjects {
    class ControlsRow {
        private Rectangle _space;
        private List<Control> _controls;
        private bool _isSelected;
        public bool IsSelected{
            get { return _isSelected; } 
            set { _isSelected = value;
                foreach(var control in _controls) {
                    control.IsSelected = _isSelected;
                }
            } 
        }
        private int _currentControl;

        public ControlsRow() : this(Rectangle.Empty) { }

        public ControlsRow(Rectangle space) : this(Rectangle.Empty, new List<Control>()) {}

        public ControlsRow(Rectangle space,List<Control> controls) {
            _space = space;
            _controls = controls;
            _currentControl = _controls.Count == 0 ? -1 : 0;
        }

        public void AddControl(Control control) {
            _controls.Add(control);
            UpdateControlsPosition();
            _currentControl = _controls.Count == 0 ? -1 : 0;
        }

        public void RemoveControl(Control control) {
            _controls.Remove(control);
            UpdateControlsPosition();
            _currentControl = _controls.Count == 0 ? -1 : 0;
        }

        public void UpdatePosition(Rectangle space) {
            _space = space;
            UpdateControlsPosition();
        }

        private void UpdateControlsPosition() {
            if (_controls.Count > 0) {
                var controlWidth = _space.Width / _controls.Count;
                for (int i = 0; i < _controls.Count; i++) {
                    _controls[i].UpdatePosition(new Rectangle(_space.X + controlWidth * i, _space.Y, controlWidth, _space.Height));
                }
            }
            
        }


        public void Update(GameTime gameTime, Command cmd) {
            if (IsSelected&& (cmd == Command.KeyLeft || cmd == Command.KeyRight) && _currentControl > -1) {
                _controls[_currentControl].IsSelected = false;
                _currentControl += cmd == Command.KeyRight ? 1 : (_controls.Count - 1);
                _currentControl %= _controls.Count;
                _controls[_currentControl].IsSelected = true;
            }

            foreach (var item in _controls) {
                item.Update(gameTime, cmd);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var item in _controls) {
                item.Draw(spriteBatch);
            }
        }
    }
}