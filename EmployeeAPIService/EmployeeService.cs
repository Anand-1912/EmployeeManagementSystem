using AutoMapper;
using EmployeeAPIService.Entities;
using EmployeeAPIService.Helpers;
using EmployeeAPIService.Model.Employee;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPIService
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Create(CreateRequest model);
        void Delete(int id);
        void Update(UpdateRequest model);    
    }
    public class EmployeeService : IEmployeeService
    {
        private DataContext _context;
        private IMapper _mapper;
        public EmployeeService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public void Create(CreateRequest model)
        {
            // validate

            if (isValid(model.Id, model.Email))
            { 
                // map model to new employee object
                var employee = _mapper.Map<Employee>(model);
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var employee = getEmployee(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees;
        }
        public Employee GetById(int id)
        {
            return getEmployee(id);
        }


        public void Update(UpdateRequest model)
        {
            var employee = getEmployee(model.Id);

            if (_context.Employees.Any(emp => emp.Email == model.Email && emp.Id != model.Id))
            {
                throw new AppException("Employee with this Email '" + model.Email
                    + "' already exists");
            }

            employee = _mapper.Map<Employee>(model);

            _context.SaveChanges();
           
        }
        private Employee getEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) throw new KeyNotFoundException("Employee not found");
            return employee;
        }

        private bool isValid(int id, string email)
        {
            if (_context.Employees.Any(x => x.Id == id)) 
            {
                throw new AppException("Employee with this Id '" + id
                    + "' already exists");
            }
            if (_context.Employees.Any(x => x.Email == email))
            {
                throw new AppException("Employee with this Email '" + email
                    + "' already exists");
            }
            else
            {
                return true;
            }

        }
    }
}
