using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace GameProgramming_SuperVirusLand_LucasHardy
{
    internal class Program
    {
        static bool gameOver = false;

        static Random random = new Random(); 
        static Random randomVirusSpawn = new Random();

        


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
            
            

            List<(int, int)> virusList = new List<(int, int)>();
            virusList.Add((4, 0));
            virusList.Add((7, 1));
            virusList.Add((1, 7));

            

            
            
            
            while (gameOver == false)
            {
                

                for (int i = 0; i < virusList.Count; i++)
                {
                    int x = virusList[i].Item1;
                    int y = virusList[i].Item2;

                    int newX = (x + random.Next(-1, 2));
                    int newY = (y + random.Next(-1, 2));

                    if (newX >= mapArray.GetLength(1) || newY >= mapArray.GetLength(0) || newX < 0 || newY < 0)
                    {
                        virusList[i] = (x, y);
                    }
                    else
                    {
                        virusList[i] = (newX, newY);
                        
                    }

                    


                    

                }


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
            }

        }
        static void virusMovement()
        {
            




        }
       
    }
}
