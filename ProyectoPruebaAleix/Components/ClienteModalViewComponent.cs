using Microsoft.AspNetCore.Mvc;
using ProyectoPruebaAleix.Models;
using System.Threading.Tasks;

namespace ProyectoPruebaAleix.Components
{
    public class ClienteModalViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ModalInformationModel oModalInformationModel)
        {
            return View(oModalInformationModel);
        }
    }
}
