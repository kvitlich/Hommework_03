using Sales.Domain;
using Sales.DomainAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales
{
  public static class Global
  {
    public static string ConnectionStringSql { get; set; } = "Server=KVITLICH;Database=SalesDB;Trusted_Connection=True;";
    public static string ProviderName { get; set; } = "System.Data.SqlClient";

    public static List<string[]> Main_(string member)
    {
      List<string[]> result = new List<string[]>();
      Entity[] temp;
      switch (member)
      {
        case "Buyer":
          BuyerRepository buyer = new BuyerRepository(Global.ConnectionStringSql, Global.ProviderName);
          temp = buyer.GetAll().ToArray<Entity>();
          Buyer[] buyers = new Buyer[temp.Length];
          for (int i = 0; i < temp.Length; i++)
          {
            buyers[i] = (Buyer)temp[i];
          }

          for (int i = 0; i < buyers.Length; i++)
          {
            result.Add(new string[5]);
            result[i][0] = buyers[i].Id.ToString();
            result[i][1] = buyers[i].CreationDate.ToString();
            result[i][2] = buyers[i].DeletedDate.ToString();
            result[i][3] = buyers[i].Name.ToString();
            result[i][4] = buyers[i].Surname.ToString();
          }
          break;
        case "Deal":
          DealRepository deal = new DealRepository(Global.ConnectionStringSql, Global.ProviderName);
          temp = deal.GetAll().ToArray<Entity>();
          Deal[] deals = new Deal[temp.Length];
          for (int i = 0; i < temp.Length; i++)
          {
            deals[i] = (Deal)temp[i];
          }
          for (int i = 0; i < deals.Length; i++)
          {
            result.Add(new string[7]);
            result[i][0] = deals[i].Id.ToString();
            result[i][1] = deals[i].CreationDate.ToString();
            //result[i][2] = deals[i].DeletedDate.ToString();
            result[i][3] = deals[i].IdBuyer.ToString();
            result[i][4] = deals[i].IdSeller.ToString();
            result[i][5] = deals[i].Summ.ToString();
            result[i][6] = deals[i].Date.ToString();
          }
          break;
        case "Saller": 
          SallerRepository saller = new SallerRepository(Global.ConnectionStringSql, Global.ProviderName);
          temp = saller.GetAll().ToArray<Entity>();
          Saller[] sallers = new Saller[temp.Length];
          for (int i = 0; i < temp.Length; i++)
          {
            sallers[i] = (Saller)temp[i];
          }
          for (int i = 0; i < sallers.Length; i++)
          {
            result.Add(new string[5]);
            result[i][0] = sallers[i].Id.ToString();
            result[i][1] = sallers[i].CreationDate.ToString();
            //result[i][2] = sallers[i].DeletedDate.ToString();
            result[i][3] = sallers[i].Name.ToString();
            result[i][4] = sallers[i].Surname.ToString();
          }
          break;
      }

      return result;
    }
  }
}
