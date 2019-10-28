using Sales.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DomainAccessAbstract
{
  public interface IEntityRepository
  {
    void Add(Entity entity);
    void Uppdate(Entity entity);
    ICollection<Entity> GetAll();
    void Delete(Entity entity);
  }
}
