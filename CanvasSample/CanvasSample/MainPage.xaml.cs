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
using Windows.UI.Input.Inking;
using Windows.UI.Input;
using Windows.UI;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CanvasSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        InkManager inkManager;

        public MainPage()
        {
            this.InitializeComponent();
            inkManager = new InkManager();
        }
        public Point startPoint;
        public UInt32 penId;


        private void inkCanvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var pt =  e.GetCurrentPoint(inkCanvas);
            startPoint = pt.Position;

            //check pointer is a pen/stylus or mouse with left click 
            if( e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Pen || 
                (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse && pt.Properties.IsLeftButtonPressed)
              )
            {
                penId = pt.PointerId;
                inkManager.ProcessPointerDown(pt);

            }
            else
            {
                //handle touch 
            }

            e.Handled = true;

             
        }

        private void inkCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
 

            //check penId 
            if( e.Pointer.PointerId == penId )
            {
                //same input 
                //for eg. a mouse and pen may interact at same time , but they will be given different pointer id 
                //you can differentiate different key strokes of different at the same time using this 

                var pt = e.GetCurrentPoint(inkCanvas);
                var currentPoint = pt.Position;

                Windows.UI.Xaml.Shapes.Line line = new Windows.UI.Xaml.Shapes.Line();
                line.X1 = startPoint.X;
                line.Y1 = startPoint.Y;
                line.X2 = currentPoint.X;
                line.Y2 = currentPoint.Y;
                line.StrokeThickness = 10;
                line.Stroke = new SolidColorBrush(Colors.Red);

                startPoint = currentPoint;

                inkCanvas.Children.Add(line);

                inkManager.ProcessPointerUpdate(pt);

            }
            else
            {
                //handle touch 
            }

            e.Handled = true;

        }

        private void inkCanvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if ( e.Pointer.PointerId == penId)
            {
                var pt = e.GetCurrentPoint(inkCanvas);

                inkManager.ProcessPointerUp(pt);

                

            }
            else
            {
                //handle touch 
            }


            penId = 0;


            e.Handled = true;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            inkCanvas.Children.Clear();
        }
       
    }
}
