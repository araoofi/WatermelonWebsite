using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;  
using System.Data;  
using Microsoft.Data.SqlClient;  
using WwatermelonWebsite.Models;
using WwatermelonWebsite.Controllers;

namespace WwatermelonWebsite.Models  
{  
    public class RequestsDBAccessLayer  
    {  
        SqlConnection conn = new SqlConnection("Server=tcp:project-watermelon.database.windows.net,1433;Initial Catalog=ProjectWatermelon;Persist Security Info=False;User ID=araoofi;Password=Password!234;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");  
        public string AddRequest(RequestModel requestModel)  
        {  
            try  
            {  
                SqlCommand cmd = new SqlCommand("sp_RequestAdd",conn);  
                cmd.CommandType = CommandType.StoredProcedure;  
                cmd.Parameters.AddWithValue("@EmailAddress", requestModel.EmailAddress);  
                cmd.Parameters.AddWithValue("@BrandRequest", requestModel.BrandRequest);  
                cmd.Parameters.AddWithValue("@IsCorrection", requestModel.IsCorrection);  
                cmd.Parameters.AddWithValue("@CorrectionDetails", requestModel.CorrectionDetails);  
                conn.Open();  
                cmd.ExecuteNonQuery();  
                conn.Close();  
                return "Data save Successfully";  
            }  
            catch(Exception ex)  
            {  
                if(conn.State==ConnectionState.Open)  
                {  
                    conn.Close();  
                }  
                return ex.Message.ToString();  
            }  
        }  
    }  
}  