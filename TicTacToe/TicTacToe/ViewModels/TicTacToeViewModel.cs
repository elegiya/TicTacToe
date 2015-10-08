using Acr.UserDialogs;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.Services;
using Xamarin.Forms;

namespace TicTacToe.ViewModels
{
    public class TicTacToeViewModel : BaseViewModel
    {
        private readonly ISetSymbolService _service;

        private bool? _leftTop;
        private bool? _centerTop;
        private bool? _rightTop;

        private bool? _leftCenter;
        private bool? _centerCenter;
        private bool? _centerRight;

        private bool? _leftDown;
        private bool? _centerDown;
        private bool? _rightDown;

        private readonly bool? isTic;

        public TicTacToeViewModel()
        {
            _service = new SetSymbolService();

            this.ChooseSymbolCommand = new Command<string>((key) =>
            {
                ChooseActionAsync();
            });
        }

        public ICommand ChooseSymbolCommand { protected set; get; }

        //public string LeftTop
        //{
        //    get { return _leftTop; }
        //    set
        //    {
        //        if (_previousSymbol != value)
        //        {
        //            _previousSymbol = value;
        //            OnPropertyChanged("LeftTop");
        //        }
        //    }
        //}

        private async Task ChooseActionAsync(string title = "Choose your symbol", string cancel = "Are you sure you want to exit?", string destructive="")
        {
            await UserDialogs.Instance?.ActionSheetAsync(title, cancel, destructive, "x", "o"); 
        }
    }
}
