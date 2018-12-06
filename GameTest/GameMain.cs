using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameCore;

namespace GameTest
{
    public class GameMain
    {
        static void Main(string[] args)
        {
            GameContext.InitGame();
            GameContext.StartGame();
            while (!GameContext.isExit) {
                GameContext.TickGame();
            }
            GameContext.QuitGame();
            System.Console.ReadLine();
        }
    }
}
