using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace PaavoApp.DatabaseModels
{

    class RestaurantUpdatedContext : DataContext
    {
            // Specify the connection string as a static, used in main page and app.xaml.
            public static string DBConnectionString = "Data Source=isostore:/Updated.sdf";

            // Pass the connection string to the base class.
            public RestaurantUpdatedContext(string connectionString)
                : base(connectionString)
            { }

            // Specify a single table for the to-do items.
            public Table<RestaurantUpdatedItem> UpdateItems;
    }
}
