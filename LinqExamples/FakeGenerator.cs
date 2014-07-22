using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
    public class FakeGenerator
    {
        private static int count = 0;
        public static List<Competence> GenerateCompetences(int count)
        {
            var competences = new List<Competence>();
            Enumerable.Range(0, count).ToList().ForEach(x => competences.Add(GenerateCompetence(x)));
            return competences;
        }

        public static List<Group> GenerateGroups(int count)
        {
            var groups = new List<Group>();
            Enumerable.Range(0, count).ToList().ForEach(x => groups.Add(GenerateGroup(x)));
            return groups;
        }

        private static Group GenerateGroup(int id)
        {
            count++;
            var competences = new List<Competence>();
            Enumerable.Range(0, 3).ToList().ForEach(x => competences.Add(GenerateCompetence(x + count)));

            return new Group
            {
                Id = id,
                Name = "Name " + id,
                Competences = competences
            };
        }

        private static Competence GenerateCompetence(int id)
        {
            return new Competence { Id = id, Name = "Name " + id };
        }
    }
}
