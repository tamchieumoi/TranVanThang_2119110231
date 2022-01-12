using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class AreaDAO : DBConnection
    {
        public List<AreaDTO> ReadAreaList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<AreaDTO> lstArea = new List<AreaDTO>();
            while (reader.Read())
            {
                AreaDTO area = new AreaDTO();
                area.Madonvi = int.Parse(reader["IdDepartment"].ToString());
                area.Tendonvi = reader["Name"].ToString();
                lstArea.Add(area);
            }
            conn.Close();
            return lstArea;
        }
        public AreaDTO ReadArea(int id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department where IdDepartment=" + id.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();

            AreaDTO area = new AreaDTO();

            if (reader.HasRows && reader.Read())
            {
                area.Madonvi = int.Parse(reader["IdDepartment"].ToString());
                area.Tendonvi = reader["Name"].ToString();
            }
            conn.Close();
            return area;
        }
    }
}
