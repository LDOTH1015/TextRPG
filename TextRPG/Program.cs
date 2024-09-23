namespace TextRPG
{
    internal class Program
    {
        public interface ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead { get; set; }
            public void TackDamage();
        }

        public class Warrior : ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead { get; set; }
            public void TackDamage()
            {

            }
        }

        public class Monster : ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead { get; set; }
            public void TackDamage()
            {

            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}