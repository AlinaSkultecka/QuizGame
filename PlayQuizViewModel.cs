using QuizGame.QuestionsFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public class PlayQuizViewModel
    {
        public List<QuestionProperties> Questions { get; set; } = new();
        public QuestionProperties CurrentQuestion { get; set; }
        public int CurrentIndex { get; set; } = 0;

        public void LoadQuestions(List<QuestionProperties> questions)
        {
            Questions = questions;
            CurrentIndex = 0;
            if (Questions.Count > 0)
            {
                CurrentQuestion = Questions[0];
            }
        }

        public void NextQuestion()
        {
            if (CurrentIndex + 1 < Questions.Count)
            {
                CurrentIndex++;
                CurrentQuestion = Questions[CurrentIndex];
            }
        }

        public bool CheckAnswer(int selectedIndex)
        {
            return CurrentQuestion?.IsCorrect(selectedIndex) ?? false;
        }
    }
}
