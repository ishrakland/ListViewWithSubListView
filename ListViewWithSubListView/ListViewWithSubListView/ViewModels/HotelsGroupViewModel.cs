using ListViewWithSubListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewWithSubListView.ViewModels
{
    public class HotelsGroupViewModel : BaseViewModel
    {
        private HotelViewModel _oldHotel;

        private ObservableCollection<HotelViewModel> items;
        public ObservableCollection<HotelViewModel> Items
        {
            get => items;

            set => SetProperty(ref items, value);
        }
      
        public Command LoadHotelsCommand { get; set; }
        public Command<HotelViewModel> RefreshItemsCommand { get; set; }

        public HotelsGroupViewModel()
        {
            items = new ObservableCollection<HotelViewModel>();
            Items = new ObservableCollection<HotelViewModel>();
            LoadHotelsCommand = new Command(async () => await ExecuteLoadItemsCommandAsync());
            RefreshItemsCommand = new Command<HotelViewModel>((item) => ExecuteRefreshItemsCommand(item));
        }
      
        public bool isExpanded = false;
        private void ExecuteRefreshItemsCommand(HotelViewModel item)
        {
            if (_oldHotel == item)
            {
                // click twice on the same item will hide it
                item.Expanded = !item.Expanded;
            }
            else
            {
                if (_oldHotel != null)
                {
                    // hide previous selected item
                    _oldHotel.Expanded = false;
                }
                // show selected item
                item.Expanded = true;
            }

            _oldHotel = item;
        }
        async System.Threading.Tasks.Task ExecuteLoadItemsCommandAsync()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                Items.Clear();
                List<Room> Hotel1rooms = new List<Room>() { new Room("Jasmine", 1), new Room("Flower Suite", 2), new Room("narcissus", 1)
                };
                List<Room> Hotel2rooms = new List<Room>()
                {
                    new Room("Princess", 1), new Room("Royale", 1), new Room("Queen", 1)
                };
                List<Room> Hotel3rooms = new List<Room>()
                {
                    new Room("Marhaba", 1), new Room("Marhaba Salem", 1), new Room("Salem Royal", 1), new Room("Wedding Roome", 1), new Room("Wedding Suite", 2)
                };
                List<Hotel> items = new List<Hotel>() { new Hotel("Yasmine Hammamet", Hotel1rooms), new Hotel("El Mouradi Hammamet,", Hotel2rooms), new Hotel("Marhaba Royal Salem", Hotel3rooms) };

                if (items != null && items.Count > 0)
                {
                    foreach (var hotel in items)
                        Items.Add(new HotelViewModel(hotel));
                }
                else { IsEmpty = true; }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
