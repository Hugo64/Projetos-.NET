using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
// biblioteca para validar no BD -> using System.Web.Mvc;

namespace Projeto4.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage="Campo nome obrigatorio")]
        public string Nome { get; set; }

        [StringLength(50, MinimumLength=5, ErrorMessage="Maximo de caracteres '50' e minimo '5'" )]
        [Required(ErrorMessage="Digite uma observação")]
        public string Observacao { get; set; }

        [Range(18,50, ErrorMessage="A idade deve estar entre 18 a 50 anos")]
        [Required(ErrorMessage="Digite a idade")]
        public int Idade { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage="O email inserido não é valido")]
        public string Email { get; set; }

        [StringLength(10,MinimumLength=5, ErrorMessage="Informe entre 5 a 10 letras")]
        [Required(ErrorMessage="O login deve ser preenchido")]
        //[Remote("BD", "Pessoa", ErrorMessage = "Este nome de login já existe")]
        public string Login { get; set; }

        [Required(ErrorMessage="A senha deve ser informada")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage="As senha não confere")]
        public string confirmarSenha { get; set; }

    }
}