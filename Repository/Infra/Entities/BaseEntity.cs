using System;
using System.ComponentModel.DataAnnotations;

namespace AchadosPerdidosApi.Repository.Infra.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime? DataAlteracao { get; set; }
    }
}