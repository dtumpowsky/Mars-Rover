using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MarsRover.Models;
using System;
using System.Text.RegularExpressions;
using System.Linq;

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
            
            string coordsInput = Request.Form["coordinates"];
            char[] delimiters = {'\r', '\n'};
            string[] coords = coordsInput.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            

            List<String> coordsList = new List<String>(coords);

            

            string plateauCoordinates = coordsList.ElementAt(0);

            int x = Int32.Parse(plateauCoordinates.Substring(0,1));
            int y = Int32.Parse(plateauCoordinates.Substring(2,1));
         
            Plateau plateau = new Plateau(x, y);

            
            //Creates Rovers and puts them on Plateau
            for(int i = 1; i < coordsList.Count; i+=2)
            {
                string roverInput = coordsList.ElementAt(i);
                string commandsInput = coordsList.ElementAt(i+1);

                string[] roverCoords = roverInput.Split(' ');

                int roverX = Int32.Parse(roverCoords[0]);
                int roverY = Int32.Parse(roverCoords[1]);
                string orientation = roverCoords[2];

                Position newPosition = new Position(roverX, roverY);
                Orientation newOrientation = new Orientation(orientation);

                char[] commands = commandsInput.ToCharArray();


                plateau.DropRover(roverX, roverY, orientation, commands);
            }
                     
            string output = plateau.Explore();
            ViewBag.output = output;
            
            return View("Index");
        }
    }
}