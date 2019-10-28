using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain
{
  class Deal : Entity
  {
    public Guid IdBuyer { get; set; }

    public Guid IdSeller { get; set; }

    public double Summ { get; set; }

    public DateTime Date { get; set; }
  }
}
