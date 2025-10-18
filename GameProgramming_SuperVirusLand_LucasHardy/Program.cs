using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Reflection;

namespace GameProgramming_SuperVirusLand_LucasHardy
{
    internal class Program
    {
        static bool gameOver = false;

        static Random random = new Random(); 
        static Random randomVirusSpawn = new Random();


        static List<(int, int)> virusList = new List<(int, int)>();


        static int x;
        static int y;

        static int newX;
        static int newY;

        static char[,] mapArray =
            {
                {'^','^','-','-','-','-','-','-','-','^',},
                {'-','-','-','-','-','-','-','-','-','^',},
                {'-','-','-','~','~','-','-','-','-','-',},
                {'-','-','-','~','~','~','-','-','-','-',},
                {'-','-','-','~','~','~','-','-','-','-',},
                {'-','-','-','~','~','~','-','-','-','-',},
                {'-','-','-','-','-','-','-','-','-','-',},
                {'-','-','^','^','-','-','-','-','-','^',},
                {'-','-','-','-','-','-','-','-','^','^',},
                {'-','-','-','-','-','-','-','-','-','-',}

            };

        static void Main(string[] args)
        {
            virusList.Add((4, 0));
            virusList.Add((7, 1));
            virusList.Add((1, 7));









            while (gameOver == false)
            {

                virusMovement();
                


                for (int y = 0; y < mapArray.GetLength(0); y++)
                {

                    for (int x = 0; x < mapArray.GetLength(1); x++)
                    {
                        Console.Write(mapArray[y, x]);


                    }
                    Console.Write("\n");
                    

                }

                foreach ((int x, int y) in virusList)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write("X");
                    

                }
                Thread.Sleep(1000);
                Console.Clear();
                virusReproduction();

            }

        }
        static void virusReproduction()
        {
            

            for (int i = 0; i < virusList.Count; i++)
            {
                int Copy = random.Next(0, 10);

                if (Copy == 5)
                {
                    virusList.Add(virusList[i]);
                }
            }
                




        }

        static void virusMovement()
        {
            for (int i = 0; i < virusList.Count; i++)
            {

                x = virusList[i].Item1;
                y = virusList[i].Item2;

                newX = (x + random.Next(-1, 2));
                newY = (y + random.Next(-1, 2));

                if(newX == x)
                {
                    virusList[i] = (x, newY);
                }
                else if (newY == y)
                {
                    virusList[i] = (newX, y);
                }


                if (newX >= mapArray.GetLength(1) || newY >= mapArray.GetLength(0) || newX < 0 || newY < 0)
                {
                    virusList[i] = (x, y);
                }

                else if  (mapArray[newY, newX] == '^' || mapArray[newY, newX] == '~')
                {
                    virusList[i] = (x, y);
                }
                
                else if (virusList[i] == (newX, newY))
                {

                    

                }
                


            }
        }

    }
}
