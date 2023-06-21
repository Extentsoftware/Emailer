// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

//This is simple POCO that represents your template that is stored in database

public class Layout
{
    [Key]
    public long LayoutId { get; set; }

    [Required]
    public string Name { get; set; }
}

public class Brand
{
    [Key]
    public long BrandId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Selector { get; set; }  // <== select brand based on metadata, e.g. communityid

}


public class BrandDesign
{
    [Key]
    public long LayoutDesignId { get; set; }

    [Required]
    public string Selector { get; set; }  // <== associate design with brand

    [Required]
    public string Language { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public bool IsPublished { get; set; }

    [Required]
    public bool IsPreProduction { get; set; }
    public int BrandId { get; internal set; }
}

public class EmailDesign
{
    [Key]
    public long EmailDesign { get; set; }

    
    public long LayoutDesignId { get; set; }

    [Required]
    public string Selector { get; set; }  // <== associate design with brand

    [Required]
    public string Language { get; set; }
    
    [Required]
    public string Subject { get; set; }

    [Required]
    public string Content { get; set; }

    [Required]
    public bool IsPublished { get; set; }

    [Required]
    public bool IsPreProduction { get; set; }

}

