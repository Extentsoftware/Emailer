// See https://aka.ms/new-console-template for more information
using RazorLight.Razor;
using System.Text;

public class EntityFrameworkRazorProjectItem : RazorLightProjectItem
{
    private string _content;

    public EntityFrameworkRazorProjectItem(string key, string content)
    {
        Key = key;
        _content = content;
    }

    public override string Key { get; }

    public override bool Exists => _content != null;

    public override Stream Read()
    {
        return new MemoryStream(Encoding.UTF8.GetBytes(_content));
    }
}
