using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Data.SqlClient;
using TestService.Models;
using System.Configuration;
using System.Data;

namespace TestService
{
    /// <summary>
    /// Summary description for Webservice
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class Webservice : System.Web.Services.WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World!";
        }

        [WebMethod]
        public ProductModel GetProductId(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetDetailProduct";
                cmd.Parameters.Add(new SqlParameter("@id", id));
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ProductModel obj = new ProductModel()
                    {
                        ProductId = Convert.ToInt32(rdr["ProductId"]),
                        ProductName = rdr["ProductName"].ToString(),
                        ProductUrl = rdr["ProductUrl"].ToString(),
                        Brand = rdr["Brand"].ToString(),
                        ImageSrc = rdr["ImageSrc"].ToString(),
                        ImageAlt = rdr["ImageAlt"].ToString(),
                        Quantity = Convert.ToInt32(rdr["Quantity"]),
                        Price = Convert.ToDecimal(rdr["Price"]),
                        PriceLine = Convert.ToDecimal(rdr["PriceLine"]),
                        Status = rdr["Status"].ToString(),
                        ImageDetail = rdr["ImageDetail"].ToString(),
                    };
                    return obj;
                }
                return null;
            }

            /*JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listProduct));*/

        }

        [WebMethod]
        public ProductModel GetTotalRows ()
        {
            string cs = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "TotalRow";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    ProductModel obj = new ProductModel()
                    {
                        TotalRows = Convert.ToInt32(rdr["TotalRows"]),
                    };
                    return obj;
                }
                return null;
            }

            /*JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listProduct));*/

        }
        [WebMethod]
        public List<ProductModel> GetProducts(int pageIndex, int pageSize)
        {
            List<ProductModel> listProduct = new List<ProductModel>();

            string cs = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetProducts";
                cmd.Parameters.Add(new SqlParameter("@PageIndex", pageIndex));
                cmd.Parameters.Add(new SqlParameter("@PageSize", pageSize));
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductModel product = new ProductModel();
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.ProductName = rdr["ProductName"].ToString();
                    product.ProductUrl = rdr["ProductUrl"].ToString();
                    product.Brand = rdr["Brand"].ToString();
                    product.ImageSrc = rdr["ImageSrc"].ToString();
                    product.ImageAlt = rdr["ImageAlt"].ToString();
                    product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    product.Price = Convert.ToDecimal(rdr["Price"]);
                    product.PriceLine = Convert.ToDecimal(rdr["PriceLine"]);
                    product.Status = rdr["Status"].ToString();
                    product.ImageDetail = rdr["ImageDetail"].ToString();
                    listProduct.Add(product);
                }

            }

            /*JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listProduct));*/
            return listProduct;
        }

        [WebMethod]
        public List<ProductModel> GetProductAll()
        {
            List<ProductModel> listProduct = new List<ProductModel>();

            string cs = ConfigurationManager.ConnectionStrings["DbContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetProductAll";
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProductModel product = new ProductModel();
                    product.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    product.ProductName = rdr["ProductName"].ToString();
                    product.ProductUrl = rdr["ProductUrl"].ToString();
                    product.Brand = rdr["Brand"].ToString();
                    product.ImageSrc = rdr["ImageSrc"].ToString();
                    product.ImageAlt = rdr["ImageAlt"].ToString();
                    product.Quantity = Convert.ToInt32(rdr["Quantity"]);
                    product.Price = Convert.ToDecimal(rdr["Price"]);
                    product.PriceLine = Convert.ToDecimal(rdr["PriceLine"]);
                    product.Status = rdr["Status"].ToString();
                    product.ImageDetail = rdr["ImageDetail"].ToString();

                    listProduct.Add(product);
                }
            }
            return listProduct;
        }
    }
}
