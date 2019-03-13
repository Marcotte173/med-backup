using System;
using System.Media;


namespace MedievalRPG
{

    class main
    {

        public static Random rand = new Random();
        public static Hero player;
        public static Weapon weap;
        public static Armor arm;
        public static monster mon;
        public static town town;

        private static int attack;
        private static int mattack;
        public static SaveLoad saveLoad;


        static Weapon[] weaponList = { new Weapon("None", 0, 0), new Weapon("Knife", 2, 500), new Weapon("Dagger", 4, 1000), new Weapon("Short Sword", 6, 2000), new Weapon("Long Sword", 8, 4000),
            new Weapon("Greatsword", 10, 6000), new Weapon("Red Sword", 12, 10000), new Weapon("Black Sword", 14, 14000),  new Weapon("Crystal Sword", 16, 18000), new Weapon("Sword of the Wind", 18, 24000),
            new Weapon("Ashton's Hand", 20, 30000), new Weapon("Arm of Deb", 23, 35000), new Weapon("Sword of Wanting", 26, 40000), new Weapon("Sword of Song", 29, 50000),  new Weapon("Sword of Life", 32, 60000),
            new Weapon("Sword of Death", 35, 70000), new Weapon("Sword of Mourning", 39, 85000), new Weapon("Sword of Healing", 43, 100000), new Weapon("Sword of Hope", 47, 125000),
            new Weapon("Blade of Slaying", 51, 150000), new Weapon("Final Blade", 55, 200000) };

        static Armor[] armourList = { new Armor("None", 0, 0), new Armor("Cloth", 2, 500), new Armor("Old Leather", 4, 1000), new Armor("Leather and chain", 6, 2000), new Armor("Chainmail", 8, 4000),
            new Armor("Coat of Plates", 10, 6000), new Armor("Red Armor", 12, 10000), new Armor("Black Armour", 14, 14000),  new Armor("Crystal Armour", 16, 18000), new Armor("Armour of the Wind", 18, 24000),
            new Armor("Ashton's Hand", 20, 30000), new Armor("Arm of Deb", 23, 35000), new Armor("Armour of Wanting", 26, 40000), new Armor("Armour of Song", 29, 50000),  new Armor("Armour of Life", 32, 60000),
            new Armor("Armour of Death", 35, 70000), new Armor("Armour of Mourning", 39, 85000), new Armor("Armour of Healing", 43, 100000), new Armor("Armour of Hope", 47, 125000),
            new Armor("Shield of Slaying", 51, 150000), new Armor("Final Armour", 55, 200000) };

        static monster[] monsterList = { new monster("none", "none", 0, 0, 0, 0), new monster("Slime", "*Squish*", 9, 9, 4, 158),
            new monster("Thug", "'Your money AND your life!'", 14, 14, 6, 163), new monster("Basilisk", "*HSSS*", 10, 10, 8, 163),
            new monster("Goblin", "'The treasure is MINE!'", 8, 8, 6, 163), };

        static monster[] monsterList1 = { new monster("none", "none", 0, 0, 0, 0), new monster("Slime", "*Squish*", 9, 9, 4, 158),
            new monster("Thug", "'Your money AND your life!'", 28, 18, 18, 463), new monster("Basilisk", "*HSSS*", 10, 10, 8, 163),
            new monster("Orc", "'ROAR! SMASH!!!'", 30, 20, 24, 513), new monster("Imp", "*Squeak, squeak*", 18, 22, 13, 374),
            new monster("Giant Cockroach", "*Skitter skitter*", 18, 18, 14, 359), new monster("Goblin", "'The treasure is MINE!'", 16, 16, 12, 363),
            new monster("Kobald", "*You no take candle!*", 16, 16, 12, 363), };

        public static int day = 1;

        public static int bankgold = 0;

        public static bool craft = false;

        public static int fights = 15;

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                             Legend of Klinton");
            Console.WriteLine("                                             Press any key to continue");
            Console.ReadKey();
            menu();
        }

        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                             (N)ew Game   (L)oad Game     (Q)uit\n                                             (?)What is this game about?\n\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "n")
                welcome();
            else if (choice == "?")
            {
                Console.WriteLine("To Be Created");
                menu();
            }
            else if (choice == "q")
                Environment.Exit(0);
            else
                menu();
        }

        public static void welcome()
        {
            Console.Clear();
            Console.WriteLine("\nWelcome! What is your name?\n");
            string pName = Console.ReadLine();
            if (pName.Length < 3)
            {
                Console.WriteLine("Too short! Try again!");
                keypress();
                welcome();
            }
            if (pName.Length > 9)
            {
                Console.WriteLine("Too long! Try again!");
                keypress();
                welcome();
            }
            else
            {
                Console.WriteLine($"\n{pName},is this correct?\n(Y)es   (N)o\n");
                string nconf = Console.ReadLine().ToLower();
                if (nconf == "y")
                {
                    weap = new Weapon("None", 0, 0);
                    arm = new Armor("None", 0, 0);
                    player = new Hero(pName, "none", 0, 0, 0, 1000);
                    weap = new Weapon("None", 0, 0);
                    arm = new Armor("None", 0, 0);
                    mon = new monster("none", "none", 0, 0, 0, 0);
                    town = new town("none", "none", "none");
                    saveLoad = new SaveLoad();
                    chooseClass();
                }
                else
                {
                    Console.WriteLine("Ok, let's try this again");
                    keypress();
                    welcome();
                }
            }
        }

        public static void chooseClass()
        {
            town.setlocation("Klinton", "Klinton appears to be a small but bustling town.\nBetween the weapon shop and the armorshop there" +
                " is a path that leads to the dungeon.\nIn it, you can find both treasure... and death.", "\n(W)eapon shop        (A)rmor shop        (I)tem shop     (D)ungeon\n(V)isit level master (C)haracter         (H)eal          (Y)our house\n(T)avern             (B)ank              (Q)uit          (?)Help\n");
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            arm.setArmor(armourList[0]);
            Console.Clear();
            Console.WriteLine($"\nOk {player.getName()}, let's get started.\nYou grew up as a child in a simple medieval village.\nAs you came of age, a small ceremony was held.\nYou were given an opportunity to choose your path.");
            colourText(ConsoleColor.DarkMagenta, "\n(W)arrior   (R)ogue     (M)age", true);
            string pClass = Console.ReadLine().ToLower();
            if (pClass == "w")
            {
                Console.WriteLine("\nA warrior.\nBig. Strong. Dumb.\nI like it");

                weap.setWeapon(weaponList[0]); //Hit, Crit, Def, SpellDam. Roll under hit to hit, crit to crit, def to make it a glancing blow. Spelldam ifs how fireball is calced for now
                player.setclass(10, "Warrior", 0, 5, 80, 15, 20, 0);
                Town1();
                

            }
            else if (pClass == "r")
            {
                Console.WriteLine("\nA rogue.\nSneaky sneaky, stabby stabby");
                weap.setWeapon(weaponList[1]);

                player.setclass(8, "Rogue", 1, 4, 85, 20, 15, 0);
                Town1();
                

            }
            else if (pClass == "m")
            {
                Console.WriteLine("\nA mage. Phenomenal cosmic power, itty bitty muscles");
                weap.setWeapon(weaponList[0]);
                player.setclass(6, "Mage", 2, 3, 80, 5, 10, 10);
                player.addpot(1);
            }
            else
            {
                Console.WriteLine("Not an option");
                chooseClass();
            }

            Town1();
        }

        public static void saveGame()
        {
            int weaponIndex = 0;
            int armourIndex = 0;

            for (int i = 0; i < weaponList.Length; i++)
            {
                if (weap.getName() == weaponList[i].getName())
                {
                    weaponIndex = i;
                    break;
                }
            }
            for (int i = 0; i < armourList.Length; i++)
            {
                if (arm.getName() == armourList[i].getName())
                {
                    armourIndex = i;
                    break;
                }
            }

            saveLoad.save(player, weaponIndex, armourIndex);
        }

        public static void keypress()
        {
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }
        public static void Town1()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou grew up in a tiny village with dreams of breaking free of your boring, peasant life.\nMany times, you have been told of the legend of " +
                "Klinton, a small town in the west.\nRumor has it there is a dungeon just outside the town, overrun with monsters.\nIn the dungeon there is also a source of power able to grant any wish to whomever can find it." +
                "\nAs you become an adult, you decide to set off for Klinton. ");

            keypress();

            Town();
        }
        public static void Town()
        {

            Console.Clear();
            Console.WriteLine($"\n\nWelcome to {town.getName()}, {player.getName()} the {player.getclass()}\n");
            Console.WriteLine($"{town.getFlavor()}");
            Console.WriteLine($"\n{town.getOptions()}");

            colourText(ConsoleColor.DarkBlue, $"It is day {day}", true);
            Console.WriteLine("\nWhat would you like to do?\n");
            string townchoice = Console.ReadLine().ToLower();
            if (townchoice == ("w"))
                weaponshop();
            else if (townchoice == ("a"))
                armorshop();
            else if (townchoice == ("i"))
                itemshop();
            else if (townchoice == ("d"))
            {
                Console.Write("You descend into the dungeon......");
                keypress();
                dungeon();
            }
            else if (townchoice == ("v"))
                levelMaster();
            else if (townchoice == ("y"))
                house();
            else if (townchoice == ("b"))
                bank();
            else if (townchoice == ("t"))
            {
                var medeley = new SoundPlayer(@"C:\Users\tmarcott\source\repos\Medieval RPG\sfx\medley.wav");
                medeley.PlayLooping();
                tavern();
            }
            else if (townchoice == ("c"))
                character();
            else if (townchoice == ("h"))
                heal();
            else if (townchoice == ("q"))
                quit();
            else if (townchoice == ("?"))
                help();
            else if (townchoice == "x")
                player.addxp(50);
            else
                Console.Write("Not an option");

            Town();
        }

        public static void bank()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a small but busy bank. One teller appears to be free. You walk up to him");
            colourText(ConsoleColor.Red, "\n'Hello. How may I be of service?'", true);

            Console.WriteLine("\n\n(D)eposit        (W)ithdraw          (R)eturn to town\n\n");
            Console.WriteLine($"Gold:{player.getgold()}     Gold in bank:{bankgold}\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "d")
            {
                if (player.getgold() > 0)
                {
                    int deposit;
                    do
                    {
                        colourText(ConsoleColor.Red, "'Excellent! How much would you like to deposit?' (0) To return to the bank \n", true);
                        
                    } while (!int.TryParse(Console.ReadLine(), out deposit));
                    if (player.getgold() >= deposit)
                    {
                        Console.WriteLine($"\nYou deposit {deposit} gold.");
                        player.subgold(deposit);
                        bankgold += deposit;
                    }
                    else
                    {
                        colourText(ConsoleColor.Red, "'You don't have enough money!'", true);    
                    }
                }
                else
                {
                    colourText(ConsoleColor.Red, "'You don't have enough money!'", true);   
                }
                keypress();
                bank();
            }

            else if (choice == "w")
            {
                if (bankgold > 0)
                {
                    int withdraw;
                    do
                    {

                        colourText(ConsoleColor.Red, "'Excellent! How much would you like to withdraw?' (0) To return to the bank ", true);
                        
                    } while (!int.TryParse(Console.ReadLine(), out withdraw));
                    if (bankgold >= withdraw)
                    {
                        Console.WriteLine($"\nYou withdraw {withdraw} gold.");
                        player.addgold(withdraw);
                        bankgold -= withdraw;
                    }
                    else
                    {
                        colourText(ConsoleColor.Red, "'You don't have enough money in the bank!'", true);
                    }
                }

                else
                {

                    colourText(ConsoleColor.Red, "'You don't have any money in the bank!'", true);

                }
                keypress();
                bank();
            }
            else if (choice == "r")
                Town();

            bank();

        }

        public static void house()
        {
            Console.Clear();
            Console.WriteLine("\nYou are in your house. It's not big, but it's clean and cozy. In the corner you see your bed.");
            if (craft == true)
            {
                Console.WriteLine("In the center of the main room you have set up your crafting machine. Now you just have to figure out how it works");
            }
            Console.Write("\n(B)ed");
            if (craft == true)
                Console.Write("                  (C)rafting machine");
            Console.WriteLine("\n(R)eturn to town       (?)Help");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"\nIt is day {day}");
            Console.ResetColor();
            Console.WriteLine("\nWhat would you like to do?\n\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "r")
            {
                Town();
            }
            else if (choice == "b")
            {
                Console.Clear();
                Console.WriteLine("You sleep until morning.");
                refresh();
                day++;
                Console.WriteLine("You wake up feeling refreshed!");
                keypress();
                if (day >= 30)
                    gameover();
                house();
            }
            if (choice == "c")
            {
                if (craft == true)
                {
                    Console.Clear();
                    Console.WriteLine("You look at the odd looking machine. You know you can do something with it, you're just not sure what yet.");
                    keypress();
                }
                else
                    house();
            }
            else
                house();

        }

        public static void tavern()
        {
            Console.Clear();
            Console.WriteLine("\nYou enter a bustling tavern. More flavor will be added soon describing the place and what you can do.");
            Console.WriteLine($"\n\n(G)amble         (L)ocal gossip          (T)alk to the bartender     (C)haracter     (R)eturn\n\nYou have {player.getgold()} gold\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "g")
                gamble();
            else if (choice == "l")
                gossip();
            else if (choice == "t")
                bartender();
            else if (choice == "r")
            {
                var medeley = new SoundPlayer(@"C:\Users\tmarcott\source\repos\Medieval RPG\sfx\medley.wav");
                medeley.Stop();
                Town();
            }
            else if (choice == "c")
                character();
            tavern();
        }

        public static void bartender()
        {
            Console.Clear();
            Console.WriteLine("You walk over to the bartender. He tells you Marcotte's still working on the game. For now, scram.");
            keypress();
            tavern();
        }

        public static void gamble()
        {
            int x = rand.Next(1, 6);
            int y = rand.Next(1, 6);
            int wager;
            do
            {
                Console.Clear();
                Console.WriteLine($"\nYou have {player.getgold()} gold\n");
                Console.WriteLine("How much would you like to wager?\n0 to wager nothing and return to the inn.");
            } while (!int.TryParse(Console.ReadLine(), out wager));
            if (wager == 0)
                tavern();
            else
            {
                if (player.getgold() >= wager)
                {
                    Console.WriteLine($"Wager {wager} gold?\n(Y)es     (N)o");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        player.subgold(wager);
                        Console.WriteLine($"Confident, you place {wager} gold on the table. You and the man each roll a die.\n");
                        keypress();
                        Console.WriteLine($"You roll a {x}\nThe man rolls a {y}");
                        if (x > y)
                        {
                            Console.WriteLine($"You win! You receive {wager * 2} gold!");
                            player.addgold(wager * 2);
                            keypress();
                            Console.WriteLine("Play again?\n\n(Y)es      (N)o \n\n");
                            string again = Console.ReadLine();
                            if (again == "y")
                                gamble();
                            else
                                tavern();
                        }
                        else if (y > x)
                        {
                            Console.WriteLine($"You lose! The man takes your gold and smiles.");
                            keypress();
                            Console.WriteLine("Play again?\n\n(Y)es      (N)o \n\n");
                            string again = Console.ReadLine();
                            if (again == "y")
                                gamble();
                            else
                                tavern();
                            tavern();
                        }
                        if (x == y)
                        {
                            Console.WriteLine($"It's a tie! You get your gold back.");
                            player.addgold(wager);
                            keypress();
                            Console.WriteLine("Play again?\n\n(Y)es      (N)o \n\n");
                            string again = Console.ReadLine();
                            if (again == "y")
                                gamble();
                            else
                                tavern();
                        }
                    }
                    else
                    {
                        colourText(ConsoleColor.Red, "'Then what are you doing here?'", true);
                        Console.WriteLine("Feeling sheepish, you leave the gambling area");
                        tavern();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have enough gold!");
                    keypress();
                    tavern();
                }

            }
        }


        public static void gossip()
        {
            Console.Clear();
            Console.WriteLine("The current gossip is that this game will be pretty sweet when it's finished. For now, tho, there's very little else to hear.");
            keypress();
            tavern();
        }

        public static void character()
        {
            Console.Clear();
            Console.Write($"\n{player.getName()}, Level {player.getplvl()}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($" {player.getclass()}\n");
            Console.ResetColor();
            if (player.getplvl() == 20)
                Console.WriteLine($"YOU ARE MAX LEVEL");
            else if (player.getxp() >= player.getxpneeded())
                Console.WriteLine($"YOU ARE ELIGIBLE FOR A LEVEL RAISE");
            else
                Console.WriteLine($"\nEXPERIENCE:{player.getxp()}/{player.getxpneeded()}");
            Console.Write($"HEALTH: { player.gethp()}/{ player.getmhp()}\nENERGY: { player.getenergy()}/{ player.getmaxenergy()}\n" +
            "WEAPON:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{weap.getName()}");
            Console.ResetColor();
            Console.Write("\nARMOR :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{ arm.getName()}");
            Console.ResetColor();
            Console.Write($"\nHEALING POTIONS:{player.getpot()}\n\nGOLD:{player.getgold()}\nGOLD IN BANK:{bankgold}\n\n" +
                $"DAMAGE :{player.getDam() - 2 + weap.getDam()} - {player.getDam() + 4 + weap.getDam()} \nDEFENCE:{arm.getDam()}");
            keypress();
        }

        public static void heal()
        {
            if (player.gethp() == player.getmhp())
                Console.Write("\nYou don't need healing!");
            else if (player.getpot() == 0)
                Console.Write("\nYou don't have a healing potion!");
            else
            {
                Console.WriteLine("\nYou drink a potion.\nYou are now at full health.");
                player.setfullhealth();
                player.setlosepot();
            }

            Console.WriteLine("\n\nPress any key to continue\n");
            Console.ReadKey();

            keypress();


        }

        public static void quit()
        {
            Console.WriteLine("Do you want to quit?\n(Y)es  (N)o");
            string quit = Console.ReadLine().ToLower();
            if (quit == "y")
            {
                Console.WriteLine("\nCoward!");
                keypress();
                Environment.Exit(0);

            }
            Town();
        }

        public static void help()
        {
            Console.Clear();
            Console.WriteLine("\n\nLegend of Klinton is a simple dungeon crawler." +
                "\nYou can buy weapons, armor and healing potions in the shops, " +
                "fight monsters in the dungeon and level up at the level master\n\nBuying WEAPON, " +
                "ARMOR and ITEMS\nTo purchase these things, select the shop you wish to go to " +
                "and then (b)uy to see a list.\nIf you can afford it, select the number beside the " +
                "item you require.\nDon't forget to check your (c)haracter sheet frequently to see " +
                "how much gold you have.\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine("\n\nLEVELING UP\nWhen you have enough experience you can visit your " +
                "level master to level up.\nDoing so will raise your hitpoints and damge (as well as energy " +
                "in the case of rogues and mages)\n\nDUNGEON\nWhen you enter the dungeon, the level of all " +
                "monster will be based on YOUR level.\nThis means that levelling up will make monsters more " +
                "difficult.\nIf you enter deep enough you will find what you are looking for\n");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.WriteLine("\n\nFIGHTING MONSTERS\nTo fight a monster, you must choose to (a)ttack it or use your " +
                "special move, if you have one\nMages get a (f)ireball and Rogues get a (b)ackstab. These do extra damage " +
                "but cost an energy point.\nBe aware that energy does not regenerate except through " +
                "levelling up so it wisely.\n\nWINNING THE GAME\nIf you defeat the boss monster on the twentieth level," +
                " YOU WIN!\n ");
            keypress();
            Town();
        }

        public static void gameover()
        {
            Console.WriteLine("You have run out of time.\nThe wizard has arrived with his army.\nThe 'all is lost' moment came and went.\nIt's all over but the tears");
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\nWell, you tried\nYou failed but you tried.\nAnd in the end, is " +
                "that not the real victory?\nThe answer is no.\nGoodbye");
            keypress();
            Environment.Exit(0);
        }

        public static void win()
        {
            Console.WriteLine("YOU WIN!\nThank you for playing Legend Klinton, a more epic win screen is surely to follow one day");
            keypress();
            Environment.Exit(0);
        }

        public static void levelMaster()
        {
            Console.Clear();
            if (player.getplvl() == 20)
            {
                Console.WriteLine("\nThe level master has left. He has taught you all he can.");
            }
            else
            {
                Console.WriteLine("\nThe Level Master is meditating. He looks up at you.");
                colourText(ConsoleColor.Red,"'Are you here to level up?'\n(Y)es    (N)o\n",true);
                string level = Console.ReadLine().ToLower();
                if (level == "y")
                {
                    if (player.getxp() >= player.getxpneeded())
                    {
                        player.lvlup();
                        Console.WriteLine($"\nCongrats! You are level {player.getplvl()}!");
                        Console.Write($"You gain {player.getshp()} health\nYou gain {player.getsdam()} damage");
                    }
                    else
                    {
                        colourText(ConsoleColor.Red,"\nHe looks at you thoughtfully.\n'Hmmm... You're not QUITE ready yet'\nCome back when you are more experienced",true);
                    }
                }
                else
                    colourText(ConsoleColor.Red,"\nQuit wasting my time!",true);
            }
            keypress();
            Town();
        }
        public static void itemshop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a cluttered shop. There are bubbling potions everywhere" +
                "\nElya the Elf looks at and smiles.\n\n");
            colourText(ConsoleColor.Red,"'Well, hello there!. Are you here to buy something? Check back frequently, I'm always getting new items!",true);
            Console.WriteLine("\n(P)otions    (1)Crafting Machine");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getgold()} gold:\n\n");
            string ischoice = Console.ReadLine().ToLower();
            if (ischoice == "c")
                character();
            if (ischoice == "r")
                Town();
            if (ischoice == "1")
            {
                colourText(ConsoleColor.Red,"\nAh yes... A very rare thing indeed. \nA crafting machine can allow you to use the scraps of " +
                    "monsters to build your own items, including weapons and armor!\nAll yours for the reasonable price of 10000 gold\nWould you like to buy it?\n\n",true);
                Console.WriteLine("(Y)es     (N)o\n\n");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    if (player.getgold() >= 10000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWonderful!");
                        Console.ResetColor();
                        Console.WriteLine("Elya takes your money and gives you the crafting machine.");
                        player.subgold(10000);
                        craft = true;
                        keypress();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough money!");
                        keypress();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nCome back when you're serious!");
                    Console.ResetColor();
                    keypress();
                }

            }
            if (ischoice == "p")
            {
                int potbuy;
                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'Great! Potions are 100 gold apiece. How many would you like to buy?' (0) To return to the shop ");
                    Console.ResetColor();
                } while (!int.TryParse(Console.ReadLine(), out potbuy));
                if (potbuy == 0)
                    itemshop();
                else if (potbuy * 100 > player.getgold())
                {
                    Console.Write("You don't have enough gold!");
                    keypress();
                    itemshop();
                }
                else
                    Console.WriteLine("'Wonderful!'");
                Console.Write($"Elya takes your money and gives you {potbuy} healing potions.");
                player.subgold(potbuy * 100);
                player.addpot(potbuy);
                keypress();
            }
            else
                itemshop();
        }
        public static void weaponshop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a nice, clean shop. Billford the Troll looks up from the book he's reading.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'Ah, a customer. What can I do for you?'");
            Console.ResetColor();
            Console.WriteLine("\n(B)uy        (S)ell");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getgold()} gold:\n\n");
            string wschoice = Console.ReadLine().ToLower();
            if (wschoice == "c")
                character();
            if (wschoice == "r")
                Town();
            if (wschoice == "b")
            {
                colourText(ConsoleColor.Red, "\nWonderful! What can I get for you?\n", true);

                //Display a list of the items
                Console.Write("(1)");
                for (int i = 1; i < weaponList.Length; i++)
                {
                    colourText(ConsoleColor.Green, weaponList[i].getName(), false);
                    Console.Write($"    {weaponList[i].getPrice()} gold\n({(i + 1)})");
                }


                int choice;
                do
                {
                    Console.WriteLine("\n\nPlease choose a number that corresponds to the item you'd like to purchase.\n(0) to return to the shop\n\n ");
                } while (!int.TryParse(Console.ReadLine(), out choice));
                if (choice < 21 && choice > 0)
                {
                    if (weap.getName() == weaponList[choice].getName())
                    {
                        Console.Write("You already have a ");
                        colourText(ConsoleColor.Green, weaponList[choice].getName(), false);
                        Console.Write("!");
                        keypress();
                        weaponshop();

                    }
                    else if (player.getgold() >= weaponList[choice].getPrice())
                    {
                        Console.Write("You sure you want to buy a ");
                        colourText(ConsoleColor.Green, weaponList[choice].getName(), false);
                        Console.Write($" for {weaponList[choice].getPrice()} gold?\n(Y)es     (N)o\n\n");
                        string buyconf = Console.ReadLine().ToLower();
                        if (buyconf == "y")
                        {
                            if (weap.getPrice() != 0)
                            {
                                colourText(ConsoleColor.Red, "'I notice you have a ", false);
                                colourText(ConsoleColor.Green, weaponList[choice].getName(), false);
                                colourText(ConsoleColor.Red, ". Would you like to sell it?'\n", false);

                                Console.Write("(Y)es     (N)o\n\n");
                                string sellconf = Console.ReadLine().ToLower();
                                if (sellconf == "y")
                                {
                                    colourText(ConsoleColor.Red, $"'Wonderful.'\n\n", false);
                                    Console.Write($"Billford gives you {weap.getPrice() / 2} gold and takes your ");
                                    colourText(ConsoleColor.Green, weap.getName(), false);
                                    player.addgold(weap.getPrice() / 2);
                                    colourText(ConsoleColor.Red, "\n\n'A pleasure doing business with you!'\n", true);
                                    Console.Write("Billford gives you the ");
                                    colourText(ConsoleColor.Green, weaponList[choice].getName(), false);
                                    Console.Write(" and takes your money.");
                                    weap.setWeapon(weaponList[choice]);
                                    player.subgold(weaponList[choice].getPrice());

                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();

                                    keypress();
                                    weaponshop();


                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("'Quit wasting my time!'");
                                    Console.ResetColor();

                                    Console.WriteLine("Press any key to continue");
                                    Console.ReadKey();

                                    keypress();
                                    weaponshop();

                                }

                            }
                            else
                            {
                                Console.WriteLine("\n\n'A pleasure doing business with you!'\n");
                                Console.ResetColor();
                                Console.Write("Billford gives you the ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(weaponList[choice].getName());
                                Console.ResetColor();
                                Console.Write(" and takes your money.");
                                weap.setWeapon(weaponList[choice]);
                                player.subgold(weaponList[choice].getPrice());

                                Console.WriteLine("Press any key to continue");
                                Console.ReadKey();

                                keypress();
                                weaponshop();

                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("'Quit wasting my time!'");
                            Console.ResetColor();

                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();

                            keypress();
                            weaponshop();

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("'You don't have enough money!'");
                        Console.ResetColor();

                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();

                        keypress();
                        weaponshop();

                    }
                }

                weaponshop();

            }

            if (wschoice == "s")
            {
                if (weap.getPrice() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'You don't have anything to sell!'");
                    Console.ResetColor();
                    keypress();
                    weaponshop();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n'Would you like to sell your ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{weap.getName()}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("?'\n\n");
                    Console.ResetColor();
                    Console.Write("\n\n(Y)es     (N)o\n\n");
                    string sellconf = Console.ReadLine().ToLower();
                    if (sellconf == "y")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n\n'Wonderful.'\n\n");
                        Console.ResetColor();
                        Console.Write($"Billford gives you {weap.getPrice() / 2} gold and takes your ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{ weap.getName()}");
                        Console.ResetColor();
                        player.addgold(weap.getPrice() / 2);
                        weap.setWeapon(weaponList[0]);
                        keypress();
                        weaponshop();
                    }
                }
            }
            else
                weaponshop();
        }

        public static void armorshop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a nice, clean shop. Stanford the Hobitt looks up from the book he's reading.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'Greetings, friend! Here to buy or sell?'");
            Console.ResetColor();
            Console.WriteLine("\n(B)uy        (S)ell");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getgold()} gold:\n\n");
            string aschoice = Console.ReadLine().ToLower();
            if (aschoice == "c")
                character();
            if (aschoice == "r")
                Town();
            if (aschoice == "b")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWonderful! What can I get for you?\n");
                Console.ResetColor();
                Console.Write("(1)");

                //Display a list of the items
                for (int i = 1; i < weaponList.Length; i++)
                {
                    colourText(ConsoleColor.Green, armourList[i].getName(), false);
                    Console.Write($"    {armourList[i].getPrice()} gold\n({i + 1})");
                }

                Console.Write($"\nYou have {player.getgold()} gold:\n\n");
                int choice;
                do
                {
                    Console.WriteLine("\n\nPlease choose a number that corresponds to the item you'd like to purchase.\n(0) to return to the shop\n\n ");
                } while (!int.TryParse(Console.ReadLine(), out choice));
                if (choice < 21 && choice > 0)
                {
                    if (arm.getName() == armourList[choice].getName())
                    {
                        Console.Write("You already have a ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(armourList[choice].getName());
                        Console.ResetColor();
                        Console.Write("!");
                        keypress();
                        armorshop();
                    }
                    else if (player.getgold() >= armourList[choice].getPrice())
                    {
                        Console.Write("You sure you want to buy a ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(armourList[choice].getName());
                        Console.ResetColor();
                        Console.Write($" for {armourList[choice].getPrice()} gold?\n(Y)es     (N)o\n\n");
                        string buyconf = Console.ReadLine().ToLower();
                        if (buyconf == "y")
                        {
                            if (arm.getPrice() != 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("'I notice you have a ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write($"{arm.getName()}");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(". Would you like to sell it?'\n");
                                Console.ResetColor();
                                Console.Write("(Y)es     (N)o\n\n");
                                string sellconf = Console.ReadLine().ToLower();
                                if (sellconf == "y")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write($"'Wonderful.'\n\n");
                                    Console.ResetColor();
                                    Console.Write($"Stanford gives you {arm.getPrice() / 2} gold and takes your ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write($"{arm.getName()}");
                                    player.addgold(arm.getPrice() / 2);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\n'A pleasure doing business with you!'\n");
                                    Console.ResetColor();
                                    Console.Write("Stanford gives you the ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(armourList[choice].getName());
                                    Console.ResetColor();
                                    Console.Write(" and takes your money.");
                                    arm.setArmor(armourList[choice]);
                                    player.subgold(armourList[choice].getPrice());
                                    keypress();
                                    armorshop();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("'Quit wasting my time!'");
                                    Console.ResetColor();
                                    keypress();
                                    armorshop();
                                }

                            }
                            else
                            {
                                Console.WriteLine("\n\n'A pleasure doing business with you!'\n");
                                Console.ResetColor();
                                Console.Write("Stanford gives you the ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(armourList[choice].getName());
                                Console.ResetColor();
                                Console.Write(" and takes your money.");
                                arm.setArmor(armourList[choice]);
                                player.subgold(armourList[choice].getPrice());
                                keypress();
                                armorshop();
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("'Quit wasting my time!'");
                            Console.ResetColor();
                            keypress();
                            armorshop();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("'You don't have enough money!'");
                        Console.ResetColor();
                        keypress();
                        armorshop();
                    }
                }
                else
                {
                    armorshop();

                }

            }
            if (aschoice == "s")
            {
                if (arm.getPrice() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'You don't have anything to sell!'");
                    Console.ResetColor();
                    keypress();
                    armorshop();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n'Would you like to sell your ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{arm.getName()}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("?'\n\n");
                    Console.ResetColor();
                    Console.Write("\n\n(Y)es     (N)o\n\n");
                    string sellconf = Console.ReadLine().ToLower();
                    if (sellconf == "y")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n\n'Wonderful.'\n\n");
                        Console.ResetColor();
                        Console.Write($"Billford gives you {arm.getPrice() / 2} gold and takes your ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{ arm.getName()}");
                        Console.ResetColor();
                        player.addgold(arm.getPrice() / 2);
                        arm.setArmor(armourList[1]);
                        armorshop();
                    }
                }
            }
            else
            {
                armorshop();
            }
        }
        public static void dungeon()
        {
            Console.Clear();
            if (player.getplvl() == 20)
            {
                Console.Write("\n\nAs you enter the dungeon, you notice it looks.... Different.\n");
                Console.WriteLine("There is treasure, as far as the eye can see, but it is being guarded by.... Marcotte!");
                Console.WriteLine("Are you ready for the final showdown?\n(Y)es     (N)o\n\n");
                string showdown = Console.ReadLine().ToLower();
                if (showdown == "y")
                    fight();
                else
                {
                    Console.WriteLine("Coward!");
                    Town();
                }
            }
            else
                dungeonmenu();
        }

        public static void dungeonmenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\nYOU ARE IN DUNGEON LEVEL {player.getplvl()}");
            Console.WriteLine("\n\n(L)ook for monsters     (H)eal      (C)haracter     (R)eturn to town\n\n");
            colourText(ConsoleColor.DarkBlue, $"You have {fights} fights left today\n\n", true);
            Console.WriteLine("What would you like to do?\n\n");
            if (player.getxp() >= player.getxpneeded())
                Console.WriteLine("YOU ARE ELIGIBLE FOR A LEVEL RAISE\n\n");
            string dunchoice = Console.ReadLine().ToLower();
            if (dunchoice == "h")
                heal();
            if (dunchoice == "c")
                character();
            if (dunchoice == "r")
                Town();
            if (dunchoice == "l")
            {
                if (fights > 0)
                {
                    fights--;
                    Console.WriteLine("\nYou find.........");
                    Console.WriteLine("\nPress any key to continue\n");
                    Console.ReadKey();
                    Console.Clear();
                    int p = player.getplvl();
                    int r = rand.Next(-1, 1);
                    int x = rand.Next(1, 6);
                    if (x < 5)
                    {
                        mon.setmonster(monsterList[x]);
                        Console.Write("\nA ");

                        colourText(ConsoleColor.DarkYellow, $"{monsterList[x].getName()}!", true);
                        Console.WriteLine("\nPress any key to continue\n");
                        Console.ReadKey();

                        fight();
                    }
                    else
                        find();
                }
                else
                {
                    Console.WriteLine("You are too tired to fight. Go to bed");
                    dungeonmenu();
                }

            }
            else
                dungeonmenu();
        }

        public static void find()
        {
            Console.Clear();
            int x = rand.Next(1, 6);
            int y = rand.Next(-5, 15);
            int z = rand.Next(0, 5);
            int ggain = player.getplvl() * 15 + y;
            int egain = player.getplvl() * 10 + z;
            if (x == 1)
            {
                Console.WriteLine("A pile of gold!");
                Console.WriteLine($"You gain {ggain} gold");
                player.addgold(ggain);
                keypress();
                dungeon();
            }
            if (x == 2)
            {
                Console.WriteLine("An old book! You read it and gain experience");
                Console.WriteLine($"You gain {egain} experience");
                player.addxp(egain);
                keypress();
                dungeon();
            }
            if (x == 3)
            {
                if (player.getplvl() <= 3)
                {
                    if (weap.getPrice() < 100)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[4].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[4]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keypress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keypress();
                        dungeon();
                    }

                }
                if (player.getplvl() >= 4 && player.getplvl() < 7)
                {
                    if (weap.getPrice() < 200)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[8].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[8]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keypress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keypress();
                        dungeon();
                    }
                }
                if (player.getplvl() > 7)
                {
                    if (weap.getPrice() < 300)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[10].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[10]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keypress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keypress();
                        dungeon();
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nA trap! You barely escape with your life!");
                player.setminhealth();
                keypress();
                dungeon();
            }

        }

        public static void refresh()
        {
            player.setfullhealth();
            fights = 15;
            var jbrown = new SoundPlayer(@"C:\Users\tmarcott\source\repos\Medieval RPG\sfx\feelgood.wav");
            jbrown.Play();
            saveGame();
        }

        public static void death()
        {
            refresh();
            day += 3;
            player.losegold();
            player.losexp();
            Console.Clear();
            Console.WriteLine($"You died! It will take three days to ressurect you.\nYou have lost all gold on hand. You have lost all XP for this level.\nBe careful, you only have {30 - day} days left");
            keypress();
            house();
        }

        public static void colourText(ConsoleColor colour, String text, bool newLine)
        {
            Console.ForegroundColor = colour;
            if (newLine)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ResetColor();
        }

        public static void fight()
        {
            int p = rand.Next(-1, 4);
            int m = rand.Next(-1, 3);
            int hit = rand.Next(1, 100);
            int crit = rand.Next(1, 100);
            int def = rand.Next(1, 100);
            Console.Clear();
            if (player.getplvl() == 10)
                Console.WriteLine("You are facing Marcotte");
            else
            {
                Console.Write($"\n\nYou are facing a level {player.getplvl()} ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{mon.getName()}\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{mon.getmonTaunt()}\n");
                Console.ResetColor();
                Console.WriteLine($"HEALTH:{player.gethp()}/{player.getmhp()}       {mon.getName()}:{mon.getmonHp()}");
                Console.WriteLine($"ENERGY:{player.getenergy()}/{player.getmaxenergy()}");
                Console.WriteLine("\n(A)ttack     (H)eal");
                Console.WriteLine("(C)haracter  (R)un");
            }
            if (player.getclass() == "Rogue")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("(B)ackstab");
                Console.ResetColor();
            }
            else if (player.getclass() == "Mage")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("(F)ireball");
                Console.ResetColor();
            }
            Console.WriteLine("\nWhat do you do?\n");
            string patt = Console.ReadLine().ToLower();
            if (patt == "r")
            {
                Console.WriteLine("Coward!");
                keypress();
                dungeon();
            }
            else if (patt == "b")
            {
                if (player.getclass() == "Rogue")
                {
                    int attack = p + weap.getDam() * 2;
                    player.subenergy(1);
                    int mattack = mon.getmonDam() * player.getplvl() + m - arm.getDam();
                    double critattack = attack * 1.75;
                    int critdam = Convert.ToInt32(critattack);
                    if (hit > player.getHit())
                        Console.WriteLine($"You miss the {mon.getmonName()}!");
                    else
                    {
                        if (crit <= player.getCrit())
                        {
                            Console.WriteLine($"WHOAH!\nYou crit the monster for {critdam} damage!");
                            mon.subhp(critdam);
                        }
                        else
                        {
                            Console.WriteLine($"You hit the {mon.getmonName()} for {attack} damage");
                            mon.subhp(attack);
                        }
                        if (mon.getmonHp() <= 0)
                        {
                            Console.WriteLine($"You kill the {mon.getmonName()}!");
                            keypress();
                            reward();
                        }
                    }
                    if (def <= player.getDef())
                    {
                        Console.WriteLine($"The {mon.getmonName()} misses you!");
                    }
                    else
                    {
                        if (mattack <= 0)
                        {

                            Console.WriteLine($"{mon.getmonName()} hits you for 0 damage");
                            keypress();

                        }

                        else
                        {
                            Console.WriteLine($"{mon.getName()} hits you for {mattack} damage");
                            player.subhp(mattack);
                            if (player.gethp() <= 0)
                            {

                                Console.WriteLine($"The {mon.getName()} kills you!");
                                keypress();

                                Console.ReadKey();
                                if (day >= 30)
                                    gameover();
                                else
                                {
                                    death();
                                }
                            }
                            else
                            {
                                keypress();
                                fight();
                            }

                        }

                    }
                    keypress();
                }
            }

            else if (patt == "f")
            {
                if (player.getclass() == "Mage")
                {
                    int attack = player.getDam() * 5 + p;
                    player.subenergy(1);
                    int mattack = mon.getmonDam() * player.getplvl() + m - arm.getDam();
                    double critattack = attack * 1.75;
                    int critdam = Convert.ToInt32(critattack);
                    if (hit > player.getHit())
                        Console.WriteLine($"You miss the {mon.getmonName()}!");
                    else
                    {
                        if (crit <= player.getCrit())
                        {
                            Console.WriteLine($"WHOAH!\nYou crit the monster for {critdam} damage!");
                            mon.subhp(critdam);
                        }
                        else
                        {
                            Console.WriteLine($"You hit the {mon.getmonName()} for {attack} damage");
                            mon.subhp(attack);
                        }
                        if (mon.getmonHp() <= 0)
                        {
                            Console.WriteLine($"You kill the {mon.getmonName()}!");
                            keypress();
                            reward();
                        }
                    }
                    if (def <= player.getDef())
                    {
                        Console.WriteLine($"The {mon.getmonName()} misses you!");
                    }
                    else
                    {
                        if (mattack <= 0)
                        {

                            Console.WriteLine($"{mon.getmonName()} hits you for 0 damage");
                            keypress();

                        }

                        else
                        {
                            Console.WriteLine($"{mon.getName()} hits you for {mattack} damage");
                            player.subhp(mattack);
                            if (player.gethp() <= 0)
                            {

                                Console.WriteLine($"The {mon.getName()} kills you!");
                                keypress();

                                Console.ReadKey();
                                if (day >= 30)
                                    gameover();
                                else
                                {
                                    death();
                                }
                            }
                            else
                            {
                                keypress();
                                fight();
                            }

                        }

                    }
                    keypress();
                }
            }
            else if (patt == "a")
            {
                var punch = new SoundPlayer(@"C:\Users\tmarcott\source\repos\Medieval RPG\sfx\punch.wav");
                punch.Play();
                int attack = player.getDam() + p + weap.getDam();
                int mattack = mon.getmonDam() * player.getplvl() + m - arm.getDam();
                double critattack = attack * 1.75;
                int critdam = Convert.ToInt32(critattack);
                if (hit > player.getHit())
                    Console.WriteLine($"You miss the {mon.getmonName()}!");
                else
                {
                    if (crit <= player.getCrit())
                    {
                        Console.WriteLine($"WHOAH!\nYou crit the monster for {critdam} damage!");
                        mon.subhp(critdam);
                    }
                    else
                    {
                        Console.WriteLine($"You hit the {mon.getmonName()} for {attack} damage");
                        mon.subhp(attack);
                    }
                    if (mon.getmonHp() <= 0)
                    {
                        Console.WriteLine($"You kill the {mon.getmonName()}!");
                        keypress();
                        reward();
                    }
                }
                if (def <= player.getDef())
                {
                    Console.WriteLine($"The {mon.getmonName()} misses you!");
                }
                else
                {
                    if (mattack <= 0)
                    {

                        Console.WriteLine($"{mon.getmonName()} hits you for 0 damage");
                        keypress();

                    }

                    else
                    {
                        Console.WriteLine($"{mon.getName()} hits you for {mattack} damage");
                        player.subhp(mattack);
                        if (player.gethp() <= 0)
                        {

                            Console.WriteLine($"The {mon.getName()} kills you!");
                            keypress();

                            Console.ReadKey();
                            if (day >= 30)
                                gameover();
                            else
                            {
                                death();
                            }
                        }
                        else
                        {
                            keypress();
                            fight();
                        }

                    }

                }
                keypress();
            }
            else if (patt == ("c"))
                character();
            else if (patt == ("h"))
                heal();
            fight();
        }

        public static void reward()
        {
            Console.Clear();
            int g = rand.Next(-10, 50);
            int e = rand.Next(-2, 7);
            if (player.getplvl() == 20)
                win();
            else
            {
                Console.WriteLine($"You gain {mon.getmonXp() + e} experience");
                Console.WriteLine($"You gain {mon.getmonGold() + g} gold");
                player.addgold(mon.getmonGold() * player.getplvl() + g);
                player.addxp(mon.getmonXp() * player.getplvl() + e);
                keypress();
                dungeon();
            }
        }
    }
}