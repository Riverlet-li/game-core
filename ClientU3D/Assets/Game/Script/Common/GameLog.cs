using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore
{
    public delegate void GameLogPrintHandler(string msg, params object[] args);

    public class GameLog
    {
        private static GameLogPrintHandler _handler = DefaultPrintHandler;

        public static void SetPrintHandler(GameLogPrintHandler handler)
        {
            _handler = handler;
        }

        public static void Info(string msg, params object[] args)
        {
            OnPrint("[Info]" + msg, args);
        }

        public static void Debug(string msg, params object[] args)
        {
            OnPrint("[Debug]" + msg, args);
        }

        public static void Error(string msg, params object[] args)
        {
            OnPrint("[Error]" + msg, args);
        }

        public static void Warn(string msg, params object[] args)
        {
            OnPrint("[Error]" + msg, args);
        }

        private static void OnPrint(string msg, params object[] args)
        {
            if (_handler != null) {
                _handler(msg, args);
            }
        }

        private static void DefaultPrintHandler(string msg, params object[] args)
        {
            System.Console.WriteLine(msg, args);
        }
    }
}
