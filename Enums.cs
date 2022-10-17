using System;

namespace ConsoleFlappyBird
{
    public enum Tiles
    {
        Null = ConsoleColor.Black,
        Sky = ConsoleColor.Blue,
        Pipe = ConsoleColor.Green,
        Bird = ConsoleColor.Yellow
    }

    public enum MoveStatus
    {
        Success,
        Fail,
        Pipe
    }
}
