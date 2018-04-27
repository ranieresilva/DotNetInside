using DotNetInside.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace DotNetInside.Razor.Pages.Cliente
{
    public class DetailsModel : PageModel
    {
        private readonly ClienteRepositorio _repositorio;

        public DetailsModel(ContextoBd contextoBd)
        {
            _repositorio = new ClienteRepositorio(contextoBd);
        }

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
    }
}