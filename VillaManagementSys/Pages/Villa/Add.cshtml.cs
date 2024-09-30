using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaManagementSys.Classes;
using VillaManagementSys.Db;

namespace VillaManagementSys.Pages.Villa
{
    /// <summary>
    /// 
    /// </summary>
    public class AddModel : PageModel
    {
        private VillaReservationContext _context;
        /// <summary>
        /// کلیه شهرها را در خود دارد
        /// </summary>
        public List<City> Cities;
        public void OnGet()  
        {
            if(_context == null)
                _context = new VillaReservationContext();
            
        }
        /// <summary>
        /// 
        /// </summary>
        public void OnPost()
        {
            if (_context == null)
                _context = new VillaReservationContext();
            VillaManagementSys.Db.Villa villa = new VillaManagementSys.Db.Villa();
            villa.Name = Request.Form["txtName"].ToString();

            byte result;
            
            bool isSucceded=  Byte.TryParse(Request.Form["txtCapacity"].ToString(),out result );
            //villa.Capacity = (isSucceded == true ? result : (byte)0);
            if (isSucceded)
            {
                villa.Capacity = result;
                short area;
                isSucceded = short.TryParse( Request.Form["txtArea"].ToString(),out area);
                villa.Area = area;
                villa.Address = Request.Form["txtAddress"].ToString();
                villa.Status = Settings.Status.Unconfirmed;
                villa.CityId = int.Parse( Request.Form["ddlCity"].ToString());
                _context.Villas.Where(v => v.ChamberNo > 2).Take(10).ToList();
                VillaManagementSys.Db.Villa myVilla = new VillaManagementSys.Db.Villa();
                myVilla.Capacity = 4;
                
                _context.SaveChanges();
            }
            else
            {
                ViewData["Message"] = "مقدار صحیح در ظرفیت اتاق وارد نمایید";
            }

           
        }
    }
}
