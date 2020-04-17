using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace MainThreadDemo
{
    public class InvokeOnMainThreadGenericsFunc
    {
        public bool State { get; set; }

        // Parent class
        public class Animal { }

        // Child class
        public class Dog : Animal { }

        // Child class
        public class Cat : Animal { }


        // Function that is running on the background
        private void DoWorkOnBackgroundThread()
        {
            MainThread.InvokeOnMainThreadAsync<Animal>(() =>
            {
                if (State)
                {
                    return new Dog();
                }
                else
                {         
                    return new Cat();
                }
            });            
        }
    }
}
