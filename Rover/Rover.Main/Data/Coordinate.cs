using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.Main.Data
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(string strX, string strY)
        {
            int x;
            bool result = Int32.TryParse(strX, out x);
            if (!result)
            {
                X = -1;
                Console.WriteLine("Attempted conversion of X axsis '{0}' failed.", strX);
            }
            else
                X = x;


            int y;
            result = Int32.TryParse(strY, out y);
            if (!result)
            {
                Y = -1;
                Console.WriteLine("Attempted conversion of Y axsis '{0}' failed.", strY);
            }
            else
                Y = y;
        }
    }
}
