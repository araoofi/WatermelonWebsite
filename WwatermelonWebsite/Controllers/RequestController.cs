using Microsoft.AspNetCore.Mvc;
using WwatermelonWebsite.Models;
using WwatermelonWebsite.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WwatermelonWebsite.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        

        List<RequestModel> open_requests_list = new List<RequestModel>();

    

        public RequestController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public IActionResult OpenRequests()
        {
            GetOpenRequests();
            return View(open_requests_list);
        }

        RequestsDBAccessLayer reqdb = new RequestsDBAccessLayer();

        [HttpGet]
        public IActionResult Submit(){
            return View();
        }

        [HttpPost]
        public IActionResult Submit([Bind] RequestModel reqmodel)
        {
            try{
                if (ModelState.IsValid){
                    
                    string resp = reqdb.AddRequest(reqmodel);
                    if(resp != null) {
                        return View("ThankYou");
                    }
                    else{
                        TempData["Msg"] = "Error. Could Not Complete Command.";
                    }
                    
                }
            }
            catch (Exception ex){
                TempData["Msg"] = ex.Message;
            }
            return View();
        }

        private void GetOpenRequests(){
            if(open_requests_list.Count > 0){
                open_requests_list.Clear();
            }
            try {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
                conn.Open();
            
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM [dbo].Requests WHERE Status not like 'Closed' ORDER BY BrandRequest ASC";
                cmd.Connection = conn;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while(dr.Read()){
                    open_requests_list.Add(new RequestModel() {BrandRequest = dr["BrandRequest"].ToString(), 
                                                            DateAdded = dr["DateAdded"].ToString(), 
                                                            Status = dr["Status"].ToString()});
                }

                conn.Close();
            }
            catch(Exception){
                throw;
            }
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}
