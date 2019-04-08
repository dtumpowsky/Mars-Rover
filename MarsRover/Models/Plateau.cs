using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Models
{
    public class Plateau
    {
        private List<Rover> _rovers = new List<Rover>();
        private int x {get;set;}
        private int y {get;set;}   

        private string _output {get;set;}     
        
        public Plateau(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void DropRover(int roverX, int roverY, string letter, char[] commands)
        {
            Plateau newPlateau = new Plateau(x, y);
            Position newPosition = new Position(roverX, roverY);
            Orientation newOrientation = new Orientation(letter);
            
            Rover newRover = new Rover(newPosition, newOrientation, commands);    
            if(newPosition.x > x || newPosition.y > y)
            {
                throw new System.InvalidOperationException("Can Not Place Rover Here");
            }
            _rovers.Add(newRover);    
        }

        public string Explore()
        {
            foreach(Rover rover in _rovers)
            {
                string marsRover = rover.Rove();

                _output += marsRover + "<br/><br/>";
               
            }


            return _output;
        }
    }
}