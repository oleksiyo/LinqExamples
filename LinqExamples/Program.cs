﻿using System;
using System.Linq;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = FakeGenerator.GenerateGroups(10);
            var id = 5;

            // find item in list by unique item in joined list
            var result = groups.First(clA => clA.Competences.Select(b => b.Id).Any(c => c == id));

            Console.ReadKey();
        }
    }
}