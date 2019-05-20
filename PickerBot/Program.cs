using System;
using System.Collections.Generic;
using System.Linq;

namespace PickerBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var grid = new Int2();
            var robots = new List<Bot>();
            bool verbose = false;
            bool removeCommand = true;

            while (true)
            {

                var input = Console.ReadLine();
                switch (input)
                {
                    case "q":
                        return;

                    case "v":
                        verbose = !verbose;
                        break;

                    case "c":
                        removeCommand = !removeCommand;
                        break;

                    default:
                        if (input.Contains('^'))
                            {
                            RobotBuilder.LineToCommands(input, out var commands);
                            if (robots.FindAll(robot => robot.Commands == null).Count() == 0) break;
                            robots.FindAll(bots => bots.Commands == null).First().SetCommands(commands);
                        }
                        break;
                }

                var parts = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                switch (parts.Count())
                {
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            RobotBuilder.LineToGridSize(input, out grid.X, out grid.Y);
                            if (grid.X == 0 || grid.Y == 0)
                            {
                                Console.WriteLine("Please Change grid to Valid Value.");
                                return;
                            }
                            break;
                        }
                    case 3:
                        {
                            robots.Add(new Bot(int.Parse(parts[0]), int.Parse(parts[1]), (Direction)char.ToUpper(parts[2].Trim()[0])));
                        }
                        break;

                    case 0:
                        if (input != "") return;

                        robots.ForEach(entity => {
                            if(entity.Commands == null)
                            {
                                if (verbose) Console.WriteLine("Bot Has No Commands");
                                return;
                            }
                            entity.Commands.ForEach(command => {
                                if (BotController.BoundsCheck(entity, grid.X, grid.Y)) return;
                                if(entity.CommandValid(command, grid.X, grid.Y))
                                    entity.ProcessCommand(command);
                                if (verbose)
                                {
                                    Console.WriteLine($"{entity.X} {entity.Y} {(char)entity.Dir}");
                                }
                            });

                            if(BotController.BoundsCheck(entity, grid.X, grid.Y))
                                Console.WriteLine("Bot Out Of Bounds!");

                            if(removeCommand) BotController.RemoveCommands(entity);

                            Console.WriteLine($"{entity.X} {entity.Y} {(char)entity.Dir}");
                            Console.WriteLine("");
                        });
                        break;
                }
            }
        }
    }
}
