using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGame
{
    static class Info
    {
        public static void Rule(MilitaryBase m)
        {
            Console.WriteLine("У вас есть пол года на подготовку своей армии.");
            Console.WriteLine("Добывайте золото, еду, содавайте профессиональную армию и в бой!");
            Console.WriteLine("Игра сохраняется автоматически, вы всегда сможете продолжить игру позже.");
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine("На старте у вас есть:");
            Console.WriteLine("Золото: {0}, Еды: {1}, Рабочих: {2}, Солдат: {3}, Танков: {4} (Танкисты: {5} чел.)", m.Gold, m.Food, m.Workers.Count, m.Soldiers.Count, m.Tanks.Count, m.Tanks.Count * 5);
            Console.WriteLine("__________________________________________________________________________________");
        }
      
        public static void WriteAllInfoCity(MilitaryBase m)
        {
            Console.WriteLine("__________________________________________________________________________________");
            Console.WriteLine($"За {m.CountOfMonth}-й месяц: Добыли Золота: {m.NewGold}, добыли Еды: {m.NewFood}, Потратили еды: {m.SpentFood}, Потратили золота: {m.SpentGold}");
            Console.WriteLine($"Погибло собратьев: {m.DeadPeople} чел, Прибыло подкрепление: {m.NewPeople} чел.");
            Console.WriteLine("Всего: Золота: {0}, Еды: {1}, Рабочих: {2}, Солдат: {3}, Танков: {4} (Танкисты: {5} чел.)",m.Gold,m.Food,m.Workers.Count,m.Soldiers.Count,m.Tanks.Count,m.Tanks.Count*5);
            Console.WriteLine("__________________________________________________________________________________");

        }
    }
}
