using MauiCRUD.Models;

namespace MauiCRUD.Repositories
{
    public interface IStudyGroupRepository
    {
        Task Init();
        Task<List<StudyGroup>> GetAllStudyGroups();
        Task<StudyGroup> GetById(int id);
        Task AddStudyGroup(StudyGroup studyGroup);
        Task UpdateStudyGroup(StudyGroup studyGroup);
        Task DeleteStudyGroup(StudyGroup studyGroup);

    }
}
