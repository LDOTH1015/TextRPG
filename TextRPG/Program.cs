namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warrior player = new Warrior();
            Inventori inven = new Inventori();
            Shop shop = new Shop();
            List<Item> items = new List<Item>();
            items.Add(new Item("수련자 갑옷","방어력 +5","수련에 도움을 주는 갑옷입니다.","1000"));
            items.Add(new Item("무쇠갑옷", "방어력 +9", "무쇠로 만들어져 튼튼한 갑옷입니다.", "2000"));
            items.Add(new Item("스파르타의 갑옷", "방어력 +15", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", "3500"));
            items.Add(new Item("낡은 검", "공격력 +2", "쉽게 볼 수 있는 낡은 검 입니다.", "600"));
            items.Add(new Item("청동 도끼", "공격력 +5", "어디선가 사용됐던거 같은 도끼입니다.", "1500"));
            items.Add(new Item("스파르타의 창", "공격력 +7", "스파르타의 전사들이 사용했다는 전설의 창입니다.", "3000"));

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다. ");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("");
            
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                String act = Console.ReadLine();
            
                switch (int.Parse(act))
                {
                    case 1: player.showStatus(); break;
                    case 2: inven.showInventori(player, items); break;
                    case 3: shop.ShowShop(player, items); break;
                    default: Console.WriteLine("잘못된 입력입니다."); break;
                }
            }
        }

        public class Item
        {
            public string Name { get; }
            public string Effect { get; }
            public string Description { get; }

            public string Status { get; set; }

            public Item(string name, string effect, string description, string status)
            {
                Name = name;
                this.Effect = effect;
                Description = description;
                Status = status;
            }

            public void UseItem(Warrior player)
            {

            } 
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
                while (int.Parse(act)!=0)
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
            public void showInventori(Warrior player, List<Item> items)
            {
                String act = "";
                int actI = 99;
                while (actI != 0)
                {
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine("");
                    Console.WriteLine("[아이템 목록]");
                    if (items != null)
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i].Status == "USE")
                            {
                                Console.WriteLine("- [E]{0}\t| {1} | {2}", items[i].Name, items[i].Effect, items[i].Description);
                            }
                            else if (items[i].Status == "HAVE")
                            {
                                Console.WriteLine("- {0}\t| {1} | {2}", items[i].Name, items[i].Effect, items[i].Description);
                            }
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");
                    while (actI != 0)
                    {
                        Console.WriteLine("원하시는 행동을 입력해주세요.");
                        act = Console.ReadLine();
                        actI = int.Parse(act);
                    
                        switch (actI)
                        {
                            case 1: Management(player,items);  break;
                            case 0: break;
                            default: Console.WriteLine("잘못된 입력입니다."); break;
                        }
                    }
                }
                
            }

            public void Management(Warrior player, List<Item> items)
            {
                String act = "";
                int actI = 99;
                while (actI != 0)
                {
                    List<int> index = new List<int>();
                    int count =  1;
                    Console.WriteLine("인벤토리");
                    Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                    Console.WriteLine("");
                    Console.WriteLine("[아이템 목록]");
                    if (items != null)
                    {
                        for (int i = 0; i < items.Count; i++)
                        {
                            if (items[i].Status == "USE")
                            {
                                index.Add(i);
                                Console.WriteLine("- {0} [E] {1}\t| {2} | {3}", count,items[i].Name, items[i].Effect, items[i].Description);
                                count++;
                            }
                            else if (items[i].Status == "HAVE")
                            {
                                index.Add(i);
                                Console.WriteLine("- {0} {1}\t| {2} | {3}", count, items[i].Name, items[i].Effect, items[i].Description);
                                count++;
                            }
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    act = Console.ReadLine();
                    actI = int.Parse(act);
                    if(actI >= 1 && actI <= count)
                    {
                        if(index.Count != 0)
                        {
                            if (items[index[actI-1]].Status == "USE")
                            {
                                items[index[actI-1]].Status = "HAVE";
                            }
                            else if (items[index[actI - 1]].Status == "HAVE")
                            {
                                items[index[actI-1]].Status = "USE";
                            }
                        }
                    }
                    else if (actI != 0)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }

            public Inventori()
            {

            }

        }

        public class Shop
        {
            public void ShowShop(Warrior player, List<Item> items)
            {
                String act = "";
                int actI = 99;
                while (actI != 0)
                {
                    Console.WriteLine("상점 - 아이템 구매");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상접입니다.");
                    Console.WriteLine("");
                    Console.WriteLine("[보유 골드]");
                    Console.WriteLine("{0} G", player.Gold);
                    Console.WriteLine("");
                    Console.WriteLine("[아이템 목록]");
                    for (int i = 0; i < items.Count; i++)
                    {
                        if (items[i].Status == "USE" || items[i].Status == "HAVE")
                        {
                            Console.WriteLine("- {0} {1}\t| {2} | {3} | 구매 완료", i + 1, items[i].Name, items[i].Effect, items[i].Description);
                        }
                        else
                        {
                            Console.WriteLine("- {0} {1}\t| {2} | {3} | {4} G", i + 1, items[i].Name, items[i].Effect, items[i].Description, items[i].Status);
                        }
                    }
                    Console.WriteLine("");
                    Console.WriteLine("0. 나가기");
                    Console.WriteLine("");
                    Console.WriteLine("원하시는 행동을 입력해주세요.");
                    act = Console.ReadLine();
                    actI = int.Parse(act);
                    if (actI >= 1 && actI <= items.Count)
                    {
                        if (items[actI - 1].Status == "USE" || items[actI - 1].Status == "HAVE")
                        {
                            Console.WriteLine("이미 구매한 아이템입니다");
                        }
                        else if (player.Gold >= int.Parse(items[actI-1].Status))
                        {
                            player.Gold -= int.Parse(items[actI - 1].Status);
                            items[actI - 1].Status = "HAVE";
                        }
                        else
                        {
                            Console.WriteLine("Gold 가 부족합니다.");
                        }
                    }
                    else if(actI != 0)
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }  
            }
        }
    }
}