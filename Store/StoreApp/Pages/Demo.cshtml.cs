using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.Pages
{

    public class DemoModel : PageModel
    {
        public string? FullName => HttpContext?.Session?.GetString("name");

        public void OnGet()
        {
        }

        public void OnPost([FromForm] string name)
        {
            HttpContext.Session.SetString("name", name);
        }
    }
}
