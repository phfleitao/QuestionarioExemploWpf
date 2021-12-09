using Questionario.Common;
using Questionario.Core;

namespace Questionario.ViewModels
{
    internal class AnswerViewModel : ViewModelBase
    {
        private readonly Answer answer = new Answer();

        public AnswerViewModel(){ }
        public AnswerViewModel(int id, string? description)
        {
            Id = id;
            Description = description;
        }

        public int Id 
        {
            get { return answer.Id; }
            set { 
                answer.Id = value; 
                OnPropertyChanged();
            } 
        }
        public string? Description 
        {
            get { return answer.Description; }
            set
            {
                answer.Description = value;
                OnPropertyChanged();
            }
        }

        private bool isSelected;
        public bool IsSelected 
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }
    }
}
