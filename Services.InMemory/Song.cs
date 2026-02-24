using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.InMemory
{
    public class Song : IPlayable
    {
        public string Title { get; set; }
        public string Artist { get; set; }

        public void Pause()
        {
            Console.WriteLine($"{Title} by {Artist} paused.");
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} by {Artist}");
        }
    }
}
