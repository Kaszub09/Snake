using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.Entites;

namespace Snake
{
    class Snake
    {
        private BodyPart _head;
        private List<BodyPart> _bodyParts;
        private BodyPart _tail;

        private Rectangle _rectParent;
        private TimeSpan _timeElapsedSinceLastMoved;
        private Field[,] _board;
        private Direction _nextDir,_lastDir;

        public bool IsMoving { private set; get; }
        public int EatenApples { private set; get; }
        public double Speed; //miliseconds per field
        public event EventHandler AppleEaten;
        
        public Snake(ref Rectangle rectParent, ref Field[,] board) {
            _rectParent = rectParent;
            _board = board;

            //Body parts
            _head = new BodyPart(ref _rectParent, Assets.Textures.SnakeHead, ref board,2,0, Direction.Right);
            _tail = new BodyPart(ref _rectParent, Assets.Textures.SnakeTail, ref board, 0, 0, Direction.Right);
            _bodyParts = new List<BodyPart>();
            _bodyParts.Add(new BodyPart(ref _rectParent, Assets.Textures.SnakeBody, ref board, 1, 0, Direction.Right));

            //Initial settings
            _timeElapsedSinceLastMoved = new TimeSpan(0);
            IsMoving = false;
            Speed = 100;
            _lastDir = Direction.Right;
            EatenApples = 0;
        }

        public void StartMoving() {
            IsMoving = true;
        }


        public void MoveSnake()
        {
            //Calculate next pos
            int nextX = _head.BoardX;
            int nextY = _head.BoardY;
            switch (_nextDir) {
                case Direction.Up:
                    nextY--;
                    break;
                case Direction.Down:
                    nextY++;
                    break;
                case Direction.Left:
                    nextX--;
                    break;
                case Direction.Right:
                    nextX++;
                    break;
            }
            _lastDir = _nextDir;

            if (CanMoveTo(nextX, nextY)) {
                if(_board[nextX, nextY] == Field.Fruit) {

                    //Insert body part where head is
                    var bodyPart = new BodyPart(ref _rectParent, Assets.Textures.SnakeBody, ref _board, _head.BoardX, _head.BoardY, _head.Dir);
                    _head.MoveTo(nextX, nextY, _nextDir);
                    bodyPart.MoveTo(bodyPart.BoardX, bodyPart.BoardY, bodyPart.Dir);
                    _bodyParts.Add(bodyPart);

                    EatenApples++;
                    AppleEaten?.Invoke(this, EventArgs.Empty);
                } else {
                    //Move tail to last part position
                    var lastPart = _bodyParts[0];
                    _board[_tail.BoardX, _tail.BoardY] = Field.Empty;
                    _tail.MoveTo(lastPart.BoardX, lastPart.BoardY, lastPart.Dir);

                    //move last part to head position
                    lastPart.MoveTo(_head.BoardX, _head.BoardY,_head.Dir);
                    _bodyParts.Insert(_bodyParts.Count, lastPart);
                    _bodyParts.RemoveAt(0);
                    
                    //move head to next position
                    _head.MoveTo(nextX, nextY, _nextDir);
                }
            } else {
                IsMoving = false;
            }
        }

        private bool CanMoveTo(int x, int y) {
            if (x < 0 || x > _board.GetUpperBound(0))
                return false;
            if (y < 0 || y > _board.GetUpperBound(1))
                return false;
            if (_board[x, y] == Field.Snake)
                return false;
            return true;
        }

        private void UpdateDirection(Command cmd) {
            switch (cmd) {
                case Command.KeyUp:
                    if(_lastDir != Direction.Down)
                        _nextDir = Direction.Up;
                    break;
                case Command.KeyDown:
                    if (_lastDir != Direction.Up)
                        _nextDir = Direction.Down;
                    break;
                case Command.KeyLeft:
                    if (_lastDir != Direction.Right)
                        _nextDir = Direction.Left;
                    break;
                case Command.KeyRight:
                    if (_lastDir != Direction.Left)
                        _nextDir = Direction.Right;
                    break;
            }
        }

        public void Update(GameTime gameTime, Command cmd) {
            if (IsMoving) {
                UpdateDirection(cmd);
                _timeElapsedSinceLastMoved =_timeElapsedSinceLastMoved.Add(gameTime.ElapsedGameTime);
                if (_timeElapsedSinceLastMoved.TotalMilliseconds > Speed) {
                    MoveSnake();
                    _timeElapsedSinceLastMoved = new TimeSpan();
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            foreach(var bodyPart in _bodyParts) {
                bodyPart.Draw(spriteBatch);
            }
            _tail.Draw(spriteBatch);
            _head.Draw(spriteBatch);
        }
    }
}
