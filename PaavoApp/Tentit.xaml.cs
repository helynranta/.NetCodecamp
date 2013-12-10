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
        string PDFcontent = null;
        string examsContent = null;
        string koul_koht = null;
        string changes = null;
        public Tentit()
        {
            InitializeComponent();
            download();
        }
        private void download()
        {
            string url = "http://uni.lut.fi/fi/kuulustelujarjestys1";
           
            WebClient wc = new WebClient();
            wc.OpenReadCompleted += new OpenReadCompletedEventHandler(PDF_OpenReadCompleted);
            wc.OpenReadAsync(new Uri(url), wc);  

        }
        void PDF_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null && !e.Cancelled)
            {
                //download pdf
                StreamReader reader = new StreamReader(e.Result);
                PDFcontent = reader.ReadToEnd();
                examsContent = PDFcontent;
                string[] stringSeparator = { "<p>" };
                string[] splitted = PDFcontent.Split(stringSeparator, StringSplitOptions.None);
                PDFcontent = null;
                foreach (string sentence in splitted)
                {
                    if(sentence.Contains("tenttisalit"))
                    {
                        PDFcontent = sentence;
                        break;
                    }
                }
                if(PDFcontent != null)
                {
                    splitted = PDFcontent.Split(new char[] {'"'}, StringSplitOptions.None);
                    PDFcontent = "https://uni.lut.fi" + splitted[1];
                }else
                    PDFcontent = "Failed to find sentence";
                //testi.Text = PDFcontent;
                
                //find Exams pages
                stringSeparator = new string[]{ "<p>"};
                splitted = examsContent.Split(stringSeparator, StringSplitOptions.None);
                foreach (string sentence in splitted)
                {
                    if(sentence.Contains("Koulutusohjelmakohtainen kuulustelujärjestys"))
                    {
                        splitted = sentence.Split(new char[] { '"' }, StringSplitOptions.None);
                        koul_koht = "https://uni.lut.fi" + splitted[1];
                        break;
                    }
                }
                //changes in exams
                splitted = examsContent.Split(stringSeparator, StringSplitOptions.None);
                foreach (string sentence in splitted)
                {
                    if (sentence.Contains("Muutokset kuulustelujärjestykseen"))
                    {
                        splitted = sentence.Split(new char[] { '"' }, StringSplitOptions.None);
                        changes = "https://uni.lut.fi" + splitted[1];
                        break;
                    }
                }
                //testi.Text = changes;
                WebClient wc = new WebClient();
                wc.OpenReadCompleted += new OpenReadCompletedEventHandler(parseExams);
                wc.OpenReadAsync(new Uri(koul_koht), wc); 
                
            }
            else
            {
                //Either cancelled or error handle appropriately for your app  
            }
        }

        private void downloadPDF(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (PDFcontent == null || PDFcontent == "Failed to find sentence")
                PDFcontent = "Failed to find sentence";
            else
            {
                WebBrowserTask browseToPDF = new WebBrowserTask();
                browseToPDF.URL = PDFcontent;
                browseToPDF.Show();
            }
        }
        private void parseExams(object sender, OpenReadCompletedEventArgs e)
        {
            StreamReader reader = new StreamReader(e.Result);
            koul_koht = reader.ReadToEnd();
            string[] splitted = koul_koht.Split(new string[] { "<tr>" }, StringSplitOptions.None);
            var exams = splitted.ToList();
            for(int i = 0; i < exams.Count(); i++)
            {
                if (exams[i].Contains("table") || exams[i].Contains("pvm/klo") || exams[i].Length < 10)
                {
                    exams.RemoveAt(i);
                    i--;
                }
            }

            List<Exam> examslist = new List<Exam>();
            
            foreach(string examstring in exams)
            {
                string[] exam = examstring.Split(new string[] {"td>"}, StringSplitOptions.RemoveEmptyEntries);
                Exam tentti = new Exam();
                //course ID
                tentti.nro = exam[0].Substring(exam[0].IndexOf('>')+1, exam[0].Length-exam[0].IndexOf('>')-3);
                //course name
                string[] course = exam[1].Split(new string[] { "b>" }, StringSplitOptions.RemoveEmptyEntries);
                tentti.name = course[1].Substring(0,course[1].Length-2);
                //dates
                //****DOES NOT WORK MUTHAFUKA****
                for (int i = 2; i == 6; i++)
                {
                    ExamsTime examtime = new ExamsTime();
                    testi.Text = exam[i];
                    string[] dates = exam[i].Split(new string[] {">"}, StringSplitOptions.RemoveEmptyEntries);
                    string time_date = dates[1].Substring(0, dates[1].Length-4);
                    string[] splitted_date = time_date.Split(new string[] {"/"}, StringSplitOptions.RemoveEmptyEntries);
                    examtime.date = splitted_date[0];
                    examtime.time_ = splitted_date[1];
                    tentti.times.Add(examtime);
                }
                examslist.Add(tentti);
            }

            
            examslist.Count();            
        }
    }
}