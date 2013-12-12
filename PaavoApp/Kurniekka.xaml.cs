
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
using System.ComponentModel;
using PaavoApp.DatabaseModels;

namespace PaavoApp
{
    public partial class Kurniekka : PhoneApplicationPage, INotifyPropertyChanged
    {
        public static readonly string Name = "Kurniekka";

        public ObservableCollection<AalefItemViewModel> MondayList { get; set; }
        public ObservableCollection<AalefItemViewModel> TuesdayList { get; set; }
        public ObservableCollection<AalefItemViewModel> WednesdayList { get; set; }
        public ObservableCollection<AalefItemViewModel> ThursdayList { get; set; }
        public ObservableCollection<AalefItemViewModel> FridayList { get; set; }

        public Kurniekka()
        {
            InitializeComponent();
            Loaded += KurniekkaPage_Loaded;

            AalefDB = new AalefDatabaseContext(AalefDatabaseContext.DBConnectionString);
            UpdatedDB = new RestaurantUpdatedContext(RestaurantUpdatedContext.DBConnectionString);
            this.DataContext = this;
        }

        /// Page loaded.
        void KurniekkaPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckIfDatabaseUpdateNeeded())
            {
                string url = "http://eatatlut.appspot.com/kurniekka";
                LoadSiteContent(url); // Load food info
            }
            else
            {
                loadDataFromDatabase();
            }
        }

        // Load food info
        public void LoadSiteContent(string url)
        {
            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(PopulateViewCallback);
            client.DownloadStringAsync(new Uri(url));
        }

        private bool CheckIfDatabaseUpdateNeeded()
        {
            IQueryable<RestaurantUpdatedItem> updateItems = from RestaurantUpdatedItem items in UpdatedDB.UpdateItems where items.Name == Name select items;
            if (updateItems.Count() != 0)
            {
                DateTime now = DateTime.Now.Date;
                DateTime lastUpdate = updateItems.First().Updated.Date;
                int asd = (now - lastUpdate).Days;
                if ((now - lastUpdate).Days > 2) // If difference is more than 2 days we update
                {
                    // Remove old items
                    var ItemsInDB = from AalefDataItem items in AalefDB.DataItems select items;
                    AalefDB.DataItems.DeleteAllOnSubmit(ItemsInDB);
                    AalefDB.SubmitChanges();
                    return true;
                }
                return false;
            }
            return true;
        }

        private void UpdateDatabase(ObservableCollection<AalefItemViewModel> listToUpdate)
        {
            List<AalefDataItem> newItems = new List<AalefDataItem>();
            foreach (AalefItemViewModel item in listToUpdate)
            {
                newItems.Add(new AalefDataItem { CourseType = item.Type, Name = item.Type, Description = item.Description, Price = item.Price, Day = item.Day });
            }
            AalefDB.DataItems.InsertAllOnSubmit(newItems);
            AalefDB.SubmitChanges();

            // Delete old update date and add new
            IQueryable<RestaurantUpdatedItem> updateItems = from RestaurantUpdatedItem items in UpdatedDB.UpdateItems where items.Name == Name select items;
            if (updateItems.Count() != 0)
            {
                UpdatedDB.UpdateItems.DeleteOnSubmit(updateItems.First());
            }
            UpdatedDB.UpdateItems.InsertOnSubmit(new RestaurantUpdatedItem { Updated = DateTime.Now, Name = Name });
            UpdatedDB.SubmitChanges();

        }

        private void loadDataFromDatabase()
        {
            IQueryable<AalefDataItem> fetchedItems = from AalefDataItem items in AalefDB.DataItems where items.Day == "monday" select items;
            if (fetchedItems.Count() != 0)
            {
                MondayList = new ObservableCollection<AalefItemViewModel>();
                foreach (AalefDataItem item in fetchedItems)
                {
                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = item.CourseType;
                    info.Description = item.Description;
                    info.Day = item.Day;
                    info.Price = item.Price;
                    MondayList.Add(info);
                }
                MenuMonday.ItemsSource = MondayList;
            }

            fetchedItems = from AalefDataItem items in AalefDB.DataItems where items.Day == "tuesday" select items;
            if (fetchedItems.Count() != 0)
            {
                TuesdayList = new ObservableCollection<AalefItemViewModel>();
                foreach (AalefDataItem item in fetchedItems)
                {
                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = item.CourseType;
                    info.Description = item.Description;
                    info.Day = item.Day;
                    info.Price = item.Price;
                    TuesdayList.Add(info);
                }
                MenuTuesday.ItemsSource = TuesdayList;
            }

            fetchedItems = from AalefDataItem items in AalefDB.DataItems where items.Day == "wednesday" select items;
            if (fetchedItems.Count() != 0)
            {
                WednesdayList = new ObservableCollection<AalefItemViewModel>();
                foreach (AalefDataItem item in fetchedItems)
                {
                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = item.CourseType;
                    info.Description = item.Description;
                    info.Day = item.Day;
                    info.Price = item.Price;
                    WednesdayList.Add(info);
                }
                MenuWednesday.ItemsSource = WednesdayList;
            }

            fetchedItems = from AalefDataItem items in AalefDB.DataItems where items.Day == "thursday" select items;
            if (fetchedItems.Count() != 0)
            {
                ThursdayList = new ObservableCollection<AalefItemViewModel>();
                foreach (AalefDataItem item in fetchedItems)
                {
                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = item.CourseType;
                    info.Description = item.Description;
                    info.Day = item.Day;
                    info.Price = item.Price;
                    ThursdayList.Add(info);
                }
                MenuThursday.ItemsSource = ThursdayList;
            }

            fetchedItems = from AalefDataItem items in AalefDB.DataItems where items.Day == "friday" select items;
            if (fetchedItems.Count() != 0)
            {
                FridayList = new ObservableCollection<AalefItemViewModel>();
                foreach (AalefDataItem item in fetchedItems)
                {
                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = item.CourseType;
                    info.Description = item.Description;
                    info.Day = item.Day;
                    info.Price = item.Price;
                    FridayList.Add(info);
                }
                MenuFriday.ItemsSource = FridayList;
            }


        }

        // Load food info
        private void PopulateViewCallback(Object sender, DownloadStringCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {

                MondayList = new ObservableCollection<AalefItemViewModel>();
                RootObject root = JsonConvert.DeserializeObject<RootObject>((string)e.Result);

                // Monday
                for (int i = 0; i < root.days.monday.Count(); i++)
                {
                    Monday ruoka = root.days.monday.ElementAt(i);

                    AalefItemViewModel info = new AalefItemViewModel();
                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;
                    info.Day = "monday";

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
                TuesdayList = new ObservableCollection<AalefItemViewModel>();
                for (int i = 0; i < root.days.tuesday.Count(); i++)
                {
                    Tuesday ruoka = root.days.tuesday.ElementAt(i);

                    AalefItemViewModel info = new AalefItemViewModel();

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;
                    info.Day = "tuesday";

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
                WednesdayList = new ObservableCollection<AalefItemViewModel>();
                for (int i = 0; i < root.days.wednesday.Count(); i++)
                {
                    Wednesday ruoka = root.days.wednesday.ElementAt(i);

                    AalefItemViewModel info = new AalefItemViewModel();

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;
                    info.Day = "wednesday";

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
                ThursdayList = new ObservableCollection<AalefItemViewModel>();
                for (int i = 0; i < root.days.thursday.Count(); i++)
                {
                    Thursday ruoka = root.days.thursday.ElementAt(i);

                    AalefItemViewModel info = new AalefItemViewModel();

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;
                    info.Day = "thursday";

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
                FridayList = new ObservableCollection<AalefItemViewModel>();
                for (int i = 0; i < root.days.friday.Count(); i++)
                {
                    Friday ruoka = root.days.friday.ElementAt(i);

                    AalefItemViewModel info = new AalefItemViewModel();

                    info.Type = ruoka.coursetype;
                    info.Description = ruoka.name;
                    info.Day = "friday";

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
                        info.Price = "1 bil $!";

                    FridayList.Add(info);
                }
                // Bind data to Listbox outside of loop
                MenuFriday.ItemsSource = FridayList;

                UpdateDatabase(MondayList);
                UpdateDatabase(TuesdayList);
                UpdateDatabase(WednesdayList);
                UpdateDatabase(ThursdayList);
                UpdateDatabase(FridayList);
            }
        }

        // Entity for Data 
        public class AalefItemViewModel
        {
            public string Type { get; set; }

            public string Description { get; set; }

            public string Price { get; set; }

            public string Day { get; set; }

        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        // Data context for the local database
        private AalefDatabaseContext AalefDB;

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<AalefDataItem> _aalefMenuItems;
        public ObservableCollection<AalefDataItem> AalefMenuItems
        {
            get
            {
                return _aalefMenuItems;
            }
            set
            {
                if (_aalefMenuItems != value)
                {
                    _aalefMenuItems = value;
                    NotifyPropertyChanged("AalefMenuItems");
                }
            }
        }

        private RestaurantUpdatedContext UpdatedDB;

        // Define an observable collection property that controls can bind to.
        private ObservableCollection<RestaurantUpdatedItem> _UpdatedItems;
        public ObservableCollection<RestaurantUpdatedItem> UpdatedItems
        {
            get
            {
                return _UpdatedItems;
            }
            set
            {
                if (_UpdatedItems != value)
                {
                    _UpdatedItems = value;
                    NotifyPropertyChanged("AalefMenuItems");
                }
            }
        }
    }
}