using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace MyGame
{
    static class Game
    {
        public static event EventHandler Event;
        public static Random random = new Random();

        static MilitaryBase m;
        static FileStream fs;
        static BinaryFormatter formatter = new BinaryFormatter();
        static void SetSoldiersAndWorkers()
        {
            if (m.Workers.Count != 0)
            {
                Console.WriteLine($"Сколько человек из {m.Workers.Count} отправить в армию? Остальные пойдут работать на пользу общества.");

                int count = ReadCount();                      //считываем количество солдат

                for (int i = 1; i <= count; i++)                         //добавляем солдат
                    m.Soldiers.Add(new Soldier("Солдат_" + i));

                m.Workers.RemoveRange(m.Workers.Count - count, count);
            }

        }

        static void MineGoldAndFood()
        {
            Event?.Invoke(m, null);

            m.NewFood = 0;
            m.NewGold = 0;

            if (m.Workers.Count != 0)
            {
                Console.WriteLine($"Сколько человек из {m.Workers.Count} отправить добывать золото? Остальные пойдут добывать еду.");

                int count = ReadCount();  //считываем количество рабочих, которые добывают золото

                for (int i = 0; i < count; i++)           //добываем золото.
                    m.NewGold += m.Workers[i].Performance;

                for (int i = count; i < m.Workers.Count; i++) //оставшиеся рабочие добывают еду.
                    m.NewFood += m.Workers[i].Performance;

                m.Gold += m.NewGold;
                m.Food += m.NewFood;
            }
        }

         static void MakeTanks()
        {
            m.SpentGold = 0;
            if (m.Gold >= 10 && m.Soldiers.Count >= 5)
            {
                Console.WriteLine($"Сколько создать танков? Для каждого танка нужно 10 золота и 5 солдат, у вас есть Золото: {m.Gold}, Солдат: {m.Soldiers.Count}");

                int count = ReadCountOfTanks();

                for (int i = 0; i < count; i++)
                {
                    m.Tanks.Add(new Tank(m.Tanks.Count, m.Soldiers.GetRange(0, 5).ToArray()));
                    m.Gold -= 10;
                    m.SpentGold += 10;
                    m.Soldiers.RemoveRange(m.Soldiers.Count - 5, 5);
                }
            }
        }

         static void PeopleEat()
        {
            m.SpentFood = 0;
            m.CountOfPeople = m.Soldiers.Count + m.Workers.Count + m.Tanks.Count * 5;
            if (m.Food >= m.CountOfPeople)
            {
                m.Food -= m.CountOfPeople;
                m.SpentFood = m.CountOfPeople;
                m.NewPeople = random.Next(10, 20);
                m.DeadPeople = 0;
                for (int i = 0; i < m.NewPeople; i++)
                    m.Workers.Add(new Worker("Рабочий_" + (m.Workers.Count + 1)));
            }
            else
            {
                m.DeadPeople = random.Next(10, 20);
                m.NewPeople = 0;

                if (m.Workers.Count > m.DeadPeople)
                    m.Workers.RemoveRange(m.Workers.Count - m.DeadPeople, m.DeadPeople);
                else if (m.Soldiers.Count > m.DeadPeople)
                    m.Soldiers.RemoveRange(m.Soldiers.Count - m.DeadPeople, m.DeadPeople);

                Console.WriteLine($"Нехватка еды! Нужно {m.CountOfPeople}, а есть только {m.Food}! Умерло от голода {m.DeadPeople} чел. Было сьедено {m.Food}ед. еды.");
                m.SpentFood = m.Food;
                m.Food = 0;
            }
        }

        static int ReadCount()
        {
            string line = Console.ReadLine();
            int count;

            while (!int.TryParse(line, out count) || count < 0 || count > m.Workers.Count)
            {
                Console.WriteLine($"Введите целое число от 0 до {m.Workers.Count}");
                line = Console.ReadLine();
            }
            return count;
        }
        static int ReadCountOfTanks() //возвращает количество танков
        {
            string line = Console.ReadLine();
            int count;

            while (!int.TryParse(line, out count) || count < 0 || count > (m.Soldiers.Count / 5) || count > (m.Gold / 10))
            {
                try
                {
                    if (count > (m.Soldiers.Count / 5))
                        throw new SoldiersDeficitException();
                    if (count > (m.Gold / 10))
                        throw new GoldDeficitException();
                }
                catch (SoldiersDeficitException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"У вас есть {m.Soldiers.Count} солдат, хватит только на {(m.Soldiers.Count / 5)} танков");
                }
                catch (GoldDeficitException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"У вас есть {m.Gold} золота, хватит только на {(m.Gold / 10)} танков");
                }

                Console.WriteLine($"Введите целое число не меньше 0");
                line = Console.ReadLine();
            }
            return count;
        }

        public static int ReadCountOfPlayers()
        {
            Console.WriteLine("Начать новую игру или загрузить старую? Введите 1 или 2");
            string line = Console.ReadLine();
            int count;

            while (!int.TryParse(line, out count) || count < 1 || count > 2)
            {
                Console.WriteLine($"Введите 1 или 2");
                line = Console.ReadLine();
            }
            return count;
        }
        public static MilitaryBase AutoCreateBase() // генерирует базу с солдатами и танками
        {
            MilitaryBase enemy = new MilitaryBase("Nord");
            Soldier[] soldiers = new Soldier[5];
            int countOfsoldiers = Game.random.Next(20, 40);
            int countOfTanks = Game.random.Next(20, 30);

            for (int i = 1; i <= countOfsoldiers; i++)                         //добавляем солдат
                enemy.Soldiers.Add(new Soldier("Вражеский cолдат_" + i));

            for (int i = 1; i <= countOfTanks; i++)
            {
                for (int a = 0; a < 5; a++)
                    soldiers[a] = new Soldier("Вражеский cолдат_" + i);
                enemy.Tanks.Add(new Tank(i, soldiers));
            }
            return enemy;
        }

        public static void CreateArmy(MilitaryBase mb)
        {
            m = mb;
            Info.Rule(m);
            while (m.CountOfMonth < 7)
            {
                Event += new EventHandler(Accident.TryGetSomeAccident);
                SetSoldiersAndWorkers();
                MineGoldAndFood();
                MakeTanks();
                PeopleEat();
                Info.WriteAllInfoCity(m);
                m.CountOfMonth++;
                SaveGame(m);
            }
        }

        public static void SaveGame(MilitaryBase m)
        {
            fs = new FileStream(@"D:\save.dat", FileMode.Create);
            formatter = new BinaryFormatter();
            formatter.Serialize(fs, m);
            fs.Close();
        }
        public static MilitaryBase LoadGame()
        {
            try
            {
                fs = new FileStream(@"D:\save.dat", FileMode.Open);
                m = (MilitaryBase)formatter.Deserialize(fs);
                fs.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Нет сохранений игры. Игра начнется заново.");
                Console.WriteLine("Введите название вашей военной базы");
                m = new MilitaryBase(Console.ReadLine());
            }
            return m;
        }
    }
}
