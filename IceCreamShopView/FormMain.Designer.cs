
namespace IceCreamShopView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIngredient = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreams = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemImplementers = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreamsList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreamIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrdersList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartWorks = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemManual,
            this.отчётыToolStripMenuItem,
            this.toolStripMenuItemStartWorks});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemManual
            // 
            this.toolStripMenuItemManual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIngredient,
            this.toolStripMenuItemIceCreams,
            this.toolStripMenuItemClients,
            this.toolStripMenuItemImplementers});
            this.toolStripMenuItemManual.Name = "toolStripMenuItemManual";
            this.toolStripMenuItemManual.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemManual.Text = "Справочники";
            // 
            // toolStripMenuItemIngredient
            // 
            this.toolStripMenuItemIngredient.Name = "toolStripMenuItemIngredient";
            this.toolStripMenuItemIngredient.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemIngredient.Text = "Ингредиенты";
            this.toolStripMenuItemIngredient.Click += new System.EventHandler(this.toolStripMenuItemIngredient_Click);
            // 
            // toolStripMenuItemIceCreams
            // 
            this.toolStripMenuItemIceCreams.Name = "toolStripMenuItemIceCreams";
            this.toolStripMenuItemIceCreams.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemIceCreams.Text = "Мороженое";
            this.toolStripMenuItemIceCreams.Click += new System.EventHandler(this.toolStripMenuItemIceCreams_Click);
            // 
            // toolStripMenuItemClients
            // 
            this.toolStripMenuItemClients.Name = "toolStripMenuItemClients";
            this.toolStripMenuItemClients.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemClients.Text = "Клиенты";
            this.toolStripMenuItemClients.Click += new System.EventHandler(this.toolStripMenuItemClients_Click);
            // 
            // toolStripMenuItemImplementers
            // 
            this.toolStripMenuItemImplementers.Name = "toolStripMenuItemImplementers";
            this.toolStripMenuItemImplementers.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItemImplementers.Text = "Исполнители";
            this.toolStripMenuItemImplementers.Click += new System.EventHandler(this.toolStripMenuItemImplementers_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIceCreamsList,
            this.toolStripMenuItemIceCreamIngredients,
            this.toolStripMenuItemOrdersList});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // toolStripMenuItemIceCreamsList
            // 
            this.toolStripMenuItemIceCreamsList.Name = "toolStripMenuItemIceCreamsList";
            this.toolStripMenuItemIceCreamsList.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemIceCreamsList.Text = "Список мороженого";
            this.toolStripMenuItemIceCreamsList.Click += new System.EventHandler(this.toolStripMenuItemIceCreamsList_Click);
            // 
            // toolStripMenuItemIceCreamIngredients
            // 
            this.toolStripMenuItemIceCreamIngredients.Name = "toolStripMenuItemIceCreamIngredients";
            this.toolStripMenuItemIceCreamIngredients.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemIceCreamIngredients.Text = "Ингредиенты по мороженым";
            this.toolStripMenuItemIceCreamIngredients.Click += new System.EventHandler(this.toolStripMenuItemIceCreamIngredient_Click);
            // 
            // toolStripMenuItemOrdersList
            // 
            this.toolStripMenuItemOrdersList.Name = "toolStripMenuItemOrdersList";
            this.toolStripMenuItemOrdersList.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemOrdersList.Text = "Список заказов";
            this.toolStripMenuItemOrdersList.Click += new System.EventHandler(this.toolStripMenuItemOrdersList_Click);
            // 
            // toolStripMenuItemStartWorks
            // 
            this.toolStripMenuItemStartWorks.Name = "toolStripMenuItemStartWorks";
            this.toolStripMenuItemStartWorks.Size = new System.Drawing.Size(92, 20);
            this.toolStripMenuItemStartWorks.Text = "Запуск работ";
            this.toolStripMenuItemStartWorks.Click += new System.EventHandler(this.toolStripMenuItemStartWorks_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(885, 429);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(908, 101);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(164, 31);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(908, 205);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(164, 30);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(908, 309);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(164, 32);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Обновить список";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 451);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Магазин мороженого";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemManual;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIngredient;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreams;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonIssuedOrder;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreamsList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreamIngredients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrdersList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartWorks;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemImplementers;
    }
}