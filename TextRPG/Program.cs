namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior player = new Warrior();

            //플레이어의 이름을 받아 플레이어 생성
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다. ");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            String act = Console.ReadLine();
            while (true)
            {
                switch (int.Parse(act))
                {
                    case 1: player.showStatus(); break;
                    case 2: break;
                    case 3: break;
                    default: Console.WriteLine("잘못된 입력입니다."); break;
                }
            }
        }

        public interface Item
        {
            public string Name { get; }
            public String effect { get; }
            public string Description { get; }
        }
        

        //전사 클래스
        public class Warrior
        {
            public int level = 1;
            public string name = "User";
            public int attack = 10;
            public int def = 5;
            public int health = 100;
            public int Gold = 1500;
            public bool isDead => health <= 0;

            public Warrior()
            {

            }
            public void showStatus()
            {
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                if(level > 10)
                {
                    Console.WriteLine("Lv. {0}", level);
                } else
                {
                    Console.WriteLine("Lv. 0{0}",level);
                }
                Console.WriteLine("{0}", name);
                Console.WriteLine("공격력 : {0}", attack);
                Console.WriteLine("방어력 : {0}", def);
                Console.WriteLine("체 력 : {0}", health);
                Console.WriteLine("Gold : {0} G", Gold);
                Console.WriteLine("");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                String act = Console.ReadLine();
                while (true)
                {
                    switch (int.Parse(act))
                    {
                        case 0:  break;
                        default: Console.WriteLine("잘못된 입력입니다."); break;
                    }
                }
            }            
        }
        public class Inventori
        {
            public void showInventori(Warrior player)
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("");
                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("");
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                String act = Console.ReadLine();
                while (true)
                {
                    switch (int.Parse(act))
                    {
                        case 0: break;
                        default: Console.WriteLine("잘못된 입력입니다."); break;
                    }
                }
            }

            public Inventori()
            {

            }

        }
    }
}