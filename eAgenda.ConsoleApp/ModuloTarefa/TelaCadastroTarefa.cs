using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;

namespace eAgenda.ConsoleApp.ModuloTarefa
{
    internal class TelaCadastroTarefa : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Conta> _repositorioConta;
        private readonly Notificador _notificador;

        public TelaCadastroConta(IRepositorio<Conta> repositorioPedido, Notificador notificador)
            : base("Cadastro de Contas")
        {
            _repositorioConta = repositorioPedido;
            _notificador = notificador;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Contas");

            Conta novoPedido = obterPedido();

            _repositorioConta.Inserir(novoPedido);

            _notificador.ApresentarMensagem("Conta cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Conta");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma conta cadastrado para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroGenero = ObterNumeroRegistro();

            Conta pedidoAtualizado = obterPedido();

            bool conseguiuEditar = _repositorioConta.Editar(numeroGenero, pedidoAtualizado);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Pedido editado com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Conta");

            bool temContasRegistradas = VisualizarRegistros("Pesquisando");

            if (temContasRegistradas == false)
            {
                _notificador.ApresentarMensagem("Nenhuma conta cadastrado para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroConta = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioConta.Excluir(numeroConta);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Conta excluída com sucesso!", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de Contas Cadastradas");

            List<Conta> contas = _repositorioConta.SelecionarTodos();

            if (contas.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma conta disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Conta conta in contas)
                Console.WriteLine(conta.ToString());

            Console.ReadLine();

            return true;
        }

        private Conta obterPedido()
        {
            Console.Write("Digite o código da conta: ");
            string codigo = Console.ReadLine();

            return new Conta(codigo);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da conta que deseja selecionar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioConta.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da conta não foi encontrada, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
