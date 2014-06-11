using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ImageControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public  MainPage()
        {
            this.InitializeComponent();

        }

        private async void btnShowImage_Click(object sender, RoutedEventArgs e)
        {
            StorageFile myfile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/windowslogo.jpg"));

            /*following will not work , since Windows 8/8.1 apps don't influence the file system directly
             * 
             * 
             * StorageFile myfile = await StorageFile.GetFileFromPathAsync("filepath");
             * 
             * proper API usage like , FileOpenPicker or KnownFolders.PictureLibrary has to be used
             * 
             * 
             * */

            using ( IRandomAccessStream  mystream = await myfile.OpenAsync(FileAccessMode.Read))
            {
                BitmapImage bi = new BitmapImage();
                bi.SetSource(mystream);
                imgFromCode.Source = bi;

            }


        }
    }
}
