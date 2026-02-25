using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Pet : Entity
    {
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} - {Age}";
        }
    }
}
