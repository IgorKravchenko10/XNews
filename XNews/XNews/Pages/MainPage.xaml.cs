using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XNews.Models.Data;
using XNews.ViewModels;

namespace XNews.Pages
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            
            _viewModel = new MainPageViewModel();
            this.BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                await _viewModel?.Init();
                listViewNews.ItemsSource = _viewModel.News;
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void listViewNews_Refreshing(object sender, EventArgs e)
        {
            try
            {
                await _viewModel?.Init();
                listViewNews.ItemsSource = _viewModel.News;
                listViewNews.IsRefreshing = !listViewNews.IsRefreshing;
            }
            catch(Exception ex)
            {
                await this.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void listViewNews_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                NewsDetailPage detailPage = new NewsDetailPage();
                detailPage.Init(e.Item as News);
                await Navigation.PushAsync(detailPage);
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
