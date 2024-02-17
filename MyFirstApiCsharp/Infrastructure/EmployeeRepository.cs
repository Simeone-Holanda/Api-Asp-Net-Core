using MyFirstApiCsharp.Model;

namespace MyFirstApiCsharp.Infrastructure
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();
        public void Add(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
}
