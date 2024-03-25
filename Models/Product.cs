using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace SuperMarket.Models
{
 
    public class Product
    {
        [Key]
        [DisplayName ("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        [StringLength(80, ErrorMessage = "Nome do produto deve conter até 80 caracteres")]
        [MinLength(3, ErrorMessage = "Nome do produto deve conter ao menos 3 caracteres")]
        [DisplayName("Nome do Produto")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o valor do produto")]                
        [DisplayName("Valor do Produto")]
        public decimal Price { get; set; } = decimal.Zero;

        [Required(ErrorMessage = "Informe a quantidade do produto em estoque")]                
        [DisplayName("Quantidade do produto em estoque")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        [StringLength(80, ErrorMessage = "Descrição do produto deve conter até 80 caracteres")]
        [MinLength(4, ErrorMessage = "Descrição do produto deve conter ao menos 3 caracteres")]
        [DisplayName("Descrição do Produto")]
        public string Description { get; set; } = string.Empty;
        

    }
}
