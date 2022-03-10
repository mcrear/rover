using Rover.Main.Constant;
using Rover.Main.Extensions;

namespace Rover.Main.Data
{
    public class Rover
    {
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }

        public Rover(string strX, string strY, string strDir)
        {
            Coordinate = new Coordinate(strX, strY);
            Direction = strDir.ToEnumValue<Direction>();
        }
    }
}
