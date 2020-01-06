using System;
using System.Collections.Generic;
using System.Linq;

namespace CPlayground
{
	class Program
	{
		   		 	
		
		static void Main(string[] args)
		{

			Console.WriteLine("1: Rock Paper Scissors");
			Console.WriteLine("2. LINQ");


			var input = Console.ReadLine();
			switch (input)
			{
				case "1":
					var rps = new Program();
					rps.RockPaperScissors();
					break;
				case "2":
					var linq = new Program();
					linq.linqStuff();
					break;
				default:
					Console.WriteLine("Invalid Input. Goodbye");
					break;
			}

			Console.ReadKey(); //Waits for you to hit a key before closing program or reads a key
		}


		public int draws = 0;
		public int wins = 0;
		public int losses = 0;

		/**
		 * Writing a small program. Simple Rock Paper Scissors Game.
		 **/
		public void RockPaperScissors()
		{

			bool keepPlaying = true;
			while (keepPlaying)
			{

				Console.WriteLine("Choose from the below options:");
				Console.WriteLine("Rock");
				Console.WriteLine("Paper");
				Console.WriteLine("Scissors");
				Console.WriteLine("***");
				Console.WriteLine("Type your selection below!");
				string userInput = Console.ReadLine();

				int rnd = new Random().Next(1, 4);
				//1 = rock
				//2 = paper
				//3 = scissors

				if (userInput.Equals("rock", StringComparison.OrdinalIgnoreCase))
				{
					switch (rnd)
					{
						case 1:
							Console.WriteLine("Rock vs Rock. DRAW");
							draws++;
							break;
						case 2:
							Console.WriteLine("Paper beats Rock. LOSS");
							losses++;
							break;
						case 3:
							Console.WriteLine("Rock beats Scissors. WIN");
							wins++;
							break;
						default:
							Console.WriteLine("Misc.");
							break;
					}
				}
				else if (userInput.Equals("paper", StringComparison.OrdinalIgnoreCase))
				{
					switch (rnd)
					{
						case 1:
							Console.WriteLine("Paper beats Rock. WIN");
							wins++;
							break;
						case 2:
							Console.WriteLine("Paper vs. Paper. DRAW");
							draws++;
							break;
						case 3:
							Console.WriteLine("Scissors beat Paper. LOSS");
							losses++;
							break;
						default:
							Console.WriteLine("Misc.");
							break;
					}

				}
				else if (userInput.Equals("scissors", StringComparison.OrdinalIgnoreCase))
				{
					switch (rnd)
					{
						case 1:
							Console.WriteLine("Rock beats Scissors. LOSS");
							losses++;
							break;
						case 2:
							Console.WriteLine("Scissors beats Paper. WIN");
							losses++;
							break;
						case 3:
							Console.WriteLine("Scissors vs. Scissors. DRAW");
							wins++;
							break;
						default:
							Console.WriteLine("Misc.");
							break;
					}

				}
				else
				{
					Console.WriteLine("Selection not valid, check your spelling maybe?");
				}


				Console.WriteLine("Play again? y/n");
				string playAgain = Console.ReadLine();

				switch (playAgain)
				{
					case "y":
						Console.WriteLine("Playing again!");
						break;
					case "n":
						Console.WriteLine("Game Over");
						Console.WriteLine("Wins: " + wins);
						Console.WriteLine("Losses: " + losses);
						Console.WriteLine("Draws: " + draws);
						keepPlaying = false;
						break;
					default:
						Console.WriteLine("Unrecognised Input, Playing Again!");
						Console.WriteLine("Wins: " + wins);
						Console.WriteLine("Losses: " + losses);
						Console.WriteLine("Draws: " + draws);
						break;
				}

			}


		}

		/**
		 * Experimenting with:
		 * LINQ Queries
		 **/

		public void linqStuff()
		{
			IList<Purchase> PurchaseList = new List<Purchase>();
			PurchaseList.Add(new Purchase("tomato", 1.10));
			PurchaseList.Add(new Purchase("banana", 0.70));
			PurchaseList.Add(new Purchase("bread", 4.20));
			PurchaseList.Add(new Purchase("spinach", 1.10));
			PurchaseList.Add(new Purchase("brie cheese", 3.75));
			PurchaseList.Add(new Purchase("blue cheese", 5.75));
			PurchaseList.Add(new Purchase("chickpeas", 0.99));
			PurchaseList.Add(new Purchase("tofu", 3.60));
			PurchaseList.Add(new Purchase("sriacha sauce", 7.16));


			Console.WriteLine();
			Console.WriteLine();

			var cheap = from it in PurchaseList
						where it.Price < 1.00
						select it;

			Console.WriteLine("**Cheap < $1**");

			foreach (var purch in cheap)
			{
				Console.WriteLine(purch.ItemName +" "+ purch.Price);
			}

			Console.WriteLine();
			Console.WriteLine();


			var expensive = from it in PurchaseList
							where it.Price > 4
							select it;

			Console.WriteLine("**Expensive** > $4");
			foreach (var purch in expensive)
			{
				Console.WriteLine(purch.ItemName + " " + purch.Price);
			}

			Console.WriteLine();
			Console.WriteLine();

			var betweenTwo = from it in PurchaseList
							where it.Price < 4 &&  it.Price > 1
							select it;

			Console.WriteLine("**Between $1 and $4**");
			foreach (var purch in betweenTwo.OrderBy(it => it.Price))
			{
				Console.WriteLine(purch.ItemName + " " + purch.Price);
			}

			Console.WriteLine();
			Console.WriteLine();


			var cheese = from it in PurchaseList
						 where it.ItemName.Contains("cheese")
						 select it;
			
			Console.WriteLine("**Cheese**");
			foreach (var purch in cheese)
			{
				Console.WriteLine(purch.ItemName + " " + purch.Price);
			}

			Console.WriteLine();
			Console.WriteLine();

			var alphabetical = PurchaseList.OrderBy(it => it.ItemName);
			Console.WriteLine("**Alphabetical**");
			foreach (var purch in alphabetical)
			{
				Console.WriteLine(purch.ItemName);
			}

		}
	}


	/**
	 * Experimenting with:
	 * Objects
	 * LINQ
	 **/
	public class Purchase
	{
		public string ItemName { get; set; }
		 public double Price { get; set; }

		public Purchase(string itemName, double price)
		{
			this.ItemName = itemName;
			this.Price = price;	
		}

	}


	/**
	 * Experimenting with:
	 * Interfaces
	 **/
	public interface INothing { }

	/**
	 * Experimenting with:
	 * Inheritance
	 * Overriding
	 **/
	public class MySuperClass
	{
		public virtual int GetZero() { return 0; } // MUST WRITE 'VIRTUAL' TO PROVIDE METHODS VIA INHERITANCE OR YOULL HAVE TWO METHODS W/ SAME NAME
	}

	/**
	 * Experimenting with:
	 * Getters and Setters
	 * Overriding
	 * * Inheritance
	 **/
	public class MyClass : MySuperClass, INothing
	{

		
		public override int GetZero() { return 1; }

		/**
		 * GETTERS AND SETTERS SHOULD NOT GENERALLY EXIST IN THE JAVA WAY. THIS IS THE DEFAULT WAY DATA SHOULD BE MADE AVAILABLE.
		 **/
		public int Age { get; set; }
		public string Name
		{ get
			{
				return "no name";
			}
			private set
			{
				
			}

		}

		public MyClass(string name)
		{
			
		}



	}
}
