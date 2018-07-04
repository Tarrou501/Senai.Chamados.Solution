using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Senai.Chamados.Web.ViewModels.Conta
{
    public class AlterarSenhaViewModel
    {
        [Required(ErrorMessage ="Informe a senha atual")]
        [DataType(DataType.Password)]
        [Display(Name ="Senha Atual")]
        [MinLength(4,ErrorMessage ="A senha deve ter pelo menos 4 caracteres")]
        public string SenhaAtual { get; set; }

        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        [MinLength(4, ErrorMessage = "A senha deve ter pelo menos 4 caracteres")]
        public string NovaSenha { get; set; }

        [Required(ErrorMessage = "Informe a nova senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirma Senha")]
        [MinLength(4, ErrorMessage = "A senha deve ter pelo menos 4 caracteres")]
        [Compare(nameof(NovaSenha),ErrorMessage ="A senha e a confirmação de senha não são iguais")]
        public string ConfirmarSenha { get; set; }
    }
}