using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class Page {
        GridDefinition _grid;
        private Rectangle _rectParent;
        private List<Control> _allControls;


        public Page(ref Rectangle rectParent) {
            _rectParent = rectParent;
            _allControls = new List<Control>();
        }

        public void SetGrid(int numberOfRows, int numberOfCols) {
            _grid = new GridDefinition(ref _rectParent);
            while (numberOfRows > 0) {
                _grid.AddRow(1);
                numberOfRows--;
            }
            while (numberOfCols > 0) {
                _grid.AddColumn(1);
                numberOfCols--;
            }
        }


        public void AddControl(Control control, int row,int col) {
            _grid.Add(control, row, col);
            _grid.UpdateAllObjectsPosition();
            control.UpdateCenter(_grid.GetCenterPoint(control));
            _allControls.Add(control);
        }


        public void Update(GameTime gameTime, Command cmd) {


        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(var item in _allControls) {
                item.Draw(spriteBatch);
            }
        }
    }
}
