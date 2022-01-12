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
        EmployeeBUS emplBUS = new EmployeeBUS();
        AreaBUS areaBUS = new AreaBUS();
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstEmpl = emplBUS.ReadEmployee();
            foreach (EmployeeDTO empl in lstEmpl)
            {
                dataGridView1.Rows.Add(empl.MaNhanVien, empl.Ten, empl.NgaySinh, empl.GioiTinh, empl.NoiSinh, empl.DonVi.Tendonvi);
            }
            List<AreaDTO> lstArea = areaBUS.ReadAreaList();
            foreach (AreaDTO area in lstArea)
            {
                cbdonvi.Items.Add(area);
            }
            cbdonvi.DisplayMember = "Tendonvi";
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
            if (tbmanv.Text != "" && tbtennv.Text != "" && dtngaysinh.Text != "" && chbgioitinh.Text != "" && tbnoisinh.Text != "" && cbdonvi.Text != "")
            {
                    EmployeeDTO empl = new EmployeeDTO();
                    empl.MaNhanVien= tbmanv.Text;
                    empl.Ten = tbtennv.Text;
                    empl.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                    empl.GioiTinh = chbgioitinh.Text;
                    empl.NoiSinh = tbnoisinh.Text;
                    empl.DonVi = (AreaDTO)cbdonvi.SelectedItem;
                    emplBUS.AddEmployee(empl);
                    dataGridView1.Rows.Add(empl.MaNhanVien, empl.Ten, empl.NgaySinh, empl.GioiTinh, empl.NoiSinh, empl.DonVi.Tendonvi);

            }
            else
                MessageBox.Show("Nhập đầy đủ thông tin nhân viên");
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (row != null)
            {
                EmployeeDTO empl = new EmployeeDTO();
                empl.MaNhanVien = tbmanv.Text;
                empl.Ten = tbtennv.Text;
                empl.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                empl.GioiTinh = chbgioitinh.Text;
                empl.NoiSinh = tbnoisinh.Text;
                empl.DonVi = (AreaDTO)cbdonvi.SelectedItem;
                emplBUS.AddEmployee(empl);

                row.Cells[0].Value = empl.MaNhanVien;
                row.Cells[1].Value = empl.Ten;
                row.Cells[2].Value = empl.NgaySinh;
                row.Cells[3].Value = empl.GioiTinh;
                row.Cells[4].Value = empl.NoiSinh;
                row.Cells[5].Value = empl.DonVi.Tendonvi;
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
                if (MessageBox.Show("Bạn có chắc chắn muốn xoá", "Thông báo",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EmployeeDTO empl = new EmployeeDTO();
                    empl.MaNhanVien = tbmanv.Text;
                    empl.Ten = tbtennv.Text;
                    empl.NgaySinh = DateTime.Parse(dtngaysinh.Value.Date.ToString());
                    empl.GioiTinh = chbgioitinh.Text;
                    empl.NoiSinh = tbnoisinh.Text;
                    empl.DonVi = (AreaDTO)cbdonvi.SelectedItem;

                    emplBUS.DeleteEmployee(empl);
                    int idx = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(idx);
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (f == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
