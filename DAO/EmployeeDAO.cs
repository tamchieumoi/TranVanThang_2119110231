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
            SqlCommand cmd = new SqlCommand("selectEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeDTO> lstEmpl = new List<EmployeeDTO>();
            EmployeeDAO employee = new EmployeeDAO();
            AreaDAO are = new AreaDAO();
            while (reader.Read())
            {
                EmployeeDTO empl = new EmployeeDTO();
                empl.MaNhanVien = reader["IdEmployee"].ToString();
                empl.Ten = reader["Name"].ToString();
                empl.NgaySinh = DateTime.Parse(reader["DateBirth"].ToString());
                empl.GioiTinh = reader["Gender"].ToString();
                empl.NoiSinh = reader["PlaceBirth"].ToString();
                empl.DonVi = are.ReadArea(int.Parse(reader["IdDepartment"].ToString()));
                lstEmpl.Add(empl);
            }
            conn.Close();
            return lstEmpl;
        }          

        public void AddEmployee(EmployeeDTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "AddEmployee";
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
        }
        public void EditEmployee(EmployeeDTO empl)
        {
            SqlConnection conn = CreateConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "EditEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;

                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = empl.MaNhanVien;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = empl.Ten;
                cmd.Parameters.Add("@DateBirth", SqlDbType.Date).Value = empl.NgaySinh;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = empl.GioiTinh;
                cmd.Parameters.Add("@PlaceBirth", SqlDbType.NVarChar).Value = empl.NoiSinh;
                cmd.Parameters.Add("@IdDepartment", SqlDbType.Int).Value = empl.DonVi.Madonvi;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine("Sua thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                conn.Close();
            }
        }

        public void DeleteEmployee(EmployeeDTO empl)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteEmployee";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@IdEmployee", SqlDbType.Int).Value = 1;
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Console.WriteLine("Xoa thanh cong !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Co loi xay ra !!!" + e);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
