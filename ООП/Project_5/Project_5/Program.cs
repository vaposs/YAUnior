using System;
using System.Collections.Generic;

namespace Project_5
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            library.Begin();
        }
    }

    class Library
    {
        private List<Book> _books = new List<Book>();

        public void Begin()
        {
            const string AddBookCommand = "1";
            const string DeleteBookCommand = "2";
            const string SortedBookCommand = "3";
            const string PrintBookCommand = "4";
            const string PrintSortBookCommand = "5";
            const string ExitProgramCommand = "6";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"{AddBookCommand}. Добавить книгу");
                Console.WriteLine($"{DeleteBookCommand}. Удалить книгу");
                Console.WriteLine($"{SortedBookCommand}. Отсортировать книги");
                Console.WriteLine($"{PrintBookCommand}. Вывести список книг");
                Console.WriteLine($"{PrintSortBookCommand}. Вывести не полный список книг");
                Console.WriteLine($"{ExitProgramCommand}. Выход");

                Console.Write($"Введите номер команды - ");

                string command;
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case AddBookCommand:
                        AddBook();
                        break;

                    case DeleteBookCommand:
                        DeleteBook();
                        break;

                    case SortedBookCommand:
                        Sorted();
                        break;

                    case PrintBookCommand:
                        PrintLibrary(_books);
                        break;

                    case PrintSortBookCommand:
                        PrintSortLibrary();
                        break;

                    case ExitProgramCommand:
                        isWork = false;
                        break;
                }
            }
        }

        private void AddBook()
        {
            Console.Write("Введите название книги: ");
            string name = Console.ReadLine();
            Console.Write("Введите имя автора: ");
            string author = Console.ReadLine();
            Console.Write("Введите год выхода в свет: ");
            int bookRelease = GetNumber();
            Console.WriteLine("Выберите жанр книги:");
            string genre = GenreSelection();
            Console.Write("Цвет обложки книги: ");
            string color = ColorBook();

            _books.Add(new Book(name, author, bookRelease, genre, color));
        }

        private int GetNumber()
        {
            string line;
            bool isConversionSucceeded = true;
            bool isNumber;
            int number = 0;

            while (isConversionSucceeded)
            {
                line = Console.ReadLine();
                isNumber = int.TryParse(line, out number);

                if (isNumber)
                {
                    if (number < 0)
                    {
                        Console.Write("Неверный ввод. Число меньше нуля. Повторите ввод - ");
                    }
                    else
                    {
                        isConversionSucceeded = false;
                    }
                }
                else
                {
                    Console.Write("Неверный ввод. Повторите ввод - ");
                }
            }

            return number;
        }

        private string ColorBook()
        {
            const string green = "1";
            const string blue = "2";
            const string yellow = "3";
            const string red = "4";

            Console.WriteLine($"{green}. Зеленый");
            Console.WriteLine($"{blue}. Синий");
            Console.WriteLine($"{yellow}. Желтый");
            Console.WriteLine($"{red}. Красная");

            Console.Write($"Введите какая обложка - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case green:
                    return "green";
                    break;

                case blue:
                    return "blue";
                    break;

                case yellow:
                    return "yellow";
                    break;

                case red:
                    return "red";
                    break;

                default:
                    Console.WriteLine("не разобрать");
                    return "white";
                    break;
            }
        }

        private void PrintLibrary(List<Book> Libr)
        {
            foreach (Book book in Libr)
            {
                book.Print();
            }
        }

        private string GenreSelection()
        {
            const string Romance = "1";
            const string Science = "2";
            const string Horror = "3";
            const string Documentary = "4";
            const string Action = "5";
            const string Drama = "6";
            const string Comedy = "7";
            const string Adventure = "8";
            const string YouChose = "9";

            string genre = "";

            Console.WriteLine($"{Romance}. Роман");
            Console.WriteLine($"{Science}. Сай-фай");
            Console.WriteLine($"{Horror}. Ужастик");
            Console.WriteLine($"{Documentary}. Документалка");
            Console.WriteLine($"{Action}. Экшен");
            Console.WriteLine($"{Drama}. Драма");
            Console.WriteLine($"{Comedy}. Комедия");
            Console.WriteLine($"{Adventure}. Приключения");
            Console.WriteLine($"{YouChose}. Ввести свой жанр -");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case Romance:
                    genre = "роман";
                    break;

                case Science:
                    genre = "сай-фай";
                    break;

                case Horror:
                    genre = "ужастик";
                    break;

                case Documentary:
                    genre = "документалка";
                    break;

                case Action:
                    genre = "экшен";
                    break;

                case Drama:
                    genre = "драма";
                    break;

                case Comedy:
                    genre = "комедия";
                    break;

                case Adventure:
                    genre = "приключения";
                    break;

                default:
                    genre = Console.ReadLine();
                    break;
            }


            return genre;
        }

        private void Sorted()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
            }
            else
            {
                const string ByName = "1";
                const string ByAuthor = "2";
                const string ByGenre = "3";

                Console.WriteLine("Как желаете отсортировать: ");
                Console.WriteLine($"{ByName}. По имени.");
                Console.WriteLine($"{ByAuthor}. По автору.");
                Console.WriteLine($"{ByGenre}. По жанру.");

                Console.Write("Введите номер команды - ");

                string command;
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case ByName:
                        SortBooksForName();
                        break;

                    case ByAuthor:
                        SortBooksForAuthor();
                        break;

                    case ByGenre:
                        SortBooksForGenre();
                        break;

                    default:
                        Console.WriteLine("Не верная команда. Сортировка не выполнена\n");
                        break;
                }
            }
        }

        private void SortBooksForName()
        {
            List<string> temp = new List<string>(_books.Count);
            List<Book> templLibrary = new List<Book>(_books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                temp.Add(_books[i].Name);
            }

            temp.Sort();

            for (int i = 0; i < _books.Count; i++)
            {
                for (int j = 0; j < _books.Count; j++)
                {
                    if (temp[i] == _books[j].Name)
                    {
                        templLibrary.Add(_books[j]);
                    }
                }
            }

            _books = templLibrary;
        }

        private void SortBooksForAuthor()
        {
            List<string> temp = new List<string>(_books.Count);
            List<Book> templLibrary = new List<Book>(_books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                temp.Add(_books[i].Author);
            }

            temp.Sort();

            for (int i = 0; i < _books.Count; i++)
            {
                for (int j = 0; j < _books.Count; j++)
                {
                    if (temp[i] == _books[j].Author)
                    {
                        templLibrary.Add(_books[j]);
                    }
                }
            }

            _books = templLibrary;
        }

        private void SortBooksForGenre()
        {
            List<string> temp = new List<string>(_books.Count);
            List<Book> templLibrary = new List<Book>(_books.Count);

            for (int i = 0; i < _books.Count; i++)
            {
                temp.Add(_books[i].Genre);
            }

            temp.Sort();

            for (int i = 0; i < _books.Count; i++)
            {
                for (int j = 0; j < _books.Count; j++)
                {
                    if (temp[i] == _books[j].Genre)
                    {
                        templLibrary.Add(_books[j]);
                    }
                }
            }

            _books = templLibrary;
        }

        private void DeleteBook()
        {
            if(_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
            }
            else
            {
                Book bookForDelete;

                Console.Write("Введите название для удаления - ");

                bookForDelete = TryGetBook();

                if (bookForDelete == null)
                {
                    Console.WriteLine("такой книги нету");
                }
                else
                {
                    _books.Remove(bookForDelete);
                    Console.WriteLine("Книга удалена.");
                }
            }
        }

        private Book TryGetBook()
        {
            string name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Name)
                {
                    return book;
                }
            }

            return null;
        }

        private void PrintSortLibrary()
        {
            const string Name = "1";
            const string Author = "2";
            const string Genre = "3";
            const string Color = "4";

            Console.WriteLine("выберите по какому принципу сортировать: ");
            Console.WriteLine($"{Name}. По имени");
            Console.WriteLine($"{Author}. По автору");
            Console.WriteLine($"{Genre}. По жанру");
            Console.WriteLine($"{Color}. По цвету обложки");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case Name:
                    PrintSortName();
                    break;

                case Author:
                    PrintSortAuthor();
                    break;

                case Genre:
                    PrintSortGenre();
                    break;

                case Color:
                    PrintSortColor();
                    break;

                default:
                    Console.WriteLine("неверная команда");
                    break;
            }
        }

        private void PrintSortName()
        {
            List<Book> names = new List<Book>(); 
            string name;

            Console.Write("Введите название - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if(name == book.Name)
                {
                    names.Add(book);
                }
            }

            PrintLibrary(names);
        }

        private void PrintSortAuthor()
        {
            List<Book> author = new List<Book>();
            string name;

            Console.Write("Введите имя автора - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Author)
                {
                    author.Add(book);
                }
            }

            PrintLibrary(author);
        }

        private void PrintSortGenre()
        {
            List<Book> genre = new List<Book>();
            string name;

            Console.Write("Введите жанр - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Genre)
                {
                    genre.Add(book);
                }
            }

            PrintLibrary(genre);
        }

        private void PrintSortColor()
        {
            List<Book> color = new List<Book>();
            string name;

            Console.Write("Введите цвет - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Color)
                {
                    color.Add(book);
                }
            }

            PrintLibrary(color);
        }
    }

    class Book
    {
        public Book(string name, string author, int bookRelease, string genre, string color)
        {
            Name = name;
            Author = author;
            BookRelease = bookRelease;
            Genre = genre;
            Color = color;
        }

        public string Name { get; private set; }
        public string Author { get; private set; }
        public int BookRelease { get; private set; }
        public string Genre { get; private set; }
        public string Color { get; private set; }

        public void Print()
        {
            const string green = "green";
            const string blue = "blue";
            const string yellow = "yellow";
            const string red = "red";

            switch (Color)
            {
                case green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.Write(Name + ", ");
            Console.Write(Author + ", ");
            Console.Write(BookRelease + ", ");
            Console.Write(Genre);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}