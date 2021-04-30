using System;
using System.Collections.Generic;

namespace TestBed
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(){1,2,4,5,6,7,8,9,10,11};
            // List<int> numbers = new List<int>();
            Chunk<int> chunker = new Chunk<int>(numbers, 0);

            while (chunker.GetNextChunk())
            {
                var chunkedResults  = chunker.CurrentChunk();
            }

            Console.WriteLine("Done!");
        }
    }
}
