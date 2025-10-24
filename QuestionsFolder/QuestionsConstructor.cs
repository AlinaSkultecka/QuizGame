using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizGame.QuestionsFolder
{
    public class QuestionsConstructor
    {
        public List<QuestionProperties> Questions { get; private set; } = new List<QuestionProperties>();
        private readonly string filePath;

        public QuestionsConstructor(string customPath = null)
        {
            // Use passed-in path or fallback to default
            filePath = customPath ?? Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "QuizGame", "QuestionsEnglish.json"
            );

            LoadQuestionsFromFile();
        }

        private void LoadQuestionsFromFile()
        {
            if (!File.Exists(filePath))
                return;

            try
            {
                string json = File.ReadAllText(filePath);
                var loadedQuestions = JsonSerializer.Deserialize<List<QuestionProperties>>(json);
                if (loadedQuestions != null)
                    Questions = loadedQuestions;
            }
            catch (JsonException ex)
            {
                System.Console.WriteLine("Error parsing questions JSON: " + ex.Message);
            }
        }

        public void SaveQuestionsToFile()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(Questions, options);

                // Ensure directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                File.WriteAllText(filePath, json);
            }
            catch (IOException ex)
            {
                System.Console.WriteLine("Error saving questions to file: " + ex.Message);
            }
        }
    }
}