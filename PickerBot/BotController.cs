using System;
using System.Collections.Generic;
using System.Text;

namespace PickerBot
{
    class BotController
    {
        public static bool BoundsCheck(Bot bot, int X, int Y)
        {
            if (bot.X > X || bot.X < 0 || bot.Y > Y || bot.Y < 0)return false;
            return true;
        }

        public static bool RemoveCommands(Bot bot)
        {
            if (bot.Commands == null) return false;
            bot.Commands = null;
            return true;

        }
    }
}
