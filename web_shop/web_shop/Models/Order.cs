using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web_shop.Areas.Identity.Data;

namespace web_shop.Models;

public class Order
{
    [Key]
    public int Id { get; set; }

    [Required]
    [Column(TypeName ="datetime")]
    public DateTime DateCreated { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName ="decimal(9,2)")]
    public decimal Subtotal { get; set; }

    [Required]
    [Column(TypeName ="decimal(9,2)")]
    public decimal Tax { get; set; }

    [Required]
    [Column(TypeName ="decimal(9,2)")]
    public decimal Total { get; set; }

    [ForeignKey(nameof(UserId))]
    public AppUser User { get; set; }

    [Column(TypeName ="nvarchar(450)")]
    public string UserId { get; set; }

    // TODO: Billing i shipping klase sa svojstvima o kupcu (za neprijavljene kupce)
        // svojstva: Id, FirstName, LastName, Adress, Email, Phone, City, Country, PostalCode, Message

    // TODO: Customer klasa koja je povezana sa AppUser klasom (labava veza)


}
