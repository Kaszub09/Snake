using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake.AllAssets {
    public class Colors {

        public GameSceneColors GameScene;
        public MenuSceneColors MenuScene;
        public Color GlobalBG;

        public Colors() {
            LoadColors();
        }

        public void LoadColors() {
            GameScene = new GameSceneColors();
            MenuScene = new MenuSceneColors();
            GlobalBG = Color.Black;
        }

        #region Game Scene Colors
        public class GameSceneColors {
            public Color Border { get; private set; }
            public Color FieldBg { get; private set; }
            public Color SceneBg { get; private set; }
            public Color StatisticsBg { get; private set; }
            public Color StatisticsFont { get; private set; }

            public GameSceneColors() {
                LoadGameSceneColors();
            }

            public void LoadGameSceneColors() {
                Border = Color.WhiteSmoke;
                FieldBg = Color.Black;
                SceneBg = Color.DarkGray;
                StatisticsBg = new Color(0,0,50);
                StatisticsFont = Color.GreenYellow;
            }
        }
        #endregion Game Scene Colors

        #region Menu Colors
        public class MenuSceneColors {
            public Color SceneBg { get; private set; }
            public Color Font { get; private set; }

            public MenuSceneColors() {
                LoadMenuSceneColors();
            }

            public void LoadMenuSceneColors() {
                SceneBg = Color.Black;
                Font = Color.White;
            }
        }
        #endregion Menu Colors
    }
}
