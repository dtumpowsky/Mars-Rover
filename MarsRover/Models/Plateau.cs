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
        
        public void DropRover(int x, int y, string letter, char[] commands)
        {
            Position newPosition = new Position(x, y);
            Orientation newOrientation = new Orientation(letter);
            
            Rover newRover = new Rover(newPosition, newOrientation, commands);    

            _rovers.Add(newRover);    
        }

        public string Explore()
        {
            foreach(Rover rover in _rovers)
            {
                _output += rover.Rove() + "<br/><br/>";
            }

            return _output;
        }
    }
}