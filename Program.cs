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

              break;
            case 2:
              int.TryParse (parts[0], out var x);
              int.TryParse (parts[1], out var y);
              break;
            case 3:
              if (grid.X == 0 || grid.Y == 0) {
                Console.WriteLine ("Please Change grid to Valid Value.");
                return;
              }
               
               
              break;
              
            case 0:
             return;
          
        }
      }
    }
  }
}