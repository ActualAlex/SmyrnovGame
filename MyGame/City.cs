using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace MyGame
{
    class City
    {
        public string Name { get; }

        static Random random = new Random();
        public int CountOfPeople { get; private set; }
        public int DeadPeople { get; private set; }

        public int NewPeople { get; private set; }
        public int CountOfMonth { get; set; } = 1;
        public int Gold { get; set; }
        public int Food { get; set; }

        List<Tank> tanks = new List<Tank>();
        List<Soldier> soldiers = new List<Soldier>();
        List<Worker> workers = new List<Worker>();

        public List<Tank> Tanks { get { return tanks; } }
        public List<Soldier> Soldiers { get { return soldiers; }  }
        public List<Worker> Workers { get { return workers; } }

        public City(string name)
        {
            Name = name;
            CountOfPeople = 100;
            Gold = 100;
            Food = 100;
        }

        public void SetSoldiersAndWorkers()
        {
            int countOfSoldiers = -1;
            if (countOfSoldiers != 0)
            {
                Console.WriteLine($"Сколько человек из {CountOfPeople} отправить в армию? Остальные пойдут работать на пользу общества.");
                while (countOfSoldiers > CountOfPeople || countOfSoldiers < 0)
                    try
                    {
                        countOfSoldiers = int.Parse(Console.ReadLine());
                        if (countOfSoldiers > CountOfPeople || countOfSoldiers < 0)
                            throw new RangeException();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Введите целое число от 0 до {CountOfPeople}");
                    }

                for (int i = 0; i < countOfSoldiers; i++)
                    Soldiers.Add(new Soldier("Солдат_" + (Soldiers.Count + 1)));

                for (int i = 0; i < CountOfPeople - countOfSoldiers; i++)
                    Workers.Add(new Worker("Рабочий_" + (Workers.Count + 1)));
            }
        }


        public void MineGoldAndFood()
        {
            int newGold = 0;
            int newFood = 0;
            int countOfWorkers = -1;
            if (Workers.Count != 0)
            {
                Console.WriteLine($"Сколько человек из {Workers.Count} отправить добывать золото? Остальные пойдут добывать еду.");

                while (countOfWorkers > Workers.Count || countOfWorkers < 0)
                    try
                    {
                        countOfWorkers = int.Parse(Console.ReadLine());
                        if (countOfWorkers > Workers.Count || countOfWorkers < 0)
                            throw new RangeException();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Введите целое число от 0 до {Workers.Count}");
                    }
                for (int i = 0; i < countOfWorkers; i++)
                    newGold += Workers[i].Performance;

                for (int i = countOfWorkers; i < Workers.Count; i++)
                    newFood += Workers[i].Performance;

                Gold += newGold;
                Food += newFood;

                Console.WriteLine($"Добыли золота: {newGold}, добыли еды: {newFood}");
            }
        }

        public void MakeTanks()
        {
            int countOfTanks = -1;
            if (Gold >= 10 && Soldiers.Count >= 5)
            {
                Console.WriteLine($"Сколько создать танков? Для каждого танка нужно 10 золота и 5 солдат, у вас есть Золото: {Gold}, Солдат: {Soldiers.Count}");

                while (countOfTanks > (Soldiers.Count / 5) || countOfTanks > (Gold / 10) || countOfTanks < 0)
                    try
                    {
                        countOfTanks = int.Parse(Console.ReadLine());
                        if (countOfTanks < 0)
                            throw new RangeException();
                        if (countOfTanks > (Soldiers.Count / 5))
                            throw new SoldiersDeficitException();
                        if (countOfTanks > (Gold / 10))
                            throw new GoldDeficitException();
                    }
                    catch (SoldiersDeficitException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine($"У вас есть {Soldiers.Count} солдат, хватит только на {(Soldiers.Count / 5)} танков");
                    }
                    catch (GoldDeficitException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine($"У вас есть {Gold} золота, хватит только на {(Gold / 10)} танков");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Введите целое число от 0 до {Workers.Count}");
                    }

                for (int i = 0; i < countOfTanks; i++)
                {
                    Tanks.Add(new Tank(Tanks.Count, Soldiers.GetRange(0, 5).ToArray()));
                    CountOfPeople -= 5;
                    Gold -= 10;
                    Soldiers.RemoveRange(Soldiers.Count - 5, 5);
                }
                Console.WriteLine($"{countOfTanks*5} солдат стали танкистами. Потрачено золота: {countOfTanks*10}");
            }

        }

        public void PeopleEat()
        {
            int allPeople = Soldiers.Count + Workers.Count + Tanks.Count * 5;
            if (Food >= allPeople)
            {
                Food -= allPeople;
                NewPeople = random.Next(10, 20);
                DeadPeople = 0;
                CountOfPeople += NewPeople;
                Console.WriteLine($"Было сьедено {allPeople}ед. еды. Прибыло подкрепелние {NewPeople} человек.");
            }
            else
            {
                DeadPeople = random.Next(10,20);
                NewPeople = 0;
                CountOfPeople -= DeadPeople;
                if (Workers.Count > DeadPeople)
                {
                    Workers.RemoveRange(Workers.Count - DeadPeople, DeadPeople);
                    Console.WriteLine($"Нехватка еды! Нужно {allPeople}, а есть только {Food}! Умерло от голода {DeadPeople} рабочих. Было сьедено {Food}ед. еды.");
                }
                else
                {
                    Soldiers.RemoveRange(Soldiers.Count - DeadPeople, DeadPeople);
                    Console.WriteLine($"Нехватка еды! Нужно {allPeople}, а есть только {Food}! Умерло от голода {DeadPeople} солдат. Было сьедено {Food}ед. еды.");
                }
                Food = 0;  
            }

            Workers.Clear();
        }
    }
}
