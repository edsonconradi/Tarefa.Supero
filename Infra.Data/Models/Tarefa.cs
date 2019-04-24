using System;

namespace Infra.Data.Models
{
    public class Tarefa
    {
        public Tarefa(int id, string titulo, string descricao, string hora,string data,bool concluida,string responsavel)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Hora = hora;
            Data = data;
            Concluida = concluida;
            Responsavel = responsavel; 
        }

        public Tarefa()
        {           
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get;  set; }
        public string Hora { get; set; }
        public string Responsavel { get; set; }
        public string Data { get; set; }
        public bool Concluida { get; set; }

    }

}
