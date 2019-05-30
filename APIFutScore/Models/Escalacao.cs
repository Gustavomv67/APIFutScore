using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIFutScore.Models
{
    public class Escalacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Jogo")]
        public Jogo jogo { get; set; }

        [DisplayName("Time")]
        public Equipe time { get; set; }

        [DisplayName("Jogador")]
        public Jogador jogador { get; set; }

        [DisplayName("Posição")]
        public Posicoes posicao { get; set; }


    }
}
