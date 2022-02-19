
namespace IceCreamShopView
{
    partial class FormWarehouses
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.WarehouseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarhouseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarhouseResponsiblePerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarhouseDateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WarhouseIngredients = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WarehouseId,
            this.WarhouseName,
            this.WarhouseResponsiblePerson,
            this.WarhouseDateCreate,
            this.WarhouseIngredients});
            this.dataGridView.Location = new System.Drawing.Point(1, 2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(591, 451);
            this.dataGridView.TabIndex = 0;
            // 
            // WarehouseId
            // 
            this.WarehouseId.HeaderText = "";
            this.WarehouseId.Name = "WarehouseId";
            this.WarehouseId.Visible = false;
            // 
            // WarhouseName
            // 
            this.WarhouseName.HeaderText = "Название";
            this.WarhouseName.Name = "WarhouseName";
            // 
            // WarhouseResponsiblePerson
            // 
            this.WarhouseResponsiblePerson.HeaderText = "Ответственное лицо";
            this.WarhouseResponsiblePerson.Name = "WarhouseResponsiblePerson";
            // 
            // WarhouseDateCreate
            // 
            this.WarhouseDateCreate.HeaderText = "Дата создания";
            this.WarhouseDateCreate.Name = "WarhouseDateCreate";
            // 
            // WarhouseIngredients
            // 
            this.WarhouseIngredients.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarhouseIngredients.HeaderText = "Ингредиенты";
            this.WarhouseIngredients.Name = "WarhouseIngredients";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(650, 78);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(92, 30);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(650, 155);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(92, 30);
            this.buttonChange.TabIndex = 2;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(650, 227);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(92, 30);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Удалить";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(650, 305);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(92, 30);
            this.buttonUpdate.TabIndex = 4;
            this.buttonUpdate.Text = "Обновить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormWarehouses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormWarehouses";
            this.Text = "Склады";
            this.Load += new System.EventHandler(this.FormWarehouses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarehouseId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarhouseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarhouseResponsiblePerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarhouseDateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarhouseIngredients;
    }
}