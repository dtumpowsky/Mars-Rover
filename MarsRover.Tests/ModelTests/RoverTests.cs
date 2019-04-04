using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MarsRover.Tests;
using NUnit.Framework;
using MarsRover.Models;
using Assert = NUnit.Framework.Assert;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTest
    {

        [TestMethod]
        public void Does_Rover_Rove()
        {
            Position newPosition = new Position(5,5);
            
            Orientation newOrientation = new Orientation("N");
            Commands commands = new Commands();

            char[] commandsChar = {'M'};

            Rover newRover = new Rover(newPosition, newOrientation, commandsChar);

            newRover.Rove();    

            Assert.IsTrue(newPosition.x == 5);
            Assert.IsTrue(newPosition.y == 6);
        }

        [TestMethod]
        public void Does_Rover_Rove_Multiple_Commands()
        {
            Position newPosition = new Position(5,5);
            
            Orientation newOrientation = new Orientation("N");
            Commands commands = new Commands();

            char[] commandsChar = {'M','M'};

            Rover newRover = new Rover(newPosition, newOrientation, commandsChar);

            newRover.Rove();

            Assert.IsTrue(newPosition.x == 5);
            Assert.IsTrue(newPosition.y == 7);
        }

        [TestMethod]
        public void Does_Commands_Loop_at_Value_0()
        {
            Position newPosition = new Position(5,5);
            
            Orientation newOrientation = new Orientation("N");
            Commands commands = new Commands();

            char[] commandsChar = {'L', 'M'};

            Rover newRover = new Rover(newPosition, newOrientation, commandsChar);

            newRover.Rove();

            Assert.IsTrue(newPosition.x == 4);
            Assert.IsTrue(newPosition.y == 5);
            Assert.IsTrue(newOrientation.Output == "W");
        }
    }
}
