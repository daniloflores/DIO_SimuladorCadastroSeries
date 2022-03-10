using DIO_SimuladorCadastroSeries.src.Enum;
using System;

namespace DIO_SimuladorCadastroSeries.src.Classes
{
    public class Series : BaseEntity
    {
        private Genre Genre;
        private string Title;
        private string Description;
        private int Year;
        bool Excluded;

        public Series(int id, string title, Genre genre, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }

        public override string ToString() {
            string seriesData = $"Genre: {this.Genre}" + Environment.NewLine;            
            seriesData += $"Title: {this.Title}" + Environment.NewLine; 
            seriesData += $"Year: {this.Year}" + Environment.NewLine; 
            seriesData += $"Description: {this.Description}";

            if(this.Excluded){
                seriesData += Environment.NewLine + "**Title unavailable**";
            }

            return seriesData;
        }

        public string ReturnTitle() {
            return this.Title;
        }

        public int ReturnId(){
            return this.Id;
        }

        public void MarkExcluded() {
            this.Excluded = true;
        }

        public bool ReturnExcluded() {
            return this.Excluded;
        }

        public Genre ReturnGenre(){
            return this.Genre;
        }

    }
}