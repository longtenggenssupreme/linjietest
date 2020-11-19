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

            //ioc容器注册
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SubViewModel>();
            
        }

        //以前是在xaml文件的cs代码中直接 DataContext = new MainViewModel();来使用viewmodel，现在统一进行管理和使用
        //现在使用，只要在xaml前端添加即可Main
        public MainViewModel Main
        {
            get
            {
                //通过ioc依赖注入，创建实例
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public SubViewModel Sub
        {
            get
            {
                //通过ioc依赖注入，创建实例
                return ServiceLocator.Current.GetInstance<SubViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}