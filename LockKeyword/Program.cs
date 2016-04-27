using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockKeywordSample
{
    class Program
    {

        static readonly object _randomLocker = new object();
        static readonly object _anotherLocker = new object();
        static readonly object _populationLocker = new object();

        static Random _rand = new Random();
        static int _cellPopulation = 100;
        static Stopwatch _stopwatch;

        static int CellPopulation
        {
            get
            {
                return _cellPopulation;
            }
            set
            {
                _cellPopulation = value;
                if (_cellPopulation < 0)
                {
                    // throw exception if population is negative
                    throw new PopulationCantBeNegativeException();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"The initial cell population in the petri dish is: {CellPopulation}");
            RunExperiments();
            Console.WriteLine($"...and {CellPopulation} cells lived happily ever after.");
            Console.Write($"Finished something else after {_stopwatch.ElapsedMilliseconds} milliseconds.");
            Console.ReadLine();
        }

        /// <summary>
        /// Simulates experiments. Depending on a random value the experiments either fail and wipe out all cells or 
        /// succeed and create more cells.
        /// </summary>
        public static void RunExperiments()
        {
            List<Task> tasks = new List<Task>();

            // start a task to do something totally unrelated
            Task.Run(() => { DoSomethingUnrelated(); });

            // create 10 tasks to modify the  population
            for (int nrTasks = 0; nrTasks < 10; nrTasks++)
            {
                tasks.Add(
                    Task.Run(() =>
                    {

                        // cell population is increased or decreased based on fortune (that means based on a random value)
                        var randomValue = GetRandomValue();

                        // critical section starts here 
                        lock (_populationLocker)
                        {
                            Console.WriteLine($"{Environment.NewLine} Starting a new experiement...");
                            if (randomValue > 50)
                            {
                                // reduce nr of cell in petri dish
                                Console.WriteLine("My Experiment failed ...");
                                var currentPop = CellPopulation;
                                for (int i = 0; i < currentPop; i++)
                                {
                                    DecreasePopulation();
                                    Console.WriteLine($"The current cell population is: {CellPopulation}");
                                    ConsumeTime();
                                }
                                Console.WriteLine("Failed experiment ended.");
                            }
                            else
                            {
                                // increase nr of cells 
                                Console.WriteLine("My Experiment started an era of love & peace & happiness...");
                                for (int i = 0; i < GetRandomValue(); i++)
                                {
                                    IncreasePopulation();
                                    ConsumeTime();
                                    Console.WriteLine($"The cell population is: {CellPopulation}");
                                }
                                Console.WriteLine("My experiment & love & peace & happiness ended.");
                            }
                        }
                    }));
            }

            // wait for all tasks to finish
            Task.WaitAll(tasks.ToArray());
        }

        /// <summary>
        /// Doesn't do anything special, it just consumes some cpu time.
        /// </summary>
        private static void ConsumeTime()
        {
            for (int j = 0; j < int.MaxValue / 100; j++)
            { }
        }

        /// <summary>
        /// This method doesn't do anything 20 times. It just calls "DoNothing". 
        /// Let's see how long it takes to finish.
        /// </summary>
        private static void DoSomethingUnrelated()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            Console.WriteLine("Start something else ...");

            for (int i = 0; i < 20; i++)
            {
                DoNothing();
            }
            _stopwatch.Stop();
        }

        /// <summary>
        /// This method does nothing. It just uses a certain lock object. 
        /// </summary>
        private static void DoNothing()
        {
            lock (_anotherLocker)
            { }
        }

        /// <summary>
        /// This method gets a random value. It's wrapped into a separate method with a lock object to make sure
        /// it works as expected from multiple threads.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomValue()
        {
            // we need this lock object here to make sure everything works as expected. Otherwise the random 
            // function might not truly show random results.
            lock (_randomLocker)
            {
                return _rand.Next(1, 100);
            }
        }

        /// <summary>
        /// Simple increase by 1
        /// </summary>
        private static void IncreasePopulation()
        {
            CellPopulation++;
        }

        /// <summary>
        /// Simple decrease by 2
        /// </summary>
        private static void DecreasePopulation()
        {
            CellPopulation--;
        }
    }
}
