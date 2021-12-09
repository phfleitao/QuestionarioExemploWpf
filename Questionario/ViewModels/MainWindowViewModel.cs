using Questionario.Common;
using Questionario.Helpers;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace Questionario.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionViewModel> Questions { get; set; }

        private string itensSelecionados;
        public string ItensSelecionados 
        {
            get 
            {
                return itensSelecionados;
            }
            set
            {
                itensSelecionados = value;
                OnPropertyChanged();
            } 
        }

        public MainWindowViewModel()
        {
            Questions = new ObservableCollection<QuestionViewModel>();
            var quiz = QuizHelper.CreateQuizViewModel();
            Questions = quiz;
        }

        private CommandHandler onClick_MostrarSelecionados;
        public CommandHandler OnClick_MostrarSelecionados
        {
            get
            {
                if (this.onClick_MostrarSelecionados == null)
                    this.onClick_MostrarSelecionados = new CommandHandler(param => MostrarSelecionados());

                return this.onClick_MostrarSelecionados;
            }
            set
            {
                this.onClick_MostrarSelecionados = value;
            }
        }
        public void MostrarSelecionados()
        {
            var msgBuilder = new StringBuilder();

            var selecionados = Questions
                .SelectMany(q => q.Answers)
                .Where(w => w.IsSelected);

            foreach (var item in selecionados)
            {
                msgBuilder.AppendLine(item.Description);
            }

            //MessageBox.Show(msgBuilder.ToString());
            ItensSelecionados = msgBuilder.ToString();
        }
    }
}
