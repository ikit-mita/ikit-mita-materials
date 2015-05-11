using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSample
{
    public class Db : DbContext
    {
        static Db()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Db, Migrations.Configuration>());
        }

        public IDbSet<Item> Items { get; set; }
        public IDbSet<ChildItem> ChildItems { get; set; } 
    }
}
