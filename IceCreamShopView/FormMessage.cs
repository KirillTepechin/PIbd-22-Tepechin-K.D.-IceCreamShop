using IceCreamShopBusinessLogic.MailWorker;
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
    public partial class FormMessage : Form
    {
        public string MessageId
        {
            set { messageId = value; }
        }
        private readonly IMessageInfoLogic _messageLogic;
        private readonly IClientLogic _clientLogic;
        private readonly AbstractMailWorker _mailWorker;
        private string messageId;
        public FormMessage(IMessageInfoLogic messageLogic, IClientLogic clientLogic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _clientLogic = clientLogic;
            _mailWorker = mailWorker;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            if (messageId != null)
            {
                try
                {
                    MessageInfoViewModel view = _messageLogic.Read(new MessageInfoBindingModel { MessageId = messageId })?[0];
                    if (view != null)
                    {
                        if (!view.Viewed)
                        {
                            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                            {
                                ClientId = _clientLogic.Read(new ClientBindingModel { Email = view.SenderName })?[0].Id,
                                MessageId = messageId,
                                FromMailAddress = view.SenderName,
                                Subject = view.Subject,
                                Body = view.Body,
                                DateDelivery = view.DateDelivery,
                                Viewed = true,
                                Reply = view.Reply
                            });
                        }
                        labelBody.Text = view.Body;
                        labelSenderName.Text = view.SenderName;
                        labelSubject.Text = view.Subject;
                        labelDate.Text = view.DateDelivery.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReply.Text))
            {
                MessageBox.Show("Введите текст ответа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = labelSenderName.Text,
                    Subject = "Re: " + labelSubject.Text,
                    Text = textBoxReply.Text
                });

                _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                {
                    ClientId = _clientLogic.Read(new ClientBindingModel { Email = labelSenderName.Text })?[0].Id,
                    MessageId = messageId,
                    FromMailAddress = labelSenderName.Text,
                    Subject = labelSubject.Text,
                    Body = labelBody.Text,
                    DateDelivery = DateTime.Parse(labelDate.Text),
                    Viewed = true,
                    Reply = textBoxReply.Text
                });
                MessageBox.Show("Ответ отправлен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
