using IceCreamShopContracts.BusinessLogicsContracts;
using IceCreamShopContracts.ViewModels;
using PagedList;
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
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic logic;
        private int pageNumber = 1;
        private IPagedList<MessageInfoViewModel> _list;
        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private  void FormMessages_Load(object sender, EventArgs e)
        {
            _list = GetPagedList();
            if (_list != null)
            {
                buttonPrev.Enabled = _list.HasPreviousPage;
                buttonNext.Enabled = _list.HasNextPage;
                dataGridView.DataSource = _list.ToList();
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                labelPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, _list.PageCount);
            }
        }
       
        public IPagedList<MessageInfoViewModel> GetPagedList(int pageNumber = 1, int pageSize = 2)
        {
            return logic.Read(null).OrderByDescending(rec => rec.DateDelivery).ToPagedList(pageNumber, pageSize);
        }

        private  void buttonPrev_Click(object sender, EventArgs e)
        {
            if (_list.HasPreviousPage)
            {
                _list = GetPagedList(--pageNumber);
                buttonPrev.Enabled = _list.HasPreviousPage;
                buttonNext.Enabled= _list.HasNextPage;
                dataGridView.DataSource=_list.ToList();
                labelPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, _list.PageCount);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_list.HasNextPage)
            {
                _list = GetPagedList(++pageNumber);
                buttonPrev.Enabled = _list.HasPreviousPage;
                buttonNext.Enabled = _list.HasNextPage;
                dataGridView.DataSource = _list.ToList();
                labelPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, _list.PageCount);
            }
        }
    }
}
