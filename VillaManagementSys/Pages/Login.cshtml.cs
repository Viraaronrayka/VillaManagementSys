using Microsoft.AspNetCore.Mvc.RazorPages;
using VillaManagementSys.Db;

namespace VillaManagementSys.Pages
{
    public class LoginModel : PageModel
    {
        private readonly VillaReservationContext _context = new VillaReservationContext();
        public void OnGet()
        {

        }
        public void OnPost()
        {

            string username = Request.Form["txtUsername"].ToString();
            string password = Request.Form["Password"].ToString();
            try
            {
                User? loggedinUser = _context.Users.Where(u => u.Username == username && u.Password == password).SingleOrDefault();

                // اگر کاربر نام کاربری و گذرواژه را صحیح وارد کرده باشد
                if (loggedinUser != null)
                {
                    ViewData["LoggedInUser"] = loggedinUser;
                    int id = loggedinUser.Id;
                    // استخراج کلیه نقش های کاربر لاگین کرده جاری
                     List<UserRole> userRoles = _context.UserRoles.Where(ur => ur.UserId == id).ToList();
                    int adminRoleId = 1;
                    if (userRoles.Count() > 0)
                    {
                        if(userRoles.Where(r => r.RoleId == adminRoleId).Count() > 0)
                        {
                            // این کاربر ادمین است
                            ViewData["IsAdmin"] = true;
                        }
                    }
                }
                else
                {
                    ViewData["Message"] = "ورود ناموفق به سیستم. نام کاربری یا گذراژه خود را بررسی نماید";
                }
            }
            catch(Exception ex)
            {
                ViewData["Error"] = ex.Message;
            }

        }
    }
}
