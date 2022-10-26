// See https://aka.ms/new-console-template for more information
using System.IO;
namespace TextEditor{

    class Program
    {

        static void Main(string[] args)
        {
            Menu();

        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja realizar?");
            Console.WriteLine("1 - Abrir novo arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("");
            short option = short.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: Abrir(); break;
                case 2: Editar(); break;
                case 3: System.Environment.Exit(0); break;


            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Qual destino do arquivo?");
            string path = Console.ReadLine();
            
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);

                Console.WriteLine("");
                Console.ReadLine();
                Menu();
            }
        }


        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto (Presione ESC para Sair)");
            Console.WriteLine("");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape );

           Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar seu arquivo?");
            var patch = Console.ReadLine();

            using (var file = new StreamWriter(patch))
            {
                file.Write(text);

                Console.WriteLine($"Arquivo {patch} salvo com sucesso...");
                Console.ReadLine();

                Menu();
            }
        }

    }

}
