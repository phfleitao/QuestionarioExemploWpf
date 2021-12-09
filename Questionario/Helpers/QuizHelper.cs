using Questionario.Core;
using Questionario.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionario.Helpers
{
    internal static class QuizHelper
    {
        /// <summary>
        /// Quiz centralizado
        /// </summary>
        private static List<Question> quizBase => new List<Question>()
        {
            new Question(1, "Pergunta 1", new List<Answer>()
                {
                    new Answer(1, "Resposta 1.1"),
                    new Answer(2, "Resposta 1.2")
                }),
            new Question(2, "Pergunta 2", new List<Answer>()
                {
                    new Answer(1, "Resposta 2.1"),
                    new Answer(2, "Resposta 2.2"),
                    new Answer(3, "Resposta 2.3")
                }),
            new Question(3, "Pergunta 3", new List<Answer>()
                {
                    new Answer(1, "Resposta 3.1"),
                    new Answer(2, "Resposta 3.2"),
                    new Answer(3, "Resposta 3.3"),
                    new Answer(4, "Resposta 3.4")
                })
        };

        /// <summary>
        /// Mock das informações pelo core
        /// </summary>
        /// <returns>Lista de Perguntas e respostas com base nas Models</returns>
        public static List<Question> CreateQuizModel()
        {
            var quiz = new List<Question>();

            foreach (var question in quizBase)
            {
                var answers = new List<Answer>();
                foreach (var answer in question.Answers)
                {
                    answers.Add(new Answer(answer.Id, answer.Description));
                }
                quiz.Add(new Question(question.Id, question.Description, answers));
            }

            return quiz;
        }

        /// <summary>
        /// Mock das informações pelo front
        /// </summary>
        /// <returns>Lista de Perguntas e respostas com base nas ViewModels</returns>
        public static ObservableCollection<QuestionViewModel> CreateQuizViewModel()
        {
            var quiz = new ObservableCollection<QuestionViewModel>();

            foreach (var question in quizBase)
            {
                var answers = new ObservableCollection<AnswerViewModel>();
                foreach (var answer in question.Answers)
                {
                    answers.Add(new AnswerViewModel(answer.Id, answer.Description));
                }
                quiz.Add(new QuestionViewModel(question.Id, question.Description, answers));
            }

            return quiz;
        }

        public static List<Question>? MapToModel(this ObservableCollection<QuestionViewModel> questions)
        {
            var mappedQuiz = new List<Question>();

            foreach (var question in questions)
            {
                var mappedAnswers = new List<Answer>();
                if(question?.Answers != null)
                {
                    foreach (var answer in question.Answers)
                    {
                        mappedAnswers.Add(new Answer(answer.Id, answer.Description));
                    }
                }
                mappedQuiz.Add(new Question(question.Id, question.Description, mappedAnswers));
            }

            return mappedQuiz;
        }

        public static ObservableCollection<QuestionViewModel>? MapToViewModel(this List<Question> questions)
        {
            var mappedQuiz = new ObservableCollection<QuestionViewModel>();

            foreach (var question in questions)
            {
                var mappedAnswers = new ObservableCollection<AnswerViewModel>();
                foreach (var answer in question.Answers)
                {
                    mappedAnswers.Add(new AnswerViewModel(answer.Id, answer.Description));
                }
                mappedQuiz.Add(new QuestionViewModel(question.Id, question.Description, mappedAnswers));
            }

            return mappedQuiz;
        }

        public static List<Answer>? MapToModel(this ObservableCollection<AnswerViewModel> answers)
        {
            var mappedAnswers = new List<Answer>();
            foreach (var answer in answers)
            {
                mappedAnswers.Add(new Answer(answer.Id, answer.Description));
            }
            return mappedAnswers;
        }

        public static ObservableCollection<AnswerViewModel>? MapToViewModel(this List<Answer> answers)
        {
            var mappedAnswers = new ObservableCollection<AnswerViewModel>();
            foreach (var answer in answers)
            {
                mappedAnswers.Add(new AnswerViewModel(answer.Id, answer.Description));
            }
            return mappedAnswers;
        }
    }
}
