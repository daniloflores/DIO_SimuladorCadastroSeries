using System;
using DIO_SimuladorCadastroSeries.src.Classes;

namespace DIO_SimuladorCadastroSeries
{
    class Program
    {

        static void Main(string[] args)
        {
            SeriesRepository sr = new SeriesRepository();

            UserInterace.Welcome();

            string userOption = UserInterace.GetUserOption();

			while (userOption.ToUpper() != "X")
			{
				UserInterace.ProcessUserOption(userOption, sr);
				userOption = UserInterace.GetUserOption();
			}

			Console.WriteLine("Thank you for using our services.");
			Console.ReadLine();
        }
    }
}
