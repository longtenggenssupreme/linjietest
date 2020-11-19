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
            Title = "Hello World����������Ĭ��ֵ";
            ChangeTitleCommand = new RelayCommand(ChangeTitle);
            SubCommand = new RelayCommand(ShowSub);
        }

        private void ChangeTitle()
        {
            Title = "Hello MvvmLight�������޸��Ժ��ֵ";
        }

        private void ShowSub()
        {
            new Window1().Show();
            //���͸���Ϣ
            //Messenger.Default.Send<string>("�漴��Ϣ");
            //Messenger.Default.Send<string>("a������", "123");
            //Messenger.Default.Send<NotificationMessageAction<string>>(new NotificationMessageAction<string>("���Ǹ������ӵ���Ϣ", m => Title = m), "123");

            //MessengerInstance.Send<string>("�漴��Ϣ");
            //MessengerInstance.Send<string>("a������", "123");
            MessengerInstance.Send<NotificationMessageAction<string>>(new NotificationMessageAction<string>("���Ǹ������ӵ���Ϣ", m => Title = m), "123");

            
        }
    }
}