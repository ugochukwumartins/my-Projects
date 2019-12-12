using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;
using Timer = System.Timers.Timer;

namespace GussingGame.Models
{
    class GuessModel : INotifyPropertyChanged
    {
        Random random = new Random();
        private int _Hours;
        private int _Minutes;
        private int _Secons;
        private string _Display;
        public string Displays { get { return _Display; } set { _Display = value; OnPropertyChange(); } }
        public int Hours { get { return _Hours; } set { _Hours = value; OnPropertyChange(); } }
        public int Minutes { get { return _Minutes; } set { _Minutes = value; OnPropertyChange(); } }
        public int Secons { get { return _Secons; } set { _Secons = value; OnPropertyChange(); } }
        public string Display {  get { return _Display; }  set { _Display = value; OnPropertyChange(); } }



        // private Timer _time = new Timer();
        public Stopwatch stopwatch = new Stopwatch();

        public ICommand button { get; private set; }

        public ICommand button2 { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public GuessModel()
        {
            button = new Command(Start);
            button2 = new Command(Stop);
        }


        public void Start()
        {


            timer();



        }


        private void timer()
        {

            stopwatch.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Hours = stopwatch.Elapsed.Hours;
                Minutes = stopwatch.Elapsed.Minutes;
                Secons = stopwatch.Elapsed.Seconds;
                Secons++;

                if (Secons == 60)
                {
                    Minutes++;
                    Secons = 0;
                }
                if (Minutes == 60)
                {
                    Hours++;
                    Minutes = 0;

                }


                return true;
            });
        }


        public void Stop()
        {


            Stoper();



        }

        private void Stoper()
        {
            int _check = Convert.ToInt32(_Display);
            int check = random.Next(1, 100);
            if(_check < check) { 
           //  stopwatch.Stop();
            Display =$"the Number :{ _Display} is less than the guess";
            }

            if (_check > check)
            {
              //  stopwatch.Stop();
                Display = $"the Number :{ _Display} is greater than the guess";
            }

            if (_check == check)
            {
              
                Display = $"the Number :{ _Display} is equal to the guess number: {check}   Congratulatons You won ";
                stopwatch.Stop();
                stopwatch.Reset();
            }
            if (Minutes == 2) {

                Display = $"Sorry You lost Time Up";
                 stopwatch.Stop();
                stopwatch.Reset();

            }
                


        }


    }
}
