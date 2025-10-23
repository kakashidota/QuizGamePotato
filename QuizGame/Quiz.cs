using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Quiz
    {
        public string Title { get; set; }
        public List<Queestion> Questions { get; set; }
        public Random Randomizer { get; set; }



        public Quiz(string title = "")
        {
            Title = title;
            Questions = new List<Queestion>();
            Randomizer = new Random();
        }

        public Queestion GetRandomQuestion()
        {
            if(Questions.Count == 0)
            {
                throw new InvalidOperationException("No questions available");
            }

            int index = Randomizer.Next(0, Questions.Count);
            return Questions[index];
        }

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            Queestion q = new Queestion(statement, correctAnswer, answers);
            Questions.Add(q);
        }

        public void RemoveQuestion(int index)
        {

        }
    }
}
