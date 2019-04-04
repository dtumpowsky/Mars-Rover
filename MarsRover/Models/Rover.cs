using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarsRover;

namespace MarsRover.Models
{
    public class Rover
    {
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
            
            return _position.x + " " + _position.y + " " + _orientation.Output;
        }
    }

}