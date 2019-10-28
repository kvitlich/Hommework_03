using Sales.Domain;
using Sales.DomainAccessAbstract;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DomainAccess
{
  class DealRepository : DbFactoryRepositry, IEntityRepository, IDisposable
  {
    public DealRepository(string ConnectionString, string ProviderName) : base(ConnectionString, ProviderName)
    {
      Connection.Open();
    }

    public void Add(Entity entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(Entity entity)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      Connection.Close();
    }

    public ICollection<Entity> GetAll()
    {
      List<Deal> result = new List<Deal>();
      Command.CommandText = "Select * FROM Deals";
      using (DbDataReader reader = Command.ExecuteReader())
      {
        while (reader.HasRows)
        {
          result.Add(new Deal
          {
            Id = Guid.Parse(reader.GetValue(0).ToString()),
            CreationDate = DateTime.Parse(reader.GetValue(1).ToString()),
            DeletedDate = DateTime.Parse(reader.GetValue(2).ToString()),
            IdBuyer = Guid.Parse(reader.GetValue(3).ToString()),
            IdSeller = Guid.Parse(reader.GetValue(4).ToString()),
            Summ = Double.Parse(reader.GetValue(5).ToString()),
            Date = DateTime.Parse(reader.GetValue(6).ToString()),
          });
        }
      }
      return result.ToArray();
    }

    public void Uppdate(Entity entity)
    {
      throw new NotImplementedException();
    }
  }
}
