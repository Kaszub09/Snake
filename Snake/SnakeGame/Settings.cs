using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    static public class Settings
    {
       
        public static int BoardX { get;  set; } = 20;
        public static int BoardY { get;  set; } = 16;
        public static int PixelPerPoint { get; set; } =18;
        public static Point WindowEnd { get; set; }
        public static int FontSize { get; set; } = 12;
        public static Random Rand = new Random();

        public static event EventHandler LanguageChanged;
        public static event EventHandler FontChanged;

        static public void ChangeLanguage(string language) {
            Subtitles.ChangeLanguage(language);
            LanguageChanged?.Invoke(null,null);
        }

        static public void ChangeFont(FontSize fontSize) {
            FontChanged?.Invoke(null, null);
        }

    }
}
