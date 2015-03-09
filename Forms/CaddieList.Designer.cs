using System.Windows.Forms;
namespace CaddieManager.Forms
{
    partial class CaddieList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaddieList));
            this.CaddieListView = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.Button();
            this.CaddieEntry = new System.Windows.Forms.Button();
            this.AvailLunch = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.btnAddCaddie = new System.Windows.Forms.Button();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbMehotd = new System.Windows.Forms.ComboBox();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaddieListView)).BeginInit();
            this.SuspendLayout();
            // 
            // CaddieListView
            // 
            this.CaddieListView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CaddieListView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CaddieListView.Location = new System.Drawing.Point(1, 61);
            this.CaddieListView.MultiSelect = false;
            this.CaddieListView.Name = "CaddieListView";
            this.CaddieListView.RowHeadersWidth = 30;
            this.CaddieListView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CaddieListView.Size = new System.Drawing.Size(547, 197);
            this.CaddieListView.TabIndex = 0;
            // 
            // Edit
            // 
            this.Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Edit.Location = new System.Drawing.Point(103, 284);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 2;
            this.Edit.Text = "&Edit";
            this.Edit.UseVisualStyleBackColor = true;
            this.Edit.Click += new System.EventHandler(this.CaddieDetails_Click);
            // 
            // CaddieEntry
            // 
            this.CaddieEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaddieEntry.Location = new System.Drawing.Point(264, 284);
            this.CaddieEntry.Name = "CaddieEntry";
            this.CaddieEntry.Size = new System.Drawing.Size(93, 23);
            this.CaddieEntry.TabIndex = 3;
            this.CaddieEntry.Text = "Caddie &Entry";
            this.CaddieEntry.UseVisualStyleBackColor = true;
            this.CaddieEntry.Click += new System.EventHandler(this.CaddieEntry_Click);
            // 
            // AvailLunch
            // 
            this.AvailLunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailLunch.Location = new System.Drawing.Point(362, 284);
            this.AvailLunch.Name = "AvailLunch";
            this.AvailLunch.Size = new System.Drawing.Size(99, 23);
            this.AvailLunch.TabIndex = 4;
            this.AvailLunch.Text = "Avail &Lunch";
            this.AvailLunch.UseVisualStyleBackColor = true;
            this.AvailLunch.Click += new System.EventHandler(this.AvailLunch_Click);
            // 
            // Close
            // 
            this.Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.Location = new System.Drawing.Point(465, 284);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 5;
            this.Close.Text = "&Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // btnAddCaddie
            // 
            this.btnAddCaddie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCaddie.Location = new System.Drawing.Point(5, 284);
            this.btnAddCaddie.Name = "btnAddCaddie";
            this.btnAddCaddie.Size = new System.Drawing.Size(92, 23);
            this.btnAddCaddie.TabIndex = 6;
            this.btnAddCaddie.Text = "&Add";
            this.btnAddCaddie.UseVisualStyleBackColor = true;
            this.btnAddCaddie.Click += new System.EventHandler(this.btnAddCaddie_Click);
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(43, 22);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(105, 21);
            this.cmbType.TabIndex = 7;
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(237, 21);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(147, 20);
            this.txtValue.TabIndex = 10;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(407, 19);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(61, 23);
            this.btnFilter.TabIndex = 11;
            this.btnFilter.Text = "&Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(477, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(61, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(2, 25);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 8;
            this.lblType.Text = "Type";
            // 
            // cmbMehotd
            // 
            this.cmbMehotd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMehotd.FormattingEnabled = true;
            this.cmbMehotd.Location = new System.Drawing.Point(154, 22);
            this.cmbMehotd.Name = "cmbMehotd";
            this.cmbMehotd.Size = new System.Drawing.Size(77, 21);
            this.cmbMehotd.TabIndex = 13;
            this.cmbMehotd.DropDownStyle = ComboBoxStyle.DropDownList;
            
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Delete.Location = new System.Drawing.Point(184, 284);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 14;
            this.Delete.Text = "&Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // CaddieList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(548, 320);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.cmbMehotd);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnAddCaddie);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.AvailLunch);
            this.Controls.Add(this.CaddieEntry);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.CaddieListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CaddieList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaddieList";
            this.Activated += new System.EventHandler(this.OnActivat);
            ((System.ComponentModel.ISupportInitialize)(this.CaddieListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CaddieListView;
        private System.Windows.Forms.Button Edit;
        private System.Windows.Forms.Button CaddieEntry;
        private System.Windows.Forms.Button AvailLunch;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button btnAddCaddie;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbMehotd;
        private System.Windows.Forms.Button Delete;
    }
}