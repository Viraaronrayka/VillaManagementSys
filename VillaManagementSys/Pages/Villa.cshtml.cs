using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaManagementSys.Db;

namespace VillaManagementSys.Pages
{
    public class VillaModel : PageModel
    {
        private readonly Db.VillaReservationContext _context = new VillaReservationContext();
        public List<VillaManagementSys.Db.Villa> villas;
        public void OnGet()
        {
            villas = _context.Villas.ToList();
        }
        public void OnPost()
        {
            
        }
    }
}
