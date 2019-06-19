﻿using Didaktika.MVVM;
using StyleFluentWpf.CustomControls.ControlNavigation;
using System;
using Wallee.Interfaces;

namespace Wallee.ViewModels
{
    public class ViewModelContainerSearch : ViewModel
    {
        public ServiceNavigation ServiceNavigationSpaceImages { get; set; } = new ServiceNavigation();
        public CustomCommand CommandSearch { get; }
        private IServiceSetting serviceSetting { get; }

        public ViewModelNavigation StartViewModel { get; }

        public ViewModelContainerSearch(IServiceSetting serviceSetting)
        {
            this.serviceSetting = serviceSetting;

            StartViewModel = new ViewModelCategories(serviceSetting, ExecuteCommandSendTag);

            #region RegisterCommand

            CommandSearch = new CustomCommand(ButtonSearch_OnClick);

            //CommandNextImage.InputGestures.Add(new KeyGesture(Key.Right));
            //CommandBackImage.InputGestures.Add(new KeyGesture(Key.Left));

            #endregion
        }

        private void ExecuteCommandSendTag(object obj)
        {
            ButtonSearch_OnClick(obj);
        }

        #region Property CurrentViewModel(ViewModel)

        private ViewModel _currentViewModel;

        public ViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        #endregion


        #region Property TextSearch(string)

        private string _textSearch;

        public string TextSearch
        {
            get { return _textSearch; }
            set
            {
                _textSearch = value;
                OnPropertyChanged(nameof(TextSearch));
            }
        }

        #endregion


        private async void ButtonSearch_OnClick(object text)
        {
            TextSearch = (string) text;

            if (ServiceNavigationSpaceImages.CurrentViewModel is ViewModelMorePhoto moorePhoto)
            {
                await moorePhoto.SearchByText(TextSearch);


                //numPage = 1;
                //  ServiceUnsplash.Reset();

                Console.WriteLine("do");
            }
            else
                ServiceNavigationSpaceImages.OpenViewModel(new ViewModelMorePhoto(serviceSetting, TextSearch));
        }

        #region Commands

        #region Properties

        #endregion


        #region Methods

        #endregion

        #endregion
    }
}