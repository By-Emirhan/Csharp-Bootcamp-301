using Csharp_Bootcamp_301_DataAccessLayer.Abstract;
using Csharp_Bootcamp_301_DataAccessLayer.Repositories;
using Csharp_Bootcamp_301_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Bootcamp_301_DataAccessLayer.EntityFramework
{
    public class EfAdminDal:GenericRepository<Admin>, IAdminDal
    {
    }
}
