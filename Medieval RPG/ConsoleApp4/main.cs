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
        public static Monster mon;
        public static Town mainTown;
        
        public static SaveLoad saveLoad;
        //Public variable to allow choosing dungeons
        public static string dungeonChoice;
        public static int fights = 15;
        public static int day = 1;
        public static int bankgold = 0;
        public static bool craft = false;

        // A list of all weapons
        private static Weapon[] weaponList = { new Weapon("None", 0, 0), new Weapon("Knife", 2, 500), new Weapon("Dagger", 4, 1000), new Weapon("Short Sword", 6, 2000), new Weapon("Long Sword", 8, 4000),
            new Weapon("Greatsword", 10, 6000), new Weapon("Red Sword", 12, 10000), new Weapon("Black Sword", 14, 14000),  new Weapon("Crystal Sword", 16, 18000), new Weapon("Sword of the Wind", 18, 24000),
            new Weapon("Ashton's Hand", 20, 30000), new Weapon("Arm of Deb", 23, 35000), new Weapon("Sword of Wanting", 26, 40000), new Weapon("Sword of Song", 29, 50000),  new Weapon("Sword of Life", 32, 60000),
            new Weapon("Sword of Death", 35, 70000), new Weapon("Sword of Mourning", 39, 85000), new Weapon("Sword of Healing", 43, 100000), new Weapon("Sword of Hope", 47, 125000),
            new Weapon("Blade of Slaying", 51, 150000), new Weapon("Final Blade", 55, 200000) };

        // A list of all Armours
        private static Armor[] armourList = { new Armor("None", 0, 0), new Armor("Cloth", 2, 500), new Armor("Old Leather", 4, 1000), new Armor("Leather and chain", 6, 2000), new Armor("Chainmail", 8, 4000),
            new Armor("Coat of Plates", 10, 6000), new Armor("Red Armor", 12, 10000), new Armor("Black Armour", 14, 14000),  new Armor("Crystal Armour", 16, 18000), new Armor("Armour of the Wind", 18, 24000),
            new Armor("Ashton's Hand", 20, 30000), new Armor("Arm of Deb", 23, 35000), new Armor("Armour of Wanting", 26, 40000), new Armor("Armour of Song", 29, 50000),  new Armor("Armour of Life", 32, 60000),
            new Armor("Armour of Death", 35, 70000), new Armor("Armour of Mourning", 39, 85000), new Armor("Armour of Healing", 43, 100000), new Armor("Armour of Hope", 47, 125000),
            new Armor("Shield of Slaying", 51, 150000), new Armor("Final Armour", 55, 200000) };

        // A list of Monsters
        private static Monster[] monsterList1 = { new Monster("none", "none", 0, 0, 0, 0), new Monster("Green Slime", "*Squish*", 10, 6, 3, 145),
            new Monster("Rat", "*Squeak*", 9, 6, 4, 145), new Monster("Basilisk", "*HSSS*", 11, 6, 4, 145),
            new Monster("Giant Cockroach", "*Skitter skitter*", 12, 6, 3, 145) };

        private static Monster[] monsterList2 = { new Monster("none", "none", 0, 0, 0, 0), new Monster("Yellow Slime", "*Squish*", 20, 12, 7, 300),
            new Monster("Thug", "'Your money AND your life!'", 24, 16, 10, 350), new Monster("Basilisk", "*HSSS*", 11, 6, 4, 145),
            new Monster("Green Slime", "*Squish*", 10, 6, 3, 145), new Monster("Imp", "*Squeak, squeak*", 17, 14, 15, 300),
            new Monster("Goblin", "'The treasure is MINE!'", 22, 14, 12, 320), new Monster("Goblin", "'The treasure is MINE!'", 22, 14, 12, 320),
            new Monster("Kobald", "*You no take candle!*", 20, 14, 14, 300), };

        private static Monster[] monsterList3 = { new Monster("none", "none", 0, 0, 0, 0), new Monster("Red Slime", "*Squish*", 28, 20,21, 460),
            new Monster("Thug", "'Your money AND your life!'", 29, 21, 19, 450), new Monster("Thug", "'Your money AND your life!'", 29, 21, 19, 450),
            new Monster("Orc", "'ROAR! SMASH!!!'", 36, 25, 30, 600), new Monster("Fire Imp", "*Squeak, squeak*", 26, 20, 28, 460),
            new Monster("Super Giant Cockroach", "*Skitter skitter*", 39, 29, 18, 459), new Monster("Fat Goblin", "'The treasure is MINE!'", 34, 20, 20, 500),
            new Monster("Kobald", "*You no take candle!*", 25, 19, 19, 450), };



        static void Main(string[] args)
        {
            saveLoad = new SaveLoad();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                             Legend of Klinton");
            Console.WriteLine("                                             Press any key to continue");
            Console.ReadKey();
            menu();
        }

        //Main menu, New Game, Load Game, Information, Quit
        public static void menu()
        {

            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                             (N)ew Game   (L)oad Game     (Q)uit\n                                             (?)What is this game about?\n\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "n")
                welcome();
            else if (choice == "?")
                Console.WriteLine("To Be Created");
            else if (choice == "l")
            {
                loadGame();
                town1();
            }
            else if (choice == "q")
                Environment.Exit(0);

            menu();
        }

        //choose name, currently also sets all variables for classes to a default.
        public static void welcome()
        {
            Console.Clear();
            Console.WriteLine("\nWelcome! What is your name?\n");
            string pName = Console.ReadLine();
            if (pName.Length < 3)
            {
                Console.WriteLine("Too short! Try again!");
                keyPress();
                welcome();
            }
            if (pName.Length > 9)
            {
                Console.WriteLine("Too long! Try again!");
                keyPress();
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
                    player = new Hero(pName, 0, 0, 0, 1000);
                    weap = new Weapon("None", 0, 0);
                    arm = new Armor("None", 0, 0);
                    mon = new Monster("none", "none", 0, 0, 0, 0);
                    chooseClass();
                }
                else
                {
                    Console.WriteLine("Ok, let's try this again");
                    keyPress();
                    welcome();
                }
            }
        }

        //This is a function the set the town information, currently just creates a new town but may need to be refactored later to update/change towns. 
        public static Town setTown(String name, String description, String options)
        {
            return new Town(name, description, options);
        }

        public static void chooseClass()
        {
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
                player.setClass(10, "Warrior", 0, 3, 80, 15, 20, 0);
            }
            else if (pClass == "r")
            {
                Console.WriteLine("\nA rogue.\nSneaky sneaky, stabby stabby");
                weap.setWeapon(weaponList[1]);
                player.setClass(8, "Rogue", 1, 2, 85, 20, 15, 0);
            }
            else if (pClass == "m")
            {
                Console.WriteLine("\nA mage. Phenomenal cosmic power, itty bitty muscles");
                weap.setWeapon(weaponList[0]);
                player.setClass(6, "Mage", 2, 1, 80, 5, 10, 10);
                player.addPot(1);
            }
            else
            {
                Console.WriteLine("Not an option");
                chooseClass();
            }

            town1();
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

        //Calls the Load function, spits the player out in their house.
        public static void loadGame()
        {
            player = saveLoad.load();
            house();
        }

        public static void keyPress()
        {
            Console.WriteLine("\nPress any key to continue\n");
            Console.ReadKey();
        }
        public static void town1()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou grew up in a tiny village with dreams of breaking free of your boring, peasant life.\nMany times, you have been told of the legend of " +
                "Klinton, a small town in the west.\nRumor has it there is a dungeon just outside the town, overrun with monsters.\nIn the dungeon there is also a source of power able to grant any wish to whomever can find it." +
                "\nAs you become an adult, you decide to set off for Klinton. ");

            mainTown = setTown("Klinton", "Klinton appears to be a small but bustling town.\nBetween the weapon shop and the armorShop there" +
                " is a path that leads to the dungeon.\nIn it, you can find both treasure... and death.", "\n(W)eapon shop        (A)rmor shop        (I)tem shop     (D)ungeon" +
                "\n(V)isit level master (C)haracter         (H)eal          (Y)our house\n(T)avern             (B)ank              (Q)uit          (?)Help\n");

            keyPress();
            town();
        }
        public static void town()
        {
            Console.Clear();
            Console.WriteLine($"\n\nWelcome to {mainTown.getName()}, {player.getName()} the {player.getClass()}\n");
            Console.WriteLine($"{mainTown.getFlavor()}");
            Console.WriteLine($"\n{mainTown.getOptions()}");

            colourText(ConsoleColor.DarkBlue, $"It is day {day}", true);
            Console.WriteLine("\nWhat would you like to do?\n");
            string townchoice = Console.ReadLine().ToLower();
            if (townchoice == ("w"))
                weaponShop();
            else if (townchoice == ("a"))
                armorShop();
            else if (townchoice == ("i"))
                itemShop();
            else if (townchoice == ("d"))
                dungeon();
            else if (townchoice == ("v"))
                levelMaster();
            else if (townchoice == ("y"))
                house();
            else if (townchoice == ("b"))
                bank();
            else if (townchoice == ("t"))
            {
                loopSound("medley.wav");
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
                player.addXP(50);
            else
                Console.Write("Not an option");

            town();
        }

        public static void bank()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a small but busy bank. One teller appears to be free. You walk up to him");
            colourText(ConsoleColor.Red, "\n'Hello. How may I be of service?'", true);

            Console.WriteLine("\n\n(D)eposit        (W)ithdraw          (R)eturn to town\n\n");
            Console.WriteLine($"Gold:{player.getGold()}     Gold in bank:{bankgold}\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "d")
            {
                if (player.getGold() > 0)
                {
                    int deposit;
                    do
                    {
                        colourText(ConsoleColor.Red, "'Excellent! How much would you like to deposit?' (0) To return to the bank \n", true);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n'Excellent! How much would you like to deposit?' (0) To return to the bank \n");
                        Console.ResetColor();
                    } while (!int.TryParse(Console.ReadLine(), out deposit));
                    if (player.getGold() >= deposit)
                    {
                        Console.WriteLine($"\nYou deposit {deposit} gold.");
                        player.subGold(deposit);
                        bankgold += deposit;
                    }
                    else
                    {
                        colourText(ConsoleColor.Red, "'You don't have enough money!'", true);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n'You don't have enough money!'");
                        Console.ResetColor();
                    }
                }
                else
                {
                    colourText(ConsoleColor.Red, "'You don't have enough money!'", true);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'You don't have any money!'");
                    Console.ResetColor();
                }
                keyPress();
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

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n'Excellent! How much would you like to withdraw?' (0) To return to the bank ");
                        Console.ResetColor();

                    } while (!int.TryParse(Console.ReadLine(), out withdraw));
                    if (bankgold >= withdraw)
                    {
                        Console.WriteLine($"\nYou withdraw {withdraw} gold.");
                        player.addGold(withdraw);
                        bankgold -= withdraw;
                    }
                    else
                    {

                        colourText(ConsoleColor.Red, "'You don't have enough money in the bank!'", true);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n'You don't have enough money in the bank!'");
                        Console.ResetColor();
                    }
                }

                else
                {

                    colourText(ConsoleColor.Red, "'You don't have any money in the bank!'", true);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n'You don't have any money in the bank!'");
                    Console.ResetColor();

                }
                keyPress();
                bank();
            }
            else if (choice == "r")
                town();

            bank();

        }

        //function to handle everything happening in your house. 
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
                town();
            }
            else if (choice == "b")
            {
                Console.Clear();
                Console.WriteLine("You sleep until morning.");
                player.setFullHealth();
                refresh();
                day++;
                Console.WriteLine("You wake up feeling refreshed!");
                keyPress(); //10 days for the moment
                if (day >= 10)
                    gameOver();
                house();
            }
            if (choice == "c")
            {
                if (craft == true)
                {
                    Console.Clear();
                    Console.WriteLine("You consider the odd looking machine. You know you can do something with it, you're just not sure what yet.");
                    keyPress();
                }
                else
                    house();
            }
            else
                house();

        }

        //function to handle the tavern options. 
        public static void tavern()
        {
            Console.Clear();
            Console.WriteLine("\nYou enter a bustling tavern. More flavor will be added soon describing the place and what you can do.");
            Console.WriteLine($"\n\n(G)amble         (L)ocal gossip          (T)alk to the bartender     (C)haracter     (R)eturn\n\nYou have {player.getGold()} gold\n");
            string choice = Console.ReadLine().ToLower();
            if (choice == "g")
                gamble();
            else if (choice == "l")
                gossip();
            else if (choice == "t")
                bartender();
            else if (choice == "r")
            {
                var medeley = new SoundPlayer(@"C:\Users\marco\source\repos\medievalRPG\sfx\medley.wav");
                medeley.Stop();
                town();
            }
            else if (choice == "c")
                character();
            tavern();
        }

        public static void bartender()
        {
            Console.Clear();
            Console.WriteLine("You walk over to the bartender. He tells you Marcotte's still working on the game. For now, scram.");
            keyPress();
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
                Console.WriteLine($"\nYou have {player.getGold()} gold\n");
                Console.WriteLine("How much would you like to wager?\n0 to wager nothing and return to the inn.");
            } while (!int.TryParse(Console.ReadLine(), out wager));
            if (wager == 0)
                tavern();
            else
            {
                if (player.getGold() >= wager)
                {
                    Console.WriteLine($"Wager {wager} gold?\n(Y)es     (N)o");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        player.subGold(wager);
                        Console.WriteLine($"Confident, you place {wager} gold on the table. You and the man each roll a die.\n");
                        keyPress();
                        Console.WriteLine($"You roll a {x}\nThe man rolls a {y}");
                        if (x > y)
                        {
                            Console.WriteLine($"You win! You receive {wager * 2} gold!");
                            player.addGold(wager * 2);
                            keyPress();
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
                            keyPress();
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
                            player.addGold(wager);
                            keyPress();
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
                    keyPress();
                    tavern();
                }

            }
        }

        //function to find information and gossip.
        public static void gossip()
        {
            Console.Clear();
            Console.WriteLine("The current gossip is that this game will be pretty sweet when it's finished. For now, tho, there's very little else to hear.");
            keyPress();
            tavern();
        }

        public static void character()
        {
            Console.Clear();
            Console.Write($"\n{player.getName()}, Level {player.getLevel()}");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write($" {player.getClass()}\n");
            Console.ResetColor();
            if (player.getLevel() == 20)
                Console.WriteLine($"YOU ARE MAX LEVEL");
            else if (player.getXP() >= player.getXPNeeded())
                Console.WriteLine($"YOU ARE ELIGIBLE FOR A LEVEL RAISE");
            else
                Console.WriteLine($"\nEXPERIENCE:{player.getXP()}/{player.getXPNeeded()}");
            Console.Write($"HEALTH: { player.getHP()}/{ player.getMHP()}\nENERGY: { player.getEnergy()}/{ player.getMaxEnergy()}\n" +
            "WEAPON:");
            colourText(ConsoleColor.Green, weap.getName(), true);

            Console.Write("ARMOR :");
            colourText(ConsoleColor.Green, arm.getName(), true);
            Console.Write($"HEALING POTIONS:{player.getPot()}\n\nGOLD:{player.getGold()}\nGOLD IN BANK:{bankgold}\n\n" +
                $"DAMAGE :{player.getDam() - 1 + weap.getDam()} - {player.getDam() + 3 + weap.getDam()} \nDEFENCE:{arm.getDam()}");
            keyPress();
        }

        //Function to heal the player to full health using a healing potion.
        public static void heal()
        {
            if (player.getHP() == player.getMHP())
                Console.Write("\nYou don't need healing!");
            else if (player.getPot() == 0)
                Console.Write("\nYou don't have a healing potion!");
            else
            {
                Console.WriteLine("\nYou drink a potion.\nYou are now at full health.");
                player.setFullHealth();
                player.reducePotions();
            }
            keyPress();
        }

        //Quit out of the game;
        public static void quit()
        {
            Console.WriteLine("Do you want to quit?\n(Y)es  (N)o");
            string quit = Console.ReadLine().ToLower();
            if (quit == "y")
            {
                Console.WriteLine("\nCoward!");
                keyPress();
                Environment.Exit(0);

            }
            town();
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
            keyPress();
            town();
        }

        public static void gameOver()
        {
            /*Console.WriteLine("You have run out of time.\nThe wizard has arrived with his army.\nThe 'all is lost' moment came and went.\nIt's all over but the tears");
            Console.WriteLine("\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\n\nWell, you tried\nYou failed but you tried.\nAnd in the end, is " +
                "that not the real victory?\nThe answer is no.\nGoodbye");
            keyPress();
            Environment.Exit(0); */
            //Temporary placeholder for "Demo". Delete this when ready to move on
            Console.WriteLine("That is all for now. Hope you had fun. Thank you for trying the game");
            keyPress();
            Environment.Exit(0);
        }

        public static void win()
        {
            Console.WriteLine("YOU WIN!\nThank you for playing Legend Klinton, a more epic win screen is surely to follow one day");
            keyPress();
            Environment.Exit(0);
        }

        public static void levelMaster()
        {
            Console.Clear();
            if (player.getLevel() == 20)
            {
                Console.WriteLine("\nThe level master has left. He has taught you all he can.");
            }
            else
            {
                Console.WriteLine("\nThe Level Master is meditating. He looks up at you. 'Are you here to level up?\n(Y)es    (N)o\n");
                string level = Console.ReadLine().ToLower();
                if (level == "y")
                {
                    if (player.getXP() >= player.getXPNeeded())
                    {
                        player.levelUp();
                        Console.WriteLine($"\nCongrats! You are level {player.getLevel()}!");
                        Console.Write($"You gain {player.getSHP()} health\nYou gain {player.getSDam()} damage");
                    }
                    else
                    {
                        Console.WriteLine("\nHe looks at you thoughtfully.\n'Hmmm... You're not QUITE ready yet'\nCome back when you are more experienced");
                    }
                }
                else
                    Console.WriteLine("\nQuit wasting my time!");
            }
            keyPress();
            town();
        }

        public static void itemShop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a cluttered shop. There are bubbling potions everywhere" +
                "\nElya the Elf looks at and smiles.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'Well, hello there!. Are you here to buy something? Check back frequently, I'm always getting new items!;");
            Console.ResetColor();
            Console.WriteLine("\n(P)otions    (1)Crafting Machine");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getGold()} gold:\n\n");
            string ischoice = Console.ReadLine().ToLower();
            if (ischoice == "c")
                character();
            if (ischoice == "r")
                town();
            if (ischoice == "1")
            {
                Console.WriteLine("Ah yes... A very rare thing indeed. \nA crafting machine can allow you to use the scraps of " +
                    "monsters to build your own items, including weapons and armor!\nAll yours for the reasonable price of 10000 gold\nWould you like to buy it?\n\n(Y)es     (N)o");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    if (player.getGold() >= 10000)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wonderful!");
                        Console.ResetColor();
                        Console.WriteLine("Elya takes your money and gives you the crafting machine.");
                        player.subGold(10000);
                        craft = true;
                        keyPress();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Come back when you're serious!");
                    Console.ResetColor();
                    keyPress();
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
                    itemShop();
                else if (potbuy * 100 > player.getGold())
                {
                    Console.Write("You don't have enough gold!");
                    keyPress();
                    itemShop();
                }
                else
                    Console.WriteLine("'Wonderful!'");
                Console.Write($"Elya takes your money and gives you {potbuy} healing potions.");
                player.subGold(potbuy * 100);
                player.addPot(potbuy);
                keyPress();
            }
            else
                itemShop();
        }

        public static void weaponShop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a nice, clean shop. Billford the Troll looks up from the book he's reading.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'Ah, a customer. What can I do for you?'");
            Console.ResetColor();
            Console.WriteLine("\n(B)uy        (S)ell");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getGold()} gold:\n\n");
            string wschoice = Console.ReadLine().ToLower();
            if (wschoice == "c")
                character();
            if (wschoice == "r")
                town();
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
                        keyPress();
                        weaponShop();

                    }
                    else if (player.getGold() >= weaponList[choice].getPrice())
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
                                    player.addGold(weap.getPrice() / 2);
                                    colourText(ConsoleColor.Red, "\n\n'A pleasure doing business with you!'\n", true);
                                    Console.Write("Billford gives you the ");
                                    colourText(ConsoleColor.Green, weaponList[choice].getName(), false);
                                    Console.Write(" and takes your money.");
                                    weap.setWeapon(weaponList[choice]);
                                    player.subGold(weaponList[choice].getPrice());
                                    keyPress();
                                    weaponShop();


                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("'Quit wasting my time!'");
                                    Console.ResetColor();
                                    keyPress();
                                    weaponShop();

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
                                player.subGold(weaponList[choice].getPrice());
                                keyPress();
                                weaponShop();

                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("'Quit wasting my time!'");
                            Console.ResetColor();
                            keyPress();
                            weaponShop();

                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("'You don't have enough money!'");
                        Console.ResetColor();
                        keyPress();
                        weaponShop();

                    }
                }

                weaponShop();

            }

            if (wschoice == "s")
            {
                if (weap.getPrice() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'You don't have anything to sell!'");
                    Console.ResetColor();
                    keyPress();
                    weaponShop();
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
                        player.addGold(weap.getPrice() / 2);
                        weap.setWeapon(weaponList[0]);
                        keyPress();
                        weaponShop();
                    }
                }
            }
            else
                weaponShop();
        }

        public static void armorShop()
        {
            Console.Clear();
            Console.WriteLine("\n\nYou enter a nice, clean shop. Stanford the Hobitt looks up from the book he's reading.\n\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("'Greetings, friend! Here to buy or sell?'");
            Console.ResetColor();
            Console.WriteLine("\n(B)uy        (S)ell");
            Console.WriteLine("(C)haracter  (R)eturn to town");
            Console.Write($"\nYou have {player.getGold()} gold:\n\n");
            string aschoice = Console.ReadLine().ToLower();
            if (aschoice == "c")
                character();
            if (aschoice == "r")
                town();
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

                Console.Write($"\nYou have {player.getGold()} gold:\n\n");
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
                        keyPress();
                        armorShop();
                    }
                    else if (player.getGold() >= armourList[choice].getPrice())
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
                                    player.addGold(arm.getPrice() / 2);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\n'A pleasure doing business with you!'\n");
                                    Console.ResetColor();
                                    Console.Write("Stanford gives you the ");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.Write(armourList[choice].getName());
                                    Console.ResetColor();
                                    Console.Write(" and takes your money.");
                                    arm.setArmor(armourList[choice]);
                                    player.subGold(armourList[choice].getPrice());
                                    keyPress();
                                    armorShop();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("'Quit wasting my time!'");
                                    Console.ResetColor();
                                    keyPress();
                                    armorShop();
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
                                player.subGold(armourList[choice].getPrice());
                                keyPress();
                                armorShop();
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("'Quit wasting my time!'");
                            Console.ResetColor();
                            keyPress();
                            armorShop();
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("'You don't have enough money!'");
                        Console.ResetColor();
                        keyPress();
                        armorShop();
                    }
                }
                else
                {
                    armorShop();

                }

            }
            if (aschoice == "s")
            {
                if (arm.getPrice() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("'You don't have anything to sell!'");
                    Console.ResetColor();
                    keyPress();
                    armorShop();
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
                        player.addGold(arm.getPrice() / 2);
                        arm.setArmor(armourList[1]);
                        armorShop();
                    }
                }
            }
            else
            {
                armorShop();
            }
        }

        public static void dungeon()
        {
            //Choose which dungeon of 3 to enter
            Console.Clear();
            Console.WriteLine("As you approach the dungeon, notice there are actually three seperate enterances." +
                "\nThe first is at ground level. The second  goes deeper. \nThe third goes down to what appears to be the bottom and is dimly lit." +
                "\nWhich entrance will you go in?\n(1)       (2)         (3)     (R)eturn");
            //This variable chooses which dungeon you will fight in. It is used to find monsters.
            dungeonChoice = Console.ReadLine().ToLower();
            if (dungeonChoice == "1")
                dungeonMenu();
            if (dungeonChoice == "2")
                dungeonMenu();
            if (dungeonChoice == "3")
                dungeonMenu();
            if (dungeonChoice == "r")
                town();
            dungeon();
        }

        public static void dungeonMenu()
        {
            Console.Clear();
            Console.WriteLine($"\n\nYOU ARE IN DUNGEON FLOOR {dungeonChoice}");
            Console.WriteLine("\n\n(L)ook for monsters     (H)eal      (C)haracter     (R)eturn to town\n\n");
            colourText(ConsoleColor.DarkBlue, $"You have {fights} fights left today\n\n", true);
            Console.WriteLine("What would you like to do?\n\n");
            if (player.getXP() >= player.getXPNeeded())
                Console.WriteLine("YOU ARE ELIGIBLE FOR A LEVEL RAISE\n\n");
            string dunchoice = Console.ReadLine().ToLower();
            if (dunchoice == "h")
                heal();
            if (dunchoice == "c")
                character();
            if (dunchoice == "r")
                town();
            if (dunchoice == "l")//Looks for monsters based on the level of dungeon
                dungeonSearch();
            else
            dungeonMenu();

        }

        private static void dungeonSearch()
        {
            //Pulls up the monster lists based on what dungeon level you are on
            if (fights > 0)
            {
                fights--;
                Console.WriteLine("\nYou find.........");
                keyPress();
                Console.Clear();
                if (dungeonChoice == "1")
                {

                    int x = rand.Next(1, 5);
                    if (x < 5)
                    {
                        mon.setmonster(monsterList1[x]);
                        Console.Write("\nA ");
                        colourText(ConsoleColor.DarkYellow, $"{monsterList1[x].getName()}!", true);
                        keyPress();
                        fight();
                    }
                    else
                        find();
                }
                if (dungeonChoice == "2")
                {

                    int x = rand.Next(1, 10);
                    if (x < 9)
                    {
                        mon.setmonster(monsterList2[x]);
                        Console.Write("\nA ");
                        colourText(ConsoleColor.DarkYellow, $"{monsterList2[x].getName()}!", true);
                        keyPress();
                        fight();
                    }
                    else
                        find();
                }
                if (dungeonChoice == "3")
                {

                    int x = rand.Next(1, 10);
                    if (x < 9)
                    {
                        mon.setmonster(monsterList3[x]);
                        Console.Write("\nA ");
                        colourText(ConsoleColor.DarkYellow, $"{monsterList3[x].getName()}!", true);
                        keyPress();
                        fight();
                    }
                    else
                        find();
                }
            }
            else
            {
                Console.WriteLine("You are too tired to fight. Go to bed");
                dungeonMenu();
            }
        }
        public static void find()
        {
            Console.Clear();
            int x = rand.Next(1, 6);
            int y = rand.Next(-5, 15);
            int z = rand.Next(0, 5);
            int ggain = player.getLevel() * 15 + y;
            int egain = player.getLevel() * 10 + z;
            if (x == 1)
            {
                Console.WriteLine("A pile of gold!");
                Console.WriteLine($"You gain {ggain} gold");
                player.addGold(ggain);
                keyPress();
                dungeon();
            }
            if (x == 2)
            {
                Console.WriteLine("An old book! You read it and gain experience");
                Console.WriteLine($"You gain {egain} experience");
                player.addXP(egain);
                keyPress();
                dungeon();
            }
            if (x == 3)
            {
                if (player.getLevel() <= 3)
                {
                    if (weap.getPrice() < 100)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[4].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[4]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keyPress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keyPress();
                        dungeon();
                    }

                }
                if (player.getLevel() >= 4 && player.getLevel() < 7)
                {
                    if (weap.getPrice() < 200)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[8].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[8]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keyPress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keyPress();
                        dungeon();
                    }
                }
                if (player.getLevel() > 7)
                {
                    if (weap.getPrice() < 300)
                    {
                        Console.Write("\n\nA ");
                        colourText(ConsoleColor.Green, weaponList[10].getName(), false);
                        Console.Write("!");
                        weap.setWeapon(weaponList[10]);
                        Console.Write($"\n\nNot quite believing your luck, you equip the {weap.getName()} and keep exploring");
                        keyPress();
                        dungeon();
                    }
                    else
                    {
                        Console.WriteLine("\n\nYou find nothing of interest. Just some old weapons you can't use");
                        keyPress();
                        dungeon();
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\nA trap! You barely escape with your life!");
                Console.WriteLine("You lose all but 1 hitpoint");
                player.setMinHealth();
                keyPress();
                dungeon();
            }

        }

        public static void refresh()
        {
            player.setFullHealth();
            fights = 15;
            playSoundOnce("feel_good_x.wav");
            saveGame();
        }

        public static void death()
        {
            refresh();
            day += 3;
            player.loseGold();
            player.loseXP();
            Console.Clear();
            //Changed to 10 days for the moment
            Console.WriteLine($"You died! It will take three days to ressurect you.\nYou have lost all gold on hand. You have lost all XP for this level." +
                $"\nBe careful, you only have {10 - day} days left");
            keyPress();
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

        public static void playSoundOnce(String path)
        {
            SoundPlayer sound = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "/sfx/" + path);
            sound.Play();
        }

        public static void loopSound(String path)
        {
            SoundPlayer medeley = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "/sfx/" + path);
            medeley.PlayLooping();
        }

        public static void fight()
        {
            int p = rand.Next(-1, 3);
            int m = rand.Next(-1, 3);
            int hit = rand.Next(1, 100);
            int crit = rand.Next(1, 100);
             //Lamda expression, essentially a single line if/else statment. It says if the monsters damage is greater than 0 then it's monster damage, if it's not greater than 0 then it is 0.
            int mAttack = (mon.getmonDam() * player.getLevel() + m - arm.getDam() > 0) ? mon.getmonDam() * player.getLevel() + m - arm.getDam() : 0;

            Console.Clear();

            //Tell the player what they are facing.
            
            Console.Write($"\n\nYou are facing a");
            colourText(ConsoleColor.DarkYellow, $" {mon.getName()}\n", true);
            colourText(ConsoleColor.Red, $"\n{mon.getmonTaunt()}\n", true);
            Console.WriteLine($"HEALTH:{player.getHP()}/{player.getMHP()}       {mon.getName()}:{mon.getmonHp()}");
            Console.WriteLine($"ENERGY:{player.getEnergy()}/{player.getMaxEnergy()}");
            Console.WriteLine("\n(A)ttack     (H)eal");
            Console.WriteLine("(C)haracter  (R)un");
            
            //Create the option for the special attack for each class.
            if (player.getClass() == "Rogue")
                colourText(ConsoleColor.DarkMagenta, "(B)ackstab", true);
            else if (player.getClass() == "Mage")
                colourText(ConsoleColor.DarkMagenta, "(F)ireball", true);

            //Get player input
            Console.WriteLine("\nWhat do you do?\n");
            string patt = Console.ReadLine().ToLower();

            //If the player runs away, call them a coward and then return to the dungeon screen.
            if (patt == "r")
            {
                Console.WriteLine("Coward!");
                keyPress();
                dungeon();
            }
            //If the player selects Backstab and is a rogue
            else if (patt == "b" && player.getClass() == "Rogue" && player.getEnergy() > 0)
            {
                int attack = (player.getDam() + p + weap.getDam()) * 4;
                player.subEnergy(1);

                playerDamageMonster(attack,mAttack);
            }
            else if (patt == "f" && player.getClass() == "Mage" && player.getEnergy() > 0)
            {
                int attack = player.getDam() * 5 + p;
                player.subEnergy(1);

                playerDamageMonster(attack, mAttack);
            }
            else if (patt == "a")
            {
                int attack = player.getDam() + p + weap.getDam();
                //check to see if you hit
                if (hit > player.getHit())
                {
                    attackRoll(hit);
                    monsterDamagePlayer(mAttack);
                }
                else
                {
                    //Check to see if you crit
                    if (crit <= player.getCrit())
                    {
                        criticalHit(attack);
                        playerDamageMonster(attack, mAttack);
                    }
                        
                    else
                    //if there is not miss or crit, deal normal damage.
                    playerDamageMonster(attack, mAttack);
                }
                
            }
            else if (patt == ("c"))
                character();
            else if (patt == ("h"))
                heal();
            else if (patt == "b" || patt == "f" && player.getEnergy() <= 0 && player.getClass() == "Mage" || player.getClass() == "Rogue")
                Console.WriteLine("You don't have enough Energy");

            keyPress();
            fight();
        }

        private static void criticalHit(int attack)
        {
            playSoundOnce("punch.wav");
            int critDam = Convert.ToInt32(attack * 1.75);
            Console.Clear();
            Console.WriteLine("Whoah, You crit!");
        }

        private static void attackRoll(int hit)
        {
                Console.WriteLine($"You miss the {mon.getmonName()}!");
        }

        
        private static void playerDamageMonster(int attack, int mAttack)
        {
            //How hard do you hit the monster, what happens?
            Console.WriteLine($"You hit the {mon.getName()} for {attack} damage");
            //decrease the monsters HP
            mon.subhp(attack);

            //Check to see if that killed the monster
            if (mon.getmonHp() <= 0)
            {
                Console.WriteLine($"You kill the {mon.getName()}!");
                keyPress();

                reward();
            }
            //If not then the monster swings back
            else
                monsterDamagePlayer(mAttack);
        }


        private static void monsterDamagePlayer(int mAttack)
        {
            //def is your defence value. If you roll under it, monster misses
            int def = rand.Next(1, 100);
            {
                if (def <= player.getDef())
                    Console.WriteLine($"The {mon.getmonName()} misses you!");
                else
                {   //Otherwise he hits you
                    Console.WriteLine($"{mon.getName()} hits you for {mAttack} damage");
                    player.subHP(mAttack);
                    if (player.getHP() <= 0)
                    {
                        Console.WriteLine($"The {mon.getName()} kills you!");
                        keyPress();

                        if (day >= 30)
                            gameOver();
                        else
                            death();
                    }
                }
                keyPress();
                fight();
            }
        }
               
        

        public static void reward()
        {
            Console.Clear();
            int g = rand.Next(-10, 40);
            int e = rand.Next(-3, 5);
            if (player.getLevel() == 20)
                win();
            else
            {
                Console.WriteLine($"You gain {mon.getmonXp() * player.getLevel() + e} experience");
                Console.WriteLine($"You gain {mon.getmonGold() * player.getLevel() + g} gold");
                player.addGold(mon.getmonGold() * player.getLevel() + g);
                player.addXP(mon.getmonXp() * player.getLevel() + e);
                keyPress();
                dungeonMenu();
            }
        }
    }
}