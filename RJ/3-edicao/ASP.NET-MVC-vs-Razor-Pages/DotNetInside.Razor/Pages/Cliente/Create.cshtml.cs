using DotNetInside.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DotNetInside.Razor.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        private readonly ClienteRepositorio _repositorio;

        public CreateModel(ContextoBd contextoBd)
        {
            _repositorio = new ClienteRepositorio(contextoBd);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DotNetInside.Dominio.Cliente Cliente { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repositorio.Incluir(Cliente);

            return RedirectToPage("./Index");
        }
    }
}