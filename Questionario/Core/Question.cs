using System.Collections.Generic;

namespace Questionario.Core
{
    internal class Question
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public List<Answer> Answers { get; set; }

        public Question()
        {
            Answers = new List<Answer>();
        }
        public Question(int id, string? description, List<Answer> answers)
        {
            Id = id;
            Description = description;
            Answers = answers;
        }
    }
}
