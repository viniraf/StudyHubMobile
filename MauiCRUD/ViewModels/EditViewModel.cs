using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCRUD.Views;

namespace MauiCRUD.ViewModels
{
    public partial class EditViewModel : ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string link;

        [RelayCommand]
        private async Task GetStudyGroups()
        {
            var studyGroups = await App.StudyGroupRepository.GetAllStudyGroups();

            foreach (var studyGroup in studyGroups)
            {
                if (studyGroup.Id == StudyGroupViewModel.Id)
                {
                    Title = studyGroup.Title;
                    Description = studyGroup.Description;
                    Link = studyGroup.Link;

                }
            }
        }

        [RelayCommand]
        public async Task Save()
        {
            var studyGroups = await App.StudyGroupRepository.GetAllStudyGroups();

            foreach (var studyGroup in studyGroups)
            {
                if (studyGroup.Id == StudyGroupViewModel.Id)
                {
                    studyGroup.Title = Title;
                    studyGroup.Description = Description;
                    studyGroup.Link = Link;

                    await App.StudyGroupRepository.UpdateStudyGroup(studyGroup);
                    await Toast.Make("Grupo alterado!").Show();

                    Title = null;
                    Description = null;
                    Link = null;
                    await Shell.Current.GoToAsync($"//{nameof(StudyGroupView)}");
                }
            }
        }

        [RelayCommand]
        public async Task Cancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(StudyGroupView)}");
        }
    }
}
