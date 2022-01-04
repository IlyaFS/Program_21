using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program_21
{
    internal class Program
    {

        public static int[,] garden = new int[10, 10];
        public static int rows = garden.GetUpperBound(0) + 1;
        public static int columns = garden.Length / rows;


        static void Main(string[] args)
        {
            Thread s1 = new Thread(sad1);
            Thread s2 = new Thread(sad2);

            s1.Start();
            s2.Start();

            s1.Join();
            s2.Join();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(garden[i, j] + " ");
                    Thread.Sleep(50);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void sad1()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (garden[i, j] == 0)
                        garden[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        public static void sad2()
        {
            for (int i = rows - 1; i > 0; i--)
            {
                for (int j = columns - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                        garden[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}


//1.Имеется пустой участок земли (двумерный массив) и план сада, который необходимо реализовать.
//Эту задачу выполняют два садовника, которые не хотят встречаться друг с другом.
//Первый садовник начинает работу с верхнего левого угла сада и перемещается слева направо, сделав ряд, он спускается вниз.
//Второй садовник начинает работу с нижнего правого угла сада и перемещается снизу вверх, сделав ряд, он перемещается влево.
//Если садовник видит, что участок сада уже выполнен другим садовником, он идет дальше. Садовники должны работать параллельно.
//Создать многопоточное приложение, моделирующее работу садовников.
