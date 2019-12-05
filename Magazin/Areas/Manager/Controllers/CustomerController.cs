using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Domain;
using Magazin.Areas.Manager.Models;
using Magazin.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Service.Services;
using Magazin.Controllers;

namespace Magazin.Areas.Manager.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CustomerController : MyController
    {
        public ICustomerService customerService;

        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        public ActionResult Index()
        {
            IEnumerable<Customer> customers = customerService.GetCustomers();
            var customerLMs = Mapper.Map<IEnumerable<Customer>, List<CustomerListModel>>(customers);
            return View(customerLMs);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerCreateModel customerCM)
        {
            // ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            //        IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            //        if (result.Succeeded)
            //        {
            //            ApplicationRole roleManager = RoleManager.FindByName("Manager");
            //            UserManager.AddToRole(user.Id, roleManager.Name);
            //            return RedirectToAction("Create", "Customer");
            //        }  return RedirectToAction("Create", "Customer");
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = customerCM.Email, Email = customerCM.Email };
                IdentityResult result = await UserManager.CreateAsync(user, customerCM.Password);
                if (result.Succeeded)
                {
                    ApplicationRole roleManager = RoleManager.FindByName("Customer");
                    UserManager.AddToRole(user.Id, roleManager.Name);
                    Customer customer = Mapper.Map<CustomerCreateModel, Customer>(customerCM);
                    customerService.CreateCustomer(customer);
                    return RedirectToAction("Create", "Customer");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(customerCM);
        }

        public ActionResult Details(string code)
        {
            Customer model = customerService.GetCustomerByCode(code);
            var customer = Mapper.Map<Customer, CustomerViewModel > (model);         
            return View(customer);
        }

        public ActionResult Edit(string code)
        {
            Customer model = customerService.GetCustomerByCode(code);
            var customer = Mapper.Map<Customer, CustomerEditModel>(model);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditModel customerEM)
        {
            Customer customer = customerService.GetCustomerByCode(customerEM.Code);
            customer.Name = customerEM.Name;
            customer.Address = customerEM.Address;
            customer.Discount = customerEM.Discount;
            customerService.EditCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}