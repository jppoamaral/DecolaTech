using System;
using WatchList;
namespace WatchList.Console
{
	class Program
	{
		static MovieRepository movieRep = new MovieRepository();
		static SeriesRepository seriesRep = new SeriesRepository();

		static void Main(string[] args)
		{
			string userCommand = getUserCommand();

			while (userCommand != "X")
			{
				switch (userCommand)
				{
					case "1":
						List();
						break;
					case "2":
						Insert();
						break;
					case "3":
						Update();
						break;
					case "4":
						Remove();
						break;
					case "5":
						Search();
						break;
					case "C":
						System.Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userCommand = getUserCommand();
			}

			System.Console.WriteLine("Thank you for using Amaral's Watchlist services.");
			System.Console.ReadLine();
		}

		private static void Remove()
		{
			System.Console.Write("Insert id to remove: ");
			int idToRemove = int.Parse(System.Console.ReadLine());
			System.Console.Write("\nAre you removing a (1)movie or (2)series: ");
			int itemType = int.Parse(System.Console.ReadLine());
			System.Console.WriteLine();
			if (itemType == 1)
			{
				var movie = movieRep.returnById(idToRemove);
				movie.Remove();
			}
			else if (itemType == 2)
			{
				var series = seriesRep.returnById(idToRemove);
				series.Remove();
			}
			System.Console.WriteLine("Successful Remove!");
		}

		private static void Search()
		{
			System.Console.Write("Searching for (1)movie or (2)series? ");
			int choice = int.Parse(System.Console.ReadLine());
			System.Console.Write("Insert id to search: ");
			int idToSearch = int.Parse(System.Console.ReadLine());
			if (choice == 1)
			{
				var movie = movieRep.returnById(idToSearch);
				System.Console.WriteLine(movie);
			}
			else if (choice == 2)
			{
				var series = seriesRep.returnById(idToSearch);
				System.Console.WriteLine(series);
			}
		}

		private static void Update()
		{
			System.Console.WriteLine("Inform the desired option");
			System.Console.WriteLine("(1) Update the status of an item");
			System.Console.WriteLine("(2) Update an item");
			int decision = int.Parse(System.Console.ReadLine());
			System.Console.WriteLine(); //pula linha
			switch (decision)
			{
				case 1:
					System.Console.Write("Insert id to set item as watched: ");
					int idToWatch = int.Parse(System.Console.ReadLine());
					System.Console.Write("\nIs it a (1)movie or a (2)series: ");
					int itemType = int.Parse(System.Console.ReadLine());
					if (itemType == 1)
					{
						var movie = movieRep.returnById(idToWatch);
						movie.Watch();
					}
					else if (itemType == 2)
					{
						var series = seriesRep.returnById(idToWatch);
						series.Watch();
					}
					break;
				case 2:
					System.Console.WriteLine("Do you want to update a movie or a series? ");
					System.Console.WriteLine("(1) Movie");
					System.Console.WriteLine("(2) Series");
					int decision1 = int.Parse(System.Console.ReadLine());
					System.Console.WriteLine(); //pula linha
					System.Console.Write("Insert Id: ");
					int newId = int.Parse(System.Console.ReadLine());

					System.Console.Write("Insert Title: ");
					string newTitle = System.Console.ReadLine();

					System.Console.WriteLine(); //pula linha
					foreach (int i in Enum.GetValues(typeof(Genre)))
					{
						System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
					}
					System.Console.WriteLine();

					System.Console.Write("Insert one of the Genres above: ");
					int newGenre = int.Parse(System.Console.ReadLine());

					System.Console.Write("Insert Release Year: ");
					int newYear = int.Parse(System.Console.ReadLine());

					System.Console.Write("Insert Description: ");
					string newDescrpt = System.Console.ReadLine();

					switch (decision1)
					{
						case 1:
							Movie updateMovie = new Movie(id: newId,
										title: newTitle,
										genre: (Genre)newGenre,
										year: newYear,
										descrpt: newDescrpt);
							movieRep.Update(newId, updateMovie);
							break;
						case 2:
							Series updateSeries = new Series(id: newId,
										title: newTitle,
										genre: (Genre)newGenre,
										year: newYear,
										descrpt: newDescrpt);
							seriesRep.Update(newId, updateSeries);
							break;
					}
					break;
			}
			System.Console.WriteLine("Successful Update!");
		}
		private static void List()
		{
			System.Console.WriteLine("Do you want to list movies or series? ");
			System.Console.WriteLine("(1) Movies");
			System.Console.WriteLine("(2) Series");
			System.Console.WriteLine("(3) List All");
			int decision = int.Parse(System.Console.ReadLine());
			System.Console.WriteLine(); //pula linha

			var lst1 = movieRep.List();
			var lst2 = seriesRep.List();
			if (lst1.Count + lst2.Count == 0)
			{
				System.Console.WriteLine("Nothing was registered.");
				return;
			}

			switch (decision)
			{
				case 1:
					System.Console.WriteLine("List movies");

					foreach (var movie in lst1)
					{
						bool watched = movie.returnWatched();
						bool removed = movie.returnRemoved();
						System.Console.WriteLine("#ID {0}: - {1} {2} {3}", movie.returnId(), movie.returnTitle(), (watched ? "*Watched*" : ""), (removed ? "*Removed*" : ""));
					}
					break;
				case 2:
					System.Console.WriteLine("List series");

					foreach (var series in lst2)
					{
						bool watched = series.returnWatched();
						bool removed = series.returnWatched();
						System.Console.WriteLine("#ID {0}: - {1} {2} {3}", series.returnId(), series.returnTitle(), (watched ? "*Watched*" : ""), (removed ? "*Removed*" : ""));
					}
					break;
				case 3:
					System.Console.WriteLine("List All");

					System.Console.WriteLine("\n---MOVIES---");
					if (lst1.Count == 0)
						System.Console.WriteLine("No movies were registered");
					foreach (var movie in lst1)
					{
						bool watched = movie.returnWatched();
						bool removed = movie.returnRemoved();
						System.Console.WriteLine("#ID {0}: - {1} {2} {3}", movie.returnId(), movie.returnTitle(), (watched ? "*Watched*" : ""), (removed ? "*Removed*" : ""));
					}
					System.Console.WriteLine("\n---SERIES---");
					if (lst2.Count == 0)
						System.Console.WriteLine("No series were registered");
					foreach (var series in lst2)
					{
						bool watched = series.returnWatched();
						bool removed = series.returnWatched();
						System.Console.WriteLine("#ID {0}: - {1} {2} {3}", series.returnId(), series.returnTitle(), (watched ? "*Watched*" : ""), (removed ? "*Removed*" : ""));
					}
					break;
			}
		}

		private static void Insert()
		{
			System.Console.WriteLine("Do you want to insert a movie or a series? ");
			System.Console.WriteLine("(1) Movie");
			System.Console.WriteLine("(2) Series");
			int decision = int.Parse(System.Console.ReadLine());
			System.Console.WriteLine(); //pula linha

			System.Console.Write("Insert Title: ");
			string newTitle = System.Console.ReadLine();

			System.Console.WriteLine(); //pula linha
			foreach (int i in Enum.GetValues(typeof(Genre)))
			{
				System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genre), i));
			}
			System.Console.WriteLine();

			System.Console.Write("Insert one of the Genres above: ");
			int newGenre = int.Parse(System.Console.ReadLine());

			System.Console.Write("Insert Release Year: ");
			int newYear = int.Parse(System.Console.ReadLine());

			System.Console.Write("Insert Description: ");
			string newDescrpt = System.Console.ReadLine();

			switch (decision)
			{
				case 1:
					Movie newMovie = new Movie(id: movieRep.nextId(),
								title: newTitle,
								genre: (Genre)newGenre,
								year: newYear,
								descrpt: newDescrpt);
					movieRep.Insert(newMovie);
					break;
				case 2:
					Series newSeries = new Series(id: seriesRep.nextId(),
								title: newTitle,
								genre: (Genre)newGenre,
								year: newYear,
								descrpt: newDescrpt);
					seriesRep.Insert(newSeries);
					break;
			}
		}

		private static string getUserCommand()
		{
			System.Console.WriteLine();
			System.Console.WriteLine("Watchlist - Main Menu");
			System.Console.WriteLine("Inform the desired option:");

			System.Console.WriteLine("1- List movies / series");
			System.Console.WriteLine("2- Insert new movie / series");
			System.Console.WriteLine("3- Update");
			System.Console.WriteLine("4- Remove");
			System.Console.WriteLine("5- Search for movie / series");
			System.Console.WriteLine("C- Clear Window");
			System.Console.WriteLine("X- EXIT");
			System.Console.WriteLine();

			string userOp = System.Console.ReadLine().ToUpper();
			System.Console.WriteLine();
			return userOp;
		}
	}
}


