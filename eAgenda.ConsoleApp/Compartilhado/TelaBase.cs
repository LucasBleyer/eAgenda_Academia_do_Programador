using System;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public abstract class TelaBase
    {
        protected string Titulo { get; set; }

        public TelaBase(string titulo)
        {
            Titulo = titulo;
        }
        public virtual string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);

            Console.WriteLine("[1] Inserir");
            Console.WriteLine("[2] Editar");
            Console.WriteLine("[3] Excluir");
            Console.WriteLine("[4] Visualizar");
            Console.WriteLine("[s] para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        protected void MostrarTitulo(string titulo)
        {
            Console.Clear();
            Console.WriteLine(titulo);
            Console.WriteLine();
        }
    }
}
