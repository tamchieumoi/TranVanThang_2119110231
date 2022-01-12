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
        public List<EmployeeDTO> ReadCustomer()
        {
            List<EmployeeDTO> lstCus = dao.ReadCustomer();
            return lstCus;
        }
        public void AddEmployee(EmployeeDTO cus)
        {
            dao.AddEmployee(cus);
        }
        public void DeleteEmployee(EmployeeDTO cus)
        {
            dao.DeleteEmployee(cus);
        }
        public void EditEmployee(EmployeeDTO cus)
        {
            dao.EditEmployee(cus);
        }
    }
}
