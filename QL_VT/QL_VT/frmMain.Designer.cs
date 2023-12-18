
namespace QL_VT
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.ddwAccount = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAccount = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ddwReport = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnRpProduct = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRpTypeProduct = new System.Windows.Forms.Button();
            this.btnRpStorage = new System.Windows.Forms.Button();
            this.btnRpSupplier = new System.Windows.Forms.Button();
            this.btnRpIncreaseProduct = new System.Windows.Forms.Button();
            this.btnRpGuest = new System.Windows.Forms.Button();
            this.btnRpDecreaseProduct = new System.Windows.Forms.Button();
            this.ddwCategory = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnList = new System.Windows.Forms.Button();
            this.btnStorage = new System.Windows.Forms.Button();
            this.btnListAccount = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnGuest = new System.Windows.Forms.Button();
            this.btnSupplier = new System.Windows.Forms.Button();
            this.btnTypeProduct = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnInsertProduct = new System.Windows.Forms.Button();
            this.btnEntryDetail = new System.Windows.Forms.Button();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnInvoiceDetail = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.ddwAccount.SuspendLayout();
            this.panel3.SuspendLayout();
            this.ddwReport.SuspendLayout();
            this.ddwCategory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(30, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(201, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(925, 802);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.ddwAccount);
            this.pnlCenter.Controls.Add(this.ddwReport);
            this.pnlCenter.Controls.Add(this.ddwCategory);
            this.pnlCenter.Location = new System.Drawing.Point(0, 108);
            this.pnlCenter.MaximumSize = new System.Drawing.Size(230, 1500);
            this.pnlCenter.MinimumSize = new System.Drawing.Size(198, 190);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(198, 1111);
            this.pnlCenter.TabIndex = 4;
            // 
            // ddwAccount
            // 
            this.ddwAccount.Controls.Add(this.panel3);
            this.ddwAccount.Controls.Add(this.button2);
            this.ddwAccount.Location = new System.Drawing.Point(0, 0);
            this.ddwAccount.Margin = new System.Windows.Forms.Padding(0);
            this.ddwAccount.MaximumSize = new System.Drawing.Size(198, 124);
            this.ddwAccount.MinimumSize = new System.Drawing.Size(198, 62);
            this.ddwAccount.Name = "ddwAccount";
            this.ddwAccount.Size = new System.Drawing.Size(198, 62);
            this.ddwAccount.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAccount);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(198, 62);
            this.panel3.TabIndex = 2;
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.Location = new System.Drawing.Point(0, 0);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(0);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(198, 62);
            this.btnAccount.TabIndex = 1;
            this.btnAccount.Text = "Tài khoản";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(0, 62);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 62);
            this.button2.TabIndex = 2;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ddwReport
            // 
            this.ddwReport.Controls.Add(this.btnReport);
            this.ddwReport.Controls.Add(this.btnRpProduct);
            this.ddwReport.Controls.Add(this.panel4);
            this.ddwReport.Controls.Add(this.btnRpTypeProduct);
            this.ddwReport.Controls.Add(this.btnRpStorage);
            this.ddwReport.Controls.Add(this.btnRpSupplier);
            this.ddwReport.Controls.Add(this.btnRpIncreaseProduct);
            this.ddwReport.Controls.Add(this.btnRpGuest);
            this.ddwReport.Controls.Add(this.btnRpDecreaseProduct);
            this.ddwReport.Location = new System.Drawing.Point(0, 124);
            this.ddwReport.MaximumSize = new System.Drawing.Size(198, 496);
            this.ddwReport.MinimumSize = new System.Drawing.Size(198, 62);
            this.ddwReport.Name = "ddwReport";
            this.ddwReport.Size = new System.Drawing.Size(198, 62);
            this.ddwReport.TabIndex = 17;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(0, 0);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(198, 62);
            this.btnReport.TabIndex = 26;
            this.btnReport.Text = "Báo cáo - Thống kê";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnRpProduct
            // 
            this.btnRpProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpProduct.Location = new System.Drawing.Point(0, 434);
            this.btnRpProduct.Name = "btnRpProduct";
            this.btnRpProduct.Size = new System.Drawing.Size(198, 62);
            this.btnRpProduct.TabIndex = 29;
            this.btnRpProduct.Text = "Hàng hóa";
            this.btnRpProduct.UseVisualStyleBackColor = false;
            this.btnRpProduct.Click += new System.EventHandler(this.btnRpProduct_Click);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(198, 62);
            this.panel4.TabIndex = 36;
            // 
            // btnRpTypeProduct
            // 
            this.btnRpTypeProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpTypeProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpTypeProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpTypeProduct.Location = new System.Drawing.Point(0, 372);
            this.btnRpTypeProduct.Name = "btnRpTypeProduct";
            this.btnRpTypeProduct.Size = new System.Drawing.Size(198, 62);
            this.btnRpTypeProduct.TabIndex = 30;
            this.btnRpTypeProduct.Text = "Loại hàng";
            this.btnRpTypeProduct.UseVisualStyleBackColor = false;
            this.btnRpTypeProduct.Click += new System.EventHandler(this.btnRpTypeProduct_Click);
            // 
            // btnRpStorage
            // 
            this.btnRpStorage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpStorage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpStorage.Location = new System.Drawing.Point(0, 62);
            this.btnRpStorage.Name = "btnRpStorage";
            this.btnRpStorage.Size = new System.Drawing.Size(198, 62);
            this.btnRpStorage.TabIndex = 35;
            this.btnRpStorage.Text = "Kho";
            this.btnRpStorage.UseVisualStyleBackColor = false;
            this.btnRpStorage.Click += new System.EventHandler(this.btnRpStorage_Click);
            // 
            // btnRpSupplier
            // 
            this.btnRpSupplier.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpSupplier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpSupplier.Location = new System.Drawing.Point(0, 310);
            this.btnRpSupplier.Name = "btnRpSupplier";
            this.btnRpSupplier.Size = new System.Drawing.Size(198, 62);
            this.btnRpSupplier.TabIndex = 31;
            this.btnRpSupplier.Text = "Nhà cung cấp";
            this.btnRpSupplier.UseVisualStyleBackColor = false;
            this.btnRpSupplier.Click += new System.EventHandler(this.btnRpSupplier_Click);
            // 
            // btnRpIncreaseProduct
            // 
            this.btnRpIncreaseProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpIncreaseProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpIncreaseProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpIncreaseProduct.Location = new System.Drawing.Point(0, 124);
            this.btnRpIncreaseProduct.Name = "btnRpIncreaseProduct";
            this.btnRpIncreaseProduct.Size = new System.Drawing.Size(198, 62);
            this.btnRpIncreaseProduct.TabIndex = 34;
            this.btnRpIncreaseProduct.Text = "Nhập hàng";
            this.btnRpIncreaseProduct.UseVisualStyleBackColor = false;
            this.btnRpIncreaseProduct.Click += new System.EventHandler(this.btnRpIncreaseProduct_Click);
            // 
            // btnRpGuest
            // 
            this.btnRpGuest.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpGuest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpGuest.Location = new System.Drawing.Point(0, 248);
            this.btnRpGuest.Name = "btnRpGuest";
            this.btnRpGuest.Size = new System.Drawing.Size(198, 62);
            this.btnRpGuest.TabIndex = 32;
            this.btnRpGuest.Text = "Khách hàng";
            this.btnRpGuest.UseVisualStyleBackColor = false;
            this.btnRpGuest.Click += new System.EventHandler(this.btnRpGuest_Click);
            // 
            // btnRpDecreaseProduct
            // 
            this.btnRpDecreaseProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnRpDecreaseProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRpDecreaseProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRpDecreaseProduct.Location = new System.Drawing.Point(0, 186);
            this.btnRpDecreaseProduct.Name = "btnRpDecreaseProduct";
            this.btnRpDecreaseProduct.Size = new System.Drawing.Size(198, 62);
            this.btnRpDecreaseProduct.TabIndex = 33;
            this.btnRpDecreaseProduct.Text = "Xuất hàng";
            this.btnRpDecreaseProduct.UseVisualStyleBackColor = false;
            this.btnRpDecreaseProduct.Click += new System.EventHandler(this.btnRpDecreaseProduct_Click);
            // 
            // ddwCategory
            // 
            this.ddwCategory.Controls.Add(this.panel1);
            this.ddwCategory.Controls.Add(this.btnStorage);
            this.ddwCategory.Controls.Add(this.btnListAccount);
            this.ddwCategory.Controls.Add(this.btnManager);
            this.ddwCategory.Controls.Add(this.btnGuest);
            this.ddwCategory.Controls.Add(this.btnSupplier);
            this.ddwCategory.Controls.Add(this.btnTypeProduct);
            this.ddwCategory.Controls.Add(this.btnProduct);
            this.ddwCategory.Controls.Add(this.btnInsertProduct);
            this.ddwCategory.Controls.Add(this.btnEntryDetail);
            this.ddwCategory.Controls.Add(this.btnDeleteProduct);
            this.ddwCategory.Controls.Add(this.btnInvoiceDetail);
            this.ddwCategory.Location = new System.Drawing.Point(0, 62);
            this.ddwCategory.Margin = new System.Windows.Forms.Padding(0);
            this.ddwCategory.MaximumSize = new System.Drawing.Size(240, 1000);
            this.ddwCategory.MinimumSize = new System.Drawing.Size(198, 62);
            this.ddwCategory.Name = "ddwCategory";
            this.ddwCategory.Size = new System.Drawing.Size(238, 62);
            this.ddwCategory.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnList);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 62);
            this.panel1.TabIndex = 4;
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnList.Location = new System.Drawing.Point(0, 0);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(198, 62);
            this.btnList.TabIndex = 28;
            this.btnList.Text = "Danh mục";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnStorage
            // 
            this.btnStorage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStorage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorage.Location = new System.Drawing.Point(0, 682);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Size = new System.Drawing.Size(198, 62);
            this.btnStorage.TabIndex = 18;
            this.btnStorage.Text = "Kho";
            this.btnStorage.UseVisualStyleBackColor = false;
            this.btnStorage.Click += new System.EventHandler(this.btnStorage_Click);
            // 
            // btnListAccount
            // 
            this.btnListAccount.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnListAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListAccount.Location = new System.Drawing.Point(0, 62);
            this.btnListAccount.Name = "btnListAccount";
            this.btnListAccount.Size = new System.Drawing.Size(198, 62);
            this.btnListAccount.TabIndex = 26;
            this.btnListAccount.Text = "Tài khoản";
            this.btnListAccount.UseVisualStyleBackColor = false;
            this.btnListAccount.Click += new System.EventHandler(this.btnListAccount_Click);
            // 
            // btnManager
            // 
            this.btnManager.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManager.Location = new System.Drawing.Point(0, 124);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(198, 62);
            this.btnManager.TabIndex = 25;
            this.btnManager.Text = "Nhân viên";
            this.btnManager.UseVisualStyleBackColor = false;
            this.btnManager.Click += new System.EventHandler(this.btnManager_Click);
            // 
            // btnGuest
            // 
            this.btnGuest.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(0, 186);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(198, 62);
            this.btnGuest.TabIndex = 24;
            this.btnGuest.Text = "Khách hàng";
            this.btnGuest.UseVisualStyleBackColor = false;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // btnSupplier
            // 
            this.btnSupplier.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupplier.Location = new System.Drawing.Point(0, 248);
            this.btnSupplier.Name = "btnSupplier";
            this.btnSupplier.Size = new System.Drawing.Size(198, 62);
            this.btnSupplier.TabIndex = 23;
            this.btnSupplier.Text = "Nhà cung cấp";
            this.btnSupplier.UseVisualStyleBackColor = false;
            this.btnSupplier.Click += new System.EventHandler(this.btnSupplier_Click);
            // 
            // btnTypeProduct
            // 
            this.btnTypeProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnTypeProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTypeProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTypeProduct.Location = new System.Drawing.Point(0, 310);
            this.btnTypeProduct.Name = "btnTypeProduct";
            this.btnTypeProduct.Size = new System.Drawing.Size(198, 62);
            this.btnTypeProduct.TabIndex = 22;
            this.btnTypeProduct.Text = "Loại hàng";
            this.btnTypeProduct.UseVisualStyleBackColor = false;
            this.btnTypeProduct.Click += new System.EventHandler(this.btnTypeProduct_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(0, 372);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(198, 62);
            this.btnProduct.TabIndex = 21;
            this.btnProduct.Text = "Hàng hóa";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnInsertProduct
            // 
            this.btnInsertProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInsertProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertProduct.Location = new System.Drawing.Point(0, 434);
            this.btnInsertProduct.Name = "btnInsertProduct";
            this.btnInsertProduct.Size = new System.Drawing.Size(198, 62);
            this.btnInsertProduct.TabIndex = 20;
            this.btnInsertProduct.Text = "Nhập hàng";
            this.btnInsertProduct.UseVisualStyleBackColor = false;
            this.btnInsertProduct.Click += new System.EventHandler(this.btnInsertProduct_Click);
            // 
            // btnEntryDetail
            // 
            this.btnEntryDetail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnEntryDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntryDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntryDetail.Location = new System.Drawing.Point(0, 496);
            this.btnEntryDetail.Name = "btnEntryDetail";
            this.btnEntryDetail.Size = new System.Drawing.Size(198, 62);
            this.btnEntryDetail.TabIndex = 18;
            this.btnEntryDetail.Text = "CT đơn nhập";
            this.btnEntryDetail.UseVisualStyleBackColor = false;
            this.btnEntryDetail.Click += new System.EventHandler(this.btnEntryDetail_Click);
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDeleteProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteProduct.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteProduct.Location = new System.Drawing.Point(0, 558);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(198, 62);
            this.btnDeleteProduct.TabIndex = 19;
            this.btnDeleteProduct.Text = "Xuất hàng";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnInvoiceDetail
            // 
            this.btnInvoiceDetail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnInvoiceDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoiceDetail.Location = new System.Drawing.Point(0, 620);
            this.btnInvoiceDetail.Name = "btnInvoiceDetail";
            this.btnInvoiceDetail.Size = new System.Drawing.Size(198, 62);
            this.btnInvoiceDetail.TabIndex = 18;
            this.btnInvoiceDetail.Text = "CT đơn xuất";
            this.btnInvoiceDetail.UseVisualStyleBackColor = false;
            this.btnInvoiceDetail.Click += new System.EventHandler(this.btnInvoiceDetail_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 1055);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmMain";
            this.Text = "frmMain1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.ddwAccount.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ddwReport.ResumeLayout(false);
            this.ddwCategory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel ddwAccount;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel ddwCategory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnListAccount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Button btnSupplier;
        private System.Windows.Forms.Button btnTypeProduct;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnInsertProduct;
        private System.Windows.Forms.Button btnEntryDetail;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnInvoiceDetail;
        private System.Windows.Forms.Button btnStorage;
        private System.Windows.Forms.Panel ddwReport;
        private System.Windows.Forms.Button btnRpStorage;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnRpIncreaseProduct;
        private System.Windows.Forms.Button btnRpDecreaseProduct;
        private System.Windows.Forms.Button btnRpGuest;
        private System.Windows.Forms.Button btnRpSupplier;
        private System.Windows.Forms.Button btnRpTypeProduct;
        private System.Windows.Forms.Button btnRpProduct;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlMain;

    }
}