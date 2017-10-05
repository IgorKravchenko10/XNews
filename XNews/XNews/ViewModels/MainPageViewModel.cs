using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNews.Adapters;
using XNews.Models.Data;
using XNews.Models.ProxyClasses;

namespace XNews.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private ObservableCollection<News> _news;

        public DbContext DbContext { get; set; }

        public ObservableCollection<News> News
        {
            get
            {                
                return _news;
            }
            set
            {
                if (_news != value)
                {
                    _news = value;
                    OnPropertyChanged("Items");
                }
            }
        }        

        public async Task Init()
        {
            this.IsBusy = true;
            this.CreateDbContext();
            await this.DbContext.SyncDataWithWeb();
            this.News = new ObservableCollection<News>(DbAdapter.GetNewsSql(this.DbContext));
            this.IsBusy = false;
        }

        private void CreateDbContext()
        {
            if (this.DbContext == null)
            {
                this.DbContext = new DbContext();
            }
        }
    }
}
