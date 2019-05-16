using System;
using System.Collections.Generic;
using System.Text;

namespace PickerBot
{
    public class Bot
    {
        public int X;
        public int Y;
        public Direction Dir;
        public List<char> Commands;

        public Bot()
        {
            X = 0;
            Y = 0;
            Dir = Direction.N;
            Commands = null;
        }

        public Bot(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Dir = direction;
        }

        public void SetCommands(List<char> commands)
        {
            Commands = commands;
        }

        public void MoveForward()
        {
            switch (Dir)
            {
                case Direction.N: Y++; break;
                case Direction.S: Y--; break;
                case Direction.E: X++; break;
                case Direction.W: X--; break;
            }
        }

        public void TurnLeft()
        {
            switch (Dir)
            {
                case Direction.N: Dir = Direction.W; break;
                case Direction.W: Dir = Direction.S; break;
                case Direction.S: Dir = Direction.E; break;
                case Direction.E: Dir = Direction.N; break;
            }
        }

        public void TurnRight()
        {
            switch (Dir)
            {
                case Direction.N: Dir = Direction.E; break;
                case Direction.E: Dir = Direction.S; break;
                case Direction.S: Dir = Direction.W; break;
                case Direction.W: Dir = Direction.N; break;
            }

        }

        public bool CommandValid(Char command, int gridX , int gridY)
        {
            if(command == '^')
            {
                if (Dir == Direction.N && Y == gridY) return false;
                if (Dir == Direction.S && Y == 0) return false;
                if (Dir == Direction.E && X == gridX) return false;
                if (Dir == Direction.W && X == 0) return false;
            }

            return true;
        }

        public bool ProcessCommand(Char command)
        {
            
            switch (command)
            {
                case '^': MoveForward(); break;
                case '>': TurnRight(); break;
                case '<': TurnLeft(); break;
                default: return false;
            }

            return true;
        }
    }
}
