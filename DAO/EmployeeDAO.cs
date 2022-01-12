using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DTO;


namespace DAO
{
    public class EmployeeDAO : DBConnection
    {
        public List<EmployeeDTO> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeDTO> lstCus = new List<EmployeeDTO>();
            AreaDAO are = new AreaDAO();
            while (reader.Read())
            {
                EmployeeDTO cus = new EmployeeDTO();
                cus.MaNhanVien = reader["IdEmployee"].ToString();
                cus.Ten = reader["Name"].ToString();
                cus.NgaySinh = DateTime.Parse(reader["DateBirth"].ToString());
                cus.GioiTinh = reader["Gender"].ToString();
                cus.NoiSinh = reader["PlaceBirth"].ToString();
                cus.DonVi = are.ReadArea(int.Parse(reader["IdDepartment"].ToString()));
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }

        public void AddEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "NewEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = cus.MaNhanVien;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = cus.Ten;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = cus.NgaySinh;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = cus.GioiTinh;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = cus.NoiSinh;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = cus.DonVi.Madonvi;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Them thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                conn.Close();
            }
        /*            SqlConnection conn = CreateConnection();
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Employee values(@IdEmployee,@Name,@DateBirth,@Gender,@PlaceBirth,@IdDepartment)", conn);
                    cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.MaNhanVien));
                    cmd.Parameters.Add(new SqlParameter("@Name", cus.Ten));
                    cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.NgaySinh));
                    cmd.Parameters.Add(new SqlParameter("@Gender", cus.GioiTinh));
                    cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.NoiSinh));
                    cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.DonVi.Madonvi));

                    cmd.ExecuteNonQuery();
                    conn.Close();*/
    }
            public void EditEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Employee set Name =@Name, DonVi=@IdDepartment where IdNhanVien=@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.MaNhanVien));
            cmd.Parameters.Add(new SqlParameter("@Name", cus.Ten));
            cmd.Parameters.Add(new SqlParameter("@DateBirth", cus.NgaySinh));
            cmd.Parameters.Add(new SqlParameter("@Gender", cus.GioiTinh));
            cmd.Parameters.Add(new SqlParameter("@PlaceBirth", cus.NoiSinh));
            cmd.Parameters.Add(new SqlParameter("@IdDepartment", cus.DonVi.Madonvi));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where IdNhanVien =@IdEmployee", conn);
            cmd.Parameters.Add(new SqlParameter("@IdEmployee", cus.MaNhanVien));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
