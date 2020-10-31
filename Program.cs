using System;

namespace ProceduralSokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Level level = new Level();
            level.generate();
            level.print();
        }
    }
}
