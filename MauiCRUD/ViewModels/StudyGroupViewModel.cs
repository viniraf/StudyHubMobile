using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCRUD.Models;
using MauiCRUD.Views;
using System.Collections.ObjectModel;

namespace MauiCRUD.ViewModels
{
    public partial class StudyGroupViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<StudyGroup> listStudyGroups;

        public static int Id { get; set; }

        public StudyGroupViewModel()
        {
            ListStudyGroups = new ObservableCollection<StudyGroup>();
        }

        [RelayCommand]
        public async Task TapDelete(StudyGroup studyGroup)
        {
            var confirm = await App.Current.MainPage.DisplayAlert("AVISO", "Excluir grupo de estudo?", "SIM", "NÃO");
            if (confirm)
            {
                await App.StudyGroupRepository.DeleteStudyGroup(studyGroup);
                await GetStudyGroups();
            }
        }

        [RelayCommand]
        public async Task TapEdit(StudyGroup studyGroup)
        {
            Id = studyGroup.Id;
            await Shell.Current.GoToAsync($"//{nameof(EditView)}");
        }

        [RelayCommand]
        private async Task GetStudyGroups()
        {
            var studyGroups = await App.StudyGroupRepository.GetAllStudyGroups();
            MapToObservableCollection(studyGroups);
        }

        private void MapToObservableCollection(List<StudyGroup> studyGroups)
        {
            ListStudyGroups.Clear();
            foreach (var studyGroup in studyGroups)
            {
                ListStudyGroups.Add(studyGroup);
            }
        }

        [RelayCommand]
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync($"//{nameof(CrudView)}");
        }
    }
}
