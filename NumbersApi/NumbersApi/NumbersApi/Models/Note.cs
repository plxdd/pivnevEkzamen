using SQLite;
using System.Net.Http;

namespace NumbersApi.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Text { get; set; }

        public string Fact { get; set; }

       
    }
}
