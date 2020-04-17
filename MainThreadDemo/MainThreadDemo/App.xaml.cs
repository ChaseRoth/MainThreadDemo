using MainThreadDemo.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MainThreadDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MasterTabbedPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
