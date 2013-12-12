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
    public partial class CampusSodexo : PhoneApplicationPage
    {
        public CampusSodexo()
        {
            InitializeComponent();

            string url = "http://eatatlut.appspot.com/campus";
            LoadSiteContent(url); // Load food info

        }

        public ObservableCollection<MyListViewModel> UniMondayList { get; set; }
        public ObservableCollection<MyListViewModel> UniTuesdayList { get; set; }
        public ObservableCollection<MyListViewModel> UniWednesdayList { get; set; }
        public ObservableCollection<MyListViewModel> UniThursdayList { get; set; }
        public ObservableCollection<MyListViewModel> UniFridayList { get; set; }

        // Load food info
        public void LoadSiteContent(string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCallback);
            client.DownloadStringAsync(new Uri(url));
        }

        // Load food info
        private void DownloadStringCallback(Object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {

                UniMondayList = new ObservableCollection<MyListViewModel>();
                UniRootObject root = JsonConvert.DeserializeObject<UniRootObject>((string)e.Result);

                // Monday
                for (int i = 0; i < root.days.monday.Count(); i++)
                {
                    UniMonday ruoka = root.days.monday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();
                    info.Type = ruoka.category;
                    info.Description = ruoka.title_fi;

                    // Set price by coursetype
                    if (info.Type == "Soup")
                        info.Price = "0.99";
                    else if (info.Type == "Vegetarian")
                        info.Price = "1.77";
                    else if (info.Type == "Scandinavian")
                        info.Price = "1.77";
                    else if (info.Type == "Global")
                        info.Price = "1.77";
                    else if (info.Type == "Special")
                        info.Price = "4.17";
                    else if (info.Type == "Salad garden")
                        info.Price = "2.30";
                    else if (info.Type == "Salad garden & Soup")
                        info.Price = "2.60";
                    else
                        info.Price = "1 bil dollars!";

                    UniMondayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuMonday.ItemsSource = UniMondayList;

                // Tuesday
                UniTuesdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.tuesday.Count(); i++)
                {
                    UniTuesday ruoka = root.days.tuesday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Type = ruoka.category;
                    info.Description = ruoka.title_fi;

                    // Set price by coursetype
                    if (info.Type == "Soup")
                        info.Price = "0.99";
                    else if (info.Type == "Vegetarian")
                        info.Price = "1.77";
                    else if (info.Type == "Scandinavian")
                        info.Price = "1.77";
                    else if (info.Type == "Global")
                        info.Price = "1.77";
                    else if (info.Type == "Special")
                        info.Price = "4.17";
                    else if (info.Type == "Salad garden")
                        info.Price = "2.30";
                    else if (info.Type == "Salad garden & Soup")
                        info.Price = "2.60";
                    else
                        info.Price = "1 bil dollars!";

                    UniTuesdayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuTuesday.ItemsSource = UniTuesdayList;

                // Wednesday
                UniWednesdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.wednesday.Count(); i++)
                {
                    UniWednesday ruoka = root.days.wednesday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Type = ruoka.category;
                    info.Description = ruoka.title_fi;

                    // Set price by coursetype
                    if (info.Type == "Soup")
                        info.Price = "0.99";
                    else if (info.Type == "Vegetarian")
                        info.Price = "1.77";
                    else if (info.Type == "Scandinavian")
                        info.Price = "1.77";
                    else if (info.Type == "Global")
                        info.Price = "1.77";
                    else if (info.Type == "Special")
                        info.Price = "4.17";
                    else if (info.Type == "Salad garden")
                        info.Price = "2.30";
                    else if (info.Type == "Salad garden & Soup")
                        info.Price = "2.60";
                    else
                        info.Price = "1 bil dollars!";

                    UniWednesdayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuWednesday.ItemsSource = UniWednesdayList;

                // Thursday
                UniThursdayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.thursday.Count(); i++)
                {
                    UniThursday ruoka = root.days.thursday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Type = ruoka.category;
                    info.Description = ruoka.title_fi;

                    // Set price by coursetype
                    if (info.Type == "Soup")
                        info.Price = "0.99";
                    else if (info.Type == "Vegetarian")
                        info.Price = "1.77";
                    else if (info.Type == "Scandinavian")
                        info.Price = "1.77";
                    else if (info.Type == "Global")
                        info.Price = "1.77";
                    else if (info.Type == "Special")
                        info.Price = "4.17";
                    else if (info.Type == "Salad garden")
                        info.Price = "2.30";
                    else if (info.Type == "Salad garden & Soup")
                        info.Price = "2.60";
                    else
                        info.Price = "1 bil dollars!";

                    UniThursdayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuThursday.ItemsSource = UniThursdayList;


                // Friday
                UniFridayList = new ObservableCollection<MyListViewModel>();
                for (int i = 0; i < root.days.friday.Count(); i++)
                {
                    UniFriday ruoka = root.days.friday.ElementAt(i);

                    MyListViewModel info = new MyListViewModel();

                    info.Type = ruoka.category;
                    info.Description = ruoka.title_fi;

                    // Set price by coursetype
                    if (info.Type == "Soup")
                        info.Price = "0.99";
                    else if (info.Type == "Vegetarian")
                        info.Price = "1.77";
                    else if (info.Type == "Scandinavian")
                        info.Price = "1.77";
                    else if (info.Type == "Global")
                        info.Price = "1.77";
                    else if (info.Type == "Special")
                        info.Price = "4.17";
                    else if (info.Type == "Salad garden")
                        info.Price = "2.30";
                    else if (info.Type == "Salad garden & Soup")
                        info.Price = "2.60";
                    else
                        info.Price = "1 bil dollars!";

                    UniFridayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuFriday.ItemsSource = UniFridayList;
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