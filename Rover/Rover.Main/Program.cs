using Rover.Main.Constant;
using System;
using Rover.Main.Data;
using Microsoft.Extensions.DependencyInjection;
using Rover.Main.Service;
using Rover.Main.Service.Interface;

namespace Rover.Main
{
    class Program
    {
        public static void Main(string[] args)
        {
            bool IsMaxCoordinateSet = false;
            bool IsRoverStartPositionSet = false;
            Coordinate MaxCoordinate = null;
            Data.Rover rover = null;
            var services = new ServiceCollection();
            services.AddSingleton<IActionService, ActionService>();
            var provider = services.BuildServiceProvider(true);
            var _actionService = provider.GetRequiredService<IActionService>();

            while (!IsMaxCoordinateSet)
            {
                /////// Max Bilgilerin İşlenmesi  //////
                Console.WriteLine("Write Max Size");
                var readMaxValues = Console.ReadLine();
                string[] maxValueList = readMaxValues.Split(' ');
                MaxCoordinate = new Coordinate(maxValueList[0], maxValueList[1]);
                if (MaxCoordinate.X != -1 && MaxCoordinate.Y != -1)
                    IsMaxCoordinateSet = true;
            }

            while (!IsRoverStartPositionSet)
            {
                ///// Rover Başlangıç Pozisyonunun Yapıladırılması /////
                Console.WriteLine("Write Rover Position");
                var readRoverPosition = Console.ReadLine();
                string[] roverPositionList = readRoverPosition.Split(" ");
                rover = new Data.Rover(roverPositionList[0], roverPositionList[1], roverPositionList[2]);
                if (rover.Coordinate.X != -1 && rover.Coordinate.Y != -1 && rover.Direction != Direction.F)
                    IsRoverStartPositionSet = true;
            }


            ///// Yönlendirmelerin Yapılması //////
            Console.WriteLine("Enter Rover Moves");
            var Path = Console.ReadLine();
            rover = _actionService.MoveRover(Path, MaxCoordinate, rover);


            Console.WriteLine($"{rover.Coordinate.X} {rover.Coordinate.Y} {rover.Direction}");

            Console.ReadKey();
        }


    }
}
