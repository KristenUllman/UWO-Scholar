using SQLite;

namespace UWOScholar
{
    [Table("folders")]
    internal class FolderTable
    {
        [PrimaryKey, AutoIncrement, Column("_FolderId")]
        public int folderId { get; set; }

        [MaxLength(15), Unique, NotNull]
        public string FolderName { get; set; }
        
    }
}