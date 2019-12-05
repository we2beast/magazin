using System;
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork: IDisposable
    {
        private EFDBContex context = new EFDBContex();
     
        private CustomerRepository _customerRepository;
        private ItemRepository _itemRepository;
        private OrderRepository _orderRepository;
        private OrderItemRepository _orderItemRepository;
        private CategoryRepository _categoryRepository;
        private StatusRepository _statusRepository;
        public CustomerRepository CustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                {
                    this._customerRepository = new CustomerRepository(context);
                }
                return _customerRepository;
            }
        }
        public ItemRepository ItemRepository
        {
            get
            {
                if (this._itemRepository == null)
                {
                    this._itemRepository = new ItemRepository(context);
                }
                return _itemRepository;
            }
        }
        public OrderRepository OrderRepository
        {
            get
            {
                if (this._orderRepository == null)
                {
                    this._orderRepository = new OrderRepository(context);
                }
                return _orderRepository;
            }
        }
        public OrderItemRepository OrderItemRepository
        {
            get
            {
                if (this._orderItemRepository == null)
                {
                    this._orderItemRepository = new OrderItemRepository(context);
                }
                return _orderItemRepository;
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this._categoryRepository == null)
                {
                    this._categoryRepository = new CategoryRepository(context);
                }
                return _categoryRepository;
            }
        }
        public StatusRepository StatusRepository
        {
            get
            {
                if (this._statusRepository == null)
                {
                    this._statusRepository = new StatusRepository(context);
                }
                return _statusRepository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
