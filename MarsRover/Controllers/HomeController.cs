using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MarsRover.Models;
using System;

namespace MarsRover.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost("/rover")]
        public ActionResult Create()
        {
            
            string coordsInput = Request.Form["plateau-coords"];
            string[] coords = coordsInput.Split(' ');

            int x = Int32.Parse(coords[0]);
            int y = Int32.Parse(coords[1]);
         
            Plateau plateau = new Plateau(x, y);

            string roverInput = Request.Form["rover-coords"];
            string[] roverCoords = roverInput.Split(' ');

            int roverX = Int32.Parse(roverCoords[0]);
            int roverY = Int32.Parse(roverCoords[1]);
            string orientation = roverCoords[2];

            Position newPosition = new Position(roverX, roverY);
            Orientation newOrientation = new Orientation(orientation);

            string commandsInput = Request.Form["rover-commands"];
            char[] commands = commandsInput.ToCharArray();

            // Rover newRover = new Rover(newPosition, newOrientation, commands);

            plateau.DropRover(roverX, roverY, orientation, commands);
            
            // plateau.Explore();

            ViewBag.output = plateau.Explore();
            
            return View("Index");
        }
    }
}