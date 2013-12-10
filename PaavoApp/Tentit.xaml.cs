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
using Microsoft.Phone.Tasks;

namespace PaavoApp
{
    public partial class Tentit : PhoneApplicationPage
    {
        string content = null;
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
                content = reader.ReadToEnd();
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
                    splitted = content.Split(new char[] {'"'}, StringSplitOptions.None);
                    content = "https://uni.lut.fi" + splitted[1];
                }else
                    content = "Failed to find sentence";
                testi.Text = content;
            }
            else
            {
                //Either cancelled or error handle appropriately for your app  
            }
        }

        private void downloadPDF(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (content == null || content == "Failed to find sentence")
                content = "Failed to find sentence";
            else
            {
                WebBrowserTask browseToPDF = new WebBrowserTask();
                browseToPDF.URL = content;
                browseToPDF.Show();
            }

        }
    }
}