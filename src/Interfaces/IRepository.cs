using System.Collections.Generic;

namespace DIO_SimuladorCadastroSeries.src.Interfaces
{
    public interface IReposiory<T>
    {
        List<T> ListAll();
        T GetById(int id);
        void Insert(T item);
        void Exclude(int id);
        void Update(int id, T item);
        int NextId();
    } 
}