using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace PaavoApp
{
    public partial class SelamPage : PhoneApplicationPage
    {
        public SelamPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sbFadeIn = new Storyboard();
            sbFadeIn.Completed += new EventHandler(sb_Completed);

            FadeInOut(this.panorama.Background, sbFadeIn, true);

            string MyNumberPhone = "054127070";
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = MyNumberPhone;
            phoneCallTask.DisplayName = "Selam";
            phoneCallTask.Show();

        }
        private void FadeInOut(DependencyObject target, Storyboard sb, bool isFadeIn)
        {
            Duration d = new Duration(TimeSpan.FromSeconds(1));
            DoubleAnimation daFade = new DoubleAnimation();
            daFade.Duration = d;
            if (isFadeIn)
            {
                daFade.From = 1.00;
                daFade.To = 0.00;
            }
            else
            {
                daFade.From = 0.00;
                daFade.To = 1.00;
            }

            sb.Duration = d;
            sb.Children.Add(daFade);
            Storyboard.SetTarget(daFade, target);
            Storyboard.SetTargetProperty(daFade, new PropertyPath("Opacity"));

            sb.Begin();
        }
        void sb_Completed(object sender, EventArgs e)
        {
            BitmapImage bitmapImage = new BitmapImage(new Uri("Resources/Selam2.png", UriKind.Relative));
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;

            this.panorama.Background = imageBrush;
            Storyboard sbFadeOut = new Storyboard();

            FadeInOut(this.panorama.Background, sbFadeOut, false);
        }


    }
}