using eAgenda.ConsoleApp.ModuloTarefa;
using System;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private readonly IRepositorio<Tarefa> repositorioTarefa;
        private readonly TelaCadastroTarefa telaCadastroTarefa;
        
        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();
            Console.WriteLine("eAgenda do José Pedro");
            Console.WriteLine();

            Console.WriteLine("[1] Gerenciar Tarefas");

            Console.WriteLine("[s] para sair");

            string opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase ObterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            if (opcao == "1")
                tela = telaCadastroTarefa;

            else if (opcao == "2")
                tela = null;

            else if (opcao == "3")
                tela = null;

            return tela;
        }
    }
}
