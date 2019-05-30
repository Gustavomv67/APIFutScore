using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Jogador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Informe o nome do Jogador")]
        public string nome { get; set; }

        [DisplayName("Time")]
        public Equipe time { get; set; }

        [DisplayName("Idade")]
        [Required(ErrorMessage = "Informe a idade do jogador")]
        public int idade { get; set; }

        [DisplayName("Numero")]
        [Required(ErrorMessage = "Informe o numero do jogador")]
        public int numero { get; set; }

        [DisplayName("Posição")]
        public Posicoes posicao { get; set; }
    }

}