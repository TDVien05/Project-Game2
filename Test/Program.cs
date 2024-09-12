using System;
using Test.Model;
using Test.View;

namespace Test
{
    class Programl
    {
        static void Main(string[] args)
        {
            int check = 1;
            do
            {
                Output output = new Output();
                int x = output.Log();
                if (x == 1)
                {
                    Console.Clear();
                    do
                    {
                        output.Menu();
                    } while (x == 1);
                    check = 0;
                }
            } while (check == 1);
        }

    }
}