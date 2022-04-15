using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloContato
{
    internal class Contato : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }

        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public override string ToString()
        {
            return "Id: " + id +
                "\nNone do contato: " + Nome +
                "\nEmail do contato: " + Email +
                "\nTelefone do contato: " + Telefone +
                "\nEmpresa contato: " + Empresa +
                "\nCargo do contato: " + Cargo;
        }
    }
}
