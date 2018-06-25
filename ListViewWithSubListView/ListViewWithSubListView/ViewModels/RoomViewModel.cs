using ListViewWithSubListView.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ListViewWithSubListView.ViewModels
{
    public class RoomViewModel 
    {
        private Room _room;

        public RoomViewModel(Room room)
        {
            this._room = room;
        }

        public string RoomName { get { return _room.RoomName; } }
        public int TypeID { get { return _room.TypeID; } }
        
        public Room Room
        {
            get => _room;
        }

    }
}
