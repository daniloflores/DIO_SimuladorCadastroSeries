using System;
using static System.Console;
using DIO_SimuladorCadastroSeries.src.Enum;

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
			WriteLine("1- List series");
			WriteLine("2- Insert new series");
			WriteLine("3- Update series record");
			WriteLine("4- Exclude series");
			WriteLine("5- See series details");
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
                case "C":
                    Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
            WriteLine();
        }

        public static void ExcludeSeries(SeriesRepository sr){
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
			Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());

            if(seriesId >= sr.NextId()){
                WriteLine("Invalid option");
            } else {
                var series = sr.GetById(seriesId);
			    WriteLine(series);
            }
			
		}

        public static void ListSeries(SeriesRepository sr)
		{
			WriteLine("Series list:");

			var list = sr.ListAll();

			if (list.Count == 0)
			{
				WriteLine("No series registered.");
				return;
			}

			foreach (var series in list)
            {
				var excluded = series.ReturnExcluded();
                WriteLine($"#ID {series.ReturnId()}: - {series.ReturnTitle()} {(excluded ? "*Not available*" : "")}");
			}
		}

        public static void InsertSeries(SeriesRepository sr)
		{
			int seriesId = sr.NextId();

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			
            Array valueArray = Genre.GetValues(typeof(Genre));

            //Array valueArray = Enum.GetValues(typeof(Genre));
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

			Series newSeries = new Series(id: seriesId,
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			sr.Update(seriesId, newSeries);
        }

        public static void UpdateSeries(SeriesRepository sr)
		{
			Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			
            Array valueArray = Genre.GetValues(typeof(Genre));

            //Array valueArray = Enum.GetValues(typeof(Genre));
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

			Series updatedSeries = new Series(id: seriesId,
										genre: (Genre)genreInput,
										title: titleInput,
										year: yearInput,
										description: descriptionInput);

			sr.Update(seriesId, updatedSeries);
        }
    }
}