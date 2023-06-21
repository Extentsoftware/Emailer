using Microsoft.EntityFrameworkCore;

public class TemplateDbContext : DbContext
{
    public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
    {
    }

    public DbSet<Brand> Brand { get; set; }                     // e.g. constructionline
    public DbSet<BrandDesign> BrandDesign { get; set; }         // designs for each brand in each language
    public DbSet<Layout> Layout { get; set; }
}
