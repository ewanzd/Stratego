using System;

namespace Stratego.App
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check system resources
            // check cpu speed
            // initialize random number generator
            // load programmers options
            // create window
            // initialize audio system
            // load players game options and saved game files
            // create drawing surface
            // perform initialization for game systems: physics, AI, ...
            // game loop
            Console.WriteLine("Hello World!");
        }

        private const int MS_PER_UPDATE = 30;

        // main

        public void Init()
        {

        }

        public void GameLoop()
        {
            long previous = GetCurrentTime();
            long lag = 0L;
            while (true)
            {
                long current = GetCurrentTime();
                long elapsed = current - previous;
                previous = current;
                lag += elapsed;

                ProcessInput();

                while (lag >= MS_PER_UPDATE)
                {
                    Update(MS_PER_UPDATE);
                    lag -= MS_PER_UPDATE;
                }

                Render();
            }
        }

        public void Clean()
        {

        }

        // game loop

        public void ProcessInput()
        {

        }

        public void Update(int deltaMs)
        {

        }

        public void Render()
        {

        }

        // helper

        public long GetCurrentTime()
        {
            return DateTime.UtcNow.Ticks;
        }
    }
}