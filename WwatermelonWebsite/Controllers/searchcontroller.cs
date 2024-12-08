using Microsoft.AspNetCore.Mvc;
using WwatermelonWebsite.Models;
using System.Linq;
using WwatermelonWebsite.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Xml;


namespace WwatermelonWebsite.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        List<BrandAction> brand_action_list = new List<BrandAction>();


        public SearchController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult Index(string query)
        {

            if (string.IsNullOrEmpty(query))
            {
                return View(); 
            }

            // remove any whitespace on left or right
            query = query.Trim();

            var results = _context.BrandActions
                .Where(b => b.Brand.Contains(query) || b.Action.Contains(query) || b.Why.Contains(query))
                .ToList();
            
            return View(results);
        }

        public IActionResult AllBrands()
        {

            // remove any whitespace on left or right

            GetBrandData();

            return View(brand_action_list); 
        }

        private void GetBrandData() {
            
            if(brand_action_list.Count > 0){
                brand_action_list.Clear();
            }
            try{
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = _configuration.GetConnectionString("DefaultConnection");
                conn.Open();
            
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM [dbo].BrandActions order by Brand asc";
                cmd.Connection = conn;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while(dr.Read()){
                    brand_action_list.Add(new BrandAction() {Brand = dr["Brand"].ToString(), 
                                                            Action = dr["Action"].ToString(), 
                                                            Why = dr["Why"].ToString()});
                }

                conn.Close();
            }
            catch(Exception){
                throw;
            }
            
        }
    }
}
