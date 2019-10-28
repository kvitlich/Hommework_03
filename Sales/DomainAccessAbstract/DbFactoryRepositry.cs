using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DomainAccessAbstract
{
  public abstract class DbFactoryRepositry
  {
    public DbProviderFactory Factory { get; set; }
    public DbConnection Connection { get; set; }
    public DbCommand Command { get; set; }

    public DbFactoryRepositry(string ConnectionString, string ProviderName)
    {

      Factory = DbProviderFactories.GetFactory(ProviderName);
      Connection = Factory.CreateConnection();
      Connection.ConnectionString = ConnectionString;
      Command = Connection.CreateCommand();
    }
  }
}
