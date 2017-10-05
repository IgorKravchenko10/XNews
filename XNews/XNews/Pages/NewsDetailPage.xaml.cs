using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XNews.Models.Data;
using XNews.ViewModels;

namespace XNews.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetailPage : ContentPage
    {
        private NewsDetailViewModel _viewModel;

        public NewsDetailPage()
        {
            InitializeComponent();
            _viewModel = new NewsDetailViewModel();
            this.BindingContext = _viewModel;
            this.Title = _viewModel.Title;
        }

        public void Init(News news)
        {
            _viewModel?.Init(news);
        }
    }
}
