using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_shop.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName ="nvarchar(10)")]
    public string Sku { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Title { get; set; }

    [Column(TypeName ="ntext")]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName ="decimal(9,2)")]
    public decimal InStock { get; set; }

    [Required]
    [Column(TypeName = "decimal(9,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "nvarchar(200)")]
    public string? Image { get; set; }
}
