using Infra.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.Mappings
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Titulo)
                .IsRequired();

            Property(x => x.Hora)
                .HasMaxLength(10)
                .IsOptional();

            Property(x => x.Data)
             .IsOptional();

            Property(x => x.Concluida)
             .IsOptional();

            Property(x => x.Responsavel)
            .IsOptional();

            Property(x => x.Descricao)
                .HasMaxLength(200)
                .IsOptional();
        }
    }
}
