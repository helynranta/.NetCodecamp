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
using Microsoft.Phone.Tasks;

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

        private void AalefTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/StudentUnion.xaml", UriKind.Relative));
        }

        private void KurniekkaTap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Tentit.xaml", UriKind.Relative));
        }

        private void Weather_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Weather.xaml", UriKind.Relative));
        }
        private void ExamButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Tentit.xaml", UriKind.Relative));
        }

        private void Selam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/SelamPage.xaml", UriKind.Relative));
        }

    }
}