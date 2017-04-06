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
using Windows.Devices.SerialCommunication;
using System.Collections.ObjectModel;
using Windows.Devices.Enumeration;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using System.Threading.Tasks;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyCosimir
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public class Item
    {
        public string Name;
        public int Value;
        public Item(string name, int value)
        {
            Name = name; Value = value;
        }
        public override string ToString()
        {
            // Generates the text shown in the combo box
            return Name;
        }
    }

    public sealed partial class MainPage : Page
    {

        private SerialDevice serialPort = null;
        private ObservableCollection<DeviceInformation> listOfDevices;

        public MainPage()
        {
            this.InitializeComponent();

            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;


            comboBox.Items.Add(new Item("Blue", 1));
            //comboBox.Items.Add(new Item("Red", 2));
            //comboBox.Items.Add(new Item("Nobugz", 666));

            listOfDevices = new ObservableCollection<DeviceInformation>();
            ListAvailablePorts(comboBox);

            //int milliseconds = 1000;
            int cnt = 0;
            

        }

        private async void ListAvailablePorts(ComboBox myComboBox)
        {
            try
            {
                string aqs = SerialDevice.GetDeviceSelector();
                var dis = await DeviceInformation.FindAllAsync(SerialDevice.GetDeviceSelectorFromUsbVidPid(0x04D8, 0x000A));
                serialPort = await SerialDevice.FromIdAsync(dis[0].Id);

                for (int i = 0; i < dis.Count; i++)
                {
                    listOfDevices.Add(dis[i]);
                    myComboBox.Items.Add(new Item(dis[i].ToString(), i));
                }

            }
            catch
            {
                ;
            }
        }

        async private void OnCreateTerminal(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
              CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
              CoreDispatcherPriority.Normal,
              () =>
              {
              newAppView = ApplicationView.GetForCurrentView();
              Window.Current.Content = new Frame();
              (Window.Current.Content as Frame).Navigate(typeof(Terminal));
              Window.Current.Activate();
              });

            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.Auto;
            //ApplicationView.PreferredLaunchViewSize = new Size(280, 72);
            //ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
              newAppView.Id,
              ViewSizePreference.UseHalf,
              mainViewId,
              ViewSizePreference.UseHalf);
        }
                
        async private void OnCreatePositions(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
              CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
              CoreDispatcherPriority.Normal,
              () =>
              {
                  newAppView = ApplicationView.GetForCurrentView();
                  Window.Current.Content = new Frame();
                  (Window.Current.Content as Frame).Navigate(typeof(Positions));
                  Window.Current.Activate();
              });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
              newAppView.Id,
              ViewSizePreference.UseHalf,
              mainViewId,
              ViewSizePreference.UseHalf);
        }

        async private void OnCreateXyz(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
              CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
              CoreDispatcherPriority.Normal,
              () =>
              {
                  newAppView = ApplicationView.GetForCurrentView();
                  Window.Current.Content = new Frame();
                  (Window.Current.Content as Frame).Navigate(typeof(Xyz));
                  Window.Current.Activate();
              });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
              newAppView.Id,
              ViewSizePreference.UseHalf,
              mainViewId,
              ViewSizePreference.UseHalf);
        }

        async private void OnCreateEditor(object sender, RoutedEventArgs e)
        {
            CoreApplicationView newCoreView = CoreApplication.CreateNewView();

            ApplicationView newAppView = null;
            int mainViewId = ApplicationView.GetApplicationViewIdForWindow(
              CoreApplication.MainView.CoreWindow);

            await newCoreView.Dispatcher.RunAsync(
              CoreDispatcherPriority.Normal,
              () =>
              {
                  newAppView = ApplicationView.GetForCurrentView();
                  Window.Current.Content = new Frame();
                  (Window.Current.Content as Frame).Navigate(typeof(Editor));
                  Window.Current.Activate();
              });

            await ApplicationViewSwitcher.TryShowAsStandaloneAsync(
              newAppView.Id,
              ViewSizePreference.UseHalf,
              mainViewId,
              ViewSizePreference.UseHalf);
        }
    }
}
