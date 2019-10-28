using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain
{
  public class Buyer : Entity
  {
     public string Name { get; set; }

     public string Surname { get; set; }
  }
}
