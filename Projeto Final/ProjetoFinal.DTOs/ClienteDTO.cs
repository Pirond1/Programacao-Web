using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.DTOs
{
    public class ClienteDTO
    {
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatória")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O CPF deve conter 14 caracteres (Considerando '.' e '-')")]
        public string cpf { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O Telefone é obrigatória")]
        public string telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória")]
        public DateOnly dataNascimento { get; set; }
    }
}
