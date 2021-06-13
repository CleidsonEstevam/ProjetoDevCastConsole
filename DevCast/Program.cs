using System;

namespace DevCast
{
    class Program
    {
      static PodcastsRepositorio repositorio = new PodcastsRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarPodcasts();
						break;
					case "2":
						InserirPodcasts();
						break;
					case "3":
						AtualizarPodcasts();
						break;
					case "4":
						ExcluirPodcasts();
						break;
					case "5":
						VisualizarPodcasts();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirPodcasts()
		{
			Console.Write("Digite o id do PodDev: ");
			int indicePod = int.Parse(Console.ReadLine());

			repositorio.Exclui(indicePod);
		}

        private static void VisualizarPodcasts()
		{
			Console.Write("Digite o id do DevCast: ");
			int indicePod = int.Parse(Console.ReadLine());

			var podcast = repositorio.RetornaPorId(indicePod);

			Console.WriteLine(podcast);
		}

        private static void AtualizarPodcasts()
		{
			Console.Write("Digite o id do DevCast ");
			int indicePod = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Assunto)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Assunto), i));
			}
			Console.Write("Digite um assunto entre as opções acima: ");
			int entradaAssunto = int.Parse(Console.ReadLine());

			Console.Write("Legal, agora digite o nome do DevCast: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de criação do PodCast: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Ok, agora digite descreva sobre o que aborda o DevCast: ");
			string entradaDescricao  = Console.ReadLine();

			Podcasts atualizaDevCast = new Podcasts(id: indicePod,
										assunto: (Assunto)entradaAssunto,
										nome: entradaNome,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Atualiza(indicePod, atualizaDevCast);
		}
        private static void ListarPodcasts()
		{
			Console.WriteLine("Listar DevCasts");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Ops! Nenhum DevCast cadastrado.");
				return;
			}

			foreach (var cast in lista)
			{
                var excluido = cast.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", cast.retornaId(), cast.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirPodcasts()
		{
			Console.WriteLine("Inserir um novo DevCast");

			
			foreach (int i in Enum.GetValues(typeof(Assunto)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Assunto), i));
			}
			Console.Write("Digite um assunto entre as opções acima: ");
			int entradaAssunto = int.Parse(Console.ReadLine());

			Console.Write("Legal, agora digite o nome do DevCast: ");
			string entradaNome = Console.ReadLine();

			Console.Write("Digite o Ano de criação do PodCast: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Ok, agora digite descreva sobre o que aborda o DevCast: ");
			string entradaDescricao = Console.ReadLine();

			Podcasts novoDevCast = new Podcasts(id: repositorio.ProximoId(),
										assunto: (Assunto)entradaAssunto,
										nome: entradaNome,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorio.Insere(novoDevCast);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Olá, somos a DevCast!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar DevCasts");
			Console.WriteLine("2- Inserir um novo PodCast na DevCast");
			Console.WriteLine("3- Atualizar PodCasts");
			Console.WriteLine("4- Excluir PodCasts");
			Console.WriteLine("5- Conhecer um PodCast");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
