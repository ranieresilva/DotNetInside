using DotNetInside.Dominio;
using DotNetInside.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DotNetInside.Razor.Pages.Cliente
{
    public class DeleteModel : PageModel
    {
        private readonly ClienteRepositorio _repositorio;

        public DeleteModel(ContextoBd contextoBd)
        {
            _repositorio = new ClienteRepositorio(contextoBd);
        }

        [BindProperty]
        public DotNetInside.Dominio.Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _repositorio.RecuperarClienteId(id.Value);

            if (Cliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente = await _repositorio.RecuperarClienteId(id.Value);

            if (Cliente != null)
            {
                await _repositorio.Excluir(Cliente);
            }

            return RedirectToPage("./Index");
        }
    }
}