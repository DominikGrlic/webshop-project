using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using web_shop.Areas.Identity.Data;
using web_shop.Models;

namespace web_shop.Data;

public class AppDbContex : IdentityDbContext<AppUser>
{
    // mapiranje klasa modela s tablicama u bazi podataka
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public AppDbContex(DbContextOptions<AppDbContex> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        List<Category> mainCategories = new List<Category>()
        {
            new Category() {Id =1, Title = "Mesni proizvodi"},
            new Category() {Id =2, Title = "Mljecni proizvodi"},
            new Category() {Id =3, Title = "Voce"},
            new Category() {Id =4, Title = "Zitarice"},
            new Category() {Id =5, Title = "Riba"},
            new Category() {Id =6, Title = "Orasasti plodovi"}
        };

        builder.Entity<Category>().HasData(mainCategories);

        List<Product> mainProducts = new List<Product>()
        {
            new Product() { Id= 100, Title = "Banane", Description = "Svjeze banane", Sku="B0900", InStock = 64, Price = 3.99m},
            new Product() { Id= 101, Title = "Zob", Description = "Sitno mljevena zob", Sku="Z1234", InStock = 32, Price = 1.99m},
            new Product() { Id= 102, Title = "Alpro bademovo mlijeko", Description = "Bademovo mlijeko bez dodatnog secera", Sku="BM0009", InStock = 27, Price = 6.50m},
            new Product() { Id= 103, Title = "Riomare Tuna", Description = "Komadici tune sa slanutkom i kuskusom", Sku="R87878", InStock = 64, Price = 3.99m},
            new Product() { Id= 104, Title = "Vincek prsut", Description = "Prsut iz Drnisa", Sku="M7767", InStock = 64, Price = 3.99m}
        };

        builder.Entity<Product>().HasData(mainProducts);

        List<ProductCategory> mainProductCategories = new List<ProductCategory>()
        {
            new ProductCategory() {Id =1, ProductId=100, CategoryId=3},
            new ProductCategory() {Id =2, ProductId=101, CategoryId=4},
            new ProductCategory() {Id =3, ProductId=102, CategoryId=6},
            new ProductCategory() {Id =4, ProductId=103, CategoryId=5},
            new ProductCategory() {Id =5, ProductId=104, CategoryId=1},
        };

        builder.Entity<ProductCategory>().HasData(mainProductCategories);
    }
}
