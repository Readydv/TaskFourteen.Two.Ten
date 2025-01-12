using System;
using System.Linq;

namespace TaskFourteen.Two.Ten
{
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                // Читаем введенный с консоли символ
                var keyChar = Console.ReadKey().KeyChar;
                Console.Clear();

                // проверяем, число ли это
                var parsed = Int32.TryParse(keyChar.ToString(), out int pageNumber);

                // если не соответствует критериям - показываем ошибку
                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine();
                    Console.WriteLine("Страницы не существует");
                }
                // если соответствует - запускаем вывод
                else
                {
                    // Сортировка сперва по имени, а затем по фамилии
                    var sorterBook = phoneBook.OrderBy(s => s.Name)
                        .ThenBy(s => s.LastName);

                    var pageContent = sorterBook.Skip((pageNumber - 1) * 2).Take(2);

                    

                    Console.WriteLine();

                    foreach (var content in pageContent)
                    {
                        Console.WriteLine(content.Name + " " + content.LastName + " " + ": " + content.PhoneNumber);
                    }
                }
            }
        }
        public class Contact // модель класса
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
        }
    }
}
