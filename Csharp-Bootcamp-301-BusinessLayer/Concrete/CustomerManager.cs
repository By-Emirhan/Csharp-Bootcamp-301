using Csharp_Bootcamp_301_BusinessLayer.Abstract;
using Csharp_Bootcamp_301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_301_BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerService _customerService;
        public CustomerManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public void TDelete(Customer entity)
        {
            _customerService.TDelete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerService.TGetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerService.TGetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerSurname != "")
            {
                //Ekleme İşlemi Yapılır...
            }
            else
            {
                //Hata Bildirimi Verilir...
            }
        }

        public void TUpdate(Customer entity)
        {
            _customerService.TUpdate(entity);
        }
    }
}
