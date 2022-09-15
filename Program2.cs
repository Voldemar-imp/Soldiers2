using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soldiers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Database database = new Database();
            string firstLetter = "Б";
            
            Console.WriteLine("До перевода солдат:");
            database.ShowByNameDetachment1();
            database.ShowByNameDetachment2();
            database.MakeTransferSoldiersBy(firstLetter);
            Console.WriteLine("\nПосле перевода солдат:");
            database.ShowByNameDetachment1();
            database.ShowByNameDetachment2();
        }
    }

    class Database
    {
        private List<Soldier> _detachment1 = new List<Soldier>();
        private List<Soldier> _detachment2 = new List<Soldier>();
        
        public Database()
        {
            _detachment1.Add(new Soldier("Гончаров Даниил", "рядовой"));
            _detachment1.Add(new Soldier("Буров Андрей", "рядовой"));
            _detachment1.Add(new Soldier("Воробьев Иван", "сержант"));
            _detachment1.Add(new Soldier("Бобров Платон", "лейтенант"));
            _detachment1.Add(new Soldier("Герасимов Егор", "младший лейтенант"));
            _detachment2.Add(new Soldier("Мухин Павел", "рядовой"));
            _detachment2.Add(new Soldier("Хохлов Адам", "рядовой"));
            _detachment2.Add(new Soldier("Андрианов Фёдор", "сержант"));
            _detachment2.Add(new Soldier("Куликов Марк", "лейтенант"));
            _detachment2.Add(new Soldier("Муравьев Михаил", "младший лейтенант"));
        }

        public void MakeTransferSoldiersBy(string firstLetter)
        {            
            var transferSoldiers = _detachment1.Where(soldier => soldier.Name.StartsWith(firstLetter)).ToList();
            var tempDetachment2 = _detachment2.Union(transferSoldiers).ToList();
            _detachment2 = tempDetachment2;
            _detachment1 = _detachment1.Except(transferSoldiers).ToList();
        }

        public void ShowByNameDetachment1()
        {
            Console.WriteLine("Отряд1:");
            _detachment1 = _detachment1.OrderBy(soldier => soldier.Name).ToList();
            ShowInfo(_detachment1);
        }

        public void ShowByNameDetachment2()
        {
            Console.WriteLine("Отряд2:");
            _detachment2 = _detachment2.OrderBy(soldier => soldier.Name).ToList();
            ShowInfo(_detachment2);
        }

        private void ShowInfo(List<Soldier> detachment)
        {
            foreach (Soldier soldier in detachment)
            {
                Console.WriteLine($"Имя: {soldier.Name}. Звание: {soldier.MilitaryRank}.");
            }
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public string MilitaryRank { get; private set; }

        public Soldier(string name, string militaryRank)
        {
            Name = name;
            MilitaryRank = militaryRank;
        }
    }
}
