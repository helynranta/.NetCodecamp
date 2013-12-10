using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;
//

namespace PaavoApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void WeatherTap(object sender, GestureEventArgs e)
        {
            Homo.Text = "Loading";
            string url = "http://eatatlut.appspot.com/studentunion";
            LoadSiteContent(url);

            string img_url = "http://ruutcam.lut.fi/yo-talo/webcam.jpg";
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(img_url), wc);  


        }
        void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                BitmapImage image = new BitmapImage();
                image.SetSource(e.Result);
                ImageBrush background = new ImageBrush();
                background.ImageSource = image;
                LayoutRoot.Background = background;
            }
            else
            {
                //Either cancelled or error handle appropriately for your app  
            }
        }
        public void LoadSiteContent(string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback2);
            client.DownloadStringAsync(new Uri(url));
        }

        private void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            { 
                RootObject root = JsonConvert.DeserializeObject<RootObject>((string)e.Result);
                Homo.Text = "";
                if (root.days.monday.ElementAt(0).name != "None")
                {
                    Homo.Text += "Maanantai:\n";
                    for (int i = 0; i < root.days.monday.Count(); i++)
                    {
                        Monday ruoka = root.days.monday.ElementAt(i);
                        Homo.Text += ruoka.coursetype + ":\n" + ruoka.name + "\n";
                    }
                }
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
                    Homo.Text += "Tiistai:\n";
                    for (int i = 0; i < root.days.tuesday.Count(); i++)
                    {
                        Tuesday ruoka = root.days.tuesday.ElementAt(i);
                        Homo.Text += ruoka.coursetype + ":\n" + ruoka.name + "\n";
                    }
                }
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
                    Homo.Text += "Keskiviikko:\n";
                    for (int i = 0; i < root.days.wednesday.Count(); i++)
                    {
                        Wednesday ruoka = root.days.wednesday.ElementAt(i);
                        Homo.Text += ruoka.coursetype + ":\n" + ruoka.name + "\n";
                    }
                }
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
                    Homo.Text += "Torstai:\n";
                    for (int i = 0; i < root.days.thursday.Count(); i++)
                    {
                        Thursday ruoka = root.days.thursday.ElementAt(i);
                        Homo.Text += ruoka.coursetype + ":\n" + ruoka.name + "\n";
                    }
                }
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
                    Homo.Text += "Perjantai:\n";
                    for (int i = 0; i < root.days.friday.Count(); i++)
                    {
                        Friday ruoka = root.days.friday.ElementAt(i);
                        Homo.Text += ruoka.coursetype + ":\n" + ruoka.name + "\n";
                    }
                }
            }
        }
    }
}