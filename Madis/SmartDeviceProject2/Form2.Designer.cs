namespace SmartDeviceProject2
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEquipamento = new System.Windows.Forms.ComboBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Salvar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.Text = "Nº do Equipamento:";
            // 
            // txtEquipamento
            // 
            this.txtEquipamento.Items.Add("1");
            this.txtEquipamento.Items.Add("2");
            this.txtEquipamento.Items.Add("3");
            this.txtEquipamento.Items.Add("4");
            this.txtEquipamento.Items.Add("5");
            this.txtEquipamento.Items.Add("6");
            this.txtEquipamento.Items.Add("7");
            this.txtEquipamento.Items.Add("8");
            this.txtEquipamento.Items.Add("9");
            this.txtEquipamento.Items.Add("10");
            this.txtEquipamento.Items.Add("11");
            this.txtEquipamento.Items.Add("12");
            this.txtEquipamento.Items.Add("13");
            this.txtEquipamento.Items.Add("14");
            this.txtEquipamento.Items.Add("15");
            this.txtEquipamento.Items.Add("16");
            this.txtEquipamento.Items.Add("17");
            this.txtEquipamento.Items.Add("18");
            this.txtEquipamento.Items.Add("19");
            this.txtEquipamento.Items.Add("20");
            this.txtEquipamento.Location = new System.Drawing.Point(149, 86);
            this.txtEquipamento.Name = "txtEquipamento";
            this.txtEquipamento.Size = new System.Drawing.Size(54, 22);
            this.txtEquipamento.TabIndex = 2;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(27, 141);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(166, 21);
            this.txtIP.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.Text = "Endereço Webservice:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEquipamento);
            this.Controls.Add(this.button1);
            this.Menu = this.mainMenu1;
            this.Name = "Form2";
            this.Text = "Configuração";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox txtEquipamento;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MainMenu mainMenu1;
    }
}