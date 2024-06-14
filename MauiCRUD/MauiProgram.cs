using CommunityToolkit.Maui;
using MauiCRUD.Models;
using MauiCRUD.Repositories;
using MauiCRUD.ViewModels;
using MauiCRUD.Views;
using Microsoft.Extensions.Logging;

namespace MauiCRUD
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<StudyGroup>();
            builder.Services.AddSingleton<IStudyGroupRepository, StudyGroupRepository>();

            builder.Services.AddSingleton<CrudView>();
            builder.Services.AddSingleton<CrudViewModel>();

            builder.Services.AddSingleton<StudyGroupView>();
            builder.Services.AddSingleton<StudyGroupViewModel>();

            builder.Services.AddSingleton<EditView>();
            builder.Services.AddSingleton<EditViewModel>();

            return builder.Build();
        }
    }
}