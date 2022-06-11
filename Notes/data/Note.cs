using SQLite;

namespace Notes.data
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public string Date { get; set; }
    }
}
