using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace HR
{
    public partial class Employee : Form
    {
        EmployeeBUS cusBUS = new EmployeeBUS();
        AreaBUS areBUS = new AreaBUS();
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstCus = cusBUS.ReadCustomer();
            foreach (EmployeeDTO cus in lstCus)
            {
                dataGridView1.Rows.Add(cus.MaNhanVien, cus.Ten,cus.NgaySinh,cus.GioiTinh,cus.NoiSinh, cus.DonVi);
            }
            List<AreaDTO> lstArea = areBUS.ReadAreaList();
            foreach (AreaDTO area in lstArea)
            {
                cbdonvi.Items.Add(area);
            }
            cbdonvi.DisplayMember = "Madonvi";
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbmanv.Text = row.Cells[0].Value.ToString();
                tbtennv.Text = row.Cells[1].Value.ToString();
                dtngaysinh.Text = row.Cells[2].Value.ToString();
                chbgioitinh.Text = row.Cells[3].Value.ToString();
                tbnoisinh.Text = row.Cells[4].Value.ToString();
                cbdonvi.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (tbmanv.Text == "" && tbtennv.Text == "" && dtngaysinh.Text == "" && chbgioitinh.Text == "" && tbnoisinh.Text == "" && cbdonvi.Text == "")
            {
                    EmployeeDTO cus = new EmployeeDTO();
                    cus.MaNhanVien= tbmanv.Text;
                    cus.Ten = tbtennv.Text;
                    cus.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                    cus.GioiTinh = chbgioitinh.Text;
                    cus.NoiSinh = tbnoisinh.Text;
                    cus.DonVi = (AreaDTO)cbdonvi.SelectedItem;
                    cusBUS.AddEmployee(cus);
                    dataGridView1.Rows.Add(cus.MaNhanVien, cus.Ten,cus.NgaySinh,cus.GioiTinh,cus.NoiSinh, cus.DonVi.Tendonvi);

            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin nhân viên");
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row != null)
            {
                EmployeeDTO cus = new EmployeeDTO();
                cus.MaNhanVien = tbmanv.Text;
                cus.Ten = tbtennv.Text;
                cus.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                cus.GioiTinh = chbgioitinh.Text;
                cus.NoiSinh = tbnoisinh.Text;
                cus.DonVi = (AreaDTO)cbdonvi.SelectedItem;
                cusBUS.AddEmployee(cus);

                row.Cells[0].Value = cus.MaNhanVien;
                row.Cells[1].Value = cus.Ten;
                row.Cells[2].Value = cus.NgaySinh;
                row.Cells[3].Value = cus.GioiTinh;
                row.Cells[4].Value = cus.NoiSinh;
                row.Cells[5].Value = cus.DonVi;
            }
            else
                MessageBox.Show("Chọn nhân viên cần sửa");
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbmanv.Text == "" && tbtennv.Text == "" && dtngaysinh.Text == "" && chbgioitinh.Text == "" && tbnoisinh.Text == "" && cbdonvi.Text == "")
            {
                MessageBox.Show("Chọn nhân viên cần xoá");
            }
            else
            {
                if (MessageBox.Show("Bạn có muốn xoá", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EmployeeDTO cus = new EmployeeDTO();
                    cus.MaNhanVien = tbmanv.Text;
                    cus.Ten = tbtennv.Text;
                    cus.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                    cus.GioiTinh = chbgioitinh.Text;
                    cus.NoiSinh = tbnoisinh.Text;
                    cus.DonVi = (AreaDTO)cbdonvi.SelectedItem;

                    cusBUS.DeleteEmployee(cus);
                    int idx = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(idx);
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
