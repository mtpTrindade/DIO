using System;

namespace DIO.Series
{  
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                    break;

                    case "2":
                        InserirSerie();
                    break;

                    case "3":
                        AtualizarSerie();
                    break;

                    case "4":
                        ExcluirSerie();
                    break;

                    case "5":
                        VisualizarSerie();
                    break;

                    case "C":
                        Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos a preferência! Até a próxima!");
            Console.ReadLine();
        }

        // CASE 1 - LISTAR SÉRIE
        private static void ListarSeries()
        {
            Console.WriteLine("Lista de Series: ");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Não há nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();   
				Console.WriteLine("#ID {0}: - {1} {2}", serie.RetornaId(), serie.RetornaTitulo(), (excluido ? "*Excluído*" : ""));
			}

            Console.WriteLine("__________________________________________");
        }

        // CASE 2 - INSERIR SÉRIE
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série: ");
            Console.WriteLine("");

            foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("");
            Console.Write("Gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero) entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);
            repositorio.Insere(novaSerie);

            Console.WriteLine("__________________________________________");

        }

        // CASE 3 - ATUALIZAR SÉRIE
        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

			Console.Write("Gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero) entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine("__________________________________________");
		}

        // CASE 4 - EXCLUIR SÉRIE
        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
            Console.WriteLine("__________________________________________");
		}

        // CASE 5 - VISUALIZAR SÉRIE
        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
            Console.WriteLine("__________________________________________");
		}

        // INÍCIO DO PROGRAMA
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("__________________________________________");
            Console.WriteLine("");
            Console.WriteLine("DIO Séries...");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("");
            Console.WriteLine("1- Listar séries. ");
            Console.WriteLine("2- Inserir nova série. ");
            Console.WriteLine("3- Atualizar série. ");
            Console.WriteLine("4- Excluir série. ");
            Console.WriteLine("5- Visualizar série. ");
            Console.WriteLine("");
            Console.WriteLine("C- Limpar tela. ");
            Console.WriteLine("X- Sair. ");
            Console.WriteLine("");
            Console.WriteLine("__________________________________________");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
