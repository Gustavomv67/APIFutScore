using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Jogo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Mandante")]
        public Equipe mandante { get; set; }

        [DisplayName("Visitante")]
        public Equipe visitante { get; set; }

        [DisplayName("Data do Jogo")]
        [DataType(DataType.Date)]
        public DateTime data { get; set; }
    }

}