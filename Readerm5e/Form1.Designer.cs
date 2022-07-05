namespace Readerm5e
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblEpcTitle = new System.Windows.Forms.Label();
            this.cmbReaderPort = new System.Windows.Forms.ComboBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.lblEPC = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Conectar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblEpcTitle
            // 
            this.lblEpcTitle.AutoSize = true;
            this.lblEpcTitle.Location = new System.Drawing.Point(12, 68);
            this.lblEpcTitle.Name = "lblEpcTitle";
            this.lblEpcTitle.Size = new System.Drawing.Size(34, 13);
            this.lblEpcTitle.TabIndex = 1;
            this.lblEpcTitle.Text = "EPC: ";
            // 
            // cmbReaderPort
            // 
            this.cmbReaderPort.FormattingEnabled = true;
            this.cmbReaderPort.Location = new System.Drawing.Point(93, 12);
            this.cmbReaderPort.Name = "cmbReaderPort";
            this.cmbReaderPort.Size = new System.Drawing.Size(158, 21);
            this.cmbReaderPort.TabIndex = 3;
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(274, 12);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(75, 23);
            this.btnRead.TabIndex = 4;
            this.btnRead.Text = "Leer";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // lblEPC
            // 
            this.lblEPC.AutoSize = true;
            this.lblEPC.Location = new System.Drawing.Point(52, 68);
            this.lblEPC.Name = "lblEPC";
            this.lblEPC.Size = new System.Drawing.Size(0, 13);
            this.lblEPC.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado: ";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Location = new System.Drawing.Point(56, 324);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(89, 13);
            this.lblEstado.TabIndex = 7;
            this.lblEstado.Text = "Desconectado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 349);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEPC);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.cmbReaderPort);
            this.Controls.Add(this.lblEpcTitle);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblEpcTitle;
        private System.Windows.Forms.ComboBox cmbReaderPort;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label lblEPC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstado;
    }
}

