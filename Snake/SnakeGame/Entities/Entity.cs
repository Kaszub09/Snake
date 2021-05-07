using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.Entites
{
    abstract class Entity
    {
        protected Texture2D _texture;
        protected Rectangle _rectParent;
        protected Color _color = Color.White;

        protected float _rotation;
        protected Vector2  _origin, _scale, _position;
        
        public bool IsExpired = false;
       
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture,_position,null,Color.White,_rotation,_origin,_scale, SpriteEffects.None, 1);
        }   

    }
}
