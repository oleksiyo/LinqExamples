using System;
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