namespace Chameleon
{
    partial class FormVendas
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
            this.dtVendas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtVendas
            // 
            this.dtVendas.AllowUserToAddRows = false;
            this.dtVendas.AllowUserToDeleteRows = false;
            this.dtVendas.AllowUserToOrderColumns = true;
            this.dtVendas.AllowUserToResizeRows = false;
            this.dtVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVendas.Location = new System.Drawing.Point(58, 51);
            this.dtVendas.Name = "dtVendas";
            this.dtVendas.RowTemplate.Height = 24;
            this.dtVendas.Size = new System.Drawing.Size(1059, 551);
            this.dtVendas.TabIndex = 0;
            // 
            // FormVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 656);
            this.Controls.Add(this.dtVendas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormVendas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chameleon -  Vendas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormVendas_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dtVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtVendas;
    }
}

