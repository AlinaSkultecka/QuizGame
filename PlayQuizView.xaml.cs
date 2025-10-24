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
    public partial class PlayQuizView : UserControl
    {
        public PlayQuizViewModel ViewModel { get; set; }

        public PlayQuizView()
        {
            InitializeComponent();

            // Initialize ViewModel and assign to DataContext
            ViewModel = new PlayQuizViewModel();
            this.DataContext = ViewModel;

            // Optionally load questions from file here
            var constructor = new QuestionsFolder.QuestionsConstructor();  
            ViewModel.LoadQuestions(constructor.Questions);
        }
    }
}
