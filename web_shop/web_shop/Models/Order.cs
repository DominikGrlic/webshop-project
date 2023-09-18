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
    public AppUser? User { get; set; }

    [Column(TypeName ="nvarchar(450)")]
    public string? UserId { get; set; }

    // TODO: Billing i shipping klase sa svojstvima o kupcu (za neprijavljene kupce)
    // svojstva: Id, FirstName, LastName, Adress, Email, Phone, City, Country, PostalCode, Message

    // TODO: Customer klasa koja je povezana sa AppUser klasom (labava veza)

    [Required(ErrorMessage = "First name is required!")]
    [StringLength(50, ErrorMessage ="Max 50 characters.")]
    [Column(TypeName ="nvarchar(50)")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required!")]
    [StringLength(50, ErrorMessage = "Max 50 characters.")]
    [Column(TypeName = "nvarchar(50)")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Email address is required!")]
    [StringLength(100, ErrorMessage = "Max 100 characters.")]
    [EmailAddress]
    [Column(TypeName = "nvarchar(100)")]
    public string EmailAddress { get; set; }

    [Required(ErrorMessage = "Phone number is required!")]
    [Column(TypeName = "nvarchar(100)")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Country is required!")]
    [Column(TypeName = "nvarchar(50)")]
    public string Country { get; set; }

    [Required(ErrorMessage = "City is required!")]
    [Column(TypeName = "nvarchar(50)")]
    public string City { get; set; }

    [Required(ErrorMessage = "Address is required!")]
    [Column(TypeName = "nvarchar(150)")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Postal code is required!")]
    [Column(TypeName = "nvarchar(10)")]
    public string PostalCode { get; set; }

    [Column(TypeName = "nvarchar(3000)")]
    public string? Message { get; set; }
}
