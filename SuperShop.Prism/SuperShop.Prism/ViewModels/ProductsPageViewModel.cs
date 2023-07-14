using Prism.Commands;
using Prism.Mvvm;
using SuperShop.Prism.Models;
using SuperShop.Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;

namespace SuperShop.Prism.ViewModels
{
    public class ProductPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navegationService;
        private readonly IApiService _apiService;
        private ObservableCollection<ProductResponse> _myProducts;
        private bool _isRunning;
        private string _seach;
        private List<ProductResponse> _myProducts;
        private DelegateComand _searchCommand;
        public ProductPageViewModel(
            
            INavigationService navegationService,
            IApiService apiService) : base(navegationService)
        {
            _navegationService = navegationService;
            _apiService = apiService;
            Title = "Products Page";
            LoadProductsAsync();
        }
        public DelegateCommand SearchCommand => _searchCommand ?? (_searchCommand = new DelegateCommand(ShowProducts));
        public string Search
        {
            get => _search;
            set
            {
                SetProperty(ref _searchCommand, value);
                ShowProducts();

            }
        }     
        public bool IsRunning
        {
            get => _isRunning;
            set => SetProperty(ref _isRunning, value);
        }
        public ObservableCollection<ProductResponse> Products
        {
            get => _myProducts;
            set => SetProperty(ref _myProducts, value);
        }
        private async void LoadProductAsync()
        {
            string url = App.Current.Resourses["UrlAPI"].ToString();

            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPageDisplayAlert(
                        "Error", 
                        "Check internet connection", "Accept");
                });
               
                return;

            }
            IsRunning = true;

            string url = App.Current.Resources["UrlAPI"].ToString();

            Response response = await _apiService.GetListAsync<ProductResponse>(url, "/api", "/Products");

            IsRunning = false;

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            _myProducts = (List<ProductResponse>)response.Result;
            ShowProducts();
           
        }
        private void ShowProducts()
        {
            if (string.IsNullOrEmpty(Search))
            {
                Products = new ObservableCollection<ProductResponse>(_myProducts);
            }
            else
            {
                Products =new ObservableCollection<ProductResponse>(
                    _myProducts.Where(propa =>p.Name.ToLower().Contains(seach.ToLower())));
            }
        }

    }



}
