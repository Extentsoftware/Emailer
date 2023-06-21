using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var options = new DbContextOptionsBuilder<TemplateDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDatabase")
           .Options;

        // Create and fill database with test data
        var db = new TemplateDbContext(options);
        FillDatabase(db);

        HtmlContentGenerator generator = new HtmlContentGenerator(db);


        var result1 = await generator.AddDescriptionAsync(new { Template = "OpportunityClosed", Layout = "France",              Date = "11 November 2022" });
        var result2 = await generator.AddDescriptionAsync(new { Template = "OpportunityClosed", Layout = "Constructionline",    Date = "11 November 2022" });
        var result3 = await generator.AddDescriptionAsync(new { Template = "NewOpportunity",    Layout = "France",              Title = "Some Text" });

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(result3);

    }


    static void FillDatabase(TemplateDbContext dbContext)
    {

        dbContext.Layout.Add(new Layout
        {
            Name = "Standard"
        });

        dbContext.Brand.Add(new Brand
        {
            BrandId = 1, 
            Name = "Constructionline",
            Selector = "Community='Constructionline'"
        });

        dbContext.Brand.Add(new Brand
        {
            BrandId = 2,
            Name = "OnceForAll",
            Selector = "Community='France'"
        });


        dbContext.BrandDesign.Add(new BrandDesign
        { 
            Language = "fr",
            BrandId = 1,
            Content = @"<html>some french text<img src='Constructionline'></img> @RenderBody() </html>"
        });

        dbContext.BrandDesign.Add(new BrandDesign
        {
            Language = "en",
            BrandId = 1,
            Content = @"<html>some english text<img src='Constructionline'></img> @RenderBody() </html>"
        });

        dbContext.BrandDesign.Add(new BrandDesign
        {
            Language = "fr",
            BrandId = 2,
            Content = @"<html>some french text<img src='AllForOne'></img> @RenderBody() </html>"
        });

        dbContext.BrandDesign.Add(new BrandDesign
        {
            Language = "en",
            BrandId = 2,
            Content = @"<html>some english text<img src='AllForOne'></img> @RenderBody() </html>"
        });

        dbContext.Layout.Add(new BrandDesign
        {
            Name = "NewOpportunity",
            Content = 
@"
@{
    Layout = @Model.Layout;
}
<body> New Opportunity! @Model.Title </body>"
        });

        dbContext.LayoutDesign.Add(new BrandDesign
        {
            Name = "OpportunityClosed",
            Content = 
@"
@{
    Layout = @Model.Layout;
}
<body> Opportunity is now closed on @Model.Date </body>"
        });
    }
}