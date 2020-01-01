using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppSharePlugin.Interfaces;
using Xamarin.Forms;

namespace TestAppSharePlugin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var screenshot = DependencyService.Get<IScreenshotService>().Capture();
            MemoryStream ms = new MemoryStream(screenshot);
            ImageSource imageSource = ImageSource.FromStream(() => { return ms; });
            //*********** Here title and message could be dynamic as per your requirements ***********
            DependencyService.Get<IShareService>().Share("Test Title","Test Message", imageSource);
        }
    }
}
