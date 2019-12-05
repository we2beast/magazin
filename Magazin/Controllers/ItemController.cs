using System.Collections.Generic;
using System.Web.Mvc;
using Magazin.Models;
using Service.Services;
using BusinessLayer.Domain;
using Magazin.Infrastructure;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace Magazin.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ItemController : MyController
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        private IItemService itemService;
        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await UserManager.FindByEmailAsync(User.Identity.Name);
            if (user != null)
            {
                IEnumerable<Item> items = itemService.GetItemsWithDiscount(user.UserName);
                var itemVMs = Mapper.Map<IEnumerable<Item>, List<ItemListModel>>(items);
                return View(itemVMs);
            }
            return View();
        }
    }
}