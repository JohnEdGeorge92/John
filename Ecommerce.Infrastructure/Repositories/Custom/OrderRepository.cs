using Ecommerce.Core.Entities;
using Ecommerce.Core.Interfaces.Repositories;
using Ecommerce.DataTransferObjects.Filters;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboGas.Infrastructure.Repositories.Custom
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }

        public IQueryable<Order> buildOrderQuery(OrderFilter OrderFilter)
        {
            var query = Query();
            query = query.Include(x => x.Customer).Include(x => x.OrdersLine).ThenInclude(x => x.Product);
            if (OrderFilter != null)
            {
                if (OrderFilter.Id != null && OrderFilter.Id != 0)
                    query = query.Where(x => x.Id == OrderFilter.Id);

                if (OrderFilter.CustomerId != null && OrderFilter.CustomerId != 0)
                    query = query.Where(x => x.CustomerId == OrderFilter.CustomerId);

                if (OrderFilter.Status != null && OrderFilter.Status != 0)
                    query = query.Where(x => x.Status == OrderFilter.Status);

                if (OrderFilter.OrderDate != null)
                    query = query.Where(x => x.OrderDate == OrderFilter.OrderDate);
            }
            return query;

        }
    }
}
