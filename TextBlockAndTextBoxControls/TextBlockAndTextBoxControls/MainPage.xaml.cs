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

namespace TextBlockAndTextBoxControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Code gets executed when Page is being initialized 
            
            //change Textblock value from C# code 
            txtBlkProgram.Text = "Text Printed from C# Code";
            txtBlkProgram.FontSize = 30; //change font size 
            //check http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textblock.aspx for more Properties and Event Handlers
 
            //change TextBox Value from C# code
            txtBxProgram.Text = "Type Input Here";
            txtBxProgram.FontSize = 30;
            //check http://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.textbox.aspx for more Properties and Event Handlers



        }
    }
}
