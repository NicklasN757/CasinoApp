using System;

namespace CasinoDLCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerCasinoCoins = 10000; //Coins you start with. 
            string playerName;
            bool isRunning = true;
            Console.Write("What your name? -> ");
            playerName = Console.ReadLine();

            while (isRunning)
            {
                Console.WriteLine("Hello and Welcome to the Casino " + playerName + "." );
                Console.WriteLine("You have " + playerCasinoCoins + " coins right now.");
                Console.WriteLine();
                Console.WriteLine("0. Close this program.");
                Console.WriteLine("1. Team Bracket Betting.");
                Console.WriteLine("2. 1v1 Team Betting.");
                Console.WriteLine("3. Slot Machines.");
                Console.WriteLine("4. Blackjack.");
                Console.WriteLine("5. Spin The Wheel.");
                Console.WriteLine();
                Console.Write("Select the game you wanna play: ");
                string reply = Console.ReadLine();
                Console.Clear();

                if (reply == "0")
                {
                    Console.WriteLine("Du har valgt nummeret " + reply + " programmet vil nu lukke.......");
                    isRunning = false;
                }
                else if (reply == "1")
                {
                    Console.WriteLine("Du har valgt nummer " + reply + ". Du spiller nu \"Team Bracket Betting\".");
                    playerCasinoCoins = TeamBracketBetting(playerCasinoCoins);
                }
                else if (reply == "2")
                {
                    Console.WriteLine("Du har valgt nummer " + reply + ". Du spiller nu \"1v1 Team Betting\".");
                    playerCasinoCoins = teamBetting(playerCasinoCoins, playerName);
                }
                else if (reply == "3")
                {
                    Console.WriteLine("Du har valgt nummer " + reply + ". Du spiller nu \"Slot Maskine\".");
                    playerCasinoCoins = slotMachine(playerCasinoCoins);
                }
                else if (reply == "4")
                {
                    Console.WriteLine("Du har valgt nummer " + reply + ". Du spiller nu \"Blackjack\".");
                    playerCasinoCoins = BlackJack(playerCasinoCoins);
                }
                else if (reply == "5")
                {
                    Console.WriteLine("Du har valgt nummer " + reply + ". Du spiller nu \"Spin The Wheel\".");
                    SpinTheWheel(playerCasinoCoins);
                }
            }

            static int TeamBracketBetting(int coins)
            {
                int points = 0;
                int arrayCounter = 0; //Used to count arrays.
                bool peopleAreDoingSomething = true; //Used in some while loops to catch errors
                int numberOfTeams = 0;

                while (peopleAreDoingSomething == true)
                {
                    Console.WriteLine("Hello! You have chosen to bet on Team Brackets! This is a protoype, so please just write the number 8!");

                    try
                    {
                        numberOfTeams = int.Parse(Console.ReadLine());
                        peopleAreDoingSomething = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Hey! That's not a valid answer!");
                    }
                }
                
                Console.WriteLine("Do you want to read the rules? y/n");
                string yesno = Console.ReadLine();
                if (yesno.Contains("y")){
                    Console.WriteLine("Currently, there are a total of " + numberOfTeams + " teams.");
                    Console.WriteLine("Rules:");
                    Console.WriteLine("When you guess a winning team correctly, you will gain 5 points");
                    Console.WriteLine("When you guess a winning team incorrectly, you will not gain any points");
                    Console.WriteLine("If you guess 3 games correctly, you won't lose nor gain any coins");
                    Console.WriteLine("For every game correctly guessed after the first 3, you will gain your inserted amount multiplied by the number of games guessed correctly");
                    Console.WriteLine("");
                    Console.WriteLine("Example:");
                    Console.WriteLine("There are 8 teams. You guess the first 3 correctly");
                    Console.WriteLine("After these first 3 games, you guess 1 more correctly, so your inserted coins are multiplied by 2");
                    Console.WriteLine("After that game, you guess 1 more correctly, so your inserted coins are multiplied by 3");
                    Console.WriteLine("etc.");
                    Console.WriteLine("GL!");
                }

                peopleAreDoingSomething = true;
                int bettingCoins = 0;
                while (peopleAreDoingSomething == true)
                {
                    Console.WriteLine("How many coins are you betting?");
                    bettingCoins = int.Parse(Console.ReadLine());
                    if (bettingCoins > coins)
                    {
                        Console.WriteLine("YOU CAN'T DO THAT YOU POOR HUMAN");
                    } else
                    {
                        peopleAreDoingSomething = false;
                    }
                }
                
                if (bettingCoins > coins)
                {

                }
                points = bracketCalculation(numberOfTeams, coins, points, bettingCoins);

                if (points < 15)
                {
                    return (coins - bettingCoins);
                }
                else if (points == 15)
                {
                    return (coins);
                }
                else if (points == 20)
                {
                    return (coins + bettingCoins * 2);
                }
                else if (points == 25)
                {
                    return (coins + bettingCoins * 3);
                }
                else if (points == 30)
                {
                    return (coins + bettingCoins * 4);
                }
                else if (points == 35)
                {
                    return (coins + bettingCoins * 5);
                }
                else if (points == 40)
                {
                    return (coins + bettingCoins * 6);
                }
                else
                {
                    return (coins);
                }
            }

            static int bracketCalculation(int numberOfTeams, int coins, int points, int bettingCoins)
            {
                int arrayCounter = 0;

                Console.WriteLine("Now! Please tell me the names of the teams in order of which they fight in!");

                string[] teamNames = new string[numberOfTeams]; //creating an array that is as long as the amount of teams
                while (arrayCounter < numberOfTeams)
                {
                    teamNames[arrayCounter] = Console.ReadLine();
                    arrayCounter++;
                    Console.WriteLine("----------------------");
                }
                arrayCounter = 0;

                string[] bets = new string[numberOfTeams / 2];
                bool doingSomething = false;
                int doingSomethingInt = 0;
                int arrayCounter2 = 0;
                while (doingSomethingInt < numberOfTeams)
                {
                    string[] teamNumbers = new string[numberOfTeams];

                    teamNumbers[arrayCounter] = teamNames[arrayCounter];
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(teamNames[arrayCounter]);
                    arrayCounter++;
                    teamNumbers[arrayCounter] = teamNames[arrayCounter];
                    Console.WriteLine(teamNames[arrayCounter]);
                    arrayCounter++;
                    doingSomethingInt += 2;

                    doingSomething = true;
                    while (doingSomething == true)
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Who are you betting on winning this match?");
                        string bet = Console.ReadLine();
                        Console.WriteLine("------------------------------------------");

                        if (bet.ToUpper().Contains(teamNumbers[arrayCounter - 2]) || bet.ToUpper().Contains(teamNumbers[arrayCounter - 1]) || bet.ToLower().Contains(teamNumbers[arrayCounter - 2]) || bet.ToLower().Contains(teamNumbers[arrayCounter - 1]))
                        {
                            bets[arrayCounter2] = bet;
                            doingSomething = false;
                        }
                        else
                        {
                            Console.WriteLine("That's none of 'em!");
                        }
                    }
                    arrayCounter2++;
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;
                Console.WriteLine(string.Join(", ", bets) + " are your bets!");
                Console.WriteLine("-----------------------------------------");

                string[] round2Bets = new string[numberOfTeams / 2 / 2];
                while (doingSomethingInt < numberOfTeams / 2)
                {
                    Console.WriteLine(bets[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine(bets[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Who are you betting on winning this match?");
                    string round2bet = Console.ReadLine();
                    Console.WriteLine("------------------------------------------");

                    if (round2bet.ToUpper().Contains(bets[arrayCounter - 2]) || round2bet.ToUpper().Contains(bets[arrayCounter - 1]) || round2bet.ToLower().Contains(bets[arrayCounter - 2]) || round2bet.ToLower().Contains(bets[arrayCounter - 1]))
                    {
                        round2Bets[arrayCounter2] = round2bet;
                        doingSomethingInt += 2;
                    }
                    else
                    {
                        Console.WriteLine("That's none of 'em!");
                    }
                    arrayCounter2++;
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;
                Console.WriteLine(string.Join(", ", round2Bets) + " are your bets!");
                Console.WriteLine("-----------------------------------------");

                string[] round3Bets = new string[numberOfTeams / 2 / 2 / 2];
                while (doingSomethingInt < numberOfTeams / 2 / 2)
                {
                    Console.WriteLine(round2Bets[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine(round2Bets[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Who are you betting on winning this match?");
                    string round3bet = Console.ReadLine();
                    Console.WriteLine("------------------------------------------");

                    if (round3bet.ToUpper().Contains(round2Bets[arrayCounter - 2]) || round3bet.ToUpper().Contains(round2Bets[arrayCounter - 1]) || round3bet.ToLower().Contains(round2Bets[arrayCounter - 2]) || round3bet.ToLower().Contains(round2Bets[arrayCounter - 1]))
                    {
                        round3Bets[arrayCounter2] = round3bet;
                        doingSomethingInt += 2;
                    }
                    else
                    {
                        Console.WriteLine("That's none of 'em!");
                    }
                    arrayCounter2++;
                }

                if (round3Bets.Length == 1)
                {
                    Console.WriteLine("You're betting on " + round3Bets[0] + " winning!");
                    Console.WriteLine("-----------------------------------------");
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;
                Console.WriteLine("LET THE GAMES BEGIN");
                Console.WriteLine("-------------------");
                string[] results = new string[numberOfTeams / 2];
                while (doingSomethingInt < numberOfTeams)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(teamNames[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine(teamNames[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Who won?");
                    string result = Console.ReadLine();
                    Console.WriteLine("------------------------------------------");

                    if (result.ToUpper().Contains(teamNames[arrayCounter - 2]) || result.ToUpper().Contains(teamNames[arrayCounter - 1]) || result.ToLower().Contains(teamNames[arrayCounter - 2]) || result.ToLower().Contains(teamNames[arrayCounter - 1]))
                    {
                        if (result.ToUpper().Contains(bets[arrayCounter2]) || result.ToLower().Contains(bets[arrayCounter2]))
                        {
                            points += 5;
                            results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                        else
                        {
                            results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's none of 'em!");
                    }
                    arrayCounter2++;
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;
                Console.WriteLine(string.Join(", ", results) + " are the winners!");
                Console.WriteLine("-----------------------------------------");

                string[] round2Results = new string[results.Length / 2];
                while (doingSomethingInt < results.Length)
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine(results[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine(results[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Who won?");
                    string result = Console.ReadLine();
                    Console.WriteLine("------------------------------------------");

                    if (result.ToUpper().Contains(results[arrayCounter - 2]) || result.ToUpper().Contains(results[arrayCounter - 1]) || result.ToLower().Contains(teamNames[arrayCounter - 2]) || result.ToLower().Contains(teamNames[arrayCounter - 1]))
                    {
                        if (result.ToUpper().Contains(round2Bets[arrayCounter2]) || result.ToLower().Contains(round2Bets[arrayCounter2]))
                        {
                            points += 5;
                            round2Results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                        else
                        {
                            round2Results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's none of 'em!");
                    }
                    arrayCounter2++;
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;
                Console.WriteLine(string.Join(", ", round2Results) + " are the winners!");
                Console.WriteLine("-----------------------------------------");

                string[] round3Results = new string[round2Results.Length / 2];
                while (doingSomethingInt < round2Results.Length)
                {
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine(round2Results[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine(round2Results[arrayCounter]);
                    arrayCounter++;
                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Who won?");
                    string result = Console.ReadLine();
                    Console.WriteLine("-----------------------------------------");

                    if (result.ToUpper().Contains(round2Results[arrayCounter - 2]) || result.ToUpper().Contains(round2Results[arrayCounter - 1]) || result.ToLower().Contains(teamNames[arrayCounter - 2]) || result.ToLower().Contains(teamNames[arrayCounter - 1]))
                    {
                        if (result.ToUpper().Contains(round3Bets[arrayCounter2]) || result.ToLower().Contains(round3Bets[arrayCounter2]))
                        {
                            points += 5;
                            round3Results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                        else
                        {
                            round3Results[arrayCounter2] = result;
                            doingSomethingInt += 2;
                        }
                    }
                    else
                    {
                        Console.WriteLine("That's none of 'em!");
                    }
                    arrayCounter2++;
                }
                arrayCounter = 0;
                arrayCounter2 = 0;
                doingSomethingInt = 0;

                if (round3Results.Length == 1)
                {
                    Console.WriteLine(round3Results[0] + " WON!! YOU GOT A TOTAL OF " + points + " POINTS!");
                    Console.WriteLine("-----------------------------------------");
                }
                return (points);
            }
            static int teamBetting(int coins, string Host)
            {
                bool isRunning = true;
                while (isRunning)
                {

                    Console.WriteLine("Ready for lose all your gold or become a God of betting");
                    Console.ReadKey();
                    Console.Clear();
                    int Pool = 0;
                    //=========================================================================================================
                    Console.Write("How many people bet on Red Team: "); int numberofpeople1 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("whats your names and how much you wanna bet: ");

                    int o = 0;

                    int RedSum = 0;
                    int[] goldarray = new int[numberofpeople1];
                    string[] namearray = new string[numberofpeople1];
                    while (o < numberofpeople1)
                    {
                        namearray[o] = Console.ReadLine();

                        Console.Write(namearray[o] + ":");
                        goldarray[o] = int.Parse(Console.ReadLine());
                        if (namearray[o] == Host)
                        {
                            coins = 10000 - goldarray[o];
                        }
                        Pool += goldarray[o];
                        RedSum += goldarray[o];
                        o++;

                    }
                    Console.Clear();
                    //=========================================================================================================
                    Console.Write("How many people bet on Blue Team: "); int numberofpeople2 = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("whats your names and how much you wanna bet: ");
                    int p = 0;
                    int blueSum = 0;

                    int[] goldarray2 = new int[numberofpeople2];
                    string[] namearray2 = new string[numberofpeople2];
                    while (p < numberofpeople2)
                    {

                        namearray2[p] = Console.ReadLine();
                        Console.Write(namearray2[p] + ": ");
                        goldarray[p] = int.Parse(Console.ReadLine());
                        if (namearray2[p] == Host)
                        {
                            coins = 10000 - goldarray2[p];
                        }

                        Pool += goldarray[p];
                        blueSum += goldarray[p];
                        p++;

                    }
                    Console.Clear();
                    //===========================================================================================
                    //int RedRatio = (Pool / RedSum);
                    //int blueRatio = (Pool / blueSum);
                    Console.WriteLine("Lets see how many gold in our Pool!!      ");
                    Console.ReadLine();
                    Console.WriteLine(Pool);
                    Console.ReadLine();
                    Random randomnumber = new Random();
                    int Winlose = randomnumber.Next(0, 2);
                    //===================================================================================== Red win 红方胜
                    if (Winlose == 0)
                    {
                        Console.WriteLine("Red win!!");
                        o = 0;
                        p = 0;
                    }

                    while (o < numberofpeople1)
                    {
                        Console.WriteLine(namearray[o] + "got : " + goldarray[o] + goldarray[o] * 1.5);
                        Console.WriteLine(namearray2[p] + "got : " + goldarray2[p] * 0.5);
                        if (namearray[o] == Host)
                        {
                            coins += (int)Math.Ceiling(goldarray[o] + goldarray[o] * 1.5);

                        }
                        else if (namearray2[p] == Host)
                        {
                            coins += (int)Math.Ceiling(goldarray2[p] * 0.5);
                        }
                        o++;
                        p++;
                    }
                    Console.ReadLine();

                    //====================================================================================== Blue win

                    if (Winlose == 1)
                    {
                        Console.WriteLine("Blue win!!");
                        p = 0;
                        o = 0;
                    }
                    while (p < numberofpeople1)
                    {
                        Console.WriteLine(namearray2[p] + "got : " + goldarray2[p] + goldarray2[p] * 0.5);
                        Console.WriteLine(namearray[o] + "got : " + goldarray[o] * 0.5);
                        if (namearray[o] == Host)
                        {
                            coins += (int)Math.Ceiling(goldarray[o] * 0.5);

                        }
                        else if (namearray2[p] == Host)
                        {
                            coins += (int)Math.Ceiling(goldarray2[p] * 1.5);
                        }
                        p++;
                        o++;

                    }
                    Console.Write("Will play again? n/y ");
                    string reply = Console.ReadLine();
                    if (reply.ToLower() == "n")
                    {
                        isRunning = false;
                    }
                }
                return coins;
            }

            static int slotMachine(int coins)
            {
                Console.WriteLine("Du har lige nu " + coins + " coins.");
                bool isRunning = true;
                int basicPay = 15;
                int totalMachinesss;
                int prize;
                int risk;
                int prizeOrPrizeCheck;
                double multipler;

                static int totalPrize(int prize, int totalMachiness, int coins)
                {
                    bool isRunning = true;
                    string reply;

                    while (isRunning)
                    {
                        Console.Write("Er du sikker på at du vil spille på " + totalMachiness + " maskiner. Det vil koste dig: " + totalMachiness * prize + " coins. (y/n): ");
                        reply = Console.ReadLine();
                        int totalPrize = totalMachiness * prize;

                        if (totalPrize > coins)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Du har desvære ikke nok coins. Prøve igen!");
                            Console.WriteLine();
                            prize = -1;
                            isRunning = false;
                        }

                        else if (reply.ToLower() == "y")
                        {
                            prize *= totalMachiness;
                            isRunning = false;
                            Console.Clear();
                        }
                        else if (reply.ToLower() == "n")
                        {
                            isRunning = false;
                        }

                    }
                    return prize;
                }
                static int numberOfMachiness()
                {
                    int numberOfMachiness;
                    Console.Write("Hvor mange maskiner vil du spille på: ");
                    numberOfMachiness = int.Parse(Console.ReadLine());
                    return numberOfMachiness;
                }
                static int machineLoop(int totalCount, int prize, int risk, double multipler)
                {
                    Random RND = new Random();
                    double totalWin = 0;
                    int s = 0;

                    int i = 0;
                    while (i < totalCount)
                    {
                        i += 1;
                        Console.WriteLine();
                        int number1 = RND.Next(1, (risk + 1));
                        int number2 = RND.Next(1, (risk + 1));
                        int number3 = RND.Next(1, (risk + 1));
                        double averageNumber = (number1 + number2 + number3) / 3;

                        Console.WriteLine("<---------------------------------------------------------------------------------------->");
                        Console.WriteLine("<|-" + number1 + "-|-" + number2 + "-|-" + number3 + "-|>");
                        Console.WriteLine("<---------------------------------------------------------------------------------------->");

                        if ((averageNumber == number1) && (averageNumber == number2) && (averageNumber == number3))
                        {
                            totalWin += prize * multipler;
                            Console.WriteLine("Du vandt " + (prize * multipler) + " coins.");
                            s += 1;
                        }
                        else if (number1 == number2)
                        {
                            totalWin += prize * (multipler / 2);
                            Console.WriteLine("Du vandt " + (prize * (multipler / 2)) + " coins.");
                            s += 1;
                        }
                        else
                        {
                            Console.WriteLine("Du vandt ikke. Bedre held næste gang.");
                        }
                    }  
                    Console.WriteLine();
                    Console.WriteLine("Du vandt " + s + " gange.");
                    Console.WriteLine("Tryke \"enter\" for at gå tilbage til menuen og for at se dit relsultat.");
                    Console.ReadLine();
                    Console.Clear();
                    return Convert.ToInt32(totalWin);
                }

                while (isRunning)
                {
                    Console.WriteLine("Velkommen til vores slot maskine.");
                    Console.WriteLine();
                    Console.WriteLine("0. Tilbage til menuen.");
                    Console.WriteLine("1. Low-Risk. (" + basicPay + ". coins)");
                    Console.WriteLine("2. Medium-Risk. (" + basicPay * 5 + ". coins)");
                    Console.WriteLine("3. High-Risk. (" + basicPay * 12 + ". coins)");
                    Console.WriteLine("4. Super High-Risk. (" + basicPay * 85 + ". coins)");
                    Console.WriteLine();
                    Console.Write("Skriv hvad for en maskine du vil spille på: ");
                    string reply = Console.ReadLine();

                    if (reply == "0")
                    {
                        isRunning = false;
                        Console.Clear();
                    }
                    else if (reply == "1")
                    {
                        multipler = 3;
                        risk = 3;
                        prize = basicPay;
                        totalMachinesss = numberOfMachiness();
                        prizeOrPrizeCheck = totalPrize(prize, totalMachinesss, coins);

                        if (prizeOrPrizeCheck != -1)
                        {
                            coins -= prizeOrPrizeCheck;
                            Console.WriteLine("Du har nu " + coins + " coins tilbage. Held og lykke.");
                            System.Threading.Thread.Sleep(6000);
                            int wins = machineLoop(totalMachinesss, prize, risk, multipler);
                            Console.WriteLine("Du vandt en total på " + wins + " coins");
                            coins += wins;
                            Console.WriteLine("Du har nu " + coins + " coins.");
                        }
                    }
                    else if (reply == "2")
                    {
                        multipler = 6;
                        risk = 6;
                        prize = basicPay * 5;
                        totalMachinesss = numberOfMachiness();
                        prizeOrPrizeCheck = totalPrize(prize, totalMachinesss, coins);

                        if (prizeOrPrizeCheck != -1)
                        {
                            coins -= prizeOrPrizeCheck;
                            Console.WriteLine("Du har nu " + coins + " coins tilbage. Held og lykke.");
                            System.Threading.Thread.Sleep(6000);
                            int wins = machineLoop(totalMachinesss, prize, risk, multipler);
                            Console.WriteLine("Du vandt en total på " + wins + " coins");
                            coins += wins;
                            Console.WriteLine("Du har nu " + coins + " coins.");
                        }
                    }
                    else if (reply == "3")
                    {
                        multipler = 9;
                        risk = 9;
                        prize = basicPay * 12;
                        totalMachinesss = numberOfMachiness();
                        prizeOrPrizeCheck = totalPrize(prize, totalMachinesss, coins);

                        if (prizeOrPrizeCheck != -1)
                        {
                            coins -= prizeOrPrizeCheck;
                            Console.WriteLine("Du har nu " + coins + " coins tilbage. Held og lykke.");
                            System.Threading.Thread.Sleep(6000);
                            int wins = machineLoop(totalMachinesss, prize, risk, multipler);
                            Console.WriteLine("Du vandt en total på " + wins + " coins");
                            coins += wins;
                            Console.WriteLine("Du har nu " + coins + " coins.");
                        }
                    }
                    else if (reply == "4")
                    {
                        multipler = 32;
                        risk = 21;
                        prize = basicPay * 85;
                        totalMachinesss = numberOfMachiness();
                        prizeOrPrizeCheck = totalPrize(prize, totalMachinesss, coins);

                        if (prizeOrPrizeCheck != -1)
                        {
                            coins -= prizeOrPrizeCheck;
                            Console.WriteLine("Du har nu " + coins + " coins tilbage. Held og lykke.");
                            System.Threading.Thread.Sleep(6000);
                            int wins = machineLoop(totalMachinesss, prize, risk, multipler);
                            Console.WriteLine("Du vandt en total på " + wins + " coins");
                            coins += wins;
                            Console.WriteLine("Du har nu " + coins + " coins.");
                        }
                    }
                }
                return coins;
            }
            int BlackJack(int indsatCoins)
            {
                //Insert coin amount
                Console.Write("How many coins you want to bet on a game of BlackJack: ");
                int Bet = int.Parse(Console.ReadLine());
                if(Bet > playerCasinoCoins)
                {
                    Console.WriteLine("The inserted amount of coins is invalid you only got " + playerCasinoCoins + " available.");
                    Console.Write("Insert a valid amount of coins you want to bet on a game of BlackJack: ");
                    Bet = int.Parse(Console.ReadLine());
                }

                //Cards color
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Blue();
                Console.WriteLine("                                                    YOUR CARDS ARE BLUE");
                Red();
                Console.WriteLine("                                                   THE HOUSE CARDS ARE RED");
                Gray();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                //Generating a random card number
                string[] array = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "10", "10", "10", "11" };
                Random randomNumber = new Random();
                int husetsFørsteKort = randomNumber.Next(array.Length);
                int husetsAndetKort = randomNumber.Next(array.Length);
                Red();
                Console.WriteLine("The house got " + array[husetsFørsteKort]);
                Gray();
                int spillerensFørsteKort = randomNumber.Next(array.Length);
                int spillerensAndetKort = randomNumber.Next(array.Length);
                Blue();
                Console.WriteLine("Your cards are: " + array[spillerensFørsteKort] + " & " + array[spillerensAndetKort]);
                Gray();

                //House gets Black Jack
                if (husetsFørsteKort == 12 && husetsAndetKort == 8 || husetsFørsteKort == 12 && husetsAndetKort == 9 || husetsFørsteKort == 12 && husetsAndetKort == 10 || husetsFørsteKort == 12 && husetsAndetKort == 11 || husetsAndetKort == 12 && husetsFørsteKort == 8 || husetsAndetKort == 12 && husetsFørsteKort == 9 || husetsAndetKort == 12 && husetsFørsteKort == 10 || husetsAndetKort == 12 && husetsFørsteKort == 11)
                {
                    Console.WriteLine("House got BJ");
                    indsatCoins -= Bet;
                }

                //You get Black Jack
                if (spillerensFørsteKort == 12 && spillerensAndetKort == 8 || spillerensFørsteKort == 12 && spillerensAndetKort == 9 || spillerensFørsteKort == 12 && spillerensAndetKort == 10 || spillerensFørsteKort == 12 && spillerensAndetKort == 11 || spillerensAndetKort == 12 && spillerensFørsteKort == 8 || spillerensAndetKort == 12 && spillerensFørsteKort == 9 || spillerensAndetKort == 12 && spillerensFørsteKort == 10 || spillerensAndetKort == 12 && spillerensFørsteKort == 11)
                {
                    Console.WriteLine("You got a BJ");
                    Bet += Bet;
                    indsatCoins += Bet;
                }

                //You want to draw or stay
                Console.Write("You want another card write \"Draw\" if you don't want another card write \"Stay\": ");
                string drawOrStay = Console.ReadLine().ToLower().Trim();
                int spillerensTredjeKort = randomNumber.Next(array.Length);
                int husetKortPointsMedToKort = int.Parse(array[husetsFørsteKort]) + int.Parse(array[husetsAndetKort]);
                int husetsTredjeKort = randomNumber.Next(array.Length);
                //Spillerens samlet point
                int spillerensHåndPointsMedTreKort = int.Parse(array[spillerensFørsteKort]) + int.Parse(array[spillerensAndetKort]) + int.Parse(array[spillerensTredjeKort]);
                //Husets samlet point
                int husetsKortPointsMedTreKort = int.Parse(array[husetsFørsteKort]) + int.Parse(array[husetsAndetKort]) + int.Parse(array[husetsTredjeKort]);
                if (husetKortPointsMedToKort < 16)
                { 
                    if (drawOrStay.Contains("draw"))
                    {
                        //int spillerensTredjeKort = randomNumber.Next(array.Length);
                        Blue();
                        Console.WriteLine("You drew a " + array[spillerensTredjeKort]);
                        Console.WriteLine("Your cards are: " + array[spillerensFørsteKort] + " & " + array[spillerensAndetKort] + " & " + array[spillerensTredjeKort]);
                        Red();
                        Console.WriteLine("The house got " + array[husetsFørsteKort] + " & " + array[husetsAndetKort] + " & " + array[husetsTredjeKort]);
                        Gray();

                        //Win mechanic
                        Red();
                        Console.WriteLine("House got " + husetsKortPointsMedTreKort);
                        Gray();
                        //Winning if statement with 3 house cards
                        if(spillerensHåndPointsMedTreKort > husetsKortPointsMedTreKort && spillerensHåndPointsMedTreKort < 22)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins += Bet;
                        }
                        //Losing else if statement with 3 house cards
                        else if (husetsKortPointsMedTreKort < 22)
                        {
                            Console.WriteLine("You Lose!");
                            indsatCoins -= Bet;
                        }
                        else if (husetsKortPointsMedTreKort > 21)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins += Bet;
                        }
                        else if (spillerensHåndPointsMedTreKort > 21)
                        {
                            Console.WriteLine("You Lose!");
                            indsatCoins -= Bet;
                        }
                        else
                        {
                            Console.WriteLine("It's a draw");
                        }
                        return indsatCoins;
                    }
                    else
                    {
                        Red();
                        Console.WriteLine("The house got " + array[husetsFørsteKort] + " & " + array[husetsAndetKort]);
                        Blue();
                        Console.WriteLine("Your cards are: " + array[spillerensFørsteKort] + " & " + array[spillerensAndetKort]);
                        Gray();
                        //Win mechanic
                        //Spillerens samlet point
                        int spillerensHåndPointsMedToKort = int.Parse(array[spillerensFørsteKort]) + int.Parse(array[spillerensAndetKort]);
                        Blue();
                        Console.WriteLine("You got " + spillerensHåndPointsMedToKort);
                        //Husets samlet point
                        Red();
                        Console.WriteLine("House got " + husetKortPointsMedToKort);
                        Gray();
                        //Winning if statement with 2 house and player cards and else if with 3 house cards and 2 player cards
                        if(spillerensHåndPointsMedToKort > husetKortPointsMedToKort && spillerensHåndPointsMedToKort < 22 || spillerensHåndPointsMedToKort > husetsKortPointsMedTreKort && spillerensHåndPointsMedToKort < 22)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins += Bet;
                            Console.WriteLine("And now you've got: " + indsatCoins);
                        }
                        //Losing else if statement with 2 house and player cards and with 3 house cards and 2 player cards
                        else if (spillerensHåndPointsMedToKort < husetKortPointsMedToKort && husetKortPointsMedToKort < 22 || spillerensHåndPointsMedToKort < husetsKortPointsMedTreKort && husetsKortPointsMedTreKort < 22)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins -= Bet;
                        }
                        return indsatCoins;
                    }
                }
                else
                {
                    if (drawOrStay.Contains("draw"))
                    {
                        //int spillerensTredjeKort = randomNumber.Next(array.Length);
                        Blue();
                        Console.WriteLine("You drew a " + array[spillerensTredjeKort]);
                        Console.WriteLine("Your cards are: " + array[spillerensFørsteKort] + " & " + array[spillerensAndetKort] + " & " + array[spillerensTredjeKort]);
                        Red();
                        Console.WriteLine("The house got " + array[husetsFørsteKort] + " & " + array[husetsAndetKort]);
                        Gray();

                        //Win mechanic
                        //Husets samlet point
                        Red();
                        Console.WriteLine("House got " + husetKortPointsMedToKort);
                        Gray();
                        //Winning if statement 3 player cards 2 house cards
                        if(spillerensHåndPointsMedTreKort > husetKortPointsMedToKort && spillerensHåndPointsMedTreKort < 22)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins += Bet;
                        }
                        //Losing else if statement 3 player cards 2 house cards
                        else if(spillerensHåndPointsMedTreKort < husetKortPointsMedToKort && husetKortPointsMedToKort < 22)
                        {
                            Console.WriteLine("You Lose!");
                            indsatCoins -= Bet;
                        }
                        return indsatCoins;
                    }
                    else
                    {
                        Red();
                        Console.WriteLine("The house got " + array[husetsFørsteKort] + " & " + array[husetsAndetKort]);
                        Blue();
                        Console.WriteLine("Your cards are: " + array[spillerensFørsteKort] + " & " + array[spillerensAndetKort]);
                        Gray();
                        //Win mechanic
                        //Spillerens samlet point
                        int spillerensHåndPointsMedToKort = int.Parse(array[spillerensFørsteKort]) + int.Parse(array[spillerensAndetKort]);
                        Blue();
                        Console.WriteLine("You got " + spillerensHåndPointsMedToKort);
                        Gray();
                        //Husets samlet point
                        Red();
                        Console.WriteLine("House got " + husetKortPointsMedToKort);
                        Gray();
                        //If else statement if nothing else is true
                        if(spillerensHåndPointsMedToKort > husetKortPointsMedToKort && spillerensHåndPointsMedToKort < 22)
                        {
                            Console.WriteLine("You Win!");
                            indsatCoins += Bet;
                        }
                        else if(spillerensHåndPointsMedToKort == husetKortPointsMedToKort || husetKortPointsMedToKort == spillerensHåndPointsMedTreKort || spillerensHåndPointsMedTreKort == husetKortPointsMedToKort || spillerensHåndPointsMedTreKort == husetsKortPointsMedTreKort)
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else
                        {
                            Console.WriteLine("You Lose!");
                            indsatCoins -= Bet;
                        }
                    }
                }

                //TextColor methods
                void Gray()
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                void Red()
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                void Blue()
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                return indsatCoins;

            }
            static void SpinTheWheel(int coins)
            {
                // Felter i spillet.
                int ten = 10;
                int hundred = 100;
                int thousand = 1000;
                int tenThousand = 10000;

                int[] wheelArray = { ten, ten, ten, ten, hundred, hundred, hundred, thousand, thousand, tenThousand };
                Random randomize = new Random();

                while (coins >= 0)
                {
                    Console.WriteLine("Write your bet!");
                    int playerInput = int.Parse(Console.ReadLine());
                    int randomNumber = randomize.Next(0, wheelArray.Length);

                    Console.WriteLine(randomNumber);

                    if (playerInput == wheelArray[randomNumber])
                    {
                        if (playerInput == ten)
                        {
                            coins += 10;
                        }
                        else if (playerInput == hundred)
                        {
                            coins += 100;
                        }
                        else if (playerInput == thousand)
                        {
                            coins += 1000;
                        }
                        else if (playerInput == tenThousand)
                        {
                            coins += 10000;
                        }
                    }
                    else
                    {
                        coins -= 1000;
                    }

                }
            }
        }

    }
}
