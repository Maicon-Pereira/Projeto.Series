using System;

namespace Projeto.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListaSeries();
                    break;
                    
                    case "2":
                    InserirSeries();
                    break;
                    
                    case "3":
                    AtualizarSeries();
                    break;
                    
                    case "4":
                    ExcluirSeries();
                    break;
                    
                    case "5":
                    VisualizarSeries();
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
    private static void ExcluirSeries()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        repositorio.Exclui(indiceSerie);
    }
    private static void VisualizarSeries()
    {
      Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        var Series = repositorio.RetornaPorId(indiceSerie);

        Console.WriteLine(Series);

    }
    private static void AtualizarSeries()
    {
        Console.Write("Digite o id da série: ");
        int indiceSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
        }
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o Descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Series atualizaSeries = new Series(id: indiceSerie,
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
       
        repositorio.Atualiza(indiceSerie, atualizaSeries);                            
        
        }
        private static void ListaSeries()
        {
            var Lista = repositorio.Lista();

            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return; 

            }
            foreach (var Series in Lista)
            {
                var Excluido = Series.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", Series.retornaId(), Series.retornaTitulo(), (Excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
        
        Console.Write("Digite o gênero entre as opções acima: ");
        int entradaGenero = int.Parse(Console.ReadLine());

        Console.Write("Digite o Título da série: ");
        string entradaTitulo = Console.ReadLine();

        Console.Write("Digite o Ano de Início da Série: ");
        int entradaAno = int.Parse(Console.ReadLine());

        Console.Write("Digite o Descrição da série: ");
        string entradaDescricao = Console.ReadLine();

        Series novaSerie = new Series(id: repositorio.ProximoId(),
                                    genero: (Genero)entradaGenero,
                                    titulo: entradaTitulo,
                                    ano: entradaAno,
                                    descricao: entradaDescricao);
       
        repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" SANTOS Séries a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;   
        }                     
    }
}    