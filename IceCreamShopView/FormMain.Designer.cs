
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
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreamsList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreamIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOrdersList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWarehouseList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWarhouseIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIngredients = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemIceCreams = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemWarehouses = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReplenish = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.toolStripMenuItemOrdersInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчётыToolStripMenuItem,
            this.toolStripMenuItemManual,
            this.toolStripMenuItemReplenish});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIceCreamsList,
            this.toolStripMenuItemIceCreamIngredients,
            this.toolStripMenuItemOrdersList,
            this.toolStripMenuItemWarehouseList,
            this.toolStripMenuItemWarhouseIngredients,
            this.toolStripMenuItemOrdersInfo});
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
            // toolStripMenuItemWarehouseList
            // 
            this.toolStripMenuItemWarehouseList.Name = "toolStripMenuItemWarehouseList";
            this.toolStripMenuItemWarehouseList.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemWarehouseList.Text = "Список складов";
            this.toolStripMenuItemWarehouseList.Click += new System.EventHandler(this.toolStripMenuItemWarehouseList_Click);
            // 
            // toolStripMenuItemWarhouseIngredients
            // 
            this.toolStripMenuItemWarhouseIngredients.Name = "toolStripMenuItemWarhouseIngredients";
            this.toolStripMenuItemWarhouseIngredients.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemWarhouseIngredients.Text = "Ингредиенты по складам";
            this.toolStripMenuItemWarhouseIngredients.Click += new System.EventHandler(this.toolStripMenuItemWarhouseIngredients_Click);
            // 
            // toolStripMenuItemManual
            // 
            this.toolStripMenuItemManual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemIngredients,
            this.toolStripMenuItemIceCreams,
            this.toolStripMenuItemWarehouses});
            this.toolStripMenuItemManual.Name = "toolStripMenuItemManual";
            this.toolStripMenuItemManual.Size = new System.Drawing.Size(94, 20);
            this.toolStripMenuItemManual.Text = "Справочники";
            // 
            // toolStripMenuItemIngredients
            // 
            this.toolStripMenuItemIngredients.Name = "toolStripMenuItemIngredients";
            this.toolStripMenuItemIngredients.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItemIngredients.Text = "Ингредиенты";
            this.toolStripMenuItemIngredients.Click += new System.EventHandler(this.toolStripMenuItemIngredient_Click);
            // 
            // toolStripMenuItemIceCreams
            // 
            this.toolStripMenuItemIceCreams.Name = "toolStripMenuItemIceCreams";
            this.toolStripMenuItemIceCreams.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItemIceCreams.Text = "Мороженое";
            this.toolStripMenuItemIceCreams.Click += new System.EventHandler(this.toolStripMenuItemIceCreams_Click);
            // 
            // toolStripMenuItemWarehouses
            // 
            this.toolStripMenuItemWarehouses.Name = "toolStripMenuItemWarehouses";
            this.toolStripMenuItemWarehouses.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItemWarehouses.Text = "Склады";
            this.toolStripMenuItemWarehouses.Click += new System.EventHandler(this.toolStripMenuItemWarehouses_Click);
            // 
            // toolStripMenuItemReplenish
            // 
            this.toolStripMenuItemReplenish.Name = "toolStripMenuItemReplenish";
            this.toolStripMenuItemReplenish.Size = new System.Drawing.Size(129, 20);
            this.toolStripMenuItemReplenish.Text = "Пополнение склада";
            this.toolStripMenuItemReplenish.Click += new System.EventHandler(this.toolStripMenuItemReplenish_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(677, 429);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(705, 78);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(164, 31);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(705, 161);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(164, 31);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(705, 243);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(164, 32);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(705, 329);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(164, 30);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(705, 407);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(164, 32);
            this.buttonUpdate.TabIndex = 6;
            this.buttonUpdate.Text = "Обновить список";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // toolStripMenuItemOrdersInfo
            // 
            this.toolStripMenuItemOrdersInfo.Name = "toolStripMenuItemOrdersInfo";
            this.toolStripMenuItemOrdersInfo.Size = new System.Drawing.Size(238, 22);
            this.toolStripMenuItemOrdersInfo.Text = "Информация о заказах";
            this.toolStripMenuItemOrdersInfo.Click += new System.EventHandler(this.toolStripMenuItemOrdersInfo_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 451);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
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
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIngredients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreams;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonIssuedOrder;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreamsList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIceCreamIngredients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrdersList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWarehouses;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReplenish;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWarehouseList;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemWarhouseIngredients;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOrdersInfo;
    }
}