using Practice.Interfaces;

namespace Practice.Utils.Models
{
    public class Book : IEntity
    {
        public Book(string name, string authorName, int pageCount)
        {
            StaticId++;
            Id = StaticId;
            Name = name;
            AuthorName = authorName;
            PageCount = pageCount;
        }
        private static int StaticId { get; set; }
        public int Id { get; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void ShowInfo()
        {
            Console.WriteLine(Id + " " + Name);
        }
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Book) return false;
            if (IsDeleted) return true;
            Book book = obj as Book;
            if (book.Name == Name) return true;
            return false;
        }
    }
}
