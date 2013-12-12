
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
    public partial class Kurniekka : PhoneApplicationPage
    {

        public ObservableCollection<MyListViewModel> MondayList { get; set; }
        public ObservableCollection<MyListViewModel> TuesdayList { get; set; }
        public ObservableCollection<MyListViewModel> WednesdayList { get; set; }
        public ObservableCollection<MyListViewModel> ThursdayList { get; set; }
        public ObservableCollection<MyListViewModel> FridayList { get; set; }

        public Kurniekka()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        /// Page loaded.
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {

            string url = "http://eatatlut.appspot.com/kurniekka";
            LoadSiteContent(url); // Load food info

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
                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;

                    // Set price by coursetype
                    if (info.Type == "Kokin suositus")
                        info.Price = "4.40";
                    else if (info.Type == "Kotoisia makuja")
                        info.Price = "2.60";
                    else if (info.Type == "Kasvisherkkuja")
                        info.Price = "2.20";
                    else if (info.Type == "Soppaa")
                        info.Price = "2.20";
                    else if (info.Type == "Kevytkeitto")
                        info.Price = "1.10";
                    else if (info.Type == "Salaattilounas")
                        info.Price = "2.60";
                    else if (info.Type == "Jälkiruoka")
                        info.Price = "0.50";
                    else
                        info.Price = "1 bil dollars!";

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

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;

                    // Set price by coursetype
                    if (info.Type == "Kokin suositus")
                        info.Price = "4.40";
                    else if (info.Type == "Kotoisia makuja")
                        info.Price = "2.60";
                    else if (info.Type == "Kasvisherkkuja")
                        info.Price = "2.20";
                    else if (info.Type == "Soppaa")
                        info.Price = "2.20";
                    else if (info.Type == "Kevytkeitto")
                        info.Price = "1.10";
                    else if (info.Type == "Salaattilounas")
                        info.Price = "2.60";
                    else if (info.Type == "Jälkiruoka")
                        info.Price = "0.50";
                    else
                        info.Price = "1 bil dollars!";

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

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;

                    // Set price by coursetype
                    if (info.Type == "Kokin suositus")
                        info.Price = "4.40";
                    else if (info.Type == "Kotoisia makuja")
                        info.Price = "2.60";
                    else if (info.Type == "Kasvisherkkuja")
                        info.Price = "2.20";
                    else if (info.Type == "Soppaa")
                        info.Price = "2.20";
                    else if (info.Type == "Kevytkeitto")
                        info.Price = "1.10";
                    else if (info.Type == "Salaattilounas")
                        info.Price = "2.60";
                    else if (info.Type == "Jälkiruoka")
                        info.Price = "0.50";
                    else
                        info.Price = "1 bil dollars!";

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

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;

                    // Set price by coursetype
                    if (info.Type == "Kokin suositus")
                        info.Price = "4.40";
                    else if (info.Type == "Kotoisia makuja")
                        info.Price = "2.60";
                    else if (info.Type == "Kasvisherkkuja")
                        info.Price = "2.20";
                    else if (info.Type == "Soppaa")
                        info.Price = "2.20";
                    else if (info.Type == "Kevytkeitto")
                        info.Price = "1.10";
                    else if (info.Type == "Salaattilounas")
                        info.Price = "2.60";
                    else if (info.Type == "Jälkiruoka")
                        info.Price = "0.50";
                    else
                        info.Price = "1 bil dollars!";

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

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;

                    // Set price by coursetype
                    if (info.Type == "Kokin suositus")
                        info.Price = "4.40";
                    else if (info.Type == "Kotoisia makuja")
                        info.Price = "2.60";
                    else if (info.Type == "Kasvisherkkuja")
                        info.Price = "2.20";
                    else if (info.Type == "Soppaa")
                        info.Price = "2.20";
                    else if (info.Type == "Kevytkeitto")
                        info.Price = "1.10";
                    else if (info.Type == "Salaattilounas")
                        info.Price = "2.60";
                    else if (info.Type == "Jälkiruoka")
                        info.Price = "0.50";
                    else
                        info.Price = "1 bil dollars!";

                    FridayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuFriday.ItemsSource = FridayList;
            }
        }

        // Entity for Data 
        public class MyListViewModel
        {
            public string Type { get; set; }

            public string Description { get; set; }

            public string Price { get; set; }

        }
    }
}