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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
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

      

        private void sliderX_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            warX.Text = sliderX.Value.ToString();
        }

        private void sliderY_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            warY.Text = sliderY.Value.ToString();
        }

        private void sliderZ_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            warZ.Text = sliderZ.Value.ToString();
        }

        private void sliderXJ_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            jointWarX.Text = sliderXJ.Value.ToString();
        }

        private void sliderYJ_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            jointWarY.Text = sliderYJ.Value.ToString();
        }

        private void sliderZJ_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            jointWarZ.Text = sliderZJ.Value.ToString();
        }

        private void sliderXT_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            toolWarX.Text = sliderXT.Value.ToString();
        }

        private void sliderYT_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            toolWarY.Text = sliderYT.Value.ToString();
        }

        private void sliderZT_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            toolWarZ.Text = sliderZT.Value.ToString();
        }
    }
}
