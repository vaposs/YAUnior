using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;

namespace задание_FightMage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string FireBall = "fire ball";
            int fireBallDamage = 25;
            int fireBallMp = 10;
            const string MegaFireBall = "mega fire ball";
            int megaFireBallDamage = 50;
            int megaFireBallMp = 25;
            const string MegicArmor = "magic armor";
            const string enemyOnFire = "enemy on fire";
            int enemyOnFireDamage = 20;
            const string ManaRestoration = "mana restoration";
            const string RsestorationLife = "restoration of life";
            int heroHpMax = 100;
            int heroMpMax = 100;
            int bossHpMax = 250;
            int potion = 50;
            int heroArmor = 0;
            int fireAtRound = 0;
            int fireAtRoundMax = 3;
            int magicArmorMp = 20;
            int enemyOnFireMp = 30;
            int heroArmorRound = 2;
            Random randonMove = new Random();
            int bossMove = 0;
            int randomMax = 4;
            int bossHit = 10;
            int hitPerRound = 0;
            int bossHitCrit = 2;
            string spell = "";
            bool isCorrectSpell = true;
            bool isNextRound = true;
            int heroHP = 100;
            int heroMP = 100;
            int bossHP = 250;
            int bossRegen = 0;
            int bossDamage = 1;
            int bossCritDamage = 2;

            Console.WriteLine("Вы входите в большой тронный зал и сразу за вами в створке ворот опускается железная решетка");
            Console.WriteLine("Со стороны трона вы слышите негромкий звут, который очень похож на скрип костей. Вы натолкнулись на Короля\n");
            Console.WriteLine("Начать бой(нажмите любую кнопку ... )");
            Console.ReadKey();
            Console.Clear();

            while (isNextRound)
            {
                isCorrectSpell = true;
                bossMove = randonMove.Next(randomMax);

                while (isCorrectSpell)
                {
                    Console.WriteLine($"HP - {heroHP} \t\t\t Босс - {bossHP}");
                    Console.WriteLine($"MP - {heroMP}");
                    Console.WriteLine($"\nкастовать {fireBall}");
                    Console.WriteLine($"кастовать {megaFireBall}");
                    Console.WriteLine($"каcтовать {magicArmor}");
                    Console.WriteLine($"кастовать {enemyOnFire}");
                    Console.WriteLine($"кастовать {manaRestoration}");
                    Console.WriteLine($"кастовать {restorationLife}\n");
                    Console.Write("Выберите действие - ");

                    if (heroArmor > 0)
                    {
                        heroArmor--;
                    }

                    spell = Console.ReadLine();

                    switch (spell)
                    {
                        case fireBall:
                            heroMP -= fireBallMp;

                            if (heroMP < 0)
                            {
                                heroMP = 0;
                                Console.WriteLine("вы старались но манны не хватило");
                            }
                            else
                            {
                                bossHP -= fireBallDamage;
                            }

                            isCorrectSpell = false;
                            break;
                        case megaFireBall:
                            heroMP -= megaFireBallMp;

                            if (heroMP < 0)
                            {
                                heroMP = 0;
                                Console.WriteLine("вы старались но манны не хватило");
                            }
                            else
                            {
                                bossHP -= megaFireBallDamage;
                            }

                            isCorrectSpell = false;
                            break;
                        case magicArmor:
                            heroMP -= magicArmorMp;

                            if (heroMP < 0)
                            {
                                heroMP = 0;
                                Console.WriteLine("вы старались но манны не хватило");
                            }
                            else
                            {
                                heroArmor = heroArmorRound;
                            }

                            isCorrectSpell = false;
                            break;
                        case enemyOnFire:
                            heroMP -= enemyOnFireMp;

                            if (heroMP < 0)
                            {
                                heroMP = 0;
                                Console.WriteLine("вы старались но манны не хватило");
                            }
                            else
                            {
                                fireAtRound = fireAtRoundMax;
                            }

                            isCorrectSpell = false;
                            break;
                        case manaRestoration:
                            heroMP += potion;

                            if (heroMP > heroMpMax)
                            {
                                heroMP = heroMpMax;
                            }
                            isCorrectSpell = false;
                            break;
                        case restorationLife:
                            heroHP += potion;

                            if (heroHP > heroHpMax)
                            {
                                heroHP = heroHpMax;
                            }
                            isCorrectSpell = false;
                            break;
                        default:

                            if (bossHP < 0 || heroHP < 0)
                            {
                                isCorrectSpell = false;
                                isNextRound = false;
                            }

                            Console.WriteLine("\nневерный ввод заклинания\n");
                            break;
                    }
                }
                    if (bossMove == bossRegen)
                    {
                        bossHP = bossHP + potion;

                        if (bossHP > bossHpMax)
                        {
                            bossHP = bossHpMax;
                        }
                    }
                    else if (bossMove == bossDamage)
                    {
                        hitPerRound = bossHit;
                    }
                    else if (bossMove == bossCritDamage)
                    {
                        hitPerRound = bossHit * bossHitCrit;
                    }

                    if(fireAtRound > 0)
                    {
                        bossHP -= enemyOnFireDamage;
                        fireAtRound--;
                    }

                    if(heroArmor > 0)
                    {
                        hitPerRound = 0;
                        heroArmor--;
                    }

                    if (bossMove == bossRegen)
                    {
                        Console.WriteLine($"\nигрок использует заклинание {spell}, босс поглощает темную сущность и востанавливает жизненую силу");
                    }
                    else
                    {
                        heroHP = heroHP - hitPerRound;
                        Console.WriteLine($"игрок использует заклинание {spell}, босс наносит {hitPerRound} урона\n");
                    }
             

                if (heroHP < 0 || bossHP < 0)
                {
                    isNextRound = false;
                }
            }

            if(bossHP < 0 && heroHP < 0)
            {
                Console.WriteLine("древний хвам не выдержал вашей бытвы и обрушился погребеня и вас и врага под грудой камней");
            }
            else if(heroHP < 0)
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
