using System;
using System.Collections.Generic;

//5) Методы сортировки разорвали шаблон - они увеличивают количество книг в какой-то геометрической прогрессии.


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
                        PrintLibrary();
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
            int bookRelease = GetPositiveNumber();
            Console.WriteLine("Выберите жанр книги:");
            string genre = GenreSelection();
            Console.Write("Цвет обложки книги: ");
            string color = ColorBook();

            _books.Add(new Book(name, author, bookRelease, genre, color));
        }

        private int GetPositiveNumber()
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
            const string GreenCommand = "1";
            const string BlueCommand = "2";
            const string YellowCommand = "3";
            const string RedCommand = "4";

            Console.WriteLine($"{GreenCommand}. Зеленый");
            Console.WriteLine($"{BlueCommand}. Синий");
            Console.WriteLine($"{YellowCommand}. Желтый");
            Console.WriteLine($"{RedCommand}. Красная");

            Console.Write($"Введите какая обложка - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case GreenCommand:
                    return "green";
                    break;

                case BlueCommand:
                    return "blue";
                    break;

                case YellowCommand:
                    return "yellow";
                    break;

                case RedCommand:
                    return "red";
                    break;

                default:
                    Console.WriteLine("не разобрать");
                    return "white";
                    break;
            }
        }

        private void PrintLibrary()
        {
            if(-_books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста");
            }
            else
            {
                int numberBook = 1;
                foreach (Book book in _books)
                {
                    Console.Write(numberBook++ + ". ");
                    book.Print();
                }
            }
        }

        private string GenreSelection()
        {
            const string RomanceCommand = "1";
            const string ScienceCommand = "2";
            const string HorrorCommand = "3";
            const string DocumentaryCommand = "4";
            const string ActionCommand = "5";
            const string DramaCommand = "6";
            const string ComedyCommand = "7";
            const string AdventureCommand = "8";
            const string YouChoseCommand = "9";

            string genre = "";

            Console.WriteLine($"{RomanceCommand}. Роман");
            Console.WriteLine($"{ScienceCommand}. Сай-фай");
            Console.WriteLine($"{HorrorCommand}. Ужастик");
            Console.WriteLine($"{DocumentaryCommand}. Документалка");
            Console.WriteLine($"{ActionCommand}. Экшен");
            Console.WriteLine($"{DramaCommand}. Драма");
            Console.WriteLine($"{ComedyCommand}. Комедия");
            Console.WriteLine($"{AdventureCommand}. Приключения");
            Console.WriteLine($"{YouChoseCommand}. Ввести свой жанр -");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case RomanceCommand:
                    genre = "роман";
                    break;

                case ScienceCommand:
                    genre = "сай-фай";
                    break;

                case HorrorCommand:
                    genre = "ужастик";
                    break;

                case DocumentaryCommand:
                    genre = "документалка";
                    break;

                case ActionCommand:
                    genre = "экшен";
                    break;

                case DramaCommand:
                    genre = "драма";
                    break;

                case ComedyCommand:
                    genre = "комедия";
                    break;

                case AdventureCommand:
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
            List<string> tempName = new List<string>();
            List<string> tempGenre = new List<string>();
            List<string> tempColor = new List<string>();


            List<Book> templLibrary = new List<Book>();

            for (int i = 0; i < _books.Count; i++)
            {
                tempName.Add(_books[i].Name);
                tempColor.Add(_books[i].Color);
                tempGenre.Add(_books[i].Genre);

            }

            tempName.Sort();

            for (int i = 0; i < _books.Count; i++)
            {
                foreach(Book book in _books)
                {
                    if(tempName[i] == book.Name && tempGenre[i] == book.Genre && tempColor[i] == book.Color)
                    {
                        templLibrary.Add(book);
                    }
                }
            }

            _books = templLibrary;
        }

        private void SortBooksForAuthor()
        {
            List<string> temp = new List<string>();
            List<Book> templLibrary = new List<Book>();

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
            List<string> temp = new List<string>();
            List<Book> templLibrary = new List<Book>();

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
                Console.Write("Введите номер книги для удаления - ");
                int bookForDelete = GetPositiveNumber();

                if(bookForDelete - 1 > _books.Count)
                {
                    Console.WriteLine("неверный номер книги");
                }
                else
                {
                    _books.RemoveAt(bookForDelete - 1);
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
            const string NameCommand = "1";
            const string AuthorCommand = "2";
            const string GenreCommand = "3";
            const string ColorCommand = "4";

            Console.WriteLine("выберите по какому принципу сортировать: ");
            Console.WriteLine($"{NameCommand}. По имени");
            Console.WriteLine($"{AuthorCommand}. По автору");
            Console.WriteLine($"{GenreCommand}. По жанру");
            Console.WriteLine($"{ColorCommand}. По цвету обложки");

            Console.Write($"Введите номер команды - ");

            string command;
            command = Console.ReadLine();

            switch (command.ToLower())
            {
                case NameCommand:
                    PrintSortName();
                    break;

                case AuthorCommand:
                    PrintSortAuthor();
                    break;

                case GenreCommand:
                    PrintSortGenre();
                    break;

                case ColorCommand:
                    PrintSortColor();
                    break;

                default:
                    Console.WriteLine("неверная команда");
                    break;
            }
        }

        private void PrintSortName()
        {
            string name;

            Console.Write("Введите название - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if(name == book.Name)
                {
                    book.Print();
                }
            }
        }

        private void PrintSortAuthor()
        {
            string name;

            Console.Write("Введите имя автора - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Author)
                {
                    book.Print();
                }
            }
        }

        private void PrintSortGenre()
        {
            string name;

            Console.Write("Введите жанр - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Genre)
                {
                    book.Print();
                }
            }
        }

        private void PrintSortColor()
        {
            string name;

            Console.Write("Введите цвет - ");
            name = Console.ReadLine();

            foreach (Book book in _books)
            {
                if (name == book.Color)
                {
                    book.Print();
                }
            }
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
            const string GreenCommand = "green";
            const string BlueCommand = "blue";
            const string YellowCommand = "yellow";
            const string RedCommand = "red";

            switch (Color)
            {
                case GreenCommand:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case BlueCommand:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case YellowCommand:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case RedCommand:
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