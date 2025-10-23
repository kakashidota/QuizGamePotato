using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizGame
{
    /// <summary>
    /// Interaction logic for PlayQuizView.xaml
    /// </summary>
    public partial class PlayQuizView : UserControl
    {
        public PlayQuizViewModel ViewModel { get; set; }
        public PlayQuizView()
        {
            InitializeComponent();
            ViewModel = new PlayQuizViewModel();
            DataContext = ViewModel;
        }

        public void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int selectedIndex = int.Parse(button.Tag.ToString());
            ViewModel.SelectedAnswerIndex = selectedIndex;
        }

        public void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.NextQuestion();
        }
    }
}
