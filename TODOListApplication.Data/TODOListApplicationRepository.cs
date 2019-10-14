using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data
{
    public class TODOListApplicationRepository: EfGenericRepository<ToDoDbContext>, ITodoListApplicationRepository
    {
        public TODOListApplicationRepository() : base(new ToDoDbContext() { })
        {

        }
    }
}
