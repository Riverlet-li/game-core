using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    class GameMain
    {
        static void Main(string[] args)
        {
            GameContext.Init();
            while (!GameContext.isExit) {
                GameContext.Tick();
            }
            GameContext.Release();
            System.Console.ReadLine();
        }
    }
}
