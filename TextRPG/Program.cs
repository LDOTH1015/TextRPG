namespace TextRPG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Goblin goblin = new Goblin("Goblin"); // 고블린 생성
            Dragon dragon = new Dragon("Dragon"); // 드래곤 생성

            //플레이어의 이름을 받아 플레이어 생성
            Console.WriteLine("플레이어 이름을 입력해주세요.");
            string playerName = Console.ReadLine();
            Warrior player = new Warrior(playerName);

            // 보상 아이템
            List<IItem> treasure = new List<IItem> { new HealthPotion(), new StrengthPotion() };

            // 스테이지 1
            Stage stage1 = new Stage(player, goblin, treasure);
            stage1.Start();

            // 플레이어 사망 확인
            if (player.isDead) return;

            // 스테이지 2
            Stage stage2 = new Stage(player, dragon, treasure);
            stage2.Start();

            // 플레이어 사망 확인
            if (player.isDead) return;

            // 게임 클리어
            Console.WriteLine("Game Clear");
            Console.WriteLine("축하합니다, {0}님", playerName);
        }

        //캐릭터 인터페이스
        public interface ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead { get; }
            //피격 메소드
            public void HitAttack(int damage);
        }

        //전사 클래스
        public class Warrior : ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead => health <= 0;

            public Warrior(string name)
            {
                this.name = name;
                health = 100;
                attack = 20;
            }
            public void HitAttack(int damage)
            {
                health -= damage;
                if (isDead)
                {
                    Console.WriteLine("You die");
                }
                else
                {
                    Console.WriteLine("{0}는 {1}만큼 데미지를 입었습니다. 남은 체력 : {2}", name, damage, health);
                }
            }
        }

        //몬스터 클래스
        public class Monster : ICharacter
        {
            public string name { get; }
            public int health { get; set; }
            public int attack { get; set; }
            public bool isDead => health <= 0;

            public Monster(string name, int health, int attack)
            {
                this.name = name;
                this.health = health;
                this.attack = attack;
            }

            public void HitAttack(int damage)
            {
                health -= damage;
                if (isDead)
                {
                    Console.WriteLine("{0} die", name);
                }
                else
                {
                    Console.WriteLine("{0}는 {1}만큼 데미지를 입었습니다. 남은 체력 : {2}", name, damage, health);
                }
            }
        }

        //고블린 클래스
        public class Goblin : Monster
        {
            public Goblin(string name) : base(name, 50, 5) { }
        }

        //드래곤 클래스
        public class Dragon : Monster
        {
            public Dragon(string name) : base(name, 150, 20) { }
        }

        // 아이템 인터페이스
        public interface IItem
        {
            string name { get; }
            void Use(Warrior warrior);
        }

        // 체력 포션
        public class HealthPotion : IItem
        {
            public string name => "체력 포션";

            public void Use(Warrior warrior)
            {
                Console.WriteLine("체력 포션을 사용합니다. 체력이 50 회복합니다.");
                warrior.health += 50;
                if (warrior.health > 100) warrior.health = 100;
            }
        }

        // 힘 포션
        public class StrengthPotion : IItem
        {
            public string name => "힘 포션";

            public void Use(Warrior warrior)
            {
                Console.WriteLine("공격력이 10 증가합니다.");
                warrior.attack += 10;
            }
        }

        //스테이지
        public class Stage
        {
            private ICharacter player;
            private ICharacter monster;
            private List<IItem> treasure;

            public delegate void GameEvent(ICharacter character);
            public event GameEvent CharactorDead;

            //스테이지 설정
            public Stage(ICharacter player, ICharacter monster, List<IItem> treasure)
            {
                this.player = player;
                this.monster = monster;
                this.treasure = treasure;
                CharactorDead += Clear;
            }

            //스테이지 시작시
            public void Start()
            {
                Console.WriteLine("스테이지 시작!");
                Console.WriteLine($"플레이어 정보: 체력({player.health}), 공격력({player.attack})");
                Console.WriteLine($"몬스터 정보: 이름({monster.name}), 체력({monster.health}), 공격력({monster.attack})");
                Console.WriteLine("----------------------------------------------------");

                //둘 중 한명이 죽을때까지 전투 반복
                while (!player.isDead && !monster.isDead)
                {
                    Console.WriteLine($"{player.name}의 공격!");
                    monster.HitAttack(player.attack);
                    Thread.Sleep(1000);

                    if (monster.isDead) break;

                    Console.WriteLine($"{monster.name}의 공격!");
                    player.HitAttack(monster.attack);
                    Thread.Sleep(1000);
                }

                //유저의 사망 확인
                if (player.isDead)
                {
                    CharactorDead?.Invoke(player);
                }
                //몬스터의 사망 확인
                else if (monster.isDead)
                {
                    CharactorDead?.Invoke(monster);
                }
            }

            //스테이지 클리어시
            private void Clear(ICharacter character)
            {
                if (character is Monster)
                {
                    Console.WriteLine($"스테이지 클리어! {character.name}를 물리쳤습니다!");

                    // 플레이어에게 아이템 보상
                    if (treasure != null)
                    {
                        Console.WriteLine("보물 중 하나를 선택하여 사용할 수 있습니다:");
                        foreach (var item in treasure)
                        {
                            Console.WriteLine(item.name);
                        }

                        Console.WriteLine("사용할 아이템 이름을 입력하세요:");
                        string input = Console.ReadLine();

                        // 선택된 아이템 사용
                        IItem selectedItem = treasure.Find(item => item.name == input);
                        if (selectedItem != null)
                        {
                            selectedItem.Use((Warrior)player);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Game Over");
                }
            }
        }
    }
}