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
  public class BuyerRepository : DbFactoryRepositry, IEntityRepository, IDisposable
  {
    public BuyerRepository(string ConnectionString, string ProviderName) : base(ConnectionString, ProviderName)
    {
      Connection.Open();
    }

    public void Add(Entity entity)
    {
      var entity_temp = (Buyer)entity;
      Command.CommandText = $"INSERT INTO Buyers (Id, CreationDate, Name, Surname) VALUES ('{entity_temp.Id.ToString()}', '{entity_temp.CreationDate.ToString("yyyy-MM-dd HH:mm:ss.fff")}', '{"Cherr"}', '{"Soumt"}')";
      Command.ExecuteNonQuery();
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
      List<Buyer> result = new List<Buyer>();
      Command.CommandText = "Select * FROM Buyers";
      using (DbDataReader reader = Command.ExecuteReader())
      {
        while (reader.Read())
        {
          result.Add(new Buyer
          {
            Id = Guid.Parse(reader.GetValue(0).ToString()),
            CreationDate = Convert.ToDateTime(reader.GetValue(1).ToString()),
           // DeletedDate = Convert.ToDateTime(reader.GetValue(2).ToString()),
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
