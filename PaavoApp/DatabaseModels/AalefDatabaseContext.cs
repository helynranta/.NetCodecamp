using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace PaavoApp.DatabaseModels
{
    class AalefDatabaseContext : DataContext
    {
        public static string DBConnectionString = "Data Source=isostore:/Aalef.sdf";

        public AalefDatabaseContext(string connectionString) : base(connectionString) { }

        public Table<AalefDataItem> DataItems;
    }
}
