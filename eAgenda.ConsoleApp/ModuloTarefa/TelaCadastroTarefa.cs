using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.ModuloTarefa
{
    internal class TelaCadastroTarefa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Tarefa> _repositorioTarefa;
        private readonly Notificador _notificador;

        public TelaCadastroTarefa(IRepositorio<Tarefa> repositorioTarefa, Notificador notificador)
            : base("Cadastro de Tarefas")
        {
            _repositorioTarefa = repositorioTarefa;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Tarefas");

            Tarefa novaTarefa = obterTarefa();

            _repositorioTarefa.Inserir(novaTarefa);

            _notificador.ApresentarMensagem("Tarefas cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Tarefa");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Tarefa terefaAtualizada = obterTarefa();

            bool conseguiuEditar = _repositorioTarefa.Editar(numeroGenero, terefaAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Tarefa");

            bool temTarefasRegistradas = VisualizarRegistros("Pesquisando");

            if (temTarefasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioTarefa.Excluir(numeroTarefa);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Tarefa excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Tarefas Cadastradas");

            List<Tarefa> tarefas = _repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma tarefa disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Tarefa tarefa in tarefas)
                Console.WriteLine(tarefa.ToString());

            Console.ReadLine();

            return true;
        }

        private Tarefa obterTarefa()
        {
            Console.Write("Digite o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Nível de prioridade da tarefa de 0 a 10: ");
            int nivel_prioridade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Data de criação da tarefa: ");
            DateTime data_criacao = new DateTime();

            Console.Write("Data de conclusão da tarefa: ");
            DateTime data_conclusao = new DateTime();

            return new Tarefa(titulo, nivel_prioridade, data_criacao,data_conclusao);//percentual_conclusao
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do tarefa que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioTarefa.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da tarefa não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
