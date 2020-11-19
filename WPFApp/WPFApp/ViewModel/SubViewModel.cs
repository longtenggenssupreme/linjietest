using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFApp.ViewModel
{
    public class SubViewModel : ViewModelBase
    {

        private string title;

        public string Title
        {
            get { return title; }
            set { Set(ref title, value); }
        }

        public ICommand BtnCommand { get; set; }

        public NotificationMessageAction<string> ActionCallBack { get; set; }
        public SubViewModel()
        {
            Title = "初始值";
            BtnCommand = new RelayCommand(SetTitle);
            //Messenger.Default.Register<string>(this, m => Title = m);
            //Messenger.Default.Register<string>(this,"123", m => Title = m);
            Messenger.Default.Register<NotificationMessageAction<string>>(this, "123",
                m =>
                {
                    Title = m.Notification;
                    ActionCallBack = m;
                });

            //MessengerInstance.Register<string>(this, m => Title = m);
            //MessengerInstance.Register<string>(this,"123", m => Title = m);
            //MessengerInstance.Register<NotificationMessageAction<string>>(this, "123",
            //    m =>
            //    {
            //        Title = m.Notification;
            //        ActionCallBack = m;
            //    });            
        }

        public void SetTitle()
        {
            Title = "值已经改变";
            ActionCallBack.Execute($"字串给父窗体的值是：{Title}");
        }

        public void SetTitleCallBack(string changed)
        {
            Title = "值已经改变";
        }
    }
}
