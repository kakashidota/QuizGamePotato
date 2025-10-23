using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Queestion
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; set; }


        public Queestion(string statement, int correctAnswer, params string[] answers)
        {
            Statement = statement;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public bool IsCorrect(int selectedIndex)
        {
            return selectedIndex == CorrectAnswer;
        }
    }


}
