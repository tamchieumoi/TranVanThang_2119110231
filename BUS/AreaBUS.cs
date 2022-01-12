using System;
using System.Collections.Generic;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class AreaBUS
    {
        AreaDAO dao = new AreaDAO();
        public List<AreaDTO> ReadAreaList()
        {
            List<AreaDTO> lstArea = dao.ReadAreaList();
            return lstArea;
        }
    }
}
