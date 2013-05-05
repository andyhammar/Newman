﻿using System.Device.Location;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps.Platform;
using Newman.Domain.ViewModels;

namespace Newman.Wp
{
    public partial class MainPage : PhoneApplicationPage
    {
        private MapVm _vm;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _vm = new MapVm();
            DataContext = _vm;
            _vm.PropertyChanged += _vm_PropertyChanged;
        }

        void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Center")
            {
                var convert = new PositionToLocationConverter().Convert(_vm.Center, null, null, null);
                map.Center = convert as GeoCoordinate;
            }
        }

        protected async override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await _vm.Init();
        }
    }
}