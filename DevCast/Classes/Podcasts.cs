using System;

namespace DevCast
{
       public class Podcasts : EntidadeBase
    {
        // Atributos
		private Assunto Assunto   { get; set; }
		private string  Nome      { get; set; }
		private string  Descricao { get; set; }
		private int     Ano       { get; set; }
        private bool    Excluido  { get; set; }

        public Podcasts(int id, Assunto assunto, string nome, string descricao, int ano)
		{
			this.Id        = id;
			this.Assunto   = assunto;
			this.Nome      = nome;
			this.Descricao = descricao;
			this.Ano       = ano;
            this.Excluido  = false;
		}

         public override string ToString()
		{
            string retorno = "";
            retorno += "Assunto: " + this.Assunto + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}
         public string retornaTitulo()
		{
			return this.Nome;
		}
        public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
    	
}