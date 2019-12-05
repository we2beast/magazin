using System.Web.Mvc;
using AutoMapper;
namespace Magazin.Controllers
{
    public class MyController : Controller
    {
        private IMapper _mapper = null;
        protected IMapper Mapper
        {
            get
            {
                if (_mapper == null) _mapper = MvcApplication.MapperConfiguration.CreateMapper();
                return _mapper;
            }
        }
    }
}