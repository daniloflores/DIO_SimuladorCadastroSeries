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
                    //InsertSeries();
                    break;
                case "3":
                    //UpdateSeries();
                    break;
                case "4":
                    ExcludeSeries(sr);
                    break;
                case "5":
                    SeeSeries(sr);
                    break;
                case "C":
                    Console.Clear();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ExcludeSeries(SeriesRepository sr){
            Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());
			sr.Exclude(seriesId);
        }

        public static void SeeSeries(SeriesRepository sr)
		{
			Write("Choose series id: ");
			int seriesId = int.Parse(ReadLine());
			var series = sr.GetById(seriesId);
			WriteLine(series);
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
                Console.WriteLine($"#ID {series.ReturnId()}: - {series.ReturnTitle()} {(excluded ? "*Not available*" : "")}");
			}
		}
    }
}