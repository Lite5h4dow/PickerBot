using System;
namespace PickerBot {
  public class Bot {
    public Int2 coord;
    public Direction dir;
    string commands;

    public Bot () {
      coord = new Int2 (0,0);
      dir = Direction.N;
      commands = "";
    }

    public Bot (int x, int y, Direction direction) {
      coord = new Int2 (x, y);
      dir = direction;
    }

    public void MoveForward()
    {

    }

    public void TurnLeft()
    {

    }

    public void TurnRight()
    {

    }


  }
}