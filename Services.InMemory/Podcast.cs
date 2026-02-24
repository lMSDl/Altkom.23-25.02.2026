using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.InMemory
{
    public class Podcast : IPlayable
    {
        public string Title { get; set; }
        public int EpisodNumber { get; set; }

        public void Pause()
        {
            Console.WriteLine($"{Title} episode {EpisodNumber} paused.");
        }

        public void Play()
        {
            Console.WriteLine($"Playing {Title} episode {EpisodNumber}");
        }
    }
}
