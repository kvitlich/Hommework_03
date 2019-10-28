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
  class SallerRepository : DbFactoryRepositry, IEntityRepository, IDisposable
  {
    public SallerRepository(string ConnectionString, string ProviderName) : base(ConnectionString, ProviderName)
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

      List<Saller> result = new List<Saller>();
      Command.CommandText = "Select * FROM Sallers";
      using (DbDataReader reader = Command.ExecuteReader())
      {
        while (reader.HasRows)
        {
          result.Add(new Saller
          {
            Id = Guid.Parse(reader.GetValue(0).ToString()),
            CreationDate = DateTime.Parse(reader.GetValue(1).ToString()),
            DeletedDate = DateTime.Parse(reader.GetValue(2).ToString()),
            Name = reader.GetValue(3).ToString(),
            Surname = reader.GetValue(4).ToString()
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
