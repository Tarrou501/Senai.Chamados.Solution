﻿using System;

using System.ComponentModel.DataAnnotations;

using System.Web.Mvc;

namespace Senai.Chamados.Web.ViewModels
{
    public class CadastrarUsuarioViewModel
    {   
        [Display (Name = "Informe o Nome")]
        [Required(ErrorMessage ="Informe o campo nome")]
        public String Nome { get; set; }

        [Display(Name = "Informe o Email")]
        [Required(ErrorMessage = "Informe o campo email")]
        [EmailAddress(ErrorMessage ="O Email é inválido")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Informe o Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Informe o campo telefone")]
        public String Telefone { get; set; }

        [Display(Name = "Informe o Senha")]
        [Required(ErrorMessage = "Informe o campo senha")]
        [DataType (DataType.Password)]
        public String Senha { get; set; }

        // SelectList vai contem uma lista de dados para uso do Combobox
        public SelectList Sexo { get; set; }

        [Required(ErrorMessage = "Informe o sexo")]
        public string SexoId { get; set; }
    }
}