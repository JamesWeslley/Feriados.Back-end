using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Entidades
{
    [PrimaryKey(nameof(Id))]
    public class Feriado
    {
        [Required]
        public int Id { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Data { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Titulo { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Legislacao { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Tipo { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string HoraInicio { get; set; }

        [Column(TypeName = "varchar(8)")]
        public string HoraFim { get; set; }

        public string DatasMoveis { get; set; }
    }
}
