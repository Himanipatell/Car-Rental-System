using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Device.Location;

namespace CarRentalSystem
{
    public partial class Index : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        private double latitude;
        private double longitude;
        GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
        protected void Page_Load(object sender, EventArgs e)
        {    }
        public void FetchCabs(double x,double y)
        {          
            //To get closest 5 cabs from your location
            da = new SqlDataAdapter("SELECT top 5 vehicleId, SQRT(POWER(locationX -"+x+",2) + POWER(locationY -"+y+",2)) as distance from Vehicle ORDER BY distance ", con);
            da.Fill(dt);
            double[] id = new double[5];
            if(dt.Rows.Count>0)
            {
                Label1.Text = "Cabs Found are:<br>";
            }
            else
            {
                Label1.Text = "No Cabs found";
            }
            for(int i=0;i<dt.Rows.Count;i++)
            {
                if(i==5)
                {
                    break;
                }                
                id[i] = Convert.ToDouble(dt.Rows[i][0].ToString());
                //To print closest cab's Id
                Label1.Text += id[i].ToString()+"<br>";
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            watcher = new GeoCoordinateWatcher();
            watcher.TryStart(false, TimeSpan.FromSeconds(2));
            //To get your current device location
            while (watcher.Status != GeoPositionStatus.Ready)
            {
                watcher.TryStart(false, TimeSpan.FromSeconds(2));
                Label1.Text = "Finding ...";
            }          
            GeoCoordinate coord = watcher.Position.Location;
            //To get your location's Latitude
            latitude = coord.Latitude;
            //To get your location's Longitude
            longitude = coord.Longitude;
            FetchCabs(latitude,longitude);
        }
    }
}
