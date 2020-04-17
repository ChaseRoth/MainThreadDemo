using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MainThreadDemo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetMainThreadSynchronizationContextAsyncPage : ContentPage
    {
        public GetMainThreadSynchronizationContextAsyncPage()
        {
            InitializeComponent();

            var test1 = MainThread.GetMainThreadSynchronizationContextAsync();

            OnDoWork();            

            Console.WriteLine();

            OnDoWork();
        }

        private async void OnDoWork() => await DoWork();

        private async Task DoWork()
        {
            await Task.Run(() =>
            {
                var test2 = MainThread.GetMainThreadSynchronizationContextAsync();

                Console.WriteLine();
            });
        }
    }
}