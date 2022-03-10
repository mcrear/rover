using Rover.Main.Data;

namespace Rover.Main.Service.Interface
{
    interface IActionService
    {
        Data.Rover MoveRover(string path, Coordinate maxCoord, Data.Rover rover);
    }
}
