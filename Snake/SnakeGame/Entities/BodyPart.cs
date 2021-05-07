using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.Entites;

namespace Snake
{
    class BodyPart:Entity
    {
        public int BoardX { get; private set; }
        public int BoardY { get; private set; }
        private Field[,] _board;
        public Direction Dir { get; private set; }

        public BodyPart(ref Rectangle rectParent,Texture2D texture, ref Field[,] board,int x, int y,Direction dir)
        {
            _texture = texture;
            _rectParent = rectParent;
            _board = board;

            _rotation = 0f;
            _scale = new Vector2(((float)Settings.PixelPerPoint / _texture.Width), ((float)Settings.PixelPerPoint / _texture.Height));
            _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            MoveTo(x, y, dir);
        }

        public void MoveTo(int x, int y,Direction dir)
        {
            //logic
            BoardX = x;
            BoardY = y;
            _board[x, y] = Field.Snake;

            //texture shenaningas
            Dir = dir;
            switch (dir) {
                case Direction.Up:
                    _rotation = 0F;
                    break;
                case Direction.Down:
                    _rotation = MathHelper.Pi;
                    break;
                case Direction.Right:
                    _rotation = MathHelper.PiOver2;
                    break;
                case Direction.Left:
                    _rotation = 3*MathHelper.PiOver2;
                    break;
            }

            _position = new Vector2(_rectParent.X + x * Settings.PixelPerPoint, _rectParent.Y + y * Settings.PixelPerPoint);
            _position += _origin * _scale;
        }

        
    }
}
