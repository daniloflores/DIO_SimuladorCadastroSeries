using System.Collections.Generic;
using DIO_SimuladorCadastroSeries.src.Interfaces;

namespace DIO_SimuladorCadastroSeries.src.Classes
{
    public class SeriesRepository : IReposiory<Series>
    {
        private List<Series> seriesList = new List<Series>();

        public List<Series> ListAll() {
            return seriesList;
        }

        public Series GetById(int id){
            return seriesList[id];
        }

        public void Insert(Series item){
            seriesList.Add(item);
        }

        public void Exclude(int id) {
            seriesList[id].MarkExcluded();
        }

        public void Update(int id, Series item){
            seriesList[id] = item;
        }

        public int NextId(){
            return seriesList.Count;
        }
    }
}