using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var groups = FakeGenerator.GenerateGroups(10);
            var persons = FakeGenerator.GeneratePersons(10);
            var id = 5;

            // find item in list by unique item in joined list
            var result = groups.First(clA => clA.Competences.Select(b => b.Id).Any(c => c == id));

            // group items by unique property's value, and calculate count in each groups           
            var competenceGroups = persons.GroupBy(p => p.Competence.Id)
                .Select(g => new CompetenceGroup
                {
                    Name = g.First().Competence.Name,
                    Id = g.First().Competence.Id,
                    Count = g.Count()
                });

            // result: id Name Count
            //          1  "a"   2
            //          2  "c"   1
            //          3  "a"   3
            var comGroups = new List<CompetenceGroup>
                {
                    new CompetenceGroup {Id = 2, Name = "c", Count = 1},
                    new CompetenceGroup {Id = 1, Name = "a", Count = 1},
                    new CompetenceGroup {Id = 1, Name = "b", Count = 2},
                    new CompetenceGroup {Id = 3, Name = "a", Count = 1},
                    new CompetenceGroup {Id = 3, Name = "b", Count = 3}
                };

            var groupBy = comGroups.GroupBy(s => s.Id).ToList();
            var uniqueItems = groupBy.Where(grouping => grouping.Count() == 1).Select(grouping => grouping.First());
            var duplicateItems = groupBy.Where(grouping => grouping.Count() > 1)
                       .SelectMany(grouping => grouping.ToList())
                       .Where(@group => @group.Name == "b")
                       .Select(c => { c.Name = "a"; return c; });

            // Update all objects in a collection using Linq
            duplicateItems.Select(c => { c.Name = "value"; return c; }).ToList();


            Console.ReadKey();
        }
    }

    public class CompetenceGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }
}