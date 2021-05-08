using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;

namespace Snake {
    static class Subtitles {
        public static Dictionary<string, string> Text { get; private set; }
        private static Dictionary<string, Dictionary<string, string>> _languages;

        static Subtitles() {
            Text = new Dictionary<string, string>();
        }

        public static void LoadAllLanguages() {
            _languages = new Dictionary<string, Dictionary<string, string>>();
            foreach (var file in Directory.GetFiles(@"Content\Lang\", "*.xml")) {
                try {
                    var lang = new Dictionary<string, string>();

                    XmlDocument doc = new XmlDocument();
                    doc.Load(file);

                    var langNode = (XmlElement)doc.GetElementsByTagName("Language")[0];

                    foreach (var node in langNode.ChildNodes) {
                        if (node is XmlElement) {
                            lang[((XmlElement)node).GetAttribute("id")] = ((XmlElement)node).InnerText;
                        }
                    }

                    _languages.Add(langNode.GetAttribute("name"), lang);
                } catch (Exception e) {
                }
            }

            ///////////////////
            ChangeLanguage("English");
        }

        public static void ChangeLanguage(string language) {
            if (_languages.ContainsKey(language)){
                Text = _languages[language];
            }
        }

    }
}
