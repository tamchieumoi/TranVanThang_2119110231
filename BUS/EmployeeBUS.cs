using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class EmployeeBUS
    {
        EmployeeDAO dao = new EmployeeDAO();
        public List<EmployeeDTO> ReadEmployee()
        {
            List<EmployeeDTO> lstEmpl = dao.ReadEmployee();
            return lstEmpl;
        }
        public void AddEmployee(EmployeeDTO empl)
        {
            dao.AddEmployee(empl);
        }
        public void DeleteEmployee(EmployeeDTO empl)
        {
            dao.DeleteEmployee(empl);
        }
        public void EditEmployee(EmployeeDTO empl)
        {
            dao.EditEmployee(empl);
        }
    }
}
