using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VolatileKeywordSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object to keep the status of the game            
            GameStatus status = new GameStatus();
            status.StopFlag = false;

            // start an infinite game loop
            Thread gameLoop = new Thread(RunLoop);
            gameLoop.Start(status);

            //play a little...
            Thread.Sleep(2000);

            // stop the game
            status.StopFlag = true;
            Console.WriteLine("Stopflag has been set.");
            Console.ReadLine();
        }

        /// <summary>
        /// Starts the loop. Runs until stop flag is set.
        /// </summary>
        /// <param name="obj">Status of the Game</param>
        private static void RunLoop(object obj)
        {
            GameStatus status = (GameStatus)obj;
            Console.WriteLine("Game loop starts now.");

            while (!status.StopFlag)
            {
                // do something
                int i = 1; 
            }

            Console.WriteLine("Game loop stopped.");            
        }
    }
}
