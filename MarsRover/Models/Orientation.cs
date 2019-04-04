using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MarsRover;

namespace MarsRover.Models
{
    public class Orientation
    {
        public int Value {get;set;}

        public Orientation(string letter)
        {
            switch(letter)
            {
              case "N":
              default:
                Value = 0;
                break;                        
              case "E":
                Value = 1;
                break;                        
              case "S":
                Value = 2;
                break;                         
              case "W":
                Value = 3;
                break;
            }
        }

        public string Output
        {
            get
            {
                int mod = Value%4;
                
                switch (mod)
                {
                    case 0:
                    default:
                        return "N";                        
                    case 1:
                        return "E";                        
                    case 2:
                      return "S";                         
                    case 3:
                      return "W";                       
                }
            }
        }

        
    }
    
}