using System.ComponentModel.DataAnnotations;

namespace OOPFive
//Создать хранилище книг.
//Каждая книга имеет название, автора и год выпуска
//(можно добавить еще параметры).
//В хранилище можно добавить книгу,
//убрать книгу,
//показать все книги и показать книги по указанному параметру
//(по названию, по автору, по году выпуска).
//Про указанный параметр,
//к примеру нужен конкретный автор,
//выбирается показ по авторам,
//запрашивается у пользователя автор и показываются все книги с этим автором.
{

    class BookStorage
    {
        Dictionary<int, BookInformation> collection = new Dictionary<int, BookInformation>();
        BookInformation bookInformation = new BookInformation();

        public void AddBook()
        {
            Console.WriteLine("Введите индекс книги.");
            bookInformation.BookIndex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите название книги.");
            bookInformation.NameBook = Console.ReadLine();

            Console.WriteLine("Введите имя автора.");
            bookInformation.AuthorBook = Console.ReadLine();

            Console.WriteLine("Введите год издания.");
            bookInformation.YearOfManufacture = Convert.ToInt32(Console.ReadLine());

            collection.Add(bookInformation.BookIndex, new BookInformation()
            {
                NameBook = bookInformation.NameBook,
                AuthorBook = bookInformation.AuthorBook,
                YearOfManufacture = bookInformation.YearOfManufacture
            });
        }

        public void SearchBooks()
        {
            Console.WriteLine();
            Console.WriteLine("Найти Книгу: Введите индекс книги или год выпуска.");

            int specialNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            foreach (var authorOrBook in collection.Values)
                if (specialNumber == authorOrBook.BookIndex
                    || specialNumber == authorOrBook.YearOfManufacture)
                {
                    Console.WriteLine("Вы искали: " 
                        + authorOrBook.BookIndex
                        + authorOrBook.NameBook
                        + " " + authorOrBook.AuthorBook + " "
                        + authorOrBook.YearOfManufacture);
                }
        }

        public void Display()
        {
            foreach (KeyValuePair<int, BookInformation> bookInformation in collection)
            {
                Console.WriteLine($"Индекс книги: {bookInformation.Key}.\n" +
                    $"Название книги: {bookInformation.Value.NameBook}.\n" +
                    $"Имя автора: {bookInformation.Value.AuthorBook}.\n" +
                    $"Год выпуска: {bookInformation.Value.YearOfManufacture}.");
                Console.WriteLine();
            }
        }

        public void RemoveBook()
        {
            SearchBooks();

            Console.WriteLine();
            Console.WriteLine("Выберите книгу: Введите индекс книги.");

            int specialNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            collection.Remove(specialNumber);
        }
    }

    class BookInformation
    {
        private string nameBook;
        private string authorBook;

        private int yearOfManufacture;
        private int bookIndex;

        public BookInformation()
        {
            BookIndex = bookIndex;
            NameBook = nameBook;
            YearOfManufacture = yearOfManufacture;
            AuthorBook = authorBook;
        }

        public string NameBook { get { return nameBook; } set { nameBook = value; } }
        public string AuthorBook { get { return authorBook; } set { authorBook = value; } }

        public int BookIndex { get { return bookIndex; } set { bookIndex = value; } }
        public int YearOfManufacture { get { return yearOfManufacture; } set { yearOfManufacture = value; } }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BookInformation> collection = new Dictionary<int, BookInformation>();
            BookStorage bookStorage = new BookStorage();

            while (true)
            {
                Console.WriteLine("Выберите команду: \n1 - Добавить книгу и автора. " +
                    "\n2 - Поиск по автору или названию. " +
                    "\n3 - Показать всю коллекцию. " +
                    "\n4 - Удалить автора книгу.");

                string comandConsole = Console.ReadLine();

                if (int.TryParse(comandConsole, out int _comandConsole))
                {
                    switch (_comandConsole)
                    {
                        case (int)NumberCalculated.AddBookAndAuthor:
                            bookStorage.AddBook();
                            break;

                        case (int)NumberCalculated.ShowSearchBooks:
                            bookStorage.SearchBooks();
                            break;

                        case (int)NumberCalculated.Display:
                            bookStorage.Display();
                            break;

                        case (int)NumberCalculated.RemoveBook:
                            bookStorage.RemoveBook();
                            break;

                        default:
                            Console.WriteLine("Неизвестная команда. Повторите ввод команды.");
                            break;
                    }
                }

            }

        }
    }

    enum NumberCalculated
    {
        AddBookAndAuthor = 1,
        ShowSearchBooks,
        Display,
        RemoveBook
    }
}