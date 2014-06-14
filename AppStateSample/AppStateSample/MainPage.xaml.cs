using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace AppStateSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Application.Current.Suspending += Current_Suspending;
            Application.Current.Resuming += Current_Resuming;


        }


        void Current_Resuming(object sender, object e)
        {
            //after resuming , update the UI by getting latest data ( eg. tweets from internet )
            txtBlkStatus.Text = "App resumed just now !";


        }

        async void Current_Suspending(object sender, Windows.ApplicationModel.SuspendingEventArgs e)
        {
            //save your application data before the application terminates 
            //two ways of saving the app - Synchronous and Asynchronous 
            //if the data is small , use synchronous 

            //Synchronous data save 
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["data"] = txtBoxData.Text;


           //Asynchronous data saving includes using a SuspendingDeferral for making the app to wait until the asynchrnous task completes 
            var deferral = e.SuspendingOperation.GetDeferral();

            //do all asynchronous task here 
            var localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await localFolder.CreateFileAsync("datafile.txt", CreationCollisionOption.ReplaceExisting);
            if (file != null)
                await FileIO.WriteTextAsync(file, txtBoxData.Text);
            
            //tell windows to complete all async operations 
            deferral.Complete();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            txtBoxData.Text = localSettings.Values["data"].ToString();            
        }

    }
}
