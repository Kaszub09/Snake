using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Snake;


namespace Snake
{
    public class Snek : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Command _lastSendCommand;

        public Snek()
        {
            Subtitles.LoadAllLanguages();
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Settings.WindowEnd = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
        }

        protected override void Initialize()
        {
            base.Initialize();
            SceneManager.Initialise();
            SceneManager.Game = this;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

             Textures.Load(Content);
            Fonts.Load(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            Command cmd;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                cmd = Command.KeyUp;
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                cmd = Command.KeyDown;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
                cmd = Command.KeyLeft;
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                cmd = Command.KeyRight;
            else if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                cmd = Command.OK;
            else if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                cmd = Command.Cancel;
            else
                cmd = Command.None;

            SceneManager.Update(gameTime,cmd);
            
            //base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear( Colors.GlobalBG);

            _spriteBatch.Begin(samplerState:SamplerState.PointClamp);
            SceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            //base.Draw(gameTime);
        }
    }
}
