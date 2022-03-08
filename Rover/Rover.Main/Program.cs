using System;

namespace Rover.Main
{
    class Program
    {
        public static int MaxX { get; set; }
        public static int MaxY { get; set; }

        static void Main(string[] args)
        {
            /////// Max Bilgilerin İşlenmesi  //////
            Console.WriteLine("Write Max Size");
            var readMaxValues = Console.ReadLine();
            string[] maxValueList = readMaxValues.Split(' ');
            MaxX = Convert.ToInt32(maxValueList[0]);
            MaxY = Convert.ToInt32(maxValueList[1]);

            ///// Rover Başlangıç Pozisyonunun Yapıladırılması /////
            Console.WriteLine("Write Rover Position");
            var readRoverPosition = Console.ReadLine();
            string[] roverPositionList = readRoverPosition.Split(" ");

            int X = Convert.ToInt32(roverPositionList[0]);
            int Y = Convert.ToInt32(roverPositionList[1]);
            Direction dir = Enum.Parse<Direction>(roverPositionList[2]);

            Rover rover = new Rover
            {
                Direction = dir,
                X = X,
                Y = Y
            };

            ///// Yönlendirmelerin Yapılması //////
            Console.WriteLine("Enter Rover Moves");
            var Path = Console.ReadLine();

            foreach (char move in Path)
            {
                switch (move)
                {
                    case 'L':
                        {
                            break;
                        }

                    case 'R':
                        {
                            break;
                        }

                    case 'M':
                        {
                            break;
                        }
                    default:
                        break;
                }
            }

        }


    }

    class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }

    enum Direction
    {
        N,
        S,
        E,
        W
    }
}
