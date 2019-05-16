using System;
using System.Collections.Generic;
using System.Linq;

namespace PickerBot
{
    public class RobotBuilder
    {
        public bool LineToRobot(string input, out Bot robot)
        {
            robot = null;

            return true;
        }

        public static bool LineToCoordinates(string line, out Bot bot)
        {
            int x;
            int y;
            Direction dir;
            bot = null;

            var parts = line?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries) ?? null;

            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out x)) return false;

            if (!int.TryParse(parts[1], out y)) return false;

            if (!CDirection.TryParseDirection(parts[2].ToUpper()[0], out dir)) return false;

            bot = new Bot(x, y, dir);

            return true;
        }

        public static bool LineToCommands(string line, out List<char> commands)
        {
            commands = null;

            if (string.IsNullOrWhiteSpace(line)) return false;

            line = line.Trim();

            var validValues = new[] { '<', '>', '^' };
            if (line.Any(k => validValues.Contains(k) == false)) return false;

            commands = line.ToList();
            return true;

        }

        public static bool LineToGridSize(string line, out int x, out int y)
        {
            y = 0;
            x = 0;

            var parts = line?.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries) ?? null;

            if (parts.Count() != 2) return false;

            int.TryParse(parts[0], out x);
            int.TryParse(parts[1], out y);
            return true;
        }
    }
}