using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Subtituicao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Jogo")]
        public Jogo jogo { get; set; }

        [DisplayName("Jogador que saiu")]
        public Jogador jogadorSaiu { get; set; }

        [DisplayName("Jogador que entrou")]
        public Jogador jogadorEntrou { get; set; }

        [DisplayName("Time")]
        public Equipe time { get; set; }

    }

}