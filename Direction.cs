namespace PickerBot 
{
  public enum Direction 
  {
    N,
    E,
    S,
    W
  };

  public class CDirection
  {
      public static bool TryParseDirection(char letter, out Direction dir)
        {
            letter = char.ToUpper(letter);
            dir = Direction.N;

            switch(letter)
            {
                case 'N': dir = Direction.N; break;
                case 'S': dir = Direction.S; break;
                case 'W': dir = Direction.W; break;
                case 'E': dir = Direction.E; break;
                default: return false;   
            }

            return true;
        }
  }
  
  
}