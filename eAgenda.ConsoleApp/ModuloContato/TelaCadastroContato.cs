using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.ModuloContato
{
    internal class TelaCadastroContato : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Contato> _repositorioContato;
        private readonly Notificador _notificador;

        public TelaCadastroContato(IRepositorio<Contato> repositorioContato, Notificador notificador)
            : base("Cadastro de Contato")
        {
            _repositorioContato = repositorioContato;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Contato");

            Contato novoContato = obterCompromisso();

            _repositorioContato.Inserir(novoContato);

            _notificador.ApresentarMensagem("Contato cadastrado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Contato");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrada para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Contato contatoAtualizado = obterCompromisso();

            bool conseguiuEditar = _repositorioContato.Editar(numeroGenero, contatoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Contato");

            bool temTarefasRegistradas = VisualizarRegistros("Pesquisando");

            if (temTarefasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhum Contato cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroContato = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioContato.Excluir(numeroContato);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Contato excluído com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Tarefas Cadastradas");

            List<Contato> contatos = _repositorioContato.SelecionarTodos();

            if (contatos.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhum contato disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Contato contato in contatos)
                Console.WriteLine(contato.ToString());

            Console.ReadLine();

            return true;
        }

        private Contato obterCompromisso()
        {
            Console.Write("Digite o assunto do compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do compromisso: ");
            DateTime data = new DateTime();

            Console.Write("Digite a hora do início do compromisso (horas:minuto): ");
            string hora_inicio = Console.ReadLine();

            Console.Write("Digite a hora do termino do compromisso (horas:minutos): ");
            string hora_termino = Console.ReadLine();

            return new Contato(assunto, local, data, hora_inicio, hora_termino);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID do Contato que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioContato.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID do Contato não foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
