using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetInside.Razor.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
        }
    }
}
