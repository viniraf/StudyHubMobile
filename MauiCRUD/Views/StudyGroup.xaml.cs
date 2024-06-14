using MauiCRUD.ViewModels;

namespace MauiCRUD.Views;

public partial class StudyGroupView : ContentPage
{
	StudyGroupViewModel viewModel;
	public StudyGroupView(StudyGroupViewModel viewModel)
	{
		//InitializeComponent();
		this.BindingContext = this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetStudyGroupsCommand.Execute(null);
    }

}