using Questionario.Common;
using Questionario.Core;
using Questionario.Helpers;
using System.Collections.ObjectModel;

namespace Questionario.ViewModels
{
    internal class QuestionViewModel : ViewModelBase
    {
        private readonly Question question = new Question();

        public QuestionViewModel()
        {
            Answers = new ObservableCollection<AnswerViewModel>();
        }
        public QuestionViewModel(int id, string? description, ObservableCollection<AnswerViewModel>? answers)
        {
            Id = id;
            Description = description;
            Answers = answers;
        }

        public int Id 
        {
            get { return question.Id; }
            set { 
                question.Id = value; 
                OnPropertyChanged();
            } 
        }
        public string? Description 
        {
            get { return question.Description; }
            set
            {
                question.Description = value;
                OnPropertyChanged();
            }
        }

        public string RadioGroupName
        {
            get { return question.Id.ToString(); }
        }
      
        private ObservableCollection<AnswerViewModel> answers;
        public ObservableCollection<AnswerViewModel>? Answers
        {
            get
            {
                return answers;
            }
            private set 
            {
                answers = value;
                OnPropertyChanged();
            }
        }
    }
}
