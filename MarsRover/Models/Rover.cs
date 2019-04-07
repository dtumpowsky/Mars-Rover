using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarsRover;

namespace MarsRover.Models
{
    public class Rover
    {
        private Plateau _plateau {get; set;}
        private Position _position;
        private Orientation _orientation;
        private char[] _commands;

        public Rover(Position position, Orientation orientation, char[] commands)
        {
            _position = position;
            _orientation = orientation;
            _commands = commands;          
        }

        public string Rove() {
            foreach(char letter in _commands)
            {
                Commands.Execute(_position, _orientation, letter);
            }

            if (_position.x < 0 || _position.y < 0)
            {
                return "INVALID MOVE";
            } 
            else 
            {           
            return _position.x + " " + _position.y + " " + _orientation.Output;
            }
        }
    }

}