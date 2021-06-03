using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMvcForAzure
{
    public class MyItemContext:DbContext
    {
        
        public MyItemContext():base("Server=tcp:connectado.database.windows.net,1433;" +
            "Initial Catalog=mydb;Persist Security Info=False;" +
            "User ID=sailesh;" +
            "Password=Iamasp123hello;MultipleActiveResultSets=False;Encrypt=True;" +
            "TrustServerCertificate=False;Connection Timeout=30;")
        {

        }
        public DbSet<MyItem> MyItems
        {
            get;
            set;
        }
    }
}
