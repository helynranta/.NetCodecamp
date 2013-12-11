
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

        public StudentUnion()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        /// <summary> 
        /// Page loaded. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadTestData();


            string url = "http://eatatlut.appspot.com/studentunion";
            LoadSiteContent(url);

            string img_url = "http://ruutcam.lut.fi/yo-talo/webcam.jpg";
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(img_url), wc);

        }


        // Load food info
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

                MondayList = new ObservableCollection<MyListViewModel>();

                RootObject root = JsonConvert.DeserializeObject<RootObject>((string)e.Result);

                // Monday
                if (root.days.monday.ElementAt(0).name != "None")
                {
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
                        MenuMonday.ItemsSource = MondayList;

                    }
                }

                // Tuesday
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
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
                        MenuTuesday.ItemsSource = TuesdayList;
                    }
                }

                // Wednesday
                if (root.days.wednesday.ElementAt(0).name != "None")
                {
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
                }

                // Thursday
                if (root.days.thursday.ElementAt(0).name != "None")
                {
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
                        MenuThursday.ItemsSource = ThursdayList;

                    }
                }
                if (root.days.tuesday.ElementAt(0).name != "None")
                {
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
                        MenuFriday.ItemsSource = FridayList;

                    }
                }

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



        /// <summary> 
        /// Test data. 
        /// </summary> 
        /*
                private void LoadTestData()
                {
                    myVM = new ObservableCollection<MyListViewModel> 
                          { 
                              new MyListViewModel 
                                  { 
                        Field1 = "Day",
                        Field2 = "Type",
                        Field3 = "Description",
                        Field4 = "Price" 
                                  }  
                          };
                    MyListViewModel toinen = new MyListViewModel
                    {
                        Field1 = "Day2",
                        Field2 = "Type2",
                        Field3 = "Desc2",
                        Field4 = "Price2"
                    };
                    myVM.Add(toinen);
                }
                */
        /// <summary> 
        /// Data bind to ListBox 
        /// </summary> 
        private void BindData()
        {
            MenuMonday.ItemsSource = MondayList;
        }

    }


    /// <summary> 
    /// Entity for testã€€Data 
    /// </summary> 
    public class MyListViewModel
    {
        public string Field2 { get; set; }

        public string Field3 { get; set; }

        public string Field4 { get; set; }

    }
}
