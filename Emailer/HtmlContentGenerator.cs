using RazorLight;
using System.Dynamic;

public class HtmlContentGenerator
{
    private readonly RazorLightEngine _razorEngine;
    
    public HtmlContentGenerator(TemplateDbContext db)
    {

        var project = new EntityFrameworkRazorLightProject(db);
        
        _razorEngine = new RazorLightEngineBuilder()
            .UseMemoryCachingProvider()
            .UseProject(project)
            .Build();
    }

    public async Task<string> AddDescriptionAsync(dynamic metadata)
    {
        var template = metadata.Template;
        string htmlContent = await _razorEngine.CompileRenderAsync(template, metadata);
        return htmlContent;
    }
}
