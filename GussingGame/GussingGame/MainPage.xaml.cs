using GussingGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Timers;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GussingGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        Random random = new Random();
        private int _Hours;
        private int _Minutes;
        private int _Secons;
        private int _Display;
        int v;
        public int Displays { get { return _Display; } set { _Display = value; OnPropertyChange(); } }
        public int Hours { get { return _Hours; } set { _Hours = value; OnPropertyChange(); } }
        public int Minutes { get { return _Minutes; } set { _Minutes = value; OnPropertyChange(); } }
        public int Secons { get { return _Secons; } set { _Secons = value; OnPropertyChange(); } }
        public string Display;// { get { return _Display; } set { _Display = value; OnPropertyChange(); } }
        public Stopwatch stopwatch = new Stopwatch();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainPage()
        {
            InitializeComponent();

          

          
        }

        private void Start_Clicked(object sender, EventArgs e)
        {
            stopwatch.Start();
            int check = random.Next(1, 1000);
            v = check;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Hours = stopwatch.Elapsed.Hours;
                hours.Text = Convert.ToString(Hours);
               Minutes = stopwatch.Elapsed.Minutes;
                minutes.Text = Convert.ToString(Minutes);
                Secons = stopwatch.Elapsed.Seconds;
                secons.Text= Convert.ToString(Secons);
                Secons++;

                if (Secons == 60)
                {
                    Minutes++;
                    Secons = 0;
                }
                if (Minutes == 5)
                {
                    Minutes = 0;
                    stopwatch.Stop();
                    stopwatch.Reset();
                    Display = $"Sorry You lost Time Up";
                    // Minutes = 0;
                    btn1.IsEnabled = true;
                    entry.Text = null;
                }

                display.Text = Display;
                return true;
            });
            btn1.IsEnabled = false;
        }
       
        private void Check_Clicked_1(object sender, EventArgs e)
        {
            if (entry.Text != null)
            {
                Displays = Convert.ToInt32(entry.Text);
                // int _check = Convert.ToInt32(_Display);

                if (_Display < v)
                {
                    //  stopwatch.Stop();
                    Display = $"the Number :{ _Display} is less than the guess";
                }

                if (_Display > v)
                {
                    //  stopwatch.Stop();
                    Display = $"the Number :{ _Display} is greater than the guess";
                }

                if (_Display == v)
                {

                    Display = $"the Number :{ _Display} is equal to the guess number:{v} Congratulatons You won ";
                    stopwatch.Stop();
                    stopwatch.Reset();
                    entry.Text = null;
                    btn1.IsEnabled = true;
                }
                else
                {

                    /// Display = $"Sorry You lost Time Up";
                    // stopwatch.Stop();
                    //  stopwatch.Reset();
                    //  entry.Text = null;
                    //  btn1.IsEnabled = true;
                }

                display.Text = Display;

            }
        }
    }
}
