using System;
using System.Collections.Generic;
using System.Drawing;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        const string MenuTitle = "\n===== MAIN MENU - CODEQUEST =====";
        const string Welcome = "===== Welcome, {0} the {1} with level {2} ====="; //name, title, level
        const string MenuOption1 = "1. Train your wizard";
        const string MenuOption2 = "2. Increase LVL";
        const string MenuOption3 = "3. Loot the mine";
        const string MenuOption4 = "4. Show inventory";
        const string MenuOption5 = "5. Buy items";
        const string MenuOption6 = "6. Show attacks by LVL";
        const string MenuOption7 = "7. Decode ancient scroll";
        const string MenuOptionExit = "0. Exit game";
        const string MenuPrompt = "Choose an option (1-7) - (0) to exit: ";
        const string InputErrorMessage = "Invalid input. Please enter a valid number.";
        const string ExitMsg = "Program exited successfully";
        const int MinMenuOpt = 0;
        const int MaxMenuOpt = 7;
        string name = "?";
        string title = "?";
        int power = 0;
        int level = 1;
        const int maxLevel = 5;
        const string InputNameMsg = "What is your name?";
        const string RankOne = "You repeat 2nd call";
        const string RankTwo = "You still mistake the wand for a spoon";
        const string RankThree = "You are a Magic Breeze Summoner.";
        const string RankFour = "Wow! You can summon dragons without burning the lab down!";
        const string RankFive = "You accomplished Arcane Master rank!";
        const int MinHours = 1;
        const int MaxHours = 25;
        const int MinPower = 1;
        const int MaxPower = 11;
        bool validInput = true;
        string[] possibleTitles = ["Raoden el Elantrí", "Zyn el Buguejat", "Arka Nullpointer", "Elarion de les Brases", "ITB-Wizard el Gris"];
        string StartOfDayMsg = "Day {0}: {1}, you have already medited {2} hours and your power is now {3} points!";
        string TitleMsg = "Your title is {0}";
        Random meditationHours = new Random();
        Random powerLevelGain = new Random();
        Random rollTheDice = new Random();
        Random monsterAppeared = new Random();
        Random isThereACoin = new Random();
        Random bitsGained = new Random();
        string[] monsters = { 
            "Wandering Skeleton 💀", 
            "Forest Goblin 👹",
            "Green Slime 🟢", 
            "Ember Wolf 🐺", 
            "Giant Spider 🕷️",
            "Iron Golem 🤖", 
            "Lost Necromancer 🧝‍♂️", 
            "Ancient Dragon 🐉"
        };
        int[] monsterHp =
        {
            3,
            5,
            10,
            11,
            18,
            15,
            20,
            50
        };
        string[] dices = {
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n |       | |\r\n |   o   | /\r\n |       |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n |     o | |\r\n |       | /\r\n | o     |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n |     o | |\r\n |   o   | /\r\n | o     |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n |       | /\r\n | o   o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n |   o   | /\r\n | o   o |/ \r\n '-------'\r\n",
            "   ________\r\n  /       /|   \r\n /_______/ |\r\n | o   o | |\r\n | o   o | /\r\n | o   o |/ \r\n '-------'\r\n"
        };
        const string EnterTheDungeon = "You arrive at the dungeon.";
        const string MonsterDefeated = "You defeated {0}!";
        const string Encounter = "A wild {0} appears!";
        const string LevelUp = "Level up! You're level {0} now!";
        const string MaxLevelReached = "You are already max level";
        const string XCoordInput = "Enter the X coordinate (0-4)";
        const string YCoordInput = "Enter the Y coordinate (0-4)";
        string[,] hiddenCoins = new string[5, 5];
        string[,] userMine = new string[5, 5];
        const string EnterTheMine = "You arrive at the bitcoin mine.\n";
        const string CurrentBitAmountMsg = "You have {0} bits";
        const string FoundMsg = "You found {0} bits!";
        const int MaxAttempts = 5;
        const int BrickChance = 30;
        int bits = 0;
        string inventory = "You have no items in your inventory!\n";
        string[][] attacksPerLevel = {
            new string[] { "Magic Spark 💫" },
            new string[] { "Fireball 🔥", "Ice Ray 🥏", "Arcane Shield ⚕️" },
            new string[] { "Meteor ☄️", "Pure Energy Explosion 💥", "Minor Charm 🎭", "Air Strike 🍃" },
            new string[] { "Wave of Light ⚜️", "Storm of Wings 🐦" },
            new string[] { "Cataclysm 🌋", "Portal of Chaos 🌀", "Arcane Blood Pact 🩸", "Elemental Storm ⛈️" }
        };
        

        


        int chosenOption = 0;


        do
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(Welcome, name, title, level);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.WriteLine(MenuOption4);
            Console.WriteLine(MenuOption5);
            Console.WriteLine(MenuOption6);
            Console.WriteLine(MenuOption7);
            Console.WriteLine(MenuOptionExit);
            Console.Write(MenuPrompt);

            do
            {

                try
                {
                    chosenOption = int.Parse(Console.ReadLine());
                    if(chosenOption < MinMenuOpt || chosenOption > MaxMenuOpt)
                    {
                        validInput = false;
                        Console.WriteLine(InputErrorMessage);
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(InputErrorMessage);
                    validInput = false;
                }
            } while (!validInput);
            
            switch (chosenOption)
            {
                case 1:
                    //Preguntar al Dani si el poder y/o horas se acumulan entre intentos
                    int currentDay = 1;
                    int trainingHours = 0;
                    string unformattedName = "";
                    name = "";
                    do
                    {
                        Console.WriteLine(InputNameMsg);
                        try
                        {
                            unformattedName = Console.ReadLine();
                            if(unformattedName == "")
                            {
                                validInput = false;
                            }
                            else
                            {
                                validInput = true;
                            }
                        }
                        catch (NullReferenceException)
                        {
                            validInput = false;
                        }
                    } while (!validInput);
                    foreach(string subs in unformattedName.Split(" "))
                    {
                        if(subs != "")
                        {
                            name += char.ToUpper(subs[0]) + subs.Substring(1).ToLower() + " ";
                        }
                    }
                    name = name.Remove(name.Length-1);
                    for (currentDay = 1; currentDay <= 5; currentDay++)
                    {
                        trainingHours += meditationHours.Next(MinHours, MaxHours);
                        power += powerLevelGain.Next(MinPower, MaxPower);
                        Console.WriteLine(StartOfDayMsg, currentDay, name, trainingHours, power);

                        switch (power)
                        {
                            case < 20:
                                Console.WriteLine(RankOne);
                                title = possibleTitles[0];
                                Console.WriteLine(TitleMsg, title);
                                break;
                            case < 30:
                                Console.WriteLine(RankTwo);
                                title = possibleTitles[1];
                                Console.WriteLine(TitleMsg, title);
                                break;
                            case < 35:
                                Console.WriteLine(RankThree);
                                title = possibleTitles[2];
                                Console.WriteLine(TitleMsg, title);
                                break;
                            case < 40:
                                Console.WriteLine(RankFour);
                                title = possibleTitles[3];
                                Console.WriteLine(TitleMsg, title);
                                break;
                            case >= 40:
                                Console.WriteLine(RankFive);
                                title = possibleTitles[4];
                                Console.WriteLine(TitleMsg, title);
                                break;
                        }
                    }
                    break;
                case 2:
                    int monster = 0;
                    string monsterName = "";
                    int currentHp = 0;
                    int damage = 0;
                    Console.WriteLine(EnterTheDungeon);
                    monster = monsterAppeared.Next(0, monsters.Length);
                    currentHp = monsterHp[monster];
                    monsterName = monsters[monster];
                    Console.WriteLine(Encounter, monsterName);
                    while(currentHp > 0)
                    {
                        Console.WriteLine(monsterName + "\t" + currentHp);
                        Console.WriteLine("Roll!");
                        Console.ReadKey();
                        damage = rollTheDice.Next(0, 6);
                        Console.WriteLine(dices[damage]);
                        currentHp -= (damage + 1);
                    }
                    Console.WriteLine(MonsterDefeated, monsterName);
                    if(level<maxLevel)
                    {
                        level++;
                        Console.WriteLine(LevelUp, level);
                    }
                    else
                    {
                        Console.WriteLine(MaxLevelReached);
                    }
                    break;
                case 3:
                    int x = 0;
                    int y = 0;
                    int coinChance = 0;
                    int bitGain = 0;
                    for (int i = 0; i < hiddenCoins.GetLength(0); i++)
                    {
                        for (int j = 0; j < hiddenCoins.GetLength(1); j++)
                        {
                            coinChance=isThereACoin.Next(1, 101);
                            if (coinChance > BrickChance)
                            {
                                hiddenCoins[i, j] = "🪙";
                            }
                            else
                            {
                                hiddenCoins[i, j] = "❌";
                            }
                            
                        }
                    }
                    Console.WriteLine(EnterTheMine);
                    for (int i = 0; i < userMine.GetLength(0); i++)
                    {
                        for (int j = 0; j < userMine.GetLength(1); j++)
                        {
                            userMine[i, j] = "➖";
                            Console.Write(userMine[i, j]);
                        }
                        Console.WriteLine();
                    }
                    for (int i = 0; i < MaxAttempts; i++)
                    {
                        Console.WriteLine(XCoordInput);
                        do
                        {

                            try
                            {
                                x = int.Parse(Console.ReadLine());
                                if (x < 0 || x > userMine.GetLength(0) - 1)
                                {
                                    validInput = false;
                                    Console.WriteLine(InputErrorMessage);
                                }
                                else
                                {
                                    validInput = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(InputErrorMessage);
                                validInput = false;
                            }
                        } while (!validInput);
                        Console.WriteLine(YCoordInput);
                        do
                        {

                            try
                            {
                                y = int.Parse(Console.ReadLine());
                                if (y < 0 || y > userMine.GetLength(1) - 1)
                                {
                                    validInput = false;
                                    Console.WriteLine(InputErrorMessage);
                                }
                                else
                                {
                                    validInput = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(InputErrorMessage);
                                validInput = false;
                            }
                        } while (!validInput);
                        if (userMine[x, y]== "🪙")
                        {
                            userMine[x, y]= "❌";
                        }
                        else if (hiddenCoins[x, y] == "🪙")
                        {
                            userMine[x, y] = hiddenCoins[x, y];
                            bitGain = bitsGained.Next(5, 51);
                            bits += bitGain;
                            Console.WriteLine(FoundMsg, bitGain);
                        }
                        else
                        {
                            userMine[x, y] = hiddenCoins[x, y];
                        }
                            
                        for (int j = 0; j < userMine.GetLength(0); j++)
                        {
                            for (int k = 0; k < userMine.GetLength(1); k++)
                            {
                                Console.Write(userMine[j, k]);
                            }
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine(CurrentBitAmountMsg, bits);
                    break;
                case 4:
                    const string InventoryMsg = "Inventory:";
                    Console.WriteLine(InventoryMsg);
                    Console.Write(inventory);
                    break;
                case 5:
                    const string ShopMenu = "===AVAILABLE SHOP ITEMS===\nItem\t\t\t\tCost(bits)";
                    const string ShopMsg = "Potion? Shield? Bows? You want it? It's yours my friend, as long as you have enough bits.\n";
                    const string Morshu = "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣤⣴⣶⣾⣿⣿⡿⠿⣿⣿⣿⣿⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⡻⠋⠉⠰⣡⣤⣶⣶⣆⠈⠙⢻⡋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢴⡾⡾⠂⢡⢨⢏⣁⡀⠀⠈⠈⠀⠀⢦⣿⣷⡄⠀⢀⠔⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢏⠢⣀⢵⢉⢦⣛⢯⡖⣿⣷⠄⢠⡆⠤⢿⣿⣿⡿⠊⣱⢪⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠣⣰⡗⠋⠉⢡⡞⡭⣭⣃⡀⠀⠉⠓⠀⠉⠛⢂⣼⢃⡞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣪⣶⣷⠦⠤⢶⣿⣷⣆⣇⢀⣤⢴⠂⢶⠀⣆⡇⢉⠟⢶⣤⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⡀⢀⣤⢶⣾⡟⢛⠻⠋⠉⠉⠉⠿⠿⠛⠋⠁⢀⡀⢨⡞⠀⠀⠈⢡⢆⢻⣽⡾⢿⡶⣤⡀⠀⠀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⢠⠎⡁⠀⠉⠉⣻⣾⡟⠀⠈⢧⣀⠀⠀⠀⠀⠀⣀⠄⠀⢐⡏⠀⠀⢀⢀⣀⣠⣿⣿⢭⣟⣳⡽⣫⣟⣷⣀⠀⠀⠀\r\n⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⢻⣟⣿⣶⠿⣽⡇⠀⠀⠸⡙⠂⠄⠀⠚⠋⠁⠀⠴⡝⠅⢠⣲⠊⠉⠉⠈⠈⠉⠛⢳⢿⣞⡵⣏⡾⡽⣦⠀⠀\r\n⠀⠀⠀⠀⠀⠀⢀⣾⣻⣼⣛⣾⡟⡾⣯⠷⠻⣄⠀⠀⠛⠬⠦⢀⡀⡤⠂⠀⠀⠀⠐⢰⢡⣤⡷⣶⠶⣶⣦⣄⡀⠈⠘⢛⣿⡼⣽⢻⣇⠀\r\n⠀⠀⠀⠀⠀⢰⣟⣧⡷⣷⣟⡯⣾⡿⠁⢀⢤⣿⡗⠢⡞⠲⠤⠦⠤⠀⠀⠀⢀⢀⣰⡾⣟⣧⢟⣧⡟⡷⢾⣹⢿⣦⡄⠀⠈⣿⣗⡯⢿⠀\r\n⠀⠀⠀⣠⣾⢿⣻⢾⣽⣻⣮⣷⠏⠀⠠⣲⣟⣧⢿⣦⣄⣀⠀⠀⢀⣀⣀⣦⣶⡿⣯⢷⡻⣼⣻⡼⣽⣛⣯⡽⣞⣳⢯⠀⠀⠀⣿⣽⢫⠄\r\n⠀⠀⢰⡟⠛⢉⡙⢯⠁⠈⠻⢅⡀⢠⣽⣟⣞⠾⣝⣾⡹⣿⣝⣿⣽⣻⡟⣷⢯⣿⣭⢷⡻⣵⣳⣻⡼⣳⢧⣟⡽⣞⣻⠁⠀⠀⣼⣞⢯⠀\r\n⠀⠀⣾⡻⣢⣤⠙⡞⠉⠀⠀⠀⠉⠚⠿⢾⢾⡿⣿⣾⢿⡽⣛⡾⣼⢧⠿⣭⡟⣾⢼⡳⣟⣵⡳⣗⣻⣭⢷⢾⣹⡾⠃⠀⠀⣾⠿⣭⡿⠀\r\n⠀⢀⡟⢫⠥⠔⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡷⣽⡻⣞⡽⡽⣞⡽⣛⣧⢿⣹⠾⣽⣝⣾⣹⡽⣳⣾⣟⡋⠁⢠⣄⣤⡿⢯⡟⣿⠃⠀\r\n⢀⠜⠊⢁⣠⠞⠢⣄⣀⣀⣀⣀⠀⠀⠀⠀⠀⣸⡿⣵⣻⡭⣟⣳⢯⣽⢻⡼⢯⣝⣿⢷⡿⣞⠿⣽⣛⣮⢽⣛⢿⡻⡽⣭⣛⣯⣿⠁⠀⠀";
                    const string NotEnoughBits = "Sorry {0}, I can't give credit, come back when you're a little, mmmmm, richer";
                    int selectedItem = 0;
                    Random exFiveRandom = new Random();
                    string[] shopItems = { "Iron Dagger 🗡️", "Healting Potion ⚗️", "Ancient Key 🗝️", "Crossbow 🏹\t", "Metal Shield 🛡️" };
                    int[] itemCost = { 30, 10, 50, 40, 20 };
                    bool isRareItem = false;
                    Console.WriteLine(Morshu);
                    Console.WriteLine(ShopMsg);
                    Console.WriteLine(CurrentBitAmountMsg, bits);
                    Console.WriteLine(ShopMenu);
                    for (int i = 0; i < shopItems.Length; i++)
                    {
                        Console.Write(i+" - "+shopItems[i] + "\t\t" + itemCost[i]+"\t");
                        Console.WriteLine();
                    }
                    do
                    {

                        try
                        {
                            selectedItem = int.Parse(Console.ReadLine());
                            if (selectedItem < 0 || selectedItem > shopItems.Length-1)
                            {
                                validInput = false;
                                Console.WriteLine(InputErrorMessage);
                            }
                            else
                            {
                                validInput = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(InputErrorMessage);
                            validInput = false;
                        }
                    } while (!validInput);
                    if (itemCost[selectedItem] > bits)
                    {
                        Console.WriteLine(NotEnoughBits, name);
                    }
                    else
                    {
                        bits -= itemCost[selectedItem];
                        Console.WriteLine($"You have a {shopItems[selectedItem]}");
                        if(inventory.Equals("You have no items in your inventory!\n"))
                        {
                            inventory = shopItems[selectedItem] + "\n";
                        }
                        else
                        {
                            inventory += shopItems[selectedItem] + "\n";
                        }
                    }
                    break;
                case 6:
                    string playerAttacks = "";
                    foreach (string attack in attacksPerLevel[level - 1])
                    {
                        playerAttacks += attack + "\n";
                    }
                    Console.WriteLine(playerAttacks);
                    break;
                case 7:
                    const string scrollSubmenu = "1 - Empty the first scroll spaces\n2 - Count vowels of the second scroll\n3 - Extract numbers from the third scroll\n0 - Exit";
                    const int scrollMaxChoices = 3;
                    const string decypheredMsg = "You successfully decyphered all the scrolls!";
                    int userScrollChoice = 0;
                    bool firstCheck = false;
                    bool secondCheck = false;
                    bool thirdCheck = false;
                    bool decyphered = false;

                    do
                    {
                        Console.WriteLine(scrollSubmenu);
                        do
                        {

                            try
                            {
                                userScrollChoice = int.Parse(Console.ReadLine());
                                if (userScrollChoice < MinMenuOpt || userScrollChoice > scrollMaxChoices)
                                {
                                    validInput = false;
                                    Console.WriteLine(InputErrorMessage);
                                }
                                else
                                {
                                    validInput = true;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(InputErrorMessage);
                                validInput = false;
                            }
                        } while (!validInput);
                        switch (userScrollChoice)
                        {
                            case 1: firstCheck = true; break;
                            case 2: secondCheck = true; break;
                            case 3: thirdCheck = true; break;
                            case 0: break;
                            default: Console.WriteLine(InputErrorMessage); break;
                        }
                        if (firstCheck && secondCheck && thirdCheck)
                        {
                            Console.WriteLine(decypheredMsg);
                            decyphered = true;
                        }
                        
                    }while(!decyphered);
                    break;
                default:
                    Console.WriteLine(ExitMsg);
                    break;

            }
            Console.ReadKey();
            Console.Clear();

        } while (chosenOption != 0);

    }


}
