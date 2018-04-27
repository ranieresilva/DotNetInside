using DotNetInside.Repositorio;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetInside.Razor.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly ClienteRepositorio _repositorio;

        public IndexModel(ContextoBd contextoBd)
        {
            _repositorio = new ClienteRepositorio(contextoBd);
        }

        public IList<DotNetInside.Dominio.Cliente> Cliente { get; set; }

        public async Task OnGetAsync()
        {
            Cliente = await _repositorio.RecuperarClientes();
        }
    }
}
