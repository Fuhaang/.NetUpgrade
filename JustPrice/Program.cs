using System;
using System.Collections.Generic;
using System.Linq;

namespace JustPrice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            #region variables
            //int goodPrice = 0;
            int userPrice;
            string userEnter;
            //var rand = new Random();
            bool bRes;

            // loop for switch
            var loop = true;

            string menuChoice;

            //Prix minimum / maximum
            //int min;
            //int max;

            //Compteur d'essais
            int cpt = 0;
            int cptMax = 0;

            //Item
            string name;
            string description;
            int price;
            int minPrice;
            int maxPrice;

            //Create a list of items
            List<Items> item = new List<Items>();

            //Init data
            Tools tools = new Tools();

            //Take random one item in the list of items
            int randomItem;
            Random rdm = new Random();


            //level difficulties
            int noob;
            int easy;
            int normal;
            int hard;
            #endregion

            #region menu
            loop = true;

            while (loop)
            {
                loop = false;
                Console.Clear();
                Console.WriteLine("1. PLAY GAME");
                Console.WriteLine("2. ADD ITEM");
                Console.WriteLine("");
                Console.Write("Please enter your selection: ");
                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                    case "PLAY GAME":
                        Console.Clear();
                        Console.WriteLine("You start the game, good luck !");
                        break;
                    case "2":
                    case "ADD ITEM":
                        Console.Clear();

                        Console.WriteLine("You want add item, please put good information for save.");
                        Console.WriteLine("");

                        Console.Write("Name : ");
                        name = Console.ReadLine();

                        Console.Write("Description : ");
                        description = Console.ReadLine();

                        Console.Write("Price : ");
                        bRes = Int32.TryParse(Console.ReadLine(), out price);
                        while (!bRes)
                        {
                            Console.WriteLine("Please, you could choose one int for price, retry");
                            Console.Write("Price : ");
                            bRes = Int32.TryParse(Console.ReadLine(), out minPrice);
                        }

                        Console.Write("Minimum Price for this game : ");
                        bRes = Int32.TryParse(Console.ReadLine(), out minPrice);
                        while (!bRes || price < minPrice)
                        {
                            if (!bRes)
                            {
                                Console.WriteLine("Please, you could choose one int for min, retry");
                            }
                            else
                            {
                                Console.WriteLine("Please, you can't use minimum price > price, retry");
                            }
                            Console.Write("Minimum Price for this game : ");
                            bRes = Int32.TryParse(Console.ReadLine(), out minPrice);
                        }

                        Console.Write("Maximum Price for the game : ");
                        bRes = Int32.TryParse(Console.ReadLine(), out maxPrice);
                        while (!bRes || maxPrice <= minPrice)
                        {
                            if (!bRes)
                            {
                                Console.WriteLine("Please, you could choose one int for max, retry");
                                Console.Write("Maximum Price for the game : ");
                                bRes = Int32.TryParse(Console.ReadLine(), out maxPrice);
                            }
                            else if (maxPrice <= minPrice)
                            {
                                Console.WriteLine($"Please, you can't choose max <= {minPrice} (your min), retry");
                                bRes = Int32.TryParse(Console.ReadLine(), out maxPrice);
                            }
                        }


                        // TODO : Init item list with old items
                        item.AddRange( tools.GetDataList());

                        //Add item to the list
                        item.Add(new Items() { Name = name, Description = description, Price = price, MinPrice = minPrice, MaxPrice = maxPrice });


                        tools.InitData(item);
                        Console.WriteLine("Your new item is save, GG! (Press Enter to continue)");
                        Console.ReadLine();
                        loop = true;
                        break;
                }

            }

            #endregion

            #region DATA


            // Add items to the list
            //item.Add(new Items() { Description = "Description 1", Price = 1, Name = "Name 1", MinPrice = 1, MaxPrice = 101 });
            //item.Add(new Items() { Description = "Description 2", Price = 2, Name = "Name 2", MinPrice = 2, MaxPrice = 102 });

            //var item = new Items { Description = "test of description", Price = 12, Name = "Name", MinPrice = 0, MaxPrice = 100};

            // TODO : Init item list with old items
            item.AddRange(tools.GetDataList());

            tools.InitData(item);
            //tools.InitData(new Items { Name = "", Price = 0, Description = "" });

            //Get data
            var item2 = tools.GetDataList();
            randomItem = rdm.Next(0, item2.Count);

            name = item2[randomItem].Name;
            description = item2[randomItem].Description;
            price = item2[randomItem].Price;
            minPrice = item2[randomItem].MinPrice;
            maxPrice = item2[randomItem].MaxPrice;
            #endregion

            #region difficulties
            noob = 50;
            easy = 25;
            normal = 10;
            hard = 5;


            string choiceDifficult = "";

            loop = true;

            while (loop)
            {
                loop = false;

                Console.WriteLine("Choose difficulties : 1= noob | 2= easy | 3= normal | 4= hard");
                Console.Write("Please enter your selection: ");
                choiceDifficult = Console.ReadLine();

                switch (choiceDifficult)
                {
                    case "1":
                    case "noob":
                        Console.WriteLine("level : noob");
                        cptMax = noob;
                        break;
                    case "2":
                    case "easy":
                        Console.WriteLine("level : easy");
                        cptMax = easy;
                        break;
                    case "3":
                    case "normal":
                        Console.WriteLine("level : normal");
                        cptMax = normal;
                        break;
                    case "4":
                    case "hard":
                        Console.WriteLine("level : hard");
                        cptMax = hard;
                        break;
                    default:
                        Console.WriteLine("Please try again with correct number");
                        loop = true;
                        break;
                }
            }

            #endregion

            #region jeu
            Console.Clear();

            Console.WriteLine("Hello Mr/Ms ! You have choose level " + choiceDifficult);
            Console.WriteLine("You are maximum " + cptMax + " test for win");
            Console.WriteLine("");
            Console.WriteLine("The item is : " + name);
            Console.WriteLine("Description item : " + description);
            Console.WriteLine("Find good price between " + minPrice + " and " + maxPrice);

            cpt++;
            Console.Write("test number " + cpt + " --> ");
            userEnter = Console.ReadLine();
            //cpt++;
            bRes = Int32.TryParse(userEnter, out userPrice);

            
            while (userPrice != price && cpt < cptMax)
            {
                if (!bRes)
                {
                    Console.WriteLine("Please, enter int, not string");
                }
                else if (userPrice < price)
                {
                    cpt++;
                    Console.WriteLine("it's more");
                }
                else if (userPrice > price)
                {
                    cpt++;
                    Console.WriteLine("it's less");
                }
                Console.Write("test number " + cpt + " --> ");
                userEnter = Console.ReadLine();
                bRes = Int32.TryParse(userEnter, out userPrice);
            }
            //Console.WriteLine($"{userPrice} is a good price, GG!");
            //Console.WriteLine($"{1} is a good price, GG!", userPrice);

            if(userPrice != price)
            {
                Console.WriteLine("Game over, you are test " + cptMax + " twice and not with true result.");
            }
            else
            {
                Console.WriteLine(userPrice + " is a good price! You tried " + cpt + " times");
            }
            #endregion
        }
    }
}
