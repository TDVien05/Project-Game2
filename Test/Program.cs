using System;
using Test.Model;
using Test.View;

namespace Test
{
    class Programl
    {
        static void Main(string[] args)
        {
            Output output = new Output();
            int x = output.Log();
            do
            {
                output.Menu();
            } while (x == 1);
        }

    }
}