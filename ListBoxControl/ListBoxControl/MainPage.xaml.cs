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

namespace ListBoxControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            listBoxMyBox.Items.Add("List Box Item 1");
            listBoxMyBox.Items.Add("List Box Item 2");
            listBoxMyBox.Items.Add("List Box Item 3");
            listBoxMyBox.Items.Add("List Box Item 4");
        }

        private void listBoxMyBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtBlkShowSelect.Text = "Selected Value :" +  listBoxMyBox.SelectedValue.ToString();



        }
    }
}
