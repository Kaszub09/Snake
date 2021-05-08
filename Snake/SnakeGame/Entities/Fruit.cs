using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.Entites;

namespace Snake
{
    class Fruit : Entity
    {
        public int _boardX { get; private set; }
        public int _boardY { get; private set; }
        private Field[,] _board;
        
        public Fruit(ref Rectangle rectParent,ref Field[,] board)
        {
            _texture = Textures.Fruit;
            _rectParent = rectParent;
            _board = board;

            _rotation = 0f;
            _scale = new Vector2(((float)Settings.PixelPerPoint / _texture.Width), ((float)Settings.PixelPerPoint / _texture.Height));
            _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            ChangePosition();
        }

        public void ChangePosition()
        {
            int x, y;
            do
            {
                x = Settings.Rand.Next(0, _board.GetUpperBound(0));
                y = Settings.Rand.Next(0, _board.GetUpperBound(1));
            } while (_board[x,y]!=Field.Empty);

            _boardX = x;
            _boardY = y;
            _board[x, y] = Field.Fruit;

            _position = new Vector2(_rectParent.X+ x * Settings.PixelPerPoint, _rectParent.Y + y * Settings.PixelPerPoint);
            _position += _origin* _scale;
        }

    }
}
