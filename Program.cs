using System;
using System.Collections.Generic;
using System.Linq;

namespace PickerBot {
  class Program {
    static void Main (string[] args) {
      var grid = new Int2 ();
      var robots = new List<Bot> ();

      while (true) {

        var input = Console.ReadLine ();
        switch(input)
        {
          case "q": 
            return;
          case var noSpace when !noSpace.Contains(" "): // command might have issue
            continue;
        }
         
        var parts = input.Split (new []{" "}, StringSplitOptions.RemoveEmptyEntries);
        switch (parts.Count ()) {
          case 1:
            {
              RobotBuilder.LineToCommands(input, out var commands);
              robots.Last().SetCommands(commands);
              break;
            }
          case 2:
            {
              RobotBuilder.LineToGridSize(input, out grid.X, out grid.Y);
              break;
            }
          case 3:
            {
              if (grid.X == 0 || grid.Y == 0) 
              {
                Console.WriteLine ("Please Change grid to Valid Value.");
                return;
              }
            }
          break;
              
          case 0:
            if(input != "") return;

            robots.ForEach(entity => {
              entity.Commands.ForEach(command =>{
                switch(command){
                  case '^': entity.MoveForward(); break;
                  case '>': entity.TurnRight(); break;
                  case '<': entity.TurnLeft(); break;
                }
              });
              Console.WriteLine(entity.X + " " + entity.Y + " " + entity.Dir);
              if(entity.X > grid.X || entity.X < 0 || entity.Y > grid.Y || entity.Y < 0) Console.WriteLine("Bot Out Of Bounds!");
            });
            break;
      
        }
      }
    }
  }
}