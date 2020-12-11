using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10
{
    class Lek
    {
        private string mass;
        private string name;
        private double price;
        private int amount;
        public void read()
        {
            Console.WriteLine("Введите название лекарства");
            name = Console.ReadLine();
            Console.WriteLine("Введите код лекарства");
            mass = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите цену лекарства");
                try
                {
                    price = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    price = -1;
                }
            } while (price < 0);
            do
            {
                Console.WriteLine("Введите колличество лекарства");
                try
                {
                    amount = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    amount = -1;
                }
            } while (amount < 0);
        }
        public Lek(string mass, string name, double price, int amount)
        {
            this.name = name;
            this.mass = mass;
            this.price = price;
            this.amount = amount;
        }
        public Lek()
        {
            this.name = "-";
            this.mass = "-";
            this.price = 0;
            this.amount = 0;
        }
        public void display()
        {
            Console.WriteLine("Название лекарства: " + name);
            Console.WriteLine("Код лекарства: " + mass);
            Console.WriteLine("Цена лекарства: " + price);
            Console.WriteLine("Колличество: " + amount);
        }
        public int Amount
        {
            set
            {
                if (value > 0)
                {
                    amount = value;
                }
            }
            get
            {
                return amount;
            }
        }
        public double Price
        {
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }
        public string Mass
        {
            get
            {
                return mass;
            }
        }
    }

    class Apteka
    {
        private string name;
        private string num;
        private int numOfMeds;
        private static int maxNumOfMeds = 10;
        private Lek[] lek = new Lek[10];
        public void read()
        {
            string f;
            Console.WriteLine("Введите название аптеки");
            name = Console.ReadLine();
            Console.WriteLine("Введите номер аптеки");
            num = Console.ReadLine();
            numOfMeds = 0;
            Console.WriteLine("Добавить лекарство ?(1 - Да, 0 - нет)");
            f = Console.ReadLine();
            while (f == "1" && numOfMeds < maxNumOfMeds)
            {
                lek[numOfMeds] = new Lek();
                lek[numOfMeds].read();
                numOfMeds++;
                Console.WriteLine("Добавить лекарство ?(1 - Да, 0 - нет)");
                f = Console.ReadLine();
                if (f == "0")
                {
                    break;
                }
            }
        }
        public Apteka(string name, string num, int numOfMeds, string[] lekName1, string[] lekMass1, double[] lekPrice1, int[] lekAmount1)
        {
            int i;
            if (numOfMeds < Apteka.maxNumOfMeds)
            {
                this.name = name;
                this.num = num;
                this.numOfMeds = numOfMeds;
                for (i = 0; i < this.numOfMeds; i++)
                {
                    lek[i] = new Lek(lekMass1[i], lekName1[i], lekPrice1[i], lekAmount1[i]);
                }
            }
        }
        public Apteka(string name)
        {
            this.name = name;
            this.num = "-";
            this.numOfMeds = 0;
        }
        public Apteka()
        {
            this.name = "-";
            this.num = "-";
            this.numOfMeds = 0;
        }
        public void display()
        {
            int i;
            Console.WriteLine("Название аптеки: " + name);
            Console.WriteLine("Номер аптеки: " + num);
            Console.WriteLine("Колличество уникальных лекарств: " + numOfMeds);
            Console.WriteLine("Колличество мест для лекарств:" + maxNumOfMeds);
            for (i = 0; i < numOfMeds; i++)
            {
                Console.WriteLine("Лекарство: " + (i + 1));
                lek[i].display();
            }
        }
        public static Apteka operator ++(Apteka apteka)
        {
            Apteka newApteka = new Apteka();
            Exception a;
            int n;
            try
            {
                if (apteka.numOfMeds >= Apteka.maxNumOfMeds)
                {
                    throw a = new Exception("0");
                }
                newApteka.name = apteka.name;
                newApteka.num = apteka.num;
                for (n = 0; n < apteka.numOfMeds; n++)
                {
                    newApteka.lek[n] = new Lek();
                    newApteka.lek[n] = apteka.lek[n];
                }
                newApteka.lek[apteka.numOfMeds] = new Lek();
                newApteka.lek[apteka.numOfMeds].read();
                newApteka.numOfMeds = ++apteka.numOfMeds;
                return newApteka;
            }
            catch (Exception)
            {
                return apteka;
            }
        }
        public void priceChange(string mass, double price)
        {
            int i = 0;
            while (i < numOfMeds)
            {
                if (lek[i].Mass == mass)
                {
                    lek[i].Price = price;
                    i = numOfMeds;
                }
                i++;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public static Apteka operator +(Apteka apteka1, Apteka apteka2)
        {
            int n, i;
            Apteka newApteka = new Apteka();
            Exception a;
            try
            {
                if (apteka1.numOfMeds + apteka2.numOfMeds > Apteka.maxNumOfMeds)
                {
                    throw a = new Exception("0");
                }
                newApteka.name = apteka1.name;
                newApteka.num = apteka1.num;
                newApteka.numOfMeds = apteka1.numOfMeds + apteka2.numOfMeds;
                for (n = 0; n < apteka1.numOfMeds; n++)
                {
                    newApteka.lek[n] = apteka1.lek[n];
                }
                i = apteka1.numOfMeds;
                for (n = 0; n < apteka2.numOfMeds; n++)
                {
                    newApteka.lek[i] = apteka2.lek[n];
                    i++;
                }
                return newApteka;
            }
            catch (Exception)
            {
                return apteka1;
            }
        }
        public void getNumber(out int number)
        {
            number = numOfMeds;
        }
        public void getNumber1(ref int number)
        {
            number = numOfMeds;
        }
        public static void maxNumOfMedsChange(int newMax)
        {
            Apteka.maxNumOfMeds = newMax;
        }

        internal static void maxNumberOfMedsChange(int numOfMeds)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Apteka[] apteka1 = new Apteka[10];
            Lek[] lek1 = new Lek[10];
            int numOfMeds, i, max, n;
            int[] lekAmount = new int[10];
            double price;
            double[] lekPrice = new double[10];
            string f, s, mass, name, num;
            string[] s1 = new string[10], lekMass = new string[10], lekName = new string[10];
            Console.WriteLine("Использовать или read чтобы ввести данные(1 - read, 2 - init)");
            f = Console.ReadLine();
            if (f == "1")
            {
                apteka1[0] = new Apteka();
                apteka1[0].read();
            }
            else if (f == "2")
            {
                Console.WriteLine("Ввести все параметры (1), только название (2), не вводить параметры(3)");
                f = Console.ReadLine();
                if (f == "1")
                {
                    Console.WriteLine("Введите название аптеки");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите номер аптеки");
                    num = Console.ReadLine();
                    numOfMeds = 0; ;
                    Console.WriteLine("Добавить лекарство ?(1 - Да, 0 - Нет)");
                    f = Console.ReadLine();
                    while (f == "1")
                    {
                        Console.WriteLine("Введите название лекарства");
                        lekName[numOfMeds] = Console.ReadLine();
                        Console.WriteLine("Введите код лекарства");
                        lekMass[numOfMeds] = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Введите цену лекарства");
                            try
                            {
                                lekPrice[numOfMeds] = Convert.ToDouble(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekPrice[numOfMeds] = -1;
                            }
                        } while (lekPrice[numOfMeds] < 0);
                        do
                        {
                            Console.WriteLine("Введите колличество лекарства");
                            try
                            {
                                lekAmount[numOfMeds] = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                lekAmount[numOfMeds] = -1;
                            }
                        } while (lekAmount[numOfMeds] < 0);
                        numOfMeds++;
                        Console.WriteLine("Добавить еще лекарство ?(1 - Да, 0 - нет)");
                        f = Console.ReadLine();
                        if (f == "0")
                        {
                            break;
                        }
                    }
                    apteka1[0] = new Apteka(name, num, numOfMeds, lekName, lekMass, lekPrice, lekAmount);
                }
                else if (f == "2")
                {
                    Console.WriteLine("Введите название аптеки");
                    name = Console.ReadLine();
                    apteka1[0] = new Apteka(name);
                }
                else
                {
                    apteka1[0] = new Apteka();
                }
            }
            i = 0;
            max = 1;
            f = "1";
            while (f != "10")
            {
                Console.WriteLine("Введите номер следующего действия:");
                Console.WriteLine("1 - показать информацию о аптеки");
                Console.WriteLine("2 - добавить новое лекарство");
                Console.WriteLine("3 - изменить цену лекарсвта");
                Console.WriteLine("4 - добавить аптеку");
                Console.WriteLine("5 - показать все аптеки");
                Console.WriteLine("6 - сменить апетку");
                Console.WriteLine("7 - сложить аптеки");
                Console.WriteLine("8 - показать колличество лекарств");
                Console.WriteLine("9 - изменить колличество мест для лекарств в аптеки");
                Console.WriteLine("10 - выйти");
                f = Console.ReadLine();
                if (f == "1")
                {
                    apteka1[i].display();
                }
                else if (f == "2")
                {
                    apteka1[i] = ++apteka1[i];
                }
                else if (f == "3")
                {
                    Console.WriteLine("Введите код лекарства");
                    mass = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Введите новую цену");
                        try
                        {
                            price = Convert.ToDouble(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            price = -1;
                        }
                    } while (price < 0);
                    apteka1[i].priceChange(mass, price);
                }
                else if (f == "4")
                {
                    apteka1[max] = new Apteka();
                    apteka1[max].read();
                    i = max;
                    max++;

                }
                else if (f == "5")
                {
                    for (n = 0; n < max; n++)
                    {
                        Console.WriteLine("Аптека: " + apteka1[n].Name);
                    }
                }
                else if (f == "6")
                {
                    Console.WriteLine("Введите название аптеки");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            i = n;
                            n = max;
                        }
                    }
                }
                else if (f == "7")
                {
                    Console.WriteLine("Введите название аптеки");
                    name = Console.ReadLine();
                    for (n = 0; n < max; n++)
                    {
                        if (apteka1[n].Name == name)
                        {
                            apteka1[i] = apteka1[i] + apteka1[n];
                            n = max;
                        }
                    }
                }
                else if (f == "8")
                {
                    Console.WriteLine("1 - out, 0 - ref");
                    s = Console.ReadLine();
                    if (s == "1")
                    {
                        apteka1[i].getNumber(out n);
                        Console.WriteLine(n);
                    }
                    else
                    {
                        n = 1;
                        apteka1[i].getNumber1(ref n);
                        Console.WriteLine(n);
                    }
                }
                else if (f == "9")
                {
                    Console.WriteLine("Введите колличество");
                    numOfMeds = Convert.ToInt32(Console.ReadLine());
                    Apteka.maxNumOfMedsChange(numOfMeds);
                }
            }
        }
    }
}
  
