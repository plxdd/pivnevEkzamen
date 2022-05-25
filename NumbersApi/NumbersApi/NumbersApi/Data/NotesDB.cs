using NumbersApi.Models;
using SQLite;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NumbersApi.Data
{
    public class NotesDB
    {
        private readonly SQLiteAsyncConnection _localDB;

        public NotesDB(string connectionString)
        {
            _localDB = new SQLiteAsyncConnection(connectionString);

            _localDB.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _localDB.Table<Note>().ToListAsync();
        }

        public Task<Note> GetNoteAsync(int id)
        {
            return _localDB.Table<Note>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public async Task<int> AddNoteAsync(Note note)
        {
            await _localDB.InsertAsync(note);

            var client = new HttpClient();
            note.Fact = await client.GetStringAsync($"http://numbersapi.com/{note.ID}");

            return await UpdateNoteAsync(note);
        }

        public Task<int> UpdateNoteAsync(Note note)
        {
            return _localDB.UpdateAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _localDB.DeleteAsync(note);
        }
    }
}
