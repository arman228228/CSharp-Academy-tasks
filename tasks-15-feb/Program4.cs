using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            Book[] books = new Book[3]
            {
                new Book { Title = "Title 1", Author = "Author 1" },
                new Book { Title = "Title 2", Author = "Author 2" },
                new Book { Title = "Title 3", Author = "Author 3" }
            };

            Console.WriteLine("Available books:");
            foreach (Book book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Choose book (1 to 3 or 4 for exit).");

                int book = int.Parse(Console.ReadLine());

                if (book == 4)
                {
                    exit = true;
                    Console.WriteLine("Exit program");
                }
                else if(book > 0 && book < 4)
                {
                    book--; // real index from user input
                    
                    bool exitNestedWhile = false;
                    
                    while(!exitNestedWhile)
                    {
                        Console.WriteLine($"\nSelected book: {books[book].Title} (№: {book + 1}). Choose process:\n1 - Borrow\n2 - Return\n\n3 - Back");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                if (books[book].IsAvailable == false)
                                {
                                    Console.WriteLine("Borrow not available for this book");
                                    break;
                                }

                                books[book].BorrowBook();

                                Console.WriteLine(
                                    $"\nBorrow book: {books[book].Title} (№: {book + 1}). Books current details:");

                                foreach (Book bookID in books)
                                {
                                    Console.WriteLine(
                                        $"Title: {bookID.Title}, Author: {bookID.Author}, Availability: {bookID.IsAvailable}");
                                }

                                break;
                            case 2:
                                if (books[book].IsAvailable == true)
                                {
                                    Console.WriteLine("Return not available for this book");
                                    break;
                                }

                                books[book].ReturnBook();

                                Console.WriteLine("Books current details:");

                                foreach (Book bookID in books)
                                {
                                    Console.WriteLine(
                                        $"Title: {bookID.Title}, Author: {bookID.Author}, Availability: {bookID.IsAvailable}");
                                }

                                break;
                            case 3:
                                exitNestedWhile = true;
                                Console.WriteLine("Back");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid parameter");
                }
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; } = true;

        public void BorrowBook()
        {
            IsAvailable = false;
        }

        public void ReturnBook()
        {
            IsAvailable = true;
        }
    }
}