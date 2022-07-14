namespace Readerm5e.UI
{
    partial class ElementsForm
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
            this.dtGridElements = new System.Windows.Forms.DataGridView();
            this.epc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFilterEpc = new System.Windows.Forms.TextBox();
            this.txtFilterName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFilterDescription = new System.Windows.Forms.TextBox();
            this.btnCleanFilters = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridElements)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGridElements
            // 
            this.dtGridElements.AllowUserToAddRows = false;
            this.dtGridElements.AllowUserToDeleteRows = false;
            this.dtGridElements.AllowUserToOrderColumns = true;
            this.dtGridElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.epc,
            this.nombre,
            this.descripcion});
            this.dtGridElements.Location = new System.Drawing.Point(192, 12);
            this.dtGridElements.MultiSelect = false;
            this.dtGridElements.Name = "dtGridElements";
            this.dtGridElements.ReadOnly = true;
            this.dtGridElements.RowHeadersVisible = false;
            this.dtGridElements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridElements.Size = new System.Drawing.Size(510, 334);
            this.dtGridElements.TabIndex = 0;
            this.dtGridElements.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridElements_CellContentClick);
            // 
            // epc
            // 
            this.epc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.epc.HeaderText = "EPC";
            this.epc.Name = "epc";
            this.epc.ReadOnly = true;
            this.epc.Width = 53;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 69;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCleanFilters);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtFilterDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFilterName);
            this.panel1.Controls.Add(this.txtFilterEpc);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 334);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filtrar";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(89, 280);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFilterEpc
            // 
            this.txtFilterEpc.Location = new System.Drawing.Point(11, 75);
            this.txtFilterEpc.Name = "txtFilterEpc";
            this.txtFilterEpc.Size = new System.Drawing.Size(153, 20);
            this.txtFilterEpc.TabIndex = 2;
            // 
            // txtFilterName
            // 
            this.txtFilterName.Location = new System.Drawing.Point(11, 142);
            this.txtFilterName.Name = "txtFilterName";
            this.txtFilterName.Size = new System.Drawing.Size(153, 20);
            this.txtFilterName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "EPC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripción";
            // 
            // txtFilterDescription
            // 
            this.txtFilterDescription.Location = new System.Drawing.Point(11, 209);
            this.txtFilterDescription.Name = "txtFilterDescription";
            this.txtFilterDescription.Size = new System.Drawing.Size(153, 20);
            this.txtFilterDescription.TabIndex = 6;
            // 
            // btnCleanFilters
            // 
            this.btnCleanFilters.Location = new System.Drawing.Point(8, 280);
            this.btnCleanFilters.Name = "btnCleanFilters";
            this.btnCleanFilters.Size = new System.Drawing.Size(75, 23);
            this.btnCleanFilters.TabIndex = 8;
            this.btnCleanFilters.Text = "Limpiar";
            this.btnCleanFilters.UseVisualStyleBackColor = true;
            this.btnCleanFilters.Click += new System.EventHandler(this.btnCleanFilters_Click);
            // 
            // ElementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtGridElements);
            this.Name = "ElementsForm";
            this.Text = "ElementForms";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridElements)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridElements;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn epc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFilterDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterName;
        private System.Windows.Forms.TextBox txtFilterEpc;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCleanFilters;
    }
}