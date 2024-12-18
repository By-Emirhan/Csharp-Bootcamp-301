using Csharp_Bootcamp_301_BusinessLayer.Abstract;
using Csharp_Bootcamp_301_DataAccessLayer.Abstract;
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
        private readonly ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
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
            _customerDal.Update(entity);
        }
    }
}
