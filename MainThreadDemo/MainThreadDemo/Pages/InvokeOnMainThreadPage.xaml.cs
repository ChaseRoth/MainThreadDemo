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
    public partial class InvokeOnMainThreadPage : ContentPage
    {
        public InvokeOnMainThreadPage()
        {
            InitializeComponent();
        }

        private async void OnStartWork(object sender, EventArgs e)
        {
            await DoWorkIncorrectly();
            //await DoWorkCorrectly();
        }

        /// <summary>
        ///     An example of attempting to manipulate a view from a different thread incorrectly.
        /// </summary>
        private async Task DoWorkIncorrectly()
        {
            await Task.Run(() =>
            {
                // Simulating work to be done
                Task.Delay(2000).Wait();
                // Assigning a new text value to the UIField.Text property on another thread.
                UIField.Text = "New Value";
            }); 
        }

        /// <summary>
        ///     An example of attempting to manipulate a view from a different thread correctly (uses MainThread).
        /// </summary>
        private async Task DoWorkCorrectly()
        {
            await Task.Run(() =>
            {
                // Simulating work to be done
                Task.Delay(2000).Wait();
                // Using MainThreads function to safely run code on the main thread.
                MainThread.BeginInvokeOnMainThread(() => UIField.Text = "New Value");                
            });
        }
    }    
}