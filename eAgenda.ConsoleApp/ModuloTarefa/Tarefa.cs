using eAgenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp.ModuloTarefa
{
    internal class Tarefa : EntidadeBase
    {
        public string Titulo { get; set; }
        public int Nivel_prioridade { get; set; }
        public DateTime Data_criacao { get; set; }
        public DateTime Data_conclusao { get; set; }
        public decimal Percentual_conclusao { get; set; } = 0m;

        public Tarefa(string titulo, int nivel_prioridade ,DateTime data_criacao, DateTime data_conclusao)//percentual_conclusao
        {
            Titulo = titulo;
            Nivel_prioridade = nivel_prioridade;
            Data_criacao = data_criacao;
            Data_conclusao = data_conclusao;
            //Percentual_conclusao = percentual_conclusao;
        }

        public override string ToString()
        {
            return "Id: " + id + 
                "\nTítulo da Tarefa: " + Titulo + 
                "\nNível de Prioridade da Tarefa: " + Nivel_prioridade + 
                "\nData de Criação: " + Data_criacao + 
                "\nData de Conclusão: " + Data_conclusao +
                "\nPercentual de Conclusão: " + Percentual_conclusao;
        }
    }
}
