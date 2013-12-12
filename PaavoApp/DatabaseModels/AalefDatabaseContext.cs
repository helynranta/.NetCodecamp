using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace PaavoApp.DatabaseModels
{
    class AalefDatabaseContext : DataContext
    {
        // Specify the connection string as a static, used in main page and app.xaml.
        public static string DBConnectionString = "Data Source=isostore:/Aalef.sdf";

        // Pass the connection string to the base class.
        public AalefDatabaseContext(string connectionString)
            : base(connectionString)
        { }

        // Specify a single table for the to-do items.
        public Table<AalefDataItem> DataItems;
    }
}
