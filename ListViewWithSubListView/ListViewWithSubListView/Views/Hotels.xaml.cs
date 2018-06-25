using ListViewWithSubListView.Models;
using ListViewWithSubListView.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ListViewWithSubListView.Views
{
    public partial class Hotels : ContentPage
	{

        private HotelsGroupViewModel ViewModel
        {
            get { return (HotelsGroupViewModel)BindingContext; }
            set { BindingContext = value; }
        }

        private List<Hotels> ListHotel = new List<Hotels>();

        protected override void OnAppearing()
        {
            try
            {
                base.OnAppearing();

                if (ViewModel.Items.Count == 0)
                {
                    ViewModel.LoadHotelsCommand.Execute(null);
                }           
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public Hotels(HotelsGroupViewModel viewModel)
		{
			InitializeComponent();
            this.ViewModel = viewModel;           
        }

       
    }
}
