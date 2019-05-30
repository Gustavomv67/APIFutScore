using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Escanteio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Jogo")]
        public Jogo jogo { get; set; }


        [DisplayName("A favor do time")]
        public Equipe time { get; set; }

    }

}