using System;

namespace PickerBot
{
    public class RobotBuilder
    {
        public bool LineToRobot(string input, out Bot robot){
            return true;
        }


        public bool LineToCoordinates(string line, out Bot bot)
        {
            int x;
            int y;
            Direction dir;
            bot = null;

            var parts = line?.Split (new []{" "}, StringSplitOptions.RemoveEmptyEntries) ?? null;

            if (parts.Length != 3)
                return false;

            if (int.TryParse (parts[0], out x) == false)
                return false;

            if (int.TryParse (parts[1], out y) == false)
                return false;

            if (Direction.TryParseDirection(parts[2], out dir) == false)
                return false;

            bot = new Bot(x,y,dir);

            return true;
        }

        

        public bool LineToCommands(string line, out List<char> commands)
        {
            
        }

        public bool LineToGridSize(string line, out int x, out int y)
        {
            
        }
    }
}