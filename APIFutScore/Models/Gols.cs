using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Gols
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Jogo")]
        public Jogo jogo { get; set; }

        [DisplayName("Jogador")]
        public Jogador jogador { get; set; }

        [DisplayName("A favor de qual time?")]
        public Equipe time { get; set; }

        [DisplayName("Falta")]
        public bool falta { get; set; }

        [DisplayName("Penalti")]
        public bool penalti { get; set; }

        [DisplayName("Escanteio")]
        public bool escanteio { get; set; }

        public Gols()
        {
            falta = false;
            penalti = false;
            escanteio = false;
        }

    }

}