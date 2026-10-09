using Demo.Models;

namespace Demo.Repository;

public sealed class OrderRepository : Repository<Order>, IRepository<Order>
{
    public OrderRepository(ShopContext context) : base(context)
    {
    }
}
