using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class ConsultaDTO
    {
        public int id { get; set; }

        [Display(Name = "Horas")]
        [Required(ErrorMessage = "As Horas é obrigatória")]
        public int horas { get; set; }

        [Display(Name = "Data da Consulta")]
        [Required(ErrorMessage = "A Data da Consulta é obrigatória")]
        public DateTime dataConsulta { get; set; }

        [Display(Name = "Valor Total")]
        [Required(ErrorMessage = "O Valor Total é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "O Valor deve ser Positivo")]
        public decimal valorTotal { get; set; }

        [Display(Name = "Seriço")]
        [Required(ErrorMessage = "O Serviço é obrigatória")]
        public int? idServico { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O Cliente é obrigatória")]
        public int? idCliente { get; set; }

        [Display(Name = "Funcionário")]
        [Required(ErrorMessage = "O Funcionário é obrigatória")]
        public int? idFuncionario { get; set; }

        [Display(Name = "Pagamento")]
        [Required(ErrorMessage = "A Forma de Pagamento é obrigatória")]
        public int? idPagamento { get; set; }
    }
}
