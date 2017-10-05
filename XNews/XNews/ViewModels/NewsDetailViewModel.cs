using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XNews.Adapters;
using XNews.Models.Data;

namespace XNews.ViewModels
{
    public class NewsDetailViewModel : ViewModel
    {
        public News News { get; set; }

        public string Link { get { return this.News?.Link; } }

        public void Init(News news)
        {
            this.IsBusy = true;
            this.News = news;
            OnPropertyChanged("Link");
            this.IsBusy = false;
        }

    }
}
