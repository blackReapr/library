using Practice.Utils.Enums;
using Practice.Utils.Models;


Console.WriteLine("Enter your username:");
string username = Console.ReadLine();

Console.WriteLine("Enter your email:");
string email = Console.ReadLine();

Console.WriteLine("Enter your role:\n1.Admin\n2.Member");

int value;

while (!int.TryParse(Console.ReadLine(), out value) || (value < 1 || value > 2))
{
    Console.WriteLine("Wrong input! Enter again");
}


Roles role = (Roles)value;

User user = new(username, email, role);

bool isAdmin = value == 1;
if (isAdmin) AdminApp();



void AdminApp()
{
    bool running = true;
    Console.WriteLine("Enter the limit of books: ");
    int limit = Convert.ToInt32(Console.ReadLine());

    Library library = new Library(limit);
    while (running)
    {

        if (isAdmin)
        {
            Console.WriteLine("1. AddBook");
            Console.WriteLine("2. GetAllBooks");
            Console.WriteLine("3. DeleteBookById");
            Console.WriteLine("4. EditBookName");
            Console.WriteLine("5. FilterByPageCount");
            Console.WriteLine("6. Quit");

            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter book's name: ");
                string bookName = Console.ReadLine();
                Console.WriteLine("Enter author's name: ");
                string authorName = Console.ReadLine();
                Console.WriteLine("Enter page count: ");
                int pageCount = Convert.ToInt32(Console.ReadLine());

                Book book = new Book(bookName, authorName, pageCount);
                library.AddBook(book);
            }
            else if (choice == 2)
            {
                Book[] books = library.GetAllBooks();
                for (int i = 0; i < books.Length; i++)
                {
                    if (books[i] is null) break;
                    Console.WriteLine($"{books[i].Id}. {books[i].Name}");
                }
            }
            else if (choice == 3)
            {
                Console.WriteLine("Enter the id of the book you wanna delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                library.DeleteBookById(id);
            }
            else if (choice == 4)
            {
                Console.WriteLine("Enter the id of the book you wanna edit: ");
                int id = Convert.ToInt32(Console.ReadLine());
                library.EditBookName(id);
            }
            else if (choice == 5)
            {
                Console.WriteLine("Enter the minimum page count: ");
                int minPageCount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the maximum page count: ");
                int maxPageCount = Convert.ToInt32(Console.ReadLine());
                Book[] books = library.FilterByPageCount(minPageCount, maxPageCount);
                for (int i = 0; i < books.Length; i++)
                {
                    Console.WriteLine($"{i}. {books[i].Name}");
                }
            }
            else if (choice == 6)
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }
    }

}


void MemberApp()
{
    bool running = true;
    Library library = new Library(5);

}


void FakeData()
{

}


