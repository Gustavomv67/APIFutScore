using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIFutScore.Models
{
    public class Equipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [DisplayName("Nome do time")]
        [Required(ErrorMessage = "Informe o nome do time")]
        public string nome { get; set; }

        [DisplayName("Pais")]
        [Required(ErrorMessage = "De qual pais é o seu time?")]
        public string pais { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "De qual estado é o seu time?")]
        public string estado { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "De qual cidade é o seu time?")]
        public string cidade { get; set; }

        [DisplayName("Sigla")]
        [StringLength(3)]
        [Required(ErrorMessage = "Informe o a sigla usada pelo clube")]
        public string sigla { get; set; }


    }

}