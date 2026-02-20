using System;

namespace задание_FightMage
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            const string FireBall = "1";
            int fireBallDamage = 25;
            int fireBallMp = 10;
            const string MegaFireBall = "2";
            int megaFireBallDamage = 50;
            int megaFireBallMp = 25;
            bool isMegaFireBallAvailable = true;
            const string MagicArmor = "3";
            const string EnemyOnFire = "4";
            int enemyOnFireDamage = 20;
            const string ManaRestoration = "5";
            const string HealthRestoration = "6";
            int heroHealthMax = 100;
            int heroManaMax = 100;
            int bossHealthMax = 250;
            int potion = 50;
            int heroArmor = 0;
            int fireAtRound = 0;
            int fireAtRoundMax = 3;
            int magicArmorMp = 20;
            int enemyOnFireMp = 30;
            int heroArmorRound = 2;
            Random randomMove = new Random();
            int bossMove = 0;
            int randomMax = 4;
            int bossHit = 10;
            int hitPerRound = 0;
            int bossHitCrit = 2;
            string spell = "";
            bool isCorrectSpell = true;
            int heroHealth = 100;
            int heroMana = 100;
            int bossHealth = 250;
            int bossRegen = 0;
            int bossDamage = 1;
            int bossCritDamage = 2;

            Console.WriteLine("Вы входите в большой тронный зал и сразу за вами в створке ворот опускается железная решетка");
            Console.WriteLine("Со стороны трона вы слышите негромкий звук, который очень похож на скрип костей. Вы натолкнулись на Короля\n");
            Console.WriteLine("Начать бой(нажмите любую кнопку ... )");
            Console.ReadKey();
            Console.Clear();

            while (heroHealth > 0 && bossHealth > 0)
            {
                isCorrectSpell = true;
                bossMove = randomMove.Next(randomMax);

                while (isCorrectSpell)
                {
                    Console.WriteLine($"Здоровье - {heroHealth} \t\t\t Босс - {bossHealth}");
                    Console.WriteLine($"Мана - {heroMana}");
                    Console.WriteLine($"\n1 - {GetSpellName(FireBall)} (урон {fireBallDamage}, мана {fireBallMp})");

                    if (isMegaFireBallAvailable)
                    {
                        Console.WriteLine($"2 - {GetSpellName(MegaFireBall)} (урон {megaFireBallDamage}, мана {megaFireBallMp})");
                    }
                    else
                    {
                        Console.WriteLine("2 - недоступно (требуется использование огненного шара)");
                    }

                    Console.WriteLine($"3 - {GetSpellName(MagicArmor)} (мана {magicArmorMp})");
                    Console.WriteLine($"4 - {GetSpellName(EnemyOnFire)} (урон {enemyOnFireDamage} в течение {fireAtRoundMax} ходов, мана {enemyOnFireMp})");
                    Console.WriteLine($"5 - {GetSpellName(ManaRestoration)} (восполнение маны)");
                    Console.WriteLine($"6 - {GetSpellName(HealthRestoration)} (восполнение здоровья)\n");
                    Console.Write("Выберите действие (1-6) - ");

                    if (heroArmor > 0)
                    {
                        heroArmor--;
                    }

                    spell = Console.ReadLine();

                    switch (spell)
                    {
                        case FireBall:
                            if (heroMana >= fireBallMp)
                            {
                                heroMana -= fireBallMp;
                                bossHealth -= fireBallDamage;
                                isMegaFireBallAvailable = true;
                                Console.WriteLine($"Вы нанесли {fireBallDamage} урона огненным шаром!");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно маны!");
                                continue;
                            }
                            isCorrectSpell = false;
                            break;

                        case MegaFireBall:
                            if (!isMegaFireBallAvailable)
                            {
                                Console.WriteLine("Мега огненный шар недоступен! Сначала используйте обычный огненный шар.");
                                continue;
                            }
                            if (heroMana >= megaFireBallMp)
                            {
                                heroMana -= megaFireBallMp;
                                bossHealth -= megaFireBallDamage;
                                isMegaFireBallAvailable = false;
                                Console.WriteLine($"Вы нанесли {megaFireBallDamage} урона мега огненным шаром!");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно маны!");
                                continue;
                            }
                            isCorrectSpell = false;
                            break;

                        case MagicArmor:
                            if (heroMana >= magicArmorMp)
                            {
                                heroMana -= magicArmorMp;
                                heroArmor = heroArmorRound;
                                Console.WriteLine("Вы активировали магическую броню!");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно маны!");
                                continue;
                            }
                            isCorrectSpell = false;
                            break;

                        case EnemyOnFire:
                            if (heroMana >= enemyOnFireMp)
                            {
                                heroMana -= enemyOnFireMp;
                                fireAtRound = fireAtRoundMax;
                                Console.WriteLine($"Босс горит! Будет получать {enemyOnFireDamage} урона {fireAtRoundMax} хода");
                            }
                            else
                            {
                                Console.WriteLine("Недостаточно маны!");
                                continue;
                            }
                            isCorrectSpell = false;
                            break;

                        case ManaRestoration:
                            heroMana += potion;
                            if (heroMana > heroManaMax)
                            {
                                heroMana = heroManaMax;
                            }
                            Console.WriteLine("Вы восстановили ману!");
                            isCorrectSpell = false;
                            break;

                        case HealthRestoration:
                            heroHealth += potion;
                            if (heroHealth > heroHealthMax)
                            {
                                heroHealth = heroHealthMax;
                            }
                            Console.WriteLine("Вы восстановили здоровье!");
                            isCorrectSpell = false;
                            break;

                        default:
                            Console.WriteLine("\nНеверный ввод! Введите число от 1 до 6\n");
                            break;
                    }
                }

                hitPerRound = 0;

                if (bossMove == bossRegen)
                {
                    bossHealth += potion;
                    if (bossHealth > bossHealthMax)
                    {
                        bossHealth = bossHealthMax;
                    }
                    Console.WriteLine($"\nБосс восстанавливает {potion} здоровья!");
                }
                else if (bossMove == bossDamage)
                {
                    hitPerRound = bossHit;
                }
                else if (bossMove == bossCritDamage)
                {
                    hitPerRound = bossHit * bossHitCrit;
                }

                if (fireAtRound > 0)
                {
                    bossHealth -= enemyOnFireDamage;
                    Console.WriteLine($"Босс получает {enemyOnFireDamage} урона от горения");
                    fireAtRound--;
                }

                if (heroArmor > 0 && hitPerRound > 0)
                {
                    Console.WriteLine($"Броня поглотила {hitPerRound} урона!");
                    hitPerRound = 0;
                }

                if (hitPerRound > 0)
                {
                    heroHealth -= hitPerRound;
                    Console.WriteLine($"Босс наносит {hitPerRound} урона\n");
                }
                else if (bossMove != bossRegen)
                {
                    Console.WriteLine("Босс промахнулся!\n");
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }

            Console.Clear();
            if (bossHealth <= 0 && heroHealth <= 0)
            {
                Console.WriteLine("Древний храм не выдержал вашей битвы и обрушился, погребя и вас, и врага под грудой камней");
            }
            else if (heroHealth <= 0)
            {
                Console.WriteLine("Вы проиграли... Король мертвых оказался сильнее");
            }
            else
            {
                Console.WriteLine("ПОБЕДА! Король мертвых повержен!");
            }
        }

        static string GetSpellName(string spellCode)
        {
            switch (spellCode)
            {
                case "1": return "Огненный шар";
                case "2": return "Мега огненный шар";
                case "3": return "Магическая броня";
                case "4": return "Поджечь врага";
                case "5": return "Восполнение маны";
                case "6": return "Восполнение здоровья";
                default: return "";
            }
        }
    }
}
