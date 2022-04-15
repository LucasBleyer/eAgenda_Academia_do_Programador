using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloCompromisso
{
    internal class Compromisso : EntidadeBase
    {
        public string Assunto { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public string Hora_inicio { get; set; }
        public string Hora_termino { get; set; }

        public Compromisso(string assunto, string local, DateTime data, string hora_inicio, string hora_termino)
        {
            Assunto = assunto;
            Local = local;
            Data = data;
            Hora_inicio = hora_inicio;
            Hora_termino = hora_termino;
        }

        public override string ToString()
        {
            return "Id: " + id +
                "\nAssunto do compromisso: " + Assunto +
                "\nLocal do compromisso: " + Local +
                "\nData do compromisso: " + Data +
                "\nHora do início do comprimisso: " + Hora_inicio +
                "\nHora do término do comprimisso: " + Hora_termino;
        }
    }
}
