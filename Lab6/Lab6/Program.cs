using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Diagnostics;


namespace Lab6
{
    
        interface IMethodPastryInfo
        {
            void Info();
        }

        interface IPastryInfo
        {
            string weight { get; set; }
            string shape { get; set; }
            string filling { get; set; }
            int fullSugar { get; set; }

            void Info();
        }

        abstract class Pastry : IMethodPastryInfo, IPastryInfo
        {
            public string weight { get; set; }
            public string shape { get; set; }
            public string filling { get; set; }
            public bool coconutChips { get; set; }
            public int fullSugar { get; set; }

            void IPastryInfo.Info()
            {
                if (coconutChips == true)
                {
                    Console.WriteLine("Покрыто кокосовой стружкой");
                }
                else
                {
                    Console.WriteLine("Не покрыто кокосовой стружкой");
                }
            }

            void IMethodPastryInfo.Info()
            {
                Console.WriteLine("Это метод info");
            }

            public virtual void addInfo()
            {
                Console.WriteLine("Введите вес");
                weight = Console.ReadLine();
                Console.WriteLine("Введите форму");
                shape = Console.ReadLine();
                Console.WriteLine("Введите начинку");
                filling = Console.ReadLine();
                Console.WriteLine("Покрыто ли кокосовой стружкой?");
                string a = Console.ReadLine();

                if (a == "Да")
                {
                    coconutChips = true;
                }

                Console.WriteLine("\n");

            }

            public virtual void Type()
            {
                Console.WriteLine("Кондитерские изделия");
            }


            public Pastry()
            {
                weight = null;
                shape = null;
                filling = null;
                coconutChips = false;
                fullSugar = 0;
            }

            

        }

        class Candy : Pastry
        {

            public override void Type()
            {
                Console.WriteLine("Конфета");
            }

            public Candy()
            {
                

                fullSugar = 7;

                Console.WriteLine("\n");

            }

    }

        sealed class Caramel : Pastry
        {
             public Caramel()
            {
                

            fullSugar = 10;

                Console.WriteLine("\n");

            }

            public override void Type()
            {
                Console.WriteLine("Карамель");
            }
        }

        class Chocolate : Pastry
        {   
             public Chocolate()
            {
               

            fullSugar = 11;

                Console.WriteLine("\n");

            }
            
            public override void Type()
            {
                Console.WriteLine("Шоколадная конфета");
            }
        }

        class Cookie : Pastry
        {   
             public Cookie()
            {
                

            fullSugar = 6;

                Console.WriteLine("\n");

            }

            public override void Type()
            {
                Console.WriteLine("Печенюшка");
            }
        }

        class BoxOfCandies : Candy
        {
            public override void Type()
            {
                Console.WriteLine("Коробка конфет");
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj);
            }

        public BoxOfCandies()
        {
            

            fullSugar = 20;

            Console.WriteLine("\n");

        }

    }

        partial class Printer
        {
            public virtual void IAmPrinting(Pastry obj)
            {
            IAmPrinting2(obj);
            }
        }

       enum nums : byte
    {
        One = 1,
        Two = 2,
        Three = 3,
    }


    struct Person
    {
        string name;
        string surname;
        int age;

        public Person(string name, string surname, int age) : this()
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public void info()
        {
            Console.WriteLine("Name:" + name + "\n" + "Surname:" + surname + "\n" + "Age:" + age);
        }

    }

    class ChildrensGift
    {
        int weight;
        string name;

        public ChildrensGift(int aWeight,string aName)
        {
            weight = aWeight;
            name = aName;
        }

        public Pastry[] array = new Pastry[0];

        public Pastry AddElem
        {
            private get
            {
                return AddElem;
            }
            set
            {
                Array.Resize(ref array, array.Length + 1);
                array[array.Length - 1] = value;
            }
        }

        public void DeleteElem(int k)
        {
            if (k > array.Length)
            {
                throw new DelException(k, array.Length);
            }
            for (int i = k - 1; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }

        public void ShowElem()
        {
            Console.WriteLine("\nСписок сладостей:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0}.", i + 1);
                array[i].Type();
            }
            Console.WriteLine("\n");
        }

        public void FindElem(int min, int max)
        {
            bool bl = true;
            for (int i = 0; i < array.Length; i++)
            {
               
                if (array[i].fullSugar > min && array[i].fullSugar < max)
                {
                    array[i].Type();
                    bl = false;
                }
            }
            if (bl)
            {
                Console.WriteLine("Совпадений не найдено!\n");
            }
        }



    }

    public class Control
    {


        static int weight;
        static string name;

        public Control(int aWeight, string aName)
        {
            weight = aWeight;
            name = aName;
        }

        ChildrensGift gift = new ChildrensGift(weight, name);


        public void AddElem()
        {
            Console.WriteLine("Что вы хотите добавить?");
            Console.WriteLine("1. Конфета");
            Console.WriteLine("2. Шоколадка");
            Console.WriteLine("3. Печенье");
            Console.WriteLine("4. Карамель");

            int x = int.Parse(Console.ReadLine());

            if (x > 0 && x < 5)
            {
                switch (x)
                {
                    case 1:
                        gift.AddElem = new Candy();
                        break;
                    case 2:
                        gift.AddElem = new Chocolate();
                        break;
                    case 3:
                        gift.AddElem = new Cookie();
                        break;
                    case 4:
                        gift.AddElem = new Caramel();
                        break;
                }
                Console.WriteLine("сладость добавлена \n");
            }
            else
            {
                Console.WriteLine("Неверное значение \n");
            }
        }

        public void DeleteElem()
        {
            Console.Write("Введите элемент который хотите удалить: ");
            int k = int.Parse(Console.ReadLine());
            gift.DeleteElem(k);
        }

        public void ShowElem()
        {
            gift.ShowElem();
        }

        public void FindElem()
        {
            Console.Write("\nВведите нижний порог сахара: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Введите верхний порог сахара: ");
            int max = int.Parse(Console.ReadLine());
            gift.FindElem(min, max);
        }


    }

    class DelException : CandyException
    {
        public int size;
        public DelException(int val, int sz) : base(val)
        {
            size = sz;
            value = val;
            Console.WriteLine($"Элемента {value} не существует!");
        }
    }

    class CandyException : Exception
    {
        public int value;
        public CandyException(int val)
        {
            value = val;
            Console.WriteLine("Таких сладостей не существует!");
        }
    }

    class ComandExceprion : Exception
    {
        public ComandExceprion()
        {
            Console.WriteLine("Такой команды нет!");
            Console.WriteLine("Используйте команды 0-4");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Для того что бы создать подарок введите 1");

            int x = int.Parse(Console.ReadLine());
            if (x == 1)
            {
                Control ctrl = Create();


                Console.WriteLine("\n\nПодарок создан!");

                try
                {
                    Comands(ref ctrl);
                }
                catch (ComandExceprion ex)
                {

                    Console.WriteLine("\n\nОшибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Имя объекта или сборки, которое вызвало исключение: " + ex.Source);
                    Console.WriteLine("Cтроковое представление стека вызывов, которые привели к возникновению исключения: " + ex.StackTrace + "\n\n");
                }



            }
            else
            {
                Console.WriteLine("Неверное значение");
            }
        }

        public static Control Create()
        {

            Console.WriteLine("Введите имя подарка: ");
            string name = null;
            name = Console.ReadLine();
            Debug.Assert(name != "", "строка не может быть пустой");
            Console.WriteLine("Введите вес подарка: ");
            int mass = 1;

            try
            {
                mass = int.Parse(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n\nОшибка: " + ex.Message);
                Console.WriteLine("Метод: " + ex.TargetSite);
                Console.WriteLine("Имя объекта или сборки, которое вызвало исключение: " + ex.Source);
                Console.WriteLine("Cтроковое представление стека вызывов, которые привели к возникновению исключения: " + ex.StackTrace + "\n\n");
            }
            finally
            {
                Console.WriteLine("Вес подарка задан!");
            }

            return new Control(mass, name);
        }

        public static void Comands(ref Control ctrl)
        {
            int k = 0;
            do
            {
                Console.WriteLine("Выберите далнеишие действия:");
                Console.WriteLine("1. Добавть сладость");
                Console.WriteLine("2. Удалить сладость");
                Console.WriteLine("3. Вывести список сладостей в подарке");
                Console.WriteLine("4. Найти элементы по сахару");
                Console.WriteLine("0. Выход");
                try
                {
                    k = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\nОшибка: " + ex.Message);
                    Console.WriteLine("Метод: " + ex.TargetSite);
                    Console.WriteLine("Имя объекта или сборки, которое вызвало исключение: " + ex.Source);
                    Console.WriteLine("Cтроковое представление стека вызывов, которые привели к возникновению исключения: " + ex.StackTrace + "\n\n");
                }


                switch (k)
                {
                    case 1:
                        try
                        {
                            ctrl.AddElem();
                        }
                        catch (CandyException ex)
                        {
                            Console.WriteLine("Значение {0} не найдено", ex.value);
                        }

                        break;
                    case 2:
                        try
                        {
                            ctrl.DeleteElem();
                        }
                        catch (DelException ex)
                        {
                            Console.WriteLine($"Существует только {ex.size} элементов");
                        }

                        break;
                    case 3:
                        ctrl.ShowElem();
                        break;
                    case 4:
                        ctrl.FindElem();
                        break;
                    case 0:
                        break;
                    default:
                        throw new ComandExceprion();
                }

            } while (k != 0);
        }
    }
}


