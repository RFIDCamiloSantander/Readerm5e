namespace Readerm5e.UI
{
    partial class WriteTagForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWriteEpc = new System.Windows.Forms.TextBox();
            this.btnReadEpc = new System.Windows.Forms.Button();
            this.btnWriteEpc = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtReadEpc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EPC: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "EPC:";
            // 
            // txtWriteEpc
            // 
            this.txtWriteEpc.Location = new System.Drawing.Point(49, 111);
            this.txtWriteEpc.Name = "txtWriteEpc";
            this.txtWriteEpc.Size = new System.Drawing.Size(197, 20);
            this.txtWriteEpc.TabIndex = 3;
            // 
            // btnReadEpc
            // 
            this.btnReadEpc.Location = new System.Drawing.Point(252, 59);
            this.btnReadEpc.Name = "btnReadEpc";
            this.btnReadEpc.Size = new System.Drawing.Size(75, 23);
            this.btnReadEpc.TabIndex = 4;
            this.btnReadEpc.Text = "Leer";
            this.btnReadEpc.UseVisualStyleBackColor = true;
            this.btnReadEpc.Click += new System.EventHandler(this.btnReadEpc_Click);
            // 
            // btnWriteEpc
            // 
            this.btnWriteEpc.Location = new System.Drawing.Point(252, 109);
            this.btnWriteEpc.Name = "btnWriteEpc";
            this.btnWriteEpc.Size = new System.Drawing.Size(75, 23);
            this.btnWriteEpc.TabIndex = 5;
            this.btnWriteEpc.Text = "Escribir";
            this.btnWriteEpc.UseVisualStyleBackColor = true;
            this.btnWriteEpc.Click += new System.EventHandler(this.btnWriteEpc_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Escribir Tag";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(117, 148);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(84, 13);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Label Resultado";
            // 
            // txtReadEpc
            // 
            this.txtReadEpc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReadEpc.Location = new System.Drawing.Point(49, 64);
            this.txtReadEpc.Name = "txtReadEpc";
            this.txtReadEpc.ReadOnly = true;
            this.txtReadEpc.Size = new System.Drawing.Size(197, 13);
            this.txtReadEpc.TabIndex = 8;
            // 
            // WriteTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 186);
            this.Controls.Add(this.txtReadEpc);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnWriteEpc);
            this.Controls.Add(this.btnReadEpc);
            this.Controls.Add(this.txtWriteEpc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WriteTagForm";
            this.Text = "WriteTagForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWriteEpc;
        private System.Windows.Forms.Button btnReadEpc;
        private System.Windows.Forms.Button btnWriteEpc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtReadEpc;
    }
}