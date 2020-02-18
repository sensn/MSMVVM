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

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace MSMVVM
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    ///
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
            Rooms = new List<Room>() { new Room(true, "R"), new Room(true, "R"), new Room(true, "R") }; ;
            Name = "A";
        }
}
public sealed partial class MainPage : Page
    {
        public ObservableCollection<Apartment> ApartmentCollection = new ObservableCollection<Apartment>() {new Apartment(), new Apartment() };
        public MainPage()
        {
            this.InitializeComponent();
           // ApartmentGridView.ItemClick += ApartmentGridView_ItemClick;
            for (int x = 0; x < 3; x++)
            {
                ApartmentCollection.Add(new Apartment());
                for (int i = 0; i < 10; i++)
                {
                   
                  //  ApartmentCollection[x].Rooms.Add(new Room(true, "R"));

                }
            }
        }
       public void ApartmentGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("HOHO");
            var item = e.ClickedItem as Apartment;
           
          //  ApartmentGridView.Visibility = Visibility.Collapsed;
            RoomGridView.ItemsSource = item.Rooms;
            //for (int i = 0; i < 80; i++)
            //{
            //    ApartmentCollection[i].Rooms[0].IsOpened=true;


            //}
        }
    }
}
