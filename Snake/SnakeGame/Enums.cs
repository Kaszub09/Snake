using System;
using System.Collections.Generic;
using System.Text;

namespace Snake {
    public enum Command {
        KeyUp,
        KeyDown,
        KeyLeft,
        KeyRight,
        OK,
        Cancel,
        Esc,
        None
    }

    public enum Direction { Up, Down, Left, Right }

    public enum GameState { Prepared, Running, Finished }

    public enum Field { Empty, Snake, Fruit }
    public enum FontSize { Small, Normal, Big }
}
