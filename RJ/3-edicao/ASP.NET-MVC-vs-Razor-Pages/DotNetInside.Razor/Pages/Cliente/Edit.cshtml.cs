using DotNetInside.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DotNetInside.Razor.Pages.Cliente
{
    public class EditModel : PageModel
    {
        private readonly ClienteRepositorio _repositorio;

        public EditModel(ContextoBd contextoBd)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _repositorio.Alterar(Cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _repositorio.RecuperarClienteId(Cliente.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}