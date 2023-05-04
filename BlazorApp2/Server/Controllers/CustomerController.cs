using BlazorApp2.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorApp2.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext db;

        public CustomersController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpPut("{id}")]
        public async Task<Customer> Put(Guid id, [FromBody] Customer cust)
        {
            var edit = await db.Customer.FindAsync(id);
            if (edit != null)
            {
                edit.name = cust.name;
                edit.address = cust.address;
                edit.zip = cust.zip;
                await db.SaveChangesAsync();
            }
            return edit;
        }

        [HttpDelete("{id}")]
        public async Task<Customer> Delete(Guid id)
        {
            var delete = await db.Customer.FindAsync(id);
            if (delete != null)
            {
                db.Customer.Remove(delete);
                await db.SaveChangesAsync();
            }
            return delete;
        }

        [HttpPost]
        public async Task<Customer> Post([FromBody] Customer create)
        {
            create.id = Guid.NewGuid();
            EntityEntry<Customer> cust = await db.Customer.AddAsync(create);
            await db.SaveChangesAsync();
            return cust.Entity;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get(string name)
        {
            return await Task.Factory.StartNew<IEnumerable<Customer>>(() =>
            {
                if (string.IsNullOrEmpty(name))
                    return db.Customer;
                else
                    return db.Customer.Where(x => x.name.Contains(name));
            });
        }

        [HttpGet("{id}")]
        public async Task<Customer> Get(Guid id)
        {
            return await db.Customer.FindAsync(id);
        }
    }
}
