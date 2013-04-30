using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bing.Maps;
using Newman.Domain.ViewModels;
using Newman.Win.Common;
using Windows.UI.ApplicationSettings;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Newman.Win.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class MapPage : Newman.Win.Common.LayoutAwarePage
    {
        private readonly MapVm _vm;

        public MapPage()
        {
            this.InitializeComponent();
            _vm = new MapVm();
            DataContext = _vm;
            _vm.PropertyChanged += _vm_PropertyChanged;
            SettingsPane.GetForCurrentView().CommandsRequested += GroupedItemsPage_CommandsRequested;
        }

        void _vm_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Center")
            {
                if (_vm.Center != null)
                    Map.Center = new Location(_vm.Center.Lat, _vm.Center.Lng);
            }
        }


        void GroupedItemsPage_CommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            SettingsHelper.AddSettingsCommands(args);
        }


        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected async override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
            bool couldInit = false;
            try
            {
                await _vm.Init();
                couldInit = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

            if (!couldInit)
            {

                var messageDialog = new MessageDialog("Kunde inte hämta lekplatser, vänligen kontrollera att du har nätverksåtkomst och försök igen.");
                await messageDialog.ShowAsync();
                Application.Current.Exit();
            }
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }
    }
}
