using eAgenda.ConsoleApp.ModuloTarefa;
using eAgenda.ConsoleApp.ModuloCompromisso;
using System;

namespace eAgenda.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private readonly IRepositorio<Tarefa> repositorioTarefa;
        private readonly TelaCadastroTarefa telaCadastroTarefa;

        private readonly IRepositorio<Compromisso> repositorioCompromisso;
        private readonly TelaCadastroCompromisso telaCadastroCompromisso;

        public TelaMenuPrincipal(Notificador notificador)
        {
            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);

            repositorioCompromisso = new RepositorioCompromisso();
            telaCadastroCompromisso = new TelaCadastroCompromisso(repositorioCompromisso, notificador);
        }

        public string MostrarOpcoes()
        {
            Console.Clear();
            Console.WriteLine("eAgenda do José Pedro");
            Console.WriteLine();

            Console.WriteLine("[1] Gerenciar Tarefas");

            Console.WriteLine("[2] Gerenciar Contatos");

            Console.WriteLine("[3] Gerenciar Compromissos");

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
                tela = telaCadastroCompromisso;

            return tela;
        }
    }
}
