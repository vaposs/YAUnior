using System;
using System.Collections.Generic;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            library.Work();
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public void Work()
        {
            const string AddCommand = "1";
            const string DeleteCommand = "2";
            const string PrintAllCommand = "3";
            const string PrintFilteredCommand = "4";
            const string ExitCommand = "5";

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine($"{AddCommand}. Добавить книгу");
                Console.WriteLine($"{DeleteCommand}. Удалить книгу");
                Console.WriteLine($"{PrintAllCommand}. Вывести список книг");
                Console.WriteLine($"{PrintFilteredCommand}. Вывести отфильтрованный список книг");
                Console.WriteLine($"{ExitCommand}. Выход");
                Console.Write("Введите номер команды - ");

                string command = Console.ReadLine();

                switch (command)
                {
                    case AddCommand:
                        AddBook();
                        break;

                    case DeleteCommand:
                        DeleteBook();
                        break;

                    case PrintAllCommand:
                        ShowAllBooks();
                        break;

                    case PrintFilteredCommand:
                        ShowFilteredBooks();
                        break;

                    case ExitCommand:
                        isRunning = false;
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddBook()
        {
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            Console.Write("Введите имя автора: ");
            string author = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            int year = GetPositiveNumber();

            Console.WriteLine("Выберите жанр книги:");
            string genre = SelectGenre();

            Console.WriteLine("Выберите цвет обложки:");
            ConsoleColor color = SelectColor();

            _books.Add(new Book(title, author, year, genre, color));
        }

        private int GetPositiveNumber()
        {
            int number;
            bool isValid = false;

            while (isValid == false)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    if (number >= 0)
                    {
                        isValid = true;
                    }
                    else
                    {
                        Console.Write("Число не может быть отрицательным. Повторите ввод - ");
                    }
                }
                else
                {
                    Console.Write("Неверный формат. Введите число - ");
                }
            }

            return number;
        }

        private ConsoleColor SelectColor()
        {
            ConsoleColor[] colors = new ConsoleColor[]
            {
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.Yellow,
                ConsoleColor.Red
            };

            string[] colorNames = new string[]
            {
                "Зеленый",
                "Синий",
                "Желтый",
                "Красный"
            };

            for (int i = 0; i < colors.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {colorNames[i]}");
            }

            Console.Write("Выберите цвет обложки - ");

            int selectedIndex = GetPositiveNumber() - 1;

            if (selectedIndex >= 0 && selectedIndex < colors.Length)
            {
                return colors[selectedIndex];
            }
            else
            {
                Console.WriteLine("Цвет не распознан, будет использован белый");
                return ConsoleColor.White;
            }
        }

        private string SelectGenre()
        {
            string[] genres = new string[]
            {
                "роман",
                "фантастика",
                "ужасы",
                "документальная",
                "экшн",
                "драма",
                "комедия",
                "приключения"
            };

            for (int i = 0; i < genres.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {genres[i]}");
            }

            Console.WriteLine($"{genres.Length + 1}. Свой вариант");
            Console.Write("Выберите жанр - ");

            int selectedIndex = GetPositiveNumber() - 1;

            if (selectedIndex >= 0 && selectedIndex < genres.Length)
            {
                return genres[selectedIndex];
            }
            else if (selectedIndex == genres.Length)
            {
                Console.Write("Введите свой вариант жанра: ");
                return Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Неверный выбор, будет использован жанр 'роман'");
                return genres[0];
            }
        }

        private void ShowAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста");
                return;
            }

            for (int i = 0; i < _books.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                PrintBook(_books[i]);
            }
        }

        private void PrintBook(Book book)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = book.CoverColor;

            Console.Write($"{book.Title}, {book.Author}, {book.Year}, {book.Genre}");
            Console.WriteLine();

            Console.ForegroundColor = originalColor;
        }

        private void DeleteBook()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }

            ShowAllBooks();

            Console.Write("Введите номер книги для удаления - ");
            int index = GetPositiveNumber() - 1;

            if (index >= 0 && index < _books.Count)
            {
                _books.RemoveAt(index);
                Console.WriteLine("Книга удалена");
            }
            else
            {
                Console.WriteLine("Неверный номер книги");
            }
        }

        private void ShowFilteredBooks()
        {
            const string FilterByTitle = "1";
            const string FilterByAuthor = "2";
            const string FilterByGenre = "3";
            const string FilterByColor = "4";

            Console.WriteLine("Выберите критерий фильтрации:");
            Console.WriteLine($"{FilterByTitle}. По названию");
            Console.WriteLine($"{FilterByAuthor}. По автору");
            Console.WriteLine($"{FilterByGenre}. По жанру");
            Console.WriteLine($"{FilterByColor}. По цвету обложки");
            Console.Write("Введите номер команды - ");

            string choice = Console.ReadLine();

            List<Book> filteredBooks = new List<Book>();

            switch (choice)
            {
                case FilterByTitle:
                    Console.Write("Введите название - ");
                    string title = Console.ReadLine();
                    filteredBooks = _books.FindAll(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                    break;

                case FilterByAuthor:
                    Console.Write("Введите имя автора - ");
                    string author = Console.ReadLine();
                    filteredBooks = _books.FindAll(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
                    break;

                case FilterByGenre:
                    Console.Write("Введите жанр - ");
                    string genre = Console.ReadLine();
                    filteredBooks = _books.FindAll(book => book.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
                    break;

                case FilterByColor:
                    ConsoleColor color = SelectColor();
                    filteredBooks = _books.FindAll(book => book.CoverColor == color);
                    break;

                default:
                    Console.WriteLine("Неверная команда");
                    return;
            }

            if (filteredBooks.Count == 0)
            {
                Console.WriteLine("Книги не найдены");
            }
            else
            {
                Console.WriteLine($"Найдено книг: {filteredBooks.Count}");
                
                foreach (Book book in filteredBooks)
                {
                    PrintBook(book);
                }
            }
        }
    }

    class Book
    {
        public Book(string title, string author, int year, string genre, ConsoleColor coverColor)
        {
            Title = title;
            Author = author;
            Year = year;
            Genre = genre;
            CoverColor = coverColor;
        }

        public string Title { get; }
        public string Author { get; }
        public int Year { get; }
        public string Genre { get; }
        public ConsoleColor CoverColor { get; }
    }
}
