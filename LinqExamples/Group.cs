using System.Collections.Generic;

namespace LinqExamples
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Competence> Competences { get; set; }
    }
}
