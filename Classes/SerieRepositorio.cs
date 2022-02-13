using System;
using System.Collections.Generic;
using Projeto.Series.Interfaces;

namespace Projeto.Series
{
     public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> ListaSeries = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            ListaSeries[id] = objeto;
        }
        public void Exclui(int id)
        {
            ListaSeries[id].Excluir();
  
        }
        public void Insere(Series objeto)
        {
            ListaSeries.Add(objeto);
            
        }
         public List<Series> Lista()
        {
            return ListaSeries;
        }
        public int ProximoId()
        {
            return ListaSeries.Count;
        }
        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }   
}