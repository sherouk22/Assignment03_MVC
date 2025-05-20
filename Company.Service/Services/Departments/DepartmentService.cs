using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Departments;
using Company.Service.Interfaces.Departments.Dto;
using Company.Service.Interfaces.Employees.Dto;

namespace Company.Service.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

       

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new Department
            //{
            //    Code = departmentDto.Code,
            //    Name = departmentDto.Name,
            //    CreateAt = DateTime.Now,

            //};

            //_unitOfWork.DepartmentRepository.Add(mappedDepartment);
            //_unitOfWork.Complete();
            var mappedDepartment = _mapper.Map<Department>(departmentDto);
            mappedDepartment.CreateAt = DateTime.Now;
            _unitOfWork.DepartmentRepository.Add(mappedDepartment);

            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            var mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetAll()
        {
            var departments = _unitOfWork.DepartmentRepository.GetAll();
            IEnumerable<DepartmentDto> mappedDepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return mappedDepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;

            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);

            if( department is null )
                return null;

            var mappedDepartments = _mapper.Map<DepartmentDto>(department);
            return mappedDepartments;
           
        }

        public void Update(DepartmentDto department)
        {

            //_unitOfWork.DepartmentRepository.Update(department);

            ////var dept = GetById(department.Id);

            ////if (dept.Name != department.Name)
            ////{
            ////    if (GetAll().Any(x => x.Name == department.Name))
            ////        throw new Exception("DuplicationDepartmentName");
            ////}

            ////dept.Name = department.Name;
            ////dept.Code = department.Code;


            //_unitOfWork.Complete();
        }
    }
}
