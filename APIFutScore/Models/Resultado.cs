using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Resultado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Jogo")]
        public Jogo jogo { get; set; }

        [DisplayName("Gols time 1")]
        [Required(ErrorMessage = "Informe a quantidade de gols")]
        public int gols1 { get; set; }

        [DisplayName("Gols time 2")]
        [Required(ErrorMessage = "Informe a quantidade de gols")]
        public int gols2 { get; set; }

        [DisplayName("Equipe vencedora")]
        public Equipe time { get; set; }

        [DisplayName("Posse de bola time 1")]
        public int posse1 { get; set; }

        [DisplayName("Posse de bola time 2")]
        public int posse2 { get; set; }


    }

}