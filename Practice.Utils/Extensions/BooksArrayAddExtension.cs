using Practice.Utils.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Utils.Extensions
{
    internal static partial class Extension
    {
        internal static void Add(this Book[] books, Book book)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] is null)
                {
                    books[i] = book;
                    break;
                }
            }
        }
    }
}
