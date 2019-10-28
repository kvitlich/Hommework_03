using Sales.Domain;
using Sales.DomainAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      BuyerRepository buyer = new BuyerRepository(Global.ConnectionStringSql, Global.ProviderName);
      buyer.Add(new Buyer());
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      comboBox1.Items.Add("Buyer");
      comboBox1.Items.Add("Deal");
      comboBox1.Items.Add("Saller");
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

      var data = Global.Main_(comboBox1.SelectedItem.ToString());
      Console.WriteLine(comboBox1.SelectedItem.ToString());
      dataGridView1.DataSource = data;

    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }
  }
}
