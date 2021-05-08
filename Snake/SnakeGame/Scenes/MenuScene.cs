using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Snake.SnakeGame.MenuSceneObjects;
using Microsoft.Xna.Framework.Graphics;

namespace Snake {
    class MenuScene:Scene {
        Command _lastSendCommand;
        Page _mainMenu;
        Page _settings;
        Page _currentPage;
        Rectangle _wSize;

        public MenuScene() : this(Rectangle.Empty) { }

        public MenuScene(Rectangle WindowSize) {
            _wSize = WindowSize;
            CreateAllPages();
            _currentPage = _mainMenu;
            _lastSendCommand = Command.None;
        }

        private void CreateAllPages() {

            //Main menu, 3 buttons
            var menuButton = new Button("MENU_new_game") { Color = Colors.MenuScene.Font };
            menuButton.Activated += (sender, e) => SceneManager.NewGameScene();
            var settingsButton = new Button("MENU_options") { Color = Colors.MenuScene.Font };
            settingsButton.Activated += (sender, e) => _currentPage=_settings;
            var exitButton = new Button("MENU_exit") { Color = Colors.MenuScene.Font };
            exitButton.Activated += (sender, e) => SceneManager.ExitGame(); ;

            _mainMenu = new Page(Rectangle.Empty, new List<ControlsRow>() {
                new ControlsRow(Rectangle.Empty, new List<Control>() { menuButton}),
                new ControlsRow(Rectangle.Empty, new List<Control>() {settingsButton }),
                new ControlsRow(Rectangle.Empty, new List<Control>() { exitButton })
            });


            var okButton = new Button("MENU_apply") { Color = Colors.MenuScene.Font };
            var backButton = new Button("MENU_back") { Color = Colors.MenuScene.Font };
            backButton.Activated += (sender, e) => _currentPage = _mainMenu;

            _settings = new Page(Rectangle.Empty, new List<ControlsRow>() {
                new ControlsRow(Rectangle.Empty, new List<Control>() {okButton }),
                new ControlsRow(Rectangle.Empty, new List<Control>() { backButton })
            });
        }

        public void UpdatePosition(Point WindowSize) {
            _wSize = new Rectangle(Point.Zero, WindowSize);
            _wSize.Inflate(0,-100);
            UpdatePagesPosition();
        }

        private void UpdatePagesPosition() {
            _mainMenu.UpdatePosition(_wSize);
            _settings.UpdatePosition(_wSize);
        }

        public void Update(GameTime gameTime, Command cmd) {
            if (cmd ==_lastSendCommand) {
                cmd = Command.None;
            } else {
                _lastSendCommand = cmd;
            }
            _currentPage.Update(gameTime, cmd);

        }

        public void Draw(SpriteBatch spriteBatch) {
            _currentPage.Draw(spriteBatch);
        }
    }
}
