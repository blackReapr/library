using Practice.Interfaces;
using Practice.Utils.Extensions;
using Practice.Utils.Services;

namespace Practice.Utils.Models
{
    public class Library : IEntity
    {
        public Library(int limit)
        {
            StaticId++;
            Id = StaticId;
            BookLimit = limit;
            Books = new Book[limit];
        }
        public int Id { get; }
        private static int StaticId { get; set; }
        private int BookLimit { get; set; }
        private Book[] Books { get; set; }

        #region AddBook
        public void AddBook(Book book)
        {
            if (LibraryService.LibrarryContainsBook(Books, book))
            {
                Books.Add(book);
            }
            
        }
        #endregion

        #region GetBookById
        public Book? GetBookById(int? id)
        {
            Book? book = LibraryService.LibrarryContainsBook(Books, id);
            return book;
        }
        #endregion

        #region GetAllBooks
        public Book[] GetAllBooks()
        {
            Book[] books = new Book[BookLimit];
            for (int i = 0; i < BookLimit; i++)
            {
                if (!Books[i].IsDeleted) books[i] = Books[i];
            }
            return books;
        }
        #endregion

        #region DeleteBookById
        public void DeleteBookById(int? id)
        {
            Book? book = LibraryService.LibrarryContainsBook(Books, id);
            if (book is not null)
            {
                book.IsDeleted = true;
            }
        }
        #endregion

        #region EditBookName
        public void EditBookName(int? id)
        {
            Book? book = LibraryService.LibrarryContainsBook(Books, id);
            if (book is not null)
            {
                Console.WriteLine("Edit book's name: ");
                string newBookName = Console.ReadLine();
                book.Name = newBookName;
            }
        }
        #endregion

        #region FilterByPageCount
        public Book[] FilterByPageCount(int minPageCount, int maxPageCount)
        {
            Book[] filteredBooks = new Book[0];
            foreach (Book book in Books)
            {
                if (!book.IsDeleted && book.PageCount >= minPageCount && book.PageCount <= maxPageCount) filteredBooks.Add(book);
            }
            return filteredBooks;
        }
        #endregion
    }
}
