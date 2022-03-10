using System;
using static System.Console;
using DIO_SimuladorCadastroSeries.src.Enum;
using System.Linq;

namespace DIO_SimuladorCadastroSeries.src.Classes
{
    public class UserInterace
    {

        public static void Welcome(){
            WriteLine("================================");
            WriteLine("== Welcome to your Series App ==");
            WriteLine("================================");
        }

        public static string GetUserOption(){

            WriteLine("------------ MAIN MENU -------------");
			WriteLine("-- Choose your option to continue --");
			WriteLine("1- List all series");
			WriteLine("2- Insert new series");
			WriteLine("3- Update series record");
			WriteLine("4- Exclude series");
			WriteLine("5- See series details");
			WriteLine("6- List series by genre");
			WriteLine("X- Exit");
			WriteLine("------------------------------------");
            
            Write("Option:");
			string userOption = ReadLine().ToUpper();
			return userOption;
		}

        public static void ProcessUserOption(string userOption, SeriesRepository sr){
            switch (userOption)
            {
                case "1":
                    UserInterace.ListSeries(sr);
                    break;
                case "2":
                    InsertSeries(sr);
                    break;
                case "3":
                    UpdateSeries(sr);
                    break;
                case "4":
                    ExcludeSeries(sr);
                    break;
                case "5":
                    SeeSeries(sr);
                    break;
				case "6":
                    ListSeriesByGenre(sr);
                    break;
                case "C":
                    Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            WriteLine();
        }

        public static void ExcludeSeries(SeriesRepository sr){

			var listSize = sr.NextId();

			if (listSize == 0)
			{
				WriteLine("No series registered.");
				return;
			}


            Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());

            if(seriesId >= sr.NextId()){
                WriteLine("Invalid option");
            } else {
			    sr.Exclude(seriesId);
            }
        }

        public static void SeeSeries(SeriesRepository sr)
		{

			var listSize = sr.NextId();

			if (listSize == 0)
			{
				WriteLine("No series registered.");
				return;
			}

			Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());

            if(seriesId >= sr.NextId()){
                WriteLine("Invalid option");
            } else {
                var series = sr.GetById(seriesId);
				WriteLine("------------------------------------");
			    WriteLine(series);
            }
			
		}

        public static void ListSeries(SeriesRepository sr)
		{

			var list = sr.ListAll();

			if (list.Count == 0)
			{
				WriteLine("No series registered.");
				return;
			}

			WriteLine("------------------------------------");
			WriteLine("------------ Series list -----------");
			WriteLine("------------------------------------");
			WriteLine("   ID          Title                ");
			WriteLine("  ----   -------------------------  ");
			
			foreach (var series in list)
            {
				var excluded = series.ReturnExcluded();
                WriteLine($" {series.ReturnId(),4}     {series.ReturnTitle()} {(excluded ? "  *Not available*" : "")}");
			}
		}

		protected static Series setSeriesInfo(int seriesId){

			Array valueArray = Genre.GetValues(typeof(Genre));
            foreach (int i in valueArray)
			{
				WriteLine("{0}-{1}", i, Genre.GetName(typeof(Genre), i));
			}
			Write("Choose from one of the genres above: ");
			int genreInput = int.Parse(ReadLine());

			Write("Type in the series title: ");
			string titleInput = ReadLine();

			Write("Type in the series start year: ");
			int yearInput = int.Parse(ReadLine());

			Write("Type in the series description: ");
			string descriptionInput = ReadLine();

			Series seriesInfo = new Series(id: seriesId,
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);
			
			return seriesInfo;
		}

        public static void InsertSeries(SeriesRepository sr)
		{
			int seriesId = sr.NextId();

			Series newSeries = setSeriesInfo(seriesId);

			sr.Insert(newSeries);
        }

        public static void UpdateSeries(SeriesRepository sr)
		{

			var listSize = sr.NextId();

			if (listSize == 0)
			{
				WriteLine("No series registered.");
				return;
			}

			Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());

			Series updatedSeries = setSeriesInfo(seriesId);

			sr.Update(seriesId, updatedSeries);
        }

		public static void ListSeriesByGenre(SeriesRepository sr)
		{

			Array valueArray = Genre.GetValues(typeof(Genre));
            foreach (int i in valueArray)
			{
				WriteLine("{0}-{1}", i, Genre.GetName(typeof(Genre), i));
			}
			Write("Choose from one of the genres above: ");

			int genreInput = int.Parse(ReadLine());
			var listByGenre = sr.ListAll().Where(series => series.ReturnGenre() == (Genre)genreInput);

			// if (listByGenre.Count == 0)
			// {
			// 	WriteLine("No series registered in this Genre.");
			// 	return;
			// }

			WriteLine("------------------------------------");
			WriteLine($"------------ Series list -----------");
			WriteLine("------------------------------------");
			WriteLine("   ID          Title                ");
			WriteLine("  ----   -------------------------  ");
			
			foreach (var series in listByGenre)
            {
				var excluded = series.ReturnExcluded();
                WriteLine($" {series.ReturnId(),4}     {series.ReturnTitle()} {(excluded ? "  *Not available*" : "")}");
			}
		}
    }
}