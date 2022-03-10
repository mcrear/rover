using Rover.Main.Constant;
using Rover.Main.Data;
using Rover.Main.Extensions;
using Rover.Main.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rover.Main.Service
{
    class ActionService : IActionService
    {
        public Data.Rover MoveRover(string path, Coordinate maxCoord, Data.Rover rover)
        {
            List<Movement> Moves = path.ToCharArray().Select(x => x.ToEnumValue<Movement>()).ToList();
            foreach (Movement move in Moves)
            {
                switch (move)
                {
                    case Movement.F:
                        break;
                    case Movement.L:
                        TurnLeft(rover);
                        break;
                    case Movement.R:
                        TurnRight(rover);
                        break;
                    case Movement.M:
                        ForwardRover(rover, maxCoord);
                        break;
                    default:
                        break;
                }
            }

            return rover;
        }

        private Data.Rover ForwardRover(Data.Rover rover, Coordinate maxCoordinate)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    if (rover.Coordinate.Y + 1 > maxCoordinate.Y)
                        return CantMove(rover.Coordinate, maxCoordinate);
                    else
                        rover.Coordinate.Y++;
                    return rover;
                case Direction.E:
                    if (rover.Coordinate.X + 1 > maxCoordinate.X)
                        return CantMove(rover.Coordinate, maxCoordinate);
                    else
                        rover.Coordinate.X++;
                    return rover;
                case Direction.S:
                    if (rover.Coordinate.Y - 1 < 0)
                        return CantMove(rover.Coordinate, maxCoordinate);
                    else
                        rover.Coordinate.Y--;
                    return rover;
                case Direction.W:
                    if (rover.Coordinate.X - 1 < 0)
                        return CantMove(rover.Coordinate, maxCoordinate);
                    else
                        rover.Coordinate.X--;
                    return rover;
                default:
                    return null;
            }
        }

        private void TurnRight(Data.Rover rover)
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

        private void TurnLeft(Data.Rover rover)
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

        private Data.Rover CantMove(Coordinate roverCoordinate, Coordinate maxCoordinate)
        {
            Console.WriteLine($"Rover try to move in {roverCoordinate.X},{roverCoordinate.Y} but it have to be in 0,0 and {maxCoordinate.X},{maxCoordinate.Y}");
            return null;
        }
    }
}
