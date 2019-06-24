using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    static class Info
    {
        public static void Rule(City city)
        {
            Console.WriteLine("Добро пожаловать в военную стратегию \"Iron War\"");
            Console.WriteLine("У вас есть пол года на подготовку своей армии.");
            Console.WriteLine("Добывайте золото, кормите хорошо свой народ, содавайте профессиональную армию и в бой!");
            Console.WriteLine("На старте у вас есть:");
            Console.WriteLine("Золото: {0}, Еды: {1}, Рабочих: {2}, Солдат: {3}, Танков: {4} (Танкисты: {5} чел.)", city.Gold, city.Food, city.CountOfPeople, city.Soldiers.Count, city.Tanks.Count, city.Tanks.Count * 5);

        }
        public static void WriteListOfWorkers(City city)
        {
            foreach (Worker w in city.Workers)
                Console.WriteLine(w);
        }
        public static void WriteListOfSoldiers(City city)
        {
            foreach (Soldier s in city.Soldiers)
                Console.WriteLine(s);
        }
        public static void WriteAllInfoCity(City city)
        {
            Console.WriteLine($"{city.CountOfMonth}-й месяц: Город: {city.Name}, Погибло: {city.DeadPeople} чел, Прибыло: {city.NewPeople} чел.");
            Console.WriteLine("Золото: {0}, Еды: {1}, Рабочих: {2}, Солдат: {3}, Танков: {4} (Танкисты: {5} чел.)",city.Gold,city.Food,city.CountOfPeople,city.Soldiers.Count,city.Tanks.Count,city.Tanks.Count*5);
        }


    }
}
