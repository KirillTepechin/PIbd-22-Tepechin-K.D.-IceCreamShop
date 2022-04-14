using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace IceCreamShopView
{
    public partial class FormWarehouses : Form
    {
        private readonly IWarehouseLogic _logic;

        public FormWarehouses(IWarehouseLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void FormWarehouses_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {

                var list = _logic.Read(null);
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var wh in list)
                    {
                        string stringIngredients = string.Empty;
                        foreach (var ingr in wh.WarehouseIngredients)
                        {
                            stringIngredients += ingr.Key + ") " + ingr.Value.Item1 + ": " + ingr.Value.Item2 + ", ";
                        }
                        if (stringIngredients.Length != 0)
                            dataGridView.Rows.Add(new object[] { wh.Id, wh.WarehouseName, wh.ResponsiblePerson, wh.DateCreate, stringIngredients[0..^2] });
                        else
                            dataGridView.Rows.Add(new object[] { wh.Id, wh.WarehouseName, wh.ResponsiblePerson, wh.DateCreate });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouse>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormWarehouse>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить?", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id =
                   Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        _logic.Delete(new WarehouseBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
