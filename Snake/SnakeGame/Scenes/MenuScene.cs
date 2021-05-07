using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.SnakeGame.MenuSceneObjects;
using Microsoft.Xna.Framework.Graphics;

namespace Snake {
    class MenuScene:Scene {

        Page _mainMenu;
        Page _currentPage;
        Rectangle _rectSceneBg;
        Rectangle _rectPage;


        public MenuScene() {
            _rectSceneBg = new Rectangle(new Point(0, 0), Settings.WindowEnd);
            _rectPage = new Rectangle(new Point(0, 0), Settings.WindowEnd);

            CreatePages();

            _currentPage = _mainMenu;

        }

        private void CreatePages() {
            _mainMenu = new Page(ref _rectPage);
            _mainMenu.SetGrid(5,3);
            _mainMenu.AddControl(new TextControl("Start", Vector2.Zero, Assets.Colors.MenuScene.Font, Assets.Fonts.Statistics_24),1,1);
            _mainMenu.AddControl(new TextControl("Settings", Vector2.Zero, Assets.Colors.MenuScene.Font, Assets.Fonts.Statistics_24), 2, 1);
            _mainMenu.AddControl(new TextControl("Exit", Vector2.Zero, Assets.Colors.MenuScene.Font, Assets.Fonts.Statistics_24), 3, 1);
        }

        public void Update(GameTime gameTime, Command cmd) {
            


        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Assets.Textures.Pixel, _rectSceneBg, Assets.Colors.GlobalBG);
            _currentPage.Draw(spriteBatch);
        }
    }
}
