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
                            TurnLeft(rover);
                            break;
                        }

                    case 'R':
                        {
                            TurnRight(rover);
                            break;
                        }

                    case 'M':
                        {
                            MoveRover(rover);
                            break;
                        }
                    default:
                        break;
                }
            }

            Console.WriteLine($"{rover.X} {rover.Y} {rover.Direction}");

            Console.ReadKey();
        }

        private static void MoveRover(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    rover.Y++;
                    break;
                case Direction.E:
                    rover.X++;
                    break;
                case Direction.S:
                    rover.Y--;
                    break;
                case Direction.W:
                    rover.X--;
                    break;
                default:
                    break;
            }
        }

        private static void TurnRight(Rover rover)
        {
            var dir = Convert.ToInt16(rover.Direction);
            if (dir == 4)
            {
                rover.Direction = Direction.N;
            }
            else
            {
                dir++;
                rover.Direction = (Direction)dir;
            }
        }

        private static void TurnLeft(Rover rover)
        {
            var dir = Convert.ToInt16(rover.Direction);
            if (dir == 1)
            {
                rover.Direction = Direction.W;
            }
            else
            {
                dir--;
                rover.Direction = (Direction)dir;
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
        N = 1,
        E = 2,
        S = 3,
        W = 4
    }
}
