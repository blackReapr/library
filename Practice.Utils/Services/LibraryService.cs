using Practice.Utils.Constants;
using Practice.Utils.Models;

namespace Practice.Utils.Services
{
    internal class LibraryService
    {
        public static bool LibrarryContainsBook(Book[] books, Book book)
        {
            if (books.Contains(book))
            {
                Console.WriteLine(ResponseMessages.AlreadyExistsException);
                return false;
            }
            else if (IsLibraryFull(books))
            {
                Console.WriteLine(ResponseMessages.CapacityLimitException);
                return false;
            }
            else
            {
                Console.WriteLine("Book successfully added.");
                return true;
            }
        }
        public static Book? LibrarryContainsBook(Book[] books, int? id)
        {
            if (id is null)
            {
                Console.WriteLine(ResponseMessages.NullReferenceException);
                return null;
            }
            foreach (Book item in books)
            {
                if (item.Id == id && !item.IsDeleted) return item;

            }
            Console.WriteLine(ResponseMessages.NotFoundException);
            return null;
        }

        public static bool IsLibraryFull(Book[] books)
        {
            int count = 0;
            foreach (Book book in books)
            {
                if (book is not null)
                {
                    count++;
                }
            }
            return books.Length - 1 == count;
        }
    }
}
