using Demo.Models;

namespace Demo.Repository;

public sealed class CustomerRepository : Repository<Customer>, IRepository<Customer>
{
    public CustomerRepository(ShopContext context) : base(context)
    {
    }

    public IQueryable<Customer> ReadAllWithOrders()
    {
        return Context.Customers;
    }
}
