using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Maui.Alerts;
using MauiCRUD.Models;
using MauiCRUD.Views;

namespace MauiCRUD.ViewModels
{
    public partial class CrudViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string link;

        [RelayCommand]
        public async Task GetStudyGroups()
        {
            await Shell.Current.GoToAsync($"//{nameof(StudyGroupView)}");
            Title = null;
            Description = null;
            Link = null;
        }

        [RelayCommand]
        public async Task Save()
        {
            var studyGroup = new StudyGroup()
            {
                Title = Title,
                Description = Description,
                Link = Link
            };

            var studyGroups = await App.StudyGroupRepository.GetAllStudyGroups();

            foreach(var item in studyGroups)
            {
                if (Link == item.Link)
                {
                    await App.Current.MainPage.DisplayAlert("Erro", "Grupo já está registrado!", "OK");
                    return;
                }
            }

            if (Title != null && Description != null && Link != null)
            {
                await App.StudyGroupRepository.AddStudyGroup(studyGroup);
                await Toast.Make("Grupo de estudo registrado!").Show();
                return;
            }

            else
            {
                await App.Current.MainPage.DisplayAlert("Erro","Preencha todos os campos!","OK");
                return;
            }
        }

        [RelayCommand]
        public async Task Edit()
        {
            var studyGroups = await App.StudyGroupRepository.GetAllStudyGroups();

            if(studyGroups == null)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Nenhum grupo de estudo cadastrado!", "OK");
                return;
            }

            foreach (var studyGroup in studyGroups)
            {
                if (Title == studyGroup.Title)
                {
                    studyGroup.Title = Title;
                    studyGroup.Description = Description;
                    studyGroup.Link = Link;
                    await App.StudyGroupRepository.UpdateStudyGroup(studyGroup);
                    return;
                }
            }

            await App.Current.MainPage.DisplayAlert("Erro", "Grupo de estudo inexistente!", "OK");
            return;
        }

    }
}
