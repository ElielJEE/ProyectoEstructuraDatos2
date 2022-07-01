
namespace ProyectoEstructuraDatos2_Eliel_Escobar
{
    partial class GrafosForm
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
            this.btnIngresarNumeros = new System.Windows.Forms.Button();
            this.btnIngresarDistancia = new System.Windows.Forms.Button();
            this.btnCaminosCortos = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumeroVertices = new System.Windows.Forms.TextBox();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnIngresarNumeros
            // 
            this.btnIngresarNumeros.Location = new System.Drawing.Point(121, 23);
            this.btnIngresarNumeros.Name = "btnIngresarNumeros";
            this.btnIngresarNumeros.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarNumeros.TabIndex = 0;
            this.btnIngresarNumeros.Text = "Ingresar";
            this.btnIngresarNumeros.UseVisualStyleBackColor = true;
            this.btnIngresarNumeros.Click += new System.EventHandler(this.btnIngresarNumeros_Click);
            // 
            // btnIngresarDistancia
            // 
            this.btnIngresarDistancia.Location = new System.Drawing.Point(111, 240);
            this.btnIngresarDistancia.Name = "btnIngresarDistancia";
            this.btnIngresarDistancia.Size = new System.Drawing.Size(75, 23);
            this.btnIngresarDistancia.TabIndex = 1;
            this.btnIngresarDistancia.Text = "Ingresar";
            this.btnIngresarDistancia.UseVisualStyleBackColor = true;
            this.btnIngresarDistancia.Click += new System.EventHandler(this.btnIngresarDistancia_Click);
            // 
            // btnCaminosCortos
            // 
            this.btnCaminosCortos.Location = new System.Drawing.Point(93, 269);
            this.btnCaminosCortos.Name = "btnCaminosCortos";
            this.btnCaminosCortos.Size = new System.Drawing.Size(109, 23);
            this.btnCaminosCortos.TabIndex = 2;
            this.btnCaminosCortos.Text = "Ver caminos Cortos";
            this.btnCaminosCortos.UseVisualStyleBackColor = true;
            this.btnCaminosCortos.Click += new System.EventHandler(this.btnCaminosCortos_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(306, 133);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ingrese numero de vertices";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ingrese distancia del";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "vertice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "al vertice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Existe una distancia entre el vertice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(367, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "al vertice";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 13);
            this.label10.TabIndex = 13;
            // 
            // txtNumeroVertices
            // 
            this.txtNumeroVertices.Location = new System.Drawing.Point(15, 25);
            this.txtNumeroVertices.Name = "txtNumeroVertices";
            this.txtNumeroVertices.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroVertices.TabIndex = 14;
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(93, 214);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(109, 20);
            this.txtDistancia.TabIndex = 15;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "No",
            "Si"});
            this.comboBox1.Location = new System.Drawing.Point(285, 106);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 299);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(504, 150);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // GrafosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 461);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtDistancia);
            this.Controls.Add(this.txtNumeroVertices);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCaminosCortos);
            this.Controls.Add(this.btnIngresarDistancia);
            this.Controls.Add(this.btnIngresarNumeros);
            this.Name = "GrafosForm";
            this.Text = "GrafosForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarNumeros;
        private System.Windows.Forms.Button btnIngresarDistancia;
        private System.Windows.Forms.Button btnCaminosCortos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumeroVertices;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}