using SQLite;
using System.Collections.Generic;

namespace Notes.data
{
    public class NotesRepository
    {
        SQLiteConnection database;
        public NotesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
        }
        public IEnumerable<Note> GetItems()
        {
            return database.Table<Note>();
        }
        public Note GetItem(int id)
        {
            return database.Get<Note>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Note>(id);
        }
        public int SaveItem(Note item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
