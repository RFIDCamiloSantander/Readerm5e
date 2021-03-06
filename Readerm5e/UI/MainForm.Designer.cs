namespace Readerm5e
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblEpcTitle = new System.Windows.Forms.Label();
            this.cmbReaderPort = new System.Windows.Forms.ComboBox();
            this.btnRead1 = new System.Windows.Forms.Button();
            this.lblEPC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnStartReading = new System.Windows.Forms.Button();
            this.dtGridResults = new System.Windows.Forms.DataGridView();
            this.EPC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantReadings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastSeenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnReWrite = new System.Windows.Forms.Button();
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnReadings = new System.Windows.Forms.Button();
            this.btnLimpiarTabla = new System.Windows.Forms.Button();
            this.btnElementos = new System.Windows.Forms.Button();
            this.btnEditElement = new System.Windows.Forms.Button();
            this.btnAutoWrite = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAutoWriteState = new System.Windows.Forms.Label();
            this.trackBarReadPower = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReadPower)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.AutoSize = true;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(124, 13);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(127, 28);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblEpcTitle
            // 
            this.lblEpcTitle.AutoSize = true;
            this.lblEpcTitle.Location = new System.Drawing.Point(16, 81);
            this.lblEpcTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEpcTitle.Name = "lblEpcTitle";
            this.lblEpcTitle.Size = new System.Drawing.Size(40, 16);
            this.lblEpcTitle.TabIndex = 1;
            this.lblEpcTitle.Text = "EPC: ";
            // 
            // cmbReaderPort
            // 
            this.cmbReaderPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReaderPort.FormattingEnabled = true;
            this.cmbReaderPort.Location = new System.Drawing.Point(259, 15);
            this.cmbReaderPort.Margin = new System.Windows.Forms.Padding(4);
            this.cmbReaderPort.Name = "cmbReaderPort";
            this.cmbReaderPort.Size = new System.Drawing.Size(237, 24);
            this.cmbReaderPort.TabIndex = 3;
            // 
            // btnRead1
            // 
            this.btnRead1.Location = new System.Drawing.Point(760, 13);
            this.btnRead1.Margin = new System.Windows.Forms.Padding(4);
            this.btnRead1.Name = "btnRead1";
            this.btnRead1.Size = new System.Drawing.Size(100, 28);
            this.btnRead1.TabIndex = 4;
            this.btnRead1.Text = "Leer 1";
            this.btnRead1.UseVisualStyleBackColor = true;
            this.btnRead1.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblEPC
            // 
            this.lblEPC.AutoSize = true;
            this.lblEPC.Location = new System.Drawing.Point(69, 81);
            this.lblEPC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEPC.Name = "lblEPC";
            this.lblEPC.Size = new System.Drawing.Size(0, 16);
            this.lblEPC.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 481);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado: ";
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Location = new System.Drawing.Point(66, 481);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(108, 16);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Desconectado";
            // 
            // btnStartReading
            // 
            this.btnStartReading.Location = new System.Drawing.Point(597, 13);
            this.btnStartReading.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartReading.Name = "btnStartReading";
            this.btnStartReading.Size = new System.Drawing.Size(155, 28);
            this.btnStartReading.TabIndex = 8;
            this.btnStartReading.Text = "Iniciar Lecturas";
            this.btnStartReading.UseVisualStyleBackColor = true;
            this.btnStartReading.Click += new System.EventHandler(this.btnStartReading_Click);
            // 
            // dtGridResults
            // 
            this.dtGridResults.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtGridResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGridResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EPC,
            this.Nombre,
            this.cantReadings,
            this.lastSeenDate,
            this.Descripcion});
            this.dtGridResults.Location = new System.Drawing.Point(16, 102);
            this.dtGridResults.Margin = new System.Windows.Forms.Padding(4);
            this.dtGridResults.Name = "dtGridResults";
            this.dtGridResults.RowHeadersVisible = false;
            this.dtGridResults.Size = new System.Drawing.Size(977, 371);
            this.dtGridResults.TabIndex = 9;
            // 
            // EPC
            // 
            this.EPC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.EPC.HeaderText = "EPC";
            this.EPC.Name = "EPC";
            this.EPC.ReadOnly = true;
            this.EPC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.EPC.Width = 59;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Nombre.Width = 81;
            // 
            // cantReadings
            // 
            this.cantReadings.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.cantReadings.HeaderText = "Veces Leído";
            this.cantReadings.Name = "cantReadings";
            this.cantReadings.ReadOnly = true;
            this.cantReadings.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cantReadings.Width = 108;
            // 
            // lastSeenDate
            // 
            this.lastSeenDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.lastSeenDate.HeaderText = "Fecha";
            this.lastSeenDate.Name = "lastSeenDate";
            this.lastSeenDate.ReadOnly = true;
            this.lastSeenDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.lastSeenDate.Width = 70;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(505, 13);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 28);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refrescar";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnReWrite
            // 
            this.btnReWrite.Location = new System.Drawing.Point(868, 13);
            this.btnReWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnReWrite.Name = "btnReWrite";
            this.btnReWrite.Size = new System.Drawing.Size(100, 28);
            this.btnReWrite.TabIndex = 11;
            this.btnReWrite.Text = "Re-escribir";
            this.btnReWrite.UseVisualStyleBackColor = true;
            this.btnReWrite.Click += new System.EventHandler(this.btnReWrite_Click);
            // 
            // btnEnroll
            // 
            this.btnEnroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnroll.Location = new System.Drawing.Point(1001, 101);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(4);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(100, 28);
            this.btnEnroll.TabIndex = 12;
            this.btnEnroll.Text = "Enrolar";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnReadings
            // 
            this.btnReadings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadings.Location = new System.Drawing.Point(1001, 173);
            this.btnReadings.Margin = new System.Windows.Forms.Padding(4);
            this.btnReadings.Name = "btnReadings";
            this.btnReadings.Size = new System.Drawing.Size(100, 28);
            this.btnReadings.TabIndex = 13;
            this.btnReadings.Text = "Lecturas";
            this.btnReadings.UseVisualStyleBackColor = true;
            this.btnReadings.Click += new System.EventHandler(this.btnReadings_Click);
            // 
            // btnLimpiarTabla
            // 
            this.btnLimpiarTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarTabla.Location = new System.Drawing.Point(1001, 445);
            this.btnLimpiarTabla.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarTabla.Name = "btnLimpiarTabla";
            this.btnLimpiarTabla.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiarTabla.TabIndex = 14;
            this.btnLimpiarTabla.Text = "Limpiar";
            this.btnLimpiarTabla.UseVisualStyleBackColor = true;
            this.btnLimpiarTabla.Click += new System.EventHandler(this.btnLimpiarTabla_Click);
            // 
            // btnElementos
            // 
            this.btnElementos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElementos.Location = new System.Drawing.Point(1001, 137);
            this.btnElementos.Margin = new System.Windows.Forms.Padding(4);
            this.btnElementos.Name = "btnElementos";
            this.btnElementos.Size = new System.Drawing.Size(100, 28);
            this.btnElementos.TabIndex = 15;
            this.btnElementos.Text = "Elementos";
            this.btnElementos.UseVisualStyleBackColor = true;
            this.btnElementos.Click += new System.EventHandler(this.btnElementos_Click);
            // 
            // btnEditElement
            // 
            this.btnEditElement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditElement.Location = new System.Drawing.Point(1001, 210);
            this.btnEditElement.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditElement.Name = "btnEditElement";
            this.btnEditElement.Size = new System.Drawing.Size(100, 43);
            this.btnEditElement.TabIndex = 16;
            this.btnEditElement.Text = "Editar Elemento";
            this.btnEditElement.UseVisualStyleBackColor = true;
            this.btnEditElement.Click += new System.EventHandler(this.btnEditElement_Click);
            // 
            // btnAutoWrite
            // 
            this.btnAutoWrite.Location = new System.Drawing.Point(976, 13);
            this.btnAutoWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoWrite.Name = "btnAutoWrite";
            this.btnAutoWrite.Size = new System.Drawing.Size(125, 28);
            this.btnAutoWrite.TabIndex = 17;
            this.btnAutoWrite.Text = "Auto-Escritura";
            this.btnAutoWrite.UseVisualStyleBackColor = true;
            this.btnAutoWrite.Click += new System.EventHandler(this.btnAutoWrite_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 481);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Auto-Escritura:";
            // 
            // lblAutoWriteState
            // 
            this.lblAutoWriteState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutoWriteState.AutoSize = true;
            this.lblAutoWriteState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutoWriteState.ForeColor = System.Drawing.Color.Red;
            this.lblAutoWriteState.Location = new System.Drawing.Point(302, 481);
            this.lblAutoWriteState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAutoWriteState.Name = "lblAutoWriteState";
            this.lblAutoWriteState.Size = new System.Drawing.Size(95, 16);
            this.lblAutoWriteState.TabIndex = 19;
            this.lblAutoWriteState.Text = "Desactivado";
            // 
            // trackBarReadPower
            // 
            this.trackBarReadPower.Location = new System.Drawing.Point(20, 25);
            this.trackBarReadPower.Maximum = 23;
            this.trackBarReadPower.Minimum = 10;
            this.trackBarReadPower.Name = "trackBarReadPower";
            this.trackBarReadPower.Size = new System.Drawing.Size(104, 45);
            this.trackBarReadPower.TabIndex = 20;
            this.trackBarReadPower.Value = 23;
            this.trackBarReadPower.Scroll += new System.EventHandler(this.trackBarReadPower_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Potencia Lector";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 506);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.trackBarReadPower);
            this.Controls.Add(this.lblAutoWriteState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAutoWrite);
            this.Controls.Add(this.btnEditElement);
            this.Controls.Add(this.btnElementos);
            this.Controls.Add(this.btnLimpiarTabla);
            this.Controls.Add(this.btnReadings);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.btnReWrite);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtGridResults);
            this.Controls.Add(this.btnStartReading);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEPC);
            this.Controls.Add(this.btnRead1);
            this.Controls.Add(this.cmbReaderPort);
            this.Controls.Add(this.lblEpcTitle);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1125, 529);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarReadPower)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblEpcTitle;
        private System.Windows.Forms.ComboBox cmbReaderPort;
        private System.Windows.Forms.Button btnRead1;
        private System.Windows.Forms.Label lblEPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnStartReading;
        private System.Windows.Forms.DataGridView dtGridResults;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReWrite;
        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnReadings;
        private System.Windows.Forms.Button btnLimpiarTabla;
        private System.Windows.Forms.Button btnElementos;
        private System.Windows.Forms.Button btnEditElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn EPC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantReadings;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastSeenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.Button btnAutoWrite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAutoWriteState;
        private System.Windows.Forms.TrackBar trackBarReadPower;
        private System.Windows.Forms.Label label3;
    }
}

