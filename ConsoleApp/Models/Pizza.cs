using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Pizza
    {
        public Pizza()
        {
        }
        public Pizza(bool hasCheese, bool hasPepperoni, bool hasMushrooms, bool hasOlives, bool hasPineapple, bool hasHam, bool hasGarlic, bool bacon)
        {
            HasCheese = hasCheese;
            HasPepperoni = hasPepperoni;
            HasMushrooms = hasMushrooms;
            HasOlives = hasOlives;
            HasPineapple = hasPineapple;
            HasHam = hasHam;
            HasGarlic = hasGarlic;
            Bacon = bacon;
        }

        public Pizza(bool hasCheese)
        {
            HasCheese = hasCheese;
        }
        public Pizza(bool hasCheese, bool hasPepperoni)
        {
            HasCheese = hasCheese;
            HasPepperoni = hasPepperoni;
        }
        /*public Pizza(bool hasCheese, bool hasPineapple)
        {
            HasCheese = hasCheese;
            HasPineapple = hasPineapple;
        }*/

        public bool HasCheese { get; set; }
        public bool HasPepperoni { get; set; }
        public bool HasMushrooms { get; set; }
        public bool HasOlives { get; set; }
        public bool HasPineapple { get; set; }
        public bool HasHam { get; set; }
        
        public bool HasGarlic { get; set; }
        public bool Bacon { get; set; }
    }
}
