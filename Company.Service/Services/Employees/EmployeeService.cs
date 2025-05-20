using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Helper;
using Company.Service.Interfaces.Employees;
using Company.Service.Interfaces.Employees.Dto;

namespace Company.Service.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Add(EmployeeDto employeeDto)
        {
            //Manual Mapping

            //Employee mappedEmployee = new Employee
            //{

            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Salary = employeeDto.Salary,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Address = employeeDto.Address,
            //    DepartmentId = employeeDto.DepartmentId,
            //};

            employeeDto.ImageUrl = DocumentSettings.UploadFile(employeeDto.Image,"Images");
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }
        

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{

            //    Name = employeeDto.Name,
            //    Age = employeeDto.Age,
            //    Salary = employeeDto.Salary,
            //    Email = employeeDto.Email,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,

            //    DepartmentId = employeeDto.DepartmentId,
            //};

            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employees = _unitOfWork.EmployeeRepository.GetAll();
            // mapp from Employee to EmployeeDto

            //var mappedEmployee = employees.Select(x => new EmployeeDto { 
            
            //    DepartmentId = x.DepartmentId,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Email = x.Email,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CeateAt =x.CreateAt
            
            
            //});


           IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id is null)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);

            if (employee is null)
                return null;

            //EmployeeDto employeeDto = new EmployeeDto
            //{

            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Salary = employee.Salary,
            //    Email = employee.Email,
            //    PhoneNumber = employee.PhoneNumber,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    Address = employee.Address,
            //    CeateAt =employee.CreateAt,
            //    Id = employee.Id,
            //    DepartmentId = employee.DepartmentId,
            //};


            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
           var employees = _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            var mappedEmployee = employees.Select(x => new EmployeeDto
            {

                DepartmentId = x.DepartmentId,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                Email = x.Email,
                Salary = x.Salary,
                Id = x.Id,
                Address = x.Address,
                Age = x.Age,
                CeateAt = x.CreateAt


            });
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public void Update(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }
    }
}
