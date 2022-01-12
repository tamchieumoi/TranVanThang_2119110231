using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class EmployeeDTO
    {
        public string MaNhanVien { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string NoiSinh { get; set; }

        public AreaDTO DonVi { get; set; }
        public string AreaName
        {
            get { return DonVi.Tendonvi; }
        }
    }
}
