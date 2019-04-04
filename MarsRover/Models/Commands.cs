using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarsRover;
using static MarsRover.Models.Orientation;

namespace MarsRover.Models
{
    public class Commands
    {

        public static void Execute(Position position, Orientation orientation, char letter)
        {
            switch (letter)
                {
                    case 'L':
                      TurnLeft(orientation);
                      break;                       
                    case 'R':
                      TurnRight(orientation);
                      break;                     
                    case 'M':
                      MoveForward(position, orientation);
                      break;
                    default:
                      Console.WriteLine("INVALID MOVE: " + letter);
                      break;                
                }
        }
        
        private static void TurnLeft(Orientation orientation)
        {  
            orientation.Value--;

            if(orientation.Value < 0)
            {
              orientation.Value = 3;
            }
        }

        private static void TurnRight(Orientation orientation)
        {
            orientation.Value++;

            if(orientation.Value > 3)
            {
              orientation.Value = 0;
            }
        }

        private static void MoveForward(Position position, Orientation orientation){
            if (orientation.Output == "N") {
                position.y++;
            }
            else if (orientation.Output == "E") {
                position.x++;
            }
            else if (orientation.Output == "S") {
                position.y--;
            }
            else
            {
                position.x--;
            }   
        }
    }
}