using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProgressBarAndProgressRingControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //start the progress bar animation
            pbMyProgress.IsIndeterminate = true;

            //start the progress ring animation 
            prMyProgress.IsActive = true;


        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //stop the progress bar animation
            pbMyProgress.IsIndeterminate = false;

            //stop the progress ring animation 
            prMyProgress.IsActive = false;

        }
    }
}
