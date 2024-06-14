using MauiCRUD.Models;
using SQLite;

namespace MauiCRUD.Repositories
{
    public class StudyGroupRepository : IStudyGroupRepository
    {
        private string dbName = "studygroup.db3";
        private SQLiteAsyncConnection con;
        
        public async Task Init()
        {
            if (con != null)
                return;

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), dbName);

            con = new SQLiteAsyncConnection(dbPath);
            await con.CreateTableAsync<StudyGroup>();
        }

        public async Task<List<StudyGroup>> GetAllStudyGroups()
        {
            await Init();
            try
            {
                return await con.Table<StudyGroup>().ToListAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StudyGroup> GetById(int id)
        {
            await Init();
            try
            {
                return await con.Table<StudyGroup>().ElementAtAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task AddStudyGroup(StudyGroup studyGroup)
        {
            await Init();
            try
            {
                await con.InsertAsync(studyGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateStudyGroup(StudyGroup studyGroup)
        {
            await Init();
            try
            {
                await con.UpdateAsync(studyGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteStudyGroup(StudyGroup studyGroup)
        {
            await Init();
            try
            {
                await con.DeleteAsync(studyGroup);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
