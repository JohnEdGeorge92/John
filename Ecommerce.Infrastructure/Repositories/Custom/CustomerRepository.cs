using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces.Repositories;
using Ecommerce.DataTransferObjects.Filters;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGas.Infrastructure.Repositories.Custom
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    { 
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Customer> buildCustomerQuery(CustomerFilter CustomerFilter)
        {
            var query = Query();
            if(CustomerFilter != null)
            {
                if (CustomerFilter.Id != null && CustomerFilter.Id != 0)
                    query = query.Where(x => x.Id == CustomerFilter.Id);

                if (!String.IsNullOrEmpty(CustomerFilter.Name))
                    query = query.Where(x => x.Name == CustomerFilter.Name);

                if (!String.IsNullOrEmpty(CustomerFilter.Email))
                    query = query.Where(x => x.Email == CustomerFilter.Email);

                if (!String.IsNullOrEmpty(CustomerFilter.Address))
                    query = query.Where(x => x.Address == CustomerFilter.Address);

            }
            return query;

        }
    }
}
