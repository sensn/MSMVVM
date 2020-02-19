using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace MSMVVM
{
    public class Room
{
    public bool IsOpened { get; set; }
    public string Name { get; set; }
        public Room(bool opened, string name)
        {
            this.IsOpened = opened;
            this.Name = name;
        }
}
public class Apartment
{
    public string Name { get; set; }
    public List<Room> Rooms { get; set; }

        public Apartment()
        {
            Rooms = new List<Room>()  ;
            Name = "A";
        }
}
public sealed partial class MainPage : Page
    {
        public ObservableCollection<Apartment> ApartmentCollection = new ObservableCollection<Apartment>() {new Apartment(), new Apartment() };
        public MainPage()
        {
            this.InitializeComponent();
           
            for (int x = 0; x < 3; x++)
            {
                ApartmentCollection.Add(new Apartment());
                for (int i = 0; i < 80; i++)
                {
                    ApartmentCollection[x].Rooms.Add(new Room(true, "R"));
                }
            }
        }
       public void ApartmentGridView_ItemClick(object sender, ItemClickEventArgs e)
       {
           var item = e.ClickedItem as Apartment;
           RoomGridView.ItemsSource = item.Rooms;
       }
        public void RToggle_Click(object sender, RoutedEventArgs e)
        {           
            var data = (sender as ToggleButton).DataContext as Apartment;  //currently selected DataClass
            RoomGridView.ItemsSource = data.Rooms;
        }
    }
}
