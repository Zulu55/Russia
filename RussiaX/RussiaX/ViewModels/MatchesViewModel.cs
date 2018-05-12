namespace RussiaX.ViewModels
{
    using Models;
    using RussiaX.Helpers;
    using Services;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class MatchesViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        private bool isRefreshing;
        #endregion

        #region Attributes
        private ObservableCollection<Match> matches;
        private List<Match> myMatches;
        #endregion

        #region Properties
        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ObservableCollection<Match> Matches
        {
            get { return this.matches; }
            set { this.SetValue(ref this.matches, value); }
        }
        #endregion

        #region Constructors
        public MatchesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadMatches();
        }
        #endregion

        #region Methods
        private async void LoadMatches()
        {
            this.IsRefreshing = true;

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await this.apiService.GetList<Match>(
                apiSecurity,
                "/api", 
                "/Matches", 
                MainViewModel.GetInstance().Token.TokenType, 
                MainViewModel.GetInstance().Token.AccessToken);

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            this.myMatches = (List<Match>)response.Result;
            foreach (var match in this.myMatches)
            {
                match.DateTime = match.DateTime.ToLocalTime();
            }

            this.Matches = new ObservableCollection<Match>(this.myMatches);
            this.IsRefreshing = false;
        }
        #endregion
    }
}
