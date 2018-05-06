using SQLite;

namespace UWOScholar
{
    public class Folder
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(15), Unique, NotNull]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}