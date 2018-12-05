using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCore
{
    public class GameLog
    {
        public static void Info(string msg, params object[] args)
        {
            Print("[Info]" + msg, args);
        }

        public static void Debug(string msg, params object[] args)
        {
            Print("[Debug]" + msg, args);
        }

        public static void Error(string msg, params object[] args)
        {
            Print("[Error]" + msg, args);
        }

        public static void Warn(string msg, params object[] args)
        {
            Print("[Error]" + msg, args);
        }

        private static void Print(string msg, params object[] args)
        {
            System.Console.WriteLine(msg, args);
        }
    }
}
