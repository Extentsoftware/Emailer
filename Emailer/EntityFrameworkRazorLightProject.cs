// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using RazorLight.Razor;

public class EntityFrameworkRazorLightProject : RazorLightProject
{
    private readonly TemplateDbContext dbContext;

    public EntityFrameworkRazorLightProject(TemplateDbContext context)
    {
        dbContext = context;
    }

    public override async Task<RazorLightProjectItem> GetItemAsync(string templateKey)
    {
        BrandDesign template = await dbContext.LayoutDesign.FindAsync(templateKey);

        var projectItem = new EntityFrameworkRazorProjectItem(templateKey, template?.Content);

        return projectItem;
    }

    public override Task<IEnumerable<RazorLightProjectItem>> GetImportsAsync(string templateKey)
    {
        return Task.FromResult(Enumerable.Empty<RazorLightProjectItem>());
    }

    public override async Task<IEnumerable<string>> GetKnownKeysAsync()
    {
        var ids = await dbContext.LayoutDesign.Select(x => x.Name).ToListAsync();
        return ids.Select(x => x.ToString());
    }
}
