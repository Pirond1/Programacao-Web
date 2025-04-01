using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class FuncionarioDTO
    {
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatória")]
        public string nome { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O Usuário é obrigatória")]
        public string usuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string senha { get; set; }

        [Display(Name = "Salário")]
        [Required(ErrorMessage = "O Salário é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "O Valor deve ser Positivo")]
        public decimal salario { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        public DateOnly dataNascimento { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "A Área é obrigatória")]
        public int? idArea { get; set; }
    }
}
