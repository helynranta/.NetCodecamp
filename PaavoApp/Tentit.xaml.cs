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

namespace PaavoApp
{
    public partial class Tentit : PhoneApplicationPage
    {
        public Tentit()
        {
            InitializeComponent();
            download();
        }
        private void download()
        {
            string img_url = "http://uni.lut.fi/fi/kuulustelujarjestys1";
           
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(img_url), wc);  

        }
        void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                StreamReader reader = new StreamReader(e.Result);
                string content = reader.ReadToEnd();
                string[] stringSeparator = { "<p>" };
                string[] splitted = content.Split(stringSeparator, StringSplitOptions.None);
                content = null;
                foreach (string sentence in splitted)
                {
                    if(sentence.Contains("tenttisalit"))
                    {
                        content = sentence;
                        break;
                    }
                }
                if(content != null)
                {
                    
                }else
                    content = "Failed to find sentence" + splitted.Count() ;
                testi.Text = content;
            }
            else
            {
                //Either cancelled or error handle appropriately for your app  
            }
        }
    }
}