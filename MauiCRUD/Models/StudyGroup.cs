using SQLite;

namespace MauiCRUD.Models
{
    [Table("StudyGroup")]
    public class StudyGroup
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Link { get; set; }
    }
}
