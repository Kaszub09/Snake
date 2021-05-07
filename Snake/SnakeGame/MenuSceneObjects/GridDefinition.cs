using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.SnakeGame.MenuSceneObjects {
    class GridDefinition {
        Rectangle _rectParent;
        List<float> Columns;
        List<float> Rows;
        float _totalWidth, _totalHeight;
        Dictionary<Object, Tuple<int,int,Vector2>> _centerPoints;


        public GridDefinition(ref Rectangle rectParent) {
            _rectParent = rectParent;
            Columns = new List<float>();
            Rows = new List<float>();
            _centerPoints = new Dictionary<object, Tuple<int, int, Vector2>>();
            _totalHeight = 0;
            _totalWidth = 0;
        }

        public void AddColumn(float width) {
            Columns.Add(width);
            _totalWidth += width;
        }

        public void AddRow(float height) {
            Rows.Add(height);
            _totalHeight += height;
        }

        public void Add(Object obj,int row, int col) {
            _centerPoints[obj] = new Tuple<int, int, Vector2>(row, col, Vector2.Zero);
        }

        public void UpdateAllObjectsPosition() {
            var pixelPerColPoint= _rectParent.Width / _totalWidth;
            var pixelPerRowPoint = _rectParent.Height / _totalHeight;

            object[] keys = new object[_centerPoints.Keys.Count];
            _centerPoints.Keys.CopyTo(keys ,0);
            foreach(var key in keys) { 
                var item = _centerPoints[key];
                try {
                    
                    int i = 0;
                    float sum = 0;
                    while(i< item.Item2) {
                        sum += Columns[i];
                        i++;
                    }
                    sum += Columns[i] / 2;
                    var X = _rectParent.X + sum * pixelPerColPoint;

                    i = 0;
                    sum = 0;
                    while (i < item.Item1) {
                        sum += Rows[i];
                        i++;
                    }
                    sum += Rows[i] / 2;
                    var Y = _rectParent.Y + sum * pixelPerRowPoint;

                    _centerPoints[key] = new Tuple<int, int, Vector2>(item.Item1,item.Item2,new Vector2(X, Y));
                } catch (Exception e) {
                    _centerPoints[key] = new Tuple<int, int, Vector2>(item.Item1, item.Item2, Vector2.Zero);
                }
            }
        }

        public Vector2 GetCenterPoint(Object obj) {
            return _centerPoints[obj].Item3;
        }

    }
}
