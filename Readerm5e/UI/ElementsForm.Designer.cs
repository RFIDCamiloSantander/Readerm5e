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
            this.panel1 = new System.Windows.Forms.Panel();
            this.epc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridElements)).BeginInit();
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 334);
            this.panel1.TabIndex = 1;
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
            // ElementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtGridElements);
            this.Name = "ElementForm";
            this.Text = "ElementForms";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridElements)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridElements;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn epc;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}