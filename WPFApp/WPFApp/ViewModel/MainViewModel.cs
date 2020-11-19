using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        //public MainViewModel()
        //{
        //    ////if (IsInDesignMode)
        //    ////{
        //    ////    // Code runs in Blend --> create design time data.
        //    ////}
        //    ////else
        //    ////{
        //    ////    // Code runs "for real"
        //    ////}
        //}

        private string title;

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        public ICommand ChangeTitleCommand { get; set; }

        public ICommand SubCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Title = "Hello World，你好这个是默认值";
            ChangeTitleCommand = new RelayCommand(ChangeTitle);
            SubCommand = new RelayCommand(ShowSub);
        }

        private void ChangeTitle()
        {
            Title = "Hello MvvmLight，这是修改以后的值";
        }

        private void ShowSub()
        {
            new Window1().Show();
            //发送给消息
            //Messenger.Default.Send<string>("随即消息");
            //Messenger.Default.Send<string>("a哈哈哈", "123");
            //Messenger.Default.Send<NotificationMessageAction<string>>(new NotificationMessageAction<string>("这是父传给子的消息", m => Title = m), "123");

            //MessengerInstance.Send<string>("随即消息");
            //MessengerInstance.Send<string>("a哈哈哈", "123");
            MessengerInstance.Send<NotificationMessageAction<string>>(new NotificationMessageAction<string>("这是父传给子的消息", m => Title = m), "123");

            
        }
    }
}