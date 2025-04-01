using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class ServicoDTO
    {
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string descricao { get; set; }

        [Display(Name = "Valor Hora")]
        [Required(ErrorMessage = "O Valor da Hora é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "O Valor deve ser Positivo")]
        public decimal valorHora { get; set; }

        [Display(Name = "Area")]
        [Required(ErrorMessage = "A Área é obrigatória")]
        public int? idArea { get; set; }
    }
}
