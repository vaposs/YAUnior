using System;
using System.IO;
using System.Security.Cryptography;

namespace задание_FightMage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // магитеский шар       - 5 манны, 10 ур
            // магическая брона     - 10 манны, неуязвимость на 1 ход
            // поджог врага         - 10 манны ,периодический урона на 3 хода - 5 ур
            // востановить 25 манны - +20 манны
            // хп - 100

            // хп босса 250
            // удары босса простой удар - 0 - 10 хп
            // крит                     - (простой удар)*2,5
            // блок                     - блокирует щитом 

            const string fireBall = "fire ball";
            const int fireBallDamage = 25;
            const int fireBallMp = 10;
            const string megaFireBall = "mega fire ball";
            const int megaFireBallDamage = 50;
            const int megaFireBallMp = 25;
            const string magicArmor = "magic armor";
            const string enemyOnFire = "enemy on fire";
            const int enemyOnFireDamage = 20;
            const string manaRestoration = "mana restoration";
            const string restorationLife = "restoration of life";
            const int heroHpMax = 100;
            const int heroMpMax = 100;
            const int potion = 50;
            int heroArmor = 0;
            int fireAtRound = 0;
            int fireAtRoundMax = 3;
            int magicArmorMp = 20;
            int enemyOnFireMp = 30;
            int heroArmorRound = 2;
            Random randonMove = new Random();
            int bossMove = 0;
            int randomMax = 4;
            int randomMin = 1;
            int bossHit = 10;
            int hitPerRound = 0;
            int bossHitCrit = 2;
            string spell = "";
            bool isCorrectSpell = true;
            bool isEnd = true;
            int heroHP = 100;
            int heroMP = 100;
            int bossHP = 250;

            Console.WriteLine("Вы входите в большой тронный зал и сразу за вами в створке ворот опускается железная решетка");
            Console.WriteLine("Со стороны трона вы слышите негромкий звут, который очень похож на скрип костей. Вы натолкнулись на Короля\n");
            Console.WriteLine("Начать бой(нажмите любую кнопку ... )");
            Console.ReadKey();
            Console.Clear();

            while (isEnd)
            {
                isCorrectSpell = true;
                bossMove = randonMove.Next(randomMin, randomMax);

                Console.WriteLine($"HP - {heroHP} \t\t\t Босс - {bossHP}");
                Console.WriteLine($"MP - {heroMP}");
                Console.WriteLine($"\nкастовать {fireBall}");
                Console.WriteLine($"кастовать {megaFireBall}");
                Console.WriteLine($"каcтовать {magicArmor}");
                Console.WriteLine($"кастовать {enemyOnFire}");
                Console.WriteLine($"кастовать {manaRestoration}");
                Console.WriteLine($"кастовать {restorationLife}\n");
                Console.Write("Выберите действие - ");

                while (isCorrectSpell)
                {
                    if (heroArmor > 0)
                    {
                        heroArmor--;
                    }

                    spell = Console.ReadLine();

                    switch (spell)
                    {
                        case fireBall:
                            bossHP -= fireBallDamage;
                            heroMP -= fireBallMp;
                            isCorrectSpell = false;
                            break;
                        case megaFireBall:
                            bossHP -= megaFireBallDamage;
                            heroMP -= megaFireBallMp;
                            isCorrectSpell = false;
                            break;
                        case magicArmor:
                            heroArmor = heroArmorRound;
                            heroMP -= magicArmorMp;
                            isCorrectSpell = false;
                            break;
                        case enemyOnFire:
                            fireAtRound = fireAtRoundMax;
                            heroMP -= enemyOnFireMp;
                            isCorrectSpell = false;
                            break;
                        case manaRestoration:
                            heroMP = heroMP + potion;

                            if (heroMP > heroMpMax)
                            {
                                heroMP = heroMpMax;
                            }
                            isCorrectSpell = false;
                            break;
                        case restorationLife:
                            heroHP = heroHP + potion;

                            if(heroHP > heroHpMax)
                            {
                                heroHP = heroHpMax;
                            }
                            isCorrectSpell = false;
                            break;
                        default:
                            Console.WriteLine("неверный ввод заклинания");
                            break;
                    }
                    if (bossMove == 0)
                    {
                        hitPerRound = 0;
                    }
                    else if (bossMove == 1)
                    {
                        hitPerRound = bossHit;
                    }
                    else if (bossMove == 2)
                    {
                        hitPerRound = bossHit * bossHitCrit;
                    }

                    if(fireAtRound > 0)
                    {
                        fireAtRound--;

                    }

                    if(heroArmor > 0)
                    {
                        hitPerRound = 0;
                        heroArmor--;
                    }

                    if (bossMove == 0)
                    {
                        Console.WriteLine($"игрок использует заклинание {spell}, босс блокирует урон");
                    }
                    else
                    {
                        heroHP = heroHP - hitPerRound;
                        Console.WriteLine($"игрок использует заклинание {spell}, босс наносит {hitPerRound} урона\n");
                    }
                }

                if (heroHP < 0 || bossHP < 0)
                {
                    isEnd = false;
                }
                else
                {
                    Console.WriteLine("следущий раунд, нажмите любую кнопку ... ");
                }
            }
            if(heroHP < 0)
            {
                Console.WriteLine("вы проиграли");

            }
            else
            {
                Console.WriteLine("вы победили");
            }
        }
    }
}
