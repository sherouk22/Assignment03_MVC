using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.Data.Models;
using Company.Repository.Repositories;

namespace Company.Repository.Interfaces
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
      
    }
}
