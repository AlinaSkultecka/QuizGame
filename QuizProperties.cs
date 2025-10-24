using QuizGame.QuestionsFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizGame
{
    public class Quiz
    {
        public string Title { get; set; }
        public List<QuestionProperties> Questions { get; set; }
        private Random Randomizer { get; set; }

        public Quiz(string title = "")
        {
            Title = title;
            Questions = new List<QuestionProperties>();
            Randomizer = new Random();
        }

        public QuestionProperties GetRandomQuestion()
        {
            if (Questions.Count == 0)
                return null;

            int index = Randomizer.Next(Questions.Count);
            return Questions[index];
        }

        public void AddQuestion(string questionText, int correctAnswerIndex, string category, params string[] answers)
        {
            var newQuestion = new QuestionProperties(
                id: Questions.Count + 1,
                category: category,
                questionText: questionText,
                correctAnswerIndex: correctAnswerIndex,
                answers: answers
            );

            Questions.Add(newQuestion);
        }

        public void RemoveQuestion(int index)
        {
            if (index >= 0 && index < Questions.Count)
            {
                Questions.RemoveAt(index);
            }
        }

        public int GetCorrectAnswerCount(List<int> selectedAnswers)
        {
            int count = 0;
            for (int i = 0; i < Math.Min(Questions.Count, selectedAnswers.Count); i++)
            {
                if (Questions[i].IsCorrect(selectedAnswers[i]))
                    count++;
            }
            return count;
        }

        public double GetScorePercentage(List<int> selectedAnswers)
        {
            if (Questions.Count == 0) return 0;
            return (double)GetCorrectAnswerCount(selectedAnswers) / Questions.Count * 100.0;
        }
    }
}
