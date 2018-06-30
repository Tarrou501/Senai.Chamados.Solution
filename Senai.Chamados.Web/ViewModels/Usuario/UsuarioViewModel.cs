using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Senai.Chamados.Web.ViewModels.Usuario
{
    public class UsuarioViewModel:BaseViewModel
    {
        [Display(Name = "Informe o Nome")]
        [Required(ErrorMessage = "Informe o campo nome")]
        public String Nome { get; set; }

        [Display(Name = "Informe o Email")]
        [Required(ErrorMessage = "Informe o campo email")]
        [EmailAddress(ErrorMessage = "O Email é inválido")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Informe o Telefone")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Informe o campo telefone")]
        public String Telefone { get; set; }

        [Required(ErrorMessage = "Informe o campo cpf")]
        [MaxLength(14)]
        public string Cpf { get; set; }

        [Display(Name = "Informe o Senha")]
        [Required(ErrorMessage = "Informe o campo senha")]
        [DataType(DataType.Password)]
        [MaxLength(8)]
        public String Senha { get; set; }

        // SelectList vai contem uma lista de dados para uso do Combobox
        public SelectList Sexo { get; set; }

        //[Required(ErrorMessage = "Informe o sexo")]
        public string SexoId { get; set; }

        [Display(Name = "Informe o Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Informe o Numero")]
        public string Numero { get; set; }

        [Display(Name = "Informe o Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Informe o Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Informe o Cep")]
        [MaxLength(9, ErrorMessage = "Cep deve possui n número maximo 9 caracteres")]
        public string Cep { get; set; }

        [Display(Name = "Informe a Cidade")]
        [MaxLength(100)]
        public string Cidade { get; set; }

        [Display(Name = "Informe o Estado")]
        [MaxLength(2)]
        public string Estado { get; set; }

    }
}