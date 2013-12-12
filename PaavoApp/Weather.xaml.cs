using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Phone.Tasks;


namespace PaavoApp
{
    public partial class Weather : PhoneApplicationPage
    {
        Dictionary<string, string> tiedot = new Dictionary<string, string> 
                { 
                    {"Lämpötila", "1"},
                    {"Kastepiste","2"},
                    {"Puuska", "2"},
                    {"Pilvistä","3"},
                    {"Kosteus", "4"},
                    {"Lounaistuulta","5"},
                    {"Paine", "6"},
                    {"Näkyvyys","7"} 
                };
        public Weather()
        {
            InitializeComponent();
            downloadContent("http://ilmatieteenlaitos.fi/saa/lappeenranta/skinnarila");
        }
        public void downloadContent(string url)
        {

            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCompleted);
            wc.OpenReadAsync(new Uri(url), wc);

        }
        void OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                //download pdf
                string content;
                StreamReader reader = new StreamReader(e.Result);
                content = reader.ReadToEnd();
                //replace ä, ö, and degree
                content = content.Replace("&auml;", "ä").Replace("&ouml;", "ö").Replace("&nbsp;", "").Replace("&deg;", "°");
                //get the table of contents
                string[] splitted = content.Split(new string[] {"<tbody>"}, StringSplitOptions.None);
                foreach (string sentence in splitted)
                {
                    if (sentence.Contains("Kosteus") && sentence.Contains(">Lämpötila</span>"))
                    {
                        content = sentence;
                        break;
                    }
                }
                
                string content_temp = "";
                foreach (string key in tiedot.Keys.ToList())
                {
                    splitted = content.Split(new string[] { "<span" }, StringSplitOptions.None);
                    for (int i = 0; i < splitted.Length; i++)
                    {
                        if (splitted[i].Contains(key.ToString()))
                        {
                            content_temp = splitted[i + 1];
                            break;
                        }
                    }
                    
                    splitted = content_temp.Split(new string[] { ">" }, StringSplitOptions.None);
                    content_temp = splitted[1].Replace("</span", "");
                    tiedot[key.ToString()] = content_temp;
                }
                WeatherLine.DataContext = tiedot;
                WeatherLine.UpdateLayout();
            }
            else
            {
                //Either cancelled or error handle appropriately for your app  
            }
        }

        private void feedListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // This method sets up the feed and binds it to our ListBox. 
    }
}