
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
using System.Collections.ObjectModel;

namespace PaavoApp
{
    public partial class StudentUnion : PhoneApplicationPage
    {

        public ObservableCollection<MyListViewModel> MondayList { get; set; }
        public ObservableCollection<MyListViewModel> TuesdayList { get; set; }
        public ObservableCollection<MyListViewModel> WednesdayList { get; set; }
        public ObservableCollection<MyListViewModel> ThursdayList { get; set; }
        public ObservableCollection<MyListViewModel> FridayList { get; set; }

        // Constructor
        public StudentUnion()
        {
            InitializeComponent();
            Loaded += StudentUnionPage_Loaded;
        }

        /// Page loaded.
        void StudentUnionPage_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "http://eatatlut.appspot.com/studentunion";
            LoadSiteContent(url); // Load food info

            string studentunionWebcamURL = "http://ruutcam.lut.fi/yo-talo/webcam.jpg";
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(studentunionWebcamURL), wc);

        }

        // Load food info
        public void LoadSiteContent(string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback2);
            client.DownloadStringAsync(new Uri(url));
        }

        // Load food info
        private void DownloadStringCallback2(Object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {

                MondayList = new ObservableCollection<MyListViewModel>();
                RootObject root = JsonConvert.DeserializeObject<RootObject>((string)e.Result);

                // Monday
                for (int i = 0; i < root.days.monday.Count(); i++)
                {
                    Monday ruoka = root.days.monday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();
                    info.Field2 = ruoka.coursetype;
                    info.Field3 = ruoka.name;

                    // Set price by coursetype
                    if (info.Field2 == "Kokin suositus")
                        info.Field4 = "4.40";
                    else if (info.Field2 == "Kotoisia makuja")
                        info.Field4 = "2.60";
                    else
                        info.Field4 = "9.99";

                    MondayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuMonday.ItemsSource = MondayList;

                // Tuesday
                TuesdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.tuesday.Count(); i++)
                {
                    Tuesday ruoka = root.days.tuesday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Field2 = ruoka.coursetype;
                    info.Field3 = ruoka.name;

                    // Set price by coursetype
                    if (info.Field2 == "Kokin suositus")
                        info.Field4 = "4.40";
                    else if (info.Field2 == "Kotoisia makuja")
                        info.Field4 = "2.60";
                    else
                        info.Field4 = "9.99";

                    TuesdayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuTuesday.ItemsSource = TuesdayList;

                // Wednesday
                WednesdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.wednesday.Count(); i++)
                {
                    Wednesday ruoka = root.days.wednesday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Field2 = ruoka.coursetype;
                    info.Field3 = ruoka.name;

                    // Set price by coursetype
                    if (info.Field2 == "Kokin suositus")
                        info.Field4 = "4.40";
                    else if (info.Field2 == "Kotoisia makuja")
                        info.Field4 = "2.60";
                    else
                        info.Field4 = "9.99";

                    WednesdayList.Add(info);
                    MenuWednesday.ItemsSource = WednesdayList;
                }
                // Bind data to Listbox outside of loop
                MenuWednesday.ItemsSource = WednesdayList;

                // Thursday
                ThursdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.thursday.Count(); i++)
                {
                    Thursday ruoka = root.days.thursday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Field2 = ruoka.coursetype;
                    info.Field3 = ruoka.name;

                    // Set price by coursetype
                    if (info.Field2 == "Kokin suositus")
                        info.Field4 = "4.40";
                    else if (info.Field2 == "Kotoisia makuja")
                        info.Field4 = "2.60";
                    else
                        info.Field4 = "9.99";

                    ThursdayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuThursday.ItemsSource = ThursdayList;


                // Friday
                FridayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.friday.Count(); i++)
                {
                    Friday ruoka = root.days.friday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Field2 = ruoka.coursetype;
                    info.Field3 = ruoka.name;

                    // Set price by coursetype
                    if (info.Field2 == "Kokin suositus")
                        info.Field4 = "4.40";
                    else if (info.Field2 == "Kotoisia makuja")
                        info.Field4 = "2.60";
                    else
                        info.Field4 = "9.99";

                    FridayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuFriday.ItemsSource = FridayList;
            }
        }

        // Background from webcam
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

        // Entity for Data 
        public class MyListViewModel
        {
            public string Field2 { get; set; }

            public string Field3 { get; set; }

            public string Field4 { get; set; }

        }
    }
}