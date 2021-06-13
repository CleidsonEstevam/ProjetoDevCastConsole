using System;
using System.Collections.Generic;
using DevCast.Interfaces;


namespace DevCast
{
    public class PodcastsRepositorio : IRepositorio<Podcasts>
    {
        private List<Podcasts> listaPod = new List<Podcasts>();
		public void Atualiza(int id, Podcasts objeto)
		{
			listaPod[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaPod[id].Excluir();
		}

		public void Insere(Podcasts objeto)
		{
			listaPod.Add(objeto);
		}

		public List<Podcasts> Lista()
		{
			return listaPod;
		}

		public int ProximoId()
		{
			return listaPod.Count;
		}

		public Podcasts RetornaPorId(int id)
		{
			return listaPod[id];
		}
    }
}