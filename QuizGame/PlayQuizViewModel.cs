using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class PlayQuizViewModel : INotifyPropertyChanged
    {
        public Quiz Quiz { get; set; }
        public Queestion CurrentQuestion { get; set; }
        public int SelectedAnswerIndex { get; set; }
        public int CorrectAnswers { get; set; }
        public int TotalAnswered { get; set; }

        public string ScoreText
        {
            get
            {
                int percent = 0;
                if(TotalAnswered > 0)
                {
                    percent = (int)((double)CorrectAnswers / TotalAnswered * 100);
                }
                return $"Rätt: {CorrectAnswers}/{TotalAnswered} ({percent}%)";
            }
        }


        public PlayQuizViewModel()
        {
            Quiz = new Quiz("TestQuiz");
            Quiz.AddQuestion("Vad heter Svergies huvudstad?", 0, "Stockholm", "Göteborg", "Malmö");
            Quiz.AddQuestion("Vilken färg har himmelen?", 2, "Röd", "Grön", "Blå");
            Quiz.AddQuestion("Hur många ben har en katt?", 1, "5", "4", "75");


            CurrentQuestion = Quiz.GetRandomQuestion();
            SelectedAnswerIndex = -1;
            OnPropertyChanged("CurrentQuestion");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void NextQuestion(int selectedIndex)
        {
            TotalAnswered++;
            if (CurrentQuestion.IsCorrect(selectedIndex))
            {
                CorrectAnswers++;
            }

            CurrentQuestion = Quiz.GetRandomQuestion();
            OnPropertyChanged("CurrentQuestion");
            OnPropertyChanged("ScoreText");

        }
    }
}
