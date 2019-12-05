using AutoMapper;
using BusinessLayer.Domain;
using Magazin.Models;
using Magazin.Areas.Manager.Models;
using System;

namespace Magazin.App_Start
{
    public class MapperProfile : Profile
    {
        
        public MapperProfile()
        {
           
            CreateMap<Item, ItemListModel>().ReverseMap();
            CreateMap<Item, ItemListModelManager>().ReverseMap();
            CreateMap<Item, ItemCreateModel>().ReverseMap();
            CreateMap<Item, ItemEditModel>().ReverseMap();
            CreateMap<Item, ItemViewModel>().ReverseMap();         
            CreateMap<Order, OrderListModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, OrderEditModel>().ReverseMap();
            CreateMap<Order, MyOrdersModel>().ReverseMap();
            CreateMap<Order, MyOrderViewModel>().ReverseMap();
            CreateMap<Order, OrdersListForCustomer>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Customer, CustomerEditModel>().ReverseMap();
            CreateMap<Customer, CustomerListModel>().ForMember("Email", opt => opt.MapFrom(src => src.UserName)).ReverseMap();
            CreateMap<Customer, CustomerCreateModel>().ForMember("Email", opt => opt.MapFrom(src => src.UserName)).ReverseMap();
           
            


        }
    }
}