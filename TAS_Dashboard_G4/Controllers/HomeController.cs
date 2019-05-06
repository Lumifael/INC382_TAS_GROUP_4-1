using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TAS_Dashboard_G4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Setting connection to Azure database

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "inc382.database.windows.net";
            builder.UserID = "inc382";
            builder.Password = "INC@kmutt";
            builder.InitialCatalog = "inc382";


            using (SqlConnection connection = new
            SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM dbo.Production");
                String sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Get data from database
                // :: Production ID
                List<int> production_id = new List<int>();
                // :: Yield
                List<int> yield = new List<int>();

                // TO DO - Capacity, Loss, Reject, OEE
                List<int> capacity = new List<int>();
                List<int> loss = new List<int>();
                List<int> reject = new List<int>();
                List<int> oee = new List<int>();


                while (reader.Read())
                {
                    production_id.Add(Convert.ToInt32(reader.GetValue(1)));
                    yield.Add(Convert.ToInt32(reader.GetValue(2)));
                    // :: TO DO - Capacity, Loss, Reject, OEE
                    capacity.Add(Convert.ToInt32(reader.GetValue(3)));
                    loss.Add(Convert.ToInt32(reader.GetValue(4)));
                    reject.Add(Convert.ToInt32(reader.GetValue(5)));
                    oee.Add(Convert.ToInt32(reader.GetValue(6)));

                }

                // ViewBag just transfer data from controller -> view, will be null if redirect
                ViewBag.productionid = production_id;
                ViewBag.yield = yield;
                // TO DO - Capacity, Loss, Reject, OEE
                ViewBag.capacity = capacity;
                ViewBag.loss = loss;
                ViewBag.reject = reject;
                ViewBag.oee = oee;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}