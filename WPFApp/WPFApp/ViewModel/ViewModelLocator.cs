/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPFApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace WPFApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //ioc����ע��
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SubViewModel>();
            
        }

        //��ǰ����xaml�ļ���cs������ֱ�� DataContext = new MainViewModel();��ʹ��viewmodel������ͳһ���й����ʹ��
        //����ʹ�ã�ֻҪ��xamlǰ����Ӽ���Main
        public MainViewModel Main
        {
            get
            {
                //ͨ��ioc����ע�룬����ʵ��
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SubViewModel Sub
        {
            get
            {
                //ͨ��ioc����ע�룬����ʵ��
                return ServiceLocator.Current.GetInstance<SubViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}