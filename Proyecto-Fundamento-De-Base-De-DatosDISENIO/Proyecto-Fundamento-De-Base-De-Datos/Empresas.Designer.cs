namespace Proyecto_Fundamento_De_Base_De_Datos
{
    partial class Empresas
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
            this.lbl_ID_Empleado = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.lbl_Industria = new System.Windows.Forms.Label();
            this.lbl_Contacto = new System.Windows.Forms.Label();
            this.lbl_Telefono_Celular = new System.Windows.Forms.Label();
            this.lbl_Domicilio = new System.Windows.Forms.Label();
            this.txt_ID_Compañia = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.txt_Industria = new System.Windows.Forms.TextBox();
            this.txt_Contacto = new System.Windows.Forms.TextBox();
            this.txt_Telefono_Celular = new System.Windows.Forms.TextBox();
            this.txt_Domicilio = new System.Windows.Forms.TextBox();
            this.btn_Primero = new System.Windows.Forms.Button();
            this.btn_Anterior = new System.Windows.Forms.Button();
            this.btn_Seleccionar = new System.Windows.Forms.Button();
            this.btn_Siguente = new System.Windows.Forms.Button();
            this.btn_Ultimo = new System.Windows.Forms.Button();
            this.btn_Agregar_Borrar = new System.Windows.Forms.Button();
            this.btn_Editar_Guardar = new System.Windows.Forms.Button();
            this.btn_Reiniciar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_ID_Empleado
            // 
            this.lbl_ID_Empleado.AutoSize = true;
            this.lbl_ID_Empleado.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ID_Empleado.Location = new System.Drawing.Point(7, 6);
            this.lbl_ID_Empleado.Name = "lbl_ID_Empleado";
            this.lbl_ID_Empleado.Size = new System.Drawing.Size(138, 16);
            this.lbl_ID_Empleado.TabIndex = 25;
            this.lbl_ID_Empleado.Text = "Numero de Compañia";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Nombre.Location = new System.Drawing.Point(7, 44);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(55, 16);
            this.lbl_Nombre.TabIndex = 26;
            this.lbl_Nombre.Text = "Nombre";
            // 
            // lbl_Industria
            // 
            this.lbl_Industria.AutoSize = true;
            this.lbl_Industria.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Industria.Location = new System.Drawing.Point(6, 85);
            this.lbl_Industria.Name = "lbl_Industria";
            this.lbl_Industria.Size = new System.Drawing.Size(56, 16);
            this.lbl_Industria.TabIndex = 27;
            this.lbl_Industria.Text = "Industria";
            // 
            // lbl_Contacto
            // 
            this.lbl_Contacto.AutoSize = true;
            this.lbl_Contacto.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Contacto.Location = new System.Drawing.Point(3, 128);
            this.lbl_Contacto.Name = "lbl_Contacto";
            this.lbl_Contacto.Size = new System.Drawing.Size(61, 16);
            this.lbl_Contacto.TabIndex = 29;
            this.lbl_Contacto.Text = "Contacto";
            // 
            // lbl_Telefono_Celular
            // 
            this.lbl_Telefono_Celular.AutoSize = true;
            this.lbl_Telefono_Celular.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Telefono_Celular.Location = new System.Drawing.Point(3, 169);
            this.lbl_Telefono_Celular.Name = "lbl_Telefono_Celular";
            this.lbl_Telefono_Celular.Size = new System.Drawing.Size(134, 16);
            this.lbl_Telefono_Celular.TabIndex = 30;
            this.lbl_Telefono_Celular.Text = "Telefono de Contacto";
            // 
            // lbl_Domicilio
            // 
            this.lbl_Domicilio.AutoSize = true;
            this.lbl_Domicilio.Font = new System.Drawing.Font("Century Gothic", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Domicilio.Location = new System.Drawing.Point(7, 209);
            this.lbl_Domicilio.Name = "lbl_Domicilio";
            this.lbl_Domicilio.Size = new System.Drawing.Size(62, 16);
            this.lbl_Domicilio.TabIndex = 31;
            this.lbl_Domicilio.Text = "Domicilio";
            // 
            // txt_ID_Compañia
            // 
            this.txt_ID_Compañia.Enabled = false;
            this.txt_ID_Compañia.Location = new System.Drawing.Point(183, 6);
            this.txt_ID_Compañia.Name = "txt_ID_Compañia";
            this.txt_ID_Compañia.Size = new System.Drawing.Size(276, 22);
            this.txt_ID_Compañia.TabIndex = 34;
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(183, 50);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.ReadOnly = true;
            this.txt_Nombre.Size = new System.Drawing.Size(276, 22);
            this.txt_Nombre.TabIndex = 35;
            // 
            // txt_Industria
            // 
            this.txt_Industria.Location = new System.Drawing.Point(183, 91);
            this.txt_Industria.Name = "txt_Industria";
            this.txt_Industria.ReadOnly = true;
            this.txt_Industria.Size = new System.Drawing.Size(276, 22);
            this.txt_Industria.TabIndex = 36;
            // 
            // txt_Contacto
            // 
            this.txt_Contacto.Location = new System.Drawing.Point(183, 134);
            this.txt_Contacto.Name = "txt_Contacto";
            this.txt_Contacto.ReadOnly = true;
            this.txt_Contacto.Size = new System.Drawing.Size(276, 22);
            this.txt_Contacto.TabIndex = 38;
            // 
            // txt_Telefono_Celular
            // 
            this.txt_Telefono_Celular.Location = new System.Drawing.Point(183, 175);
            this.txt_Telefono_Celular.Name = "txt_Telefono_Celular";
            this.txt_Telefono_Celular.ReadOnly = true;
            this.txt_Telefono_Celular.Size = new System.Drawing.Size(276, 22);
            this.txt_Telefono_Celular.TabIndex = 39;
            // 
            // txt_Domicilio
            // 
            this.txt_Domicilio.Location = new System.Drawing.Point(183, 212);
            this.txt_Domicilio.Name = "txt_Domicilio";
            this.txt_Domicilio.ReadOnly = true;
            this.txt_Domicilio.Size = new System.Drawing.Size(276, 22);
            this.txt_Domicilio.TabIndex = 40;
            // 
            // btn_Primero
            // 
            this.btn_Primero.Location = new System.Drawing.Point(8, 14);
            this.btn_Primero.Name = "btn_Primero";
            this.btn_Primero.Size = new System.Drawing.Size(75, 33);
            this.btn_Primero.TabIndex = 43;
            this.btn_Primero.Text = "<<";
            this.btn_Primero.UseVisualStyleBackColor = true;
            this.btn_Primero.Click += new System.EventHandler(this.btn_Primero_Click);
            // 
            // btn_Anterior
            // 
            this.btn_Anterior.Location = new System.Drawing.Point(90, 13);
            this.btn_Anterior.Name = "btn_Anterior";
            this.btn_Anterior.Size = new System.Drawing.Size(75, 33);
            this.btn_Anterior.TabIndex = 44;
            this.btn_Anterior.Text = "<";
            this.btn_Anterior.UseVisualStyleBackColor = true;
            this.btn_Anterior.Click += new System.EventHandler(this.btn_Anterior_Click);
            // 
            // btn_Seleccionar
            // 
            this.btn_Seleccionar.Location = new System.Drawing.Point(180, 14);
            this.btn_Seleccionar.Name = "btn_Seleccionar";
            this.btn_Seleccionar.Size = new System.Drawing.Size(98, 33);
            this.btn_Seleccionar.TabIndex = 45;
            this.btn_Seleccionar.Text = "Seleccionar";
            this.btn_Seleccionar.UseVisualStyleBackColor = true;
            this.btn_Seleccionar.Click += new System.EventHandler(this.btn_Seleccionar_Click);
            // 
            // btn_Siguente
            // 
            this.btn_Siguente.Location = new System.Drawing.Point(284, 14);
            this.btn_Siguente.Name = "btn_Siguente";
            this.btn_Siguente.Size = new System.Drawing.Size(75, 33);
            this.btn_Siguente.TabIndex = 46;
            this.btn_Siguente.Text = ">";
            this.btn_Siguente.UseVisualStyleBackColor = true;
            this.btn_Siguente.Click += new System.EventHandler(this.btn_Siguente_Click);
            // 
            // btn_Ultimo
            // 
            this.btn_Ultimo.Location = new System.Drawing.Point(365, 14);
            this.btn_Ultimo.Name = "btn_Ultimo";
            this.btn_Ultimo.Size = new System.Drawing.Size(75, 33);
            this.btn_Ultimo.TabIndex = 47;
            this.btn_Ultimo.Text = ">>";
            this.btn_Ultimo.UseVisualStyleBackColor = true;
            this.btn_Ultimo.Click += new System.EventHandler(this.btn_Ultimo_Click);
            // 
            // btn_Agregar_Borrar
            // 
            this.btn_Agregar_Borrar.Location = new System.Drawing.Point(180, 52);
            this.btn_Agregar_Borrar.Name = "btn_Agregar_Borrar";
            this.btn_Agregar_Borrar.Size = new System.Drawing.Size(98, 35);
            this.btn_Agregar_Borrar.TabIndex = 48;
            this.btn_Agregar_Borrar.Text = "Agregar";
            this.btn_Agregar_Borrar.UseVisualStyleBackColor = true;
            this.btn_Agregar_Borrar.Click += new System.EventHandler(this.btn_Agregar_Borrar_Click);
            // 
            // btn_Editar_Guardar
            // 
            this.btn_Editar_Guardar.Location = new System.Drawing.Point(284, 53);
            this.btn_Editar_Guardar.Name = "btn_Editar_Guardar";
            this.btn_Editar_Guardar.Size = new System.Drawing.Size(75, 34);
            this.btn_Editar_Guardar.TabIndex = 49;
            this.btn_Editar_Guardar.Text = "btn_Editar_Guardar";
            this.btn_Editar_Guardar.UseVisualStyleBackColor = true;
            this.btn_Editar_Guardar.Visible = false;
            this.btn_Editar_Guardar.Click += new System.EventHandler(this.btn_Editar_Guardar_Click);
            // 
            // btn_Reiniciar
            // 
            this.btn_Reiniciar.Location = new System.Drawing.Point(90, 52);
            this.btn_Reiniciar.Name = "btn_Reiniciar";
            this.btn_Reiniciar.Size = new System.Drawing.Size(75, 34);
            this.btn_Reiniciar.TabIndex = 50;
            this.btn_Reiniciar.Text = "Reiniciar";
            this.btn_Reiniciar.UseVisualStyleBackColor = true;
            this.btn_Reiniciar.Visible = false;
            this.btn_Reiniciar.Click += new System.EventHandler(this.btn_Reiniciar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightPink;
            this.panel1.Controls.Add(this.btn_Buscar);
            this.panel1.Controls.Add(this.btn_Regresar);
            this.panel1.Controls.Add(this.btn_Seleccionar);
            this.panel1.Controls.Add(this.btn_Reiniciar);
            this.panel1.Controls.Add(this.btn_Primero);
            this.panel1.Controls.Add(this.btn_Editar_Guardar);
            this.panel1.Controls.Add(this.btn_Anterior);
            this.panel1.Controls.Add(this.btn_Agregar_Borrar);
            this.panel1.Controls.Add(this.btn_Siguente);
            this.panel1.Controls.Add(this.btn_Ultimo);
            this.panel1.Location = new System.Drawing.Point(12, 333);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 105);
            this.panel1.TabIndex = 51;
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Location = new System.Drawing.Point(365, 51);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(74, 35);
            this.btn_Buscar.TabIndex = 52;
            this.btn_Buscar.Text = "Buscar";
            this.btn_Buscar.UseVisualStyleBackColor = true;
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Location = new System.Drawing.Point(10, 52);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(75, 34);
            this.btn_Regresar.TabIndex = 51;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = true;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Controls.Add(this.lbl_ID_Empleado);
            this.panel2.Controls.Add(this.lbl_Nombre);
            this.panel2.Controls.Add(this.lbl_Industria);
            this.panel2.Controls.Add(this.lbl_Contacto);
            this.panel2.Controls.Add(this.lbl_Telefono_Celular);
            this.panel2.Controls.Add(this.lbl_Domicilio);
            this.panel2.Location = new System.Drawing.Point(12, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(165, 321);
            this.panel2.TabIndex = 52;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Empresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(471, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_Domicilio);
            this.Controls.Add(this.txt_Telefono_Celular);
            this.Controls.Add(this.txt_Contacto);
            this.Controls.Add(this.txt_Industria);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.txt_ID_Compañia);
            this.Name = "Empresas";
            this.Text = "Empresas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Empresas_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_ID_Empleado;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.Label lbl_Industria;
        private System.Windows.Forms.Label lbl_Contacto;
        private System.Windows.Forms.Label lbl_Telefono_Celular;
        private System.Windows.Forms.Label lbl_Domicilio;
        private System.Windows.Forms.TextBox txt_ID_Compañia;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.TextBox txt_Industria;
        private System.Windows.Forms.TextBox txt_Contacto;
        private System.Windows.Forms.TextBox txt_Telefono_Celular;
        private System.Windows.Forms.TextBox txt_Domicilio;
        private System.Windows.Forms.Button btn_Primero;
        private System.Windows.Forms.Button btn_Anterior;
        private System.Windows.Forms.Button btn_Seleccionar;
        private System.Windows.Forms.Button btn_Siguente;
        private System.Windows.Forms.Button btn_Ultimo;
        private System.Windows.Forms.Button btn_Agregar_Borrar;
        private System.Windows.Forms.Button btn_Editar_Guardar;
        private System.Windows.Forms.Button btn_Reiniciar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btn_Buscar;
    }
}