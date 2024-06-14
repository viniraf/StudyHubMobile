using MauiCRUD.Repositories;

namespace MauiCRUD
{
    public partial class App : Application
    {
        public static IStudyGroupRepository StudyGroupRepository { get; private set; }

        public App(IStudyGroupRepository studyGroupRepository)
        {
            InitializeComponent();

            MainPage = new AppShell();

            StudyGroupRepository = studyGroupRepository;
        }
    }
}