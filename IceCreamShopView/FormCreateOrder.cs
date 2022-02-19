using IceCreamShopContracts.BindingModels;
using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceCreamShopView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IIceCreamLogic _logicI;
        private readonly IOrderLogic _logicO;

        public FormCreateOrder(IIceCreamLogic logicI, IOrderLogic logicO)
        {
            InitializeComponent();
            _logicI = logicI;
            _logicO = logicO;
        }
        private void CalcSum()
        {
            if (comboBoxIceCream.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxIceCream.SelectedValue);
                    IceCreamViewModel iceCream = _logicI.Read(new IceCreamBindingModel
                    {
                        Id
                    = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * iceCream?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<IceCreamViewModel> iceCreamList = _logicI.Read(null);
                if (iceCreamList != null)
                {
                    comboBoxIceCream.DisplayMember = "IceCreamName";
                    comboBoxIceCream.ValueMember = "Id";
                    comboBoxIceCream.DataSource = iceCreamList;
                    comboBoxIceCream.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIceCream.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    IceCreamId = Convert.ToInt32(comboBoxIceCream.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void comboBoxIceCream_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
