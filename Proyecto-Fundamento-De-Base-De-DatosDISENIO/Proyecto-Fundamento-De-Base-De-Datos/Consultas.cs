using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Proyecto_Fundamento_De_Base_De_Datos
{
    public partial class Consultas : Form
    {
        static bool Busqueda = false;
        static int Contador = 1;
        static int ContadorBusqueda = -1;
        static int Inicio = 1;
        static int Tope = 0;
        static int TopeBusqueda = 0;
        static int[]IDs = new int[99];
        static string[] NombreEmpresas = new string[99];
        static string[] ListaEstatus = {"Activo","En Espera","Inactivo","Despedido"};
        static TextBox[] CajasDeTexto = new TextBox[8];
        public Consultas()
        {
            InitializeComponent();
            TextBox[] TXT = { txt_ID_Empleado, txt_Nombre, txt_Apellido_Paterno, txt_Apellido_Materno, txt_Edad, 
                txt_Telefono_Celular, txt_Domicilio, txt_Observaciones };
            CajasDeTexto = TXT;
            Tope = Metodos.ObtencionDeTope("Empleados","ID_Empleado");
            NombreEmpresas = Metodos.ObtenerNombresDeEmpresas();
            AñadirNombresAComboBox();
            CambioDeRegistro(Contador);
        }
        public string AñadirNombresAComboBox()
        {
            for (int i = 0; i < NombreEmpresas.Length - 1; i++)
            {
                if (NombreEmpresas[i] == null)
                {
                    return null;
                }
                else
                {
                    cob_Compañia.Items.Add(NombreEmpresas[i]);
                }
            }
            return null;
        }
        public void CambioDeRegistro(int NumRegistro)
        {
            string SacarInformacion = "Select Nombre,ApellidoP,ApellidoM,Edad,Tel_E,Dirrecion,ID_Estatus,ID_Compañia,Observacion From Empleados Where ID_Empleado=" + NumRegistro + "";
            SqlCommand QuerySacarInformacion = new SqlCommand(SacarInformacion, ConexionBD.Conexion);
            ConexionBD.Conexion.Open();
            SqlDataReader Informacion = QuerySacarInformacion.ExecuteReader();
            Informacion.Read();
            txt_ID_Empleado.Text = Convert.ToString(NumRegistro);
            txt_Nombre.Text = Informacion.GetString(0);
            txt_Apellido_Paterno.Text = Informacion.GetString(1);
            txt_Apellido_Materno.Text = Informacion.GetString(2);
            txt_Edad.Text = Convert.ToString(Informacion.GetInt32(3));
            txt_Telefono_Celular.Text = Informacion.GetString(4);
            txt_Domicilio.Text = Informacion.GetString(5);
            cob_Estatus.Text = ListaEstatus[Informacion.GetInt32(6)-1];
            cob_Compañia.Text = NombreEmpresas[Informacion.GetInt32(7)];
            if(Informacion.GetString(8)!=null)
            {
                txt_Observaciones.Text = Informacion.GetString(8);
            }
            ConexionBD.Conexion.Close();
        }

        private void btn_Siguente_Click(object sender, EventArgs e)
        {
            if (Busqueda == false)
            {
                if (Contador > Tope)
                { }
                else
                {
                    CambioDeRegistro(Contador);
                    Contador++;
                }
            }
            else
            {
                if(ContadorBusqueda >= TopeBusqueda) { }
                else
                {
                    CambioDeRegistro(IDs[ContadorBusqueda]);
                    ContadorBusqueda++;
                }
            }
            

        }

        private void btn_Ultimo_Click(object sender, EventArgs e)
        {
            if (Busqueda == false)
            {
                CambioDeRegistro(Tope);
                Contador = Tope;
            }
            else
            {
                CambioDeRegistro(IDs[TopeBusqueda-1]);
                ContadorBusqueda = TopeBusqueda-1;
            }
        }

        private void btn_Primero_Click(object sender, EventArgs e)
        {
            if(Busqueda == false)
            {
                CambioDeRegistro(Inicio);
                Contador = Inicio;
            }
            else
            {
                ContadorBusqueda = 1;
                CambioDeRegistro(ContadorBusqueda);
            }
        }

        private void btn_Anterior_Click(object sender, EventArgs e)
        {   if(Busqueda == false)
            {
                if (Contador == 1)
                { }
                else
                {
                    Contador--;
                    CambioDeRegistro(Contador);
                }
            }
            else
            {
                if (ContadorBusqueda == 0)
                { }
                else
                {
                    ContadorBusqueda--;
                    CambioDeRegistro(IDs[ContadorBusqueda]);
                }
            }

        }
        public void Reiniciar()
        {
            Busqueda = false;
            for(int i = 0; i < IDs.Length; i++)
            {
                IDs[i] = 0;
            }
            ContadorBusqueda = -1;
            TopeBusqueda = 0;
            for (int i = 0; i < CajasDeTexto.Length; i++)
            {
                CajasDeTexto[i].Text = null;
            }
            cob_Compañia.Text = null;
            cob_Estatus.Text = null;
            for(int i = 1;i < CajasDeTexto.Length; i++)
            {
                CajasDeTexto[i].ReadOnly = true;
            }
            txt_ID_Empleado.Enabled = false;
            cob_Compañia.Enabled = false;
            cob_Estatus.Enabled = false;
            btn_Guardar_Actualizar.Visible = false;
            btn_Reiniciar.Visible = false;
            btn_Agregar.Visible = true;
            btn_Buscar.Visible = true;
            btn_Agregar.Text = "Agregar";
            Contador = 1;

            btn_Primero.Visible = true;
            btn_Siguente.Visible = true;
            btn_Anterior.Visible = true;
            btn_Ultimo.Visible = true;
            btn_Buscar.Visible = true;
            btn_Seleccionar.Visible = true;
            btn_Agregar.Visible=true;
            CambioDeRegistro(Contador);

        }

        private void btn_Reiniciar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }
        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            for(int i = 1; i < CajasDeTexto.Length; i++)
            {
                if (i == 2)
                    i = 4;
                CajasDeTexto[i].ReadOnly = false;
            }
            cob_Compañia.Enabled = true;
            cob_Estatus.Enabled = true;
            btn_Reiniciar.Visible = true;
            btn_Agregar.Visible = false;
            btn_Guardar_Actualizar.Visible=true;
            btn_Guardar_Actualizar.Text = "Actualizar";

            txt_ID_Empleado.Enabled = false;
            btn_Primero.Visible = false;
            btn_Siguente.Visible = false;
            btn_Anterior.Visible = false;   
            btn_Ultimo.Visible = false;
            btn_Buscar.Visible=false;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            if(btn_Agregar.Text == "Agregar")
            {   
                btn_Agregar.Visible=false;
                btn_Guardar_Actualizar.Text = "Guardar";
                btn_Guardar_Actualizar.Visible = true;
                btn_Reiniciar.Visible=true;
                btn_Buscar.Visible = false;
                //Limpia las Txt
                for(int i = 1;i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].Clear();
                }
                for(int i = 1; i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].ReadOnly = false;
                }
                cob_Compañia.Enabled=true ;
                cob_Estatus.Enabled=true ;
                int I = 1;
                string ID = String.Concat(I); int Bandera = 0;
                do
                {
                    string BuscarID = "Select * from Empleados where ID_Empleado = '" + ID + "'";
                    SqlCommand QueryBuscarID = new SqlCommand(BuscarID, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    SqlDataReader RD = QueryBuscarID.ExecuteReader();
                    if (RD.Read())
                    {
                        I++;
                        ID = String.Concat(I);
                    }
                    else
                    {
                        Bandera = 1;
                        
                    }
                    ConexionBD.Conexion.Close();
                } while (Bandera == 0);
                txt_ID_Empleado.Text = ID;
            }
        }
        private void btn_Empresas_Click(object sender, EventArgs e)
        {
            Principal Cambio = new Principal();
            Cambio.Show();
            this.Hide();
        }

        private void btn_Guardar_Actualizar_Click(object sender, EventArgs e)
        {
            bool Error = false;
            string Observaciones = "Nada";
            if (btn_Guardar_Actualizar.Text == "Guardar")
            {
                try
                {
                    for (int i = 1; i < CajasDeTexto.Length - 4; i++)
                    {
                        if (CajasDeTexto[i].Text == "")
                            throw new Exception();
                        if (Metodos.NoIngresarNumeros(CajasDeTexto[i].Text))
                        {
                            if (Error == false)
                            {
                                MessageBox.Show("No ingresar numeros en los nombres");
                                Error = true;
                            }
                        }
                    }
                    long convertor = Convert.ToInt64(txt_Telefono_Celular.Text);
                    convertor = Convert.ToInt64(txt_Edad.Text);
                }
                catch (FormatException)
                {
                    Error = true;
                    MessageBox.Show("No ingresar letras en la casilla del telefono/Edad");
                }
                catch (Exception)
                {
                    Error = true;
                    MessageBox.Show("Caja de texto vacia. Por favor rellenarla");
                }
                if (Error == false)
                {
                    if(txt_Observaciones.Text != "")
                        Observaciones = txt_Observaciones.Text;
                    string Compañia = cob_Compañia.Text;
                    string Estatus = cob_Estatus.Text;
                    string InsertarInformacion = "INSERT INTO Empleados(ID_Empleado,Nombre,ApellidoP,ApellidoM,Edad,Tel_E,Dirrecion,ID_Estatus,ID_Compañia,Observacion) " +
                        "VALUES (" + Convert.ToInt32(txt_ID_Empleado.Text) + ",'" + txt_Nombre.Text + "','" + txt_Apellido_Paterno.Text + "','" + txt_Apellido_Materno.Text + "'" +
                        "," + Convert.ToInt32(txt_Edad.Text) + ",'" + txt_Telefono_Celular.Text + "'," +
                        "'" + txt_Domicilio.Text + "'," + ObtenerClaveEstatus(Estatus) + "," + ObtenerClaveCompañia(Compañia) + ",'"+Observaciones+"')";
                    SqlCommand QueryInsertarInformacion = new SqlCommand(InsertarInformacion, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    QueryInsertarInformacion.ExecuteNonQuery();
                    ConexionBD.Conexion.Close();
                    MessageBox.Show("Trabajador insertado");
                    Tope = Metodos.ObtencionDeTope("Empleados", "ID_Empleado");
                    Reiniciar();
                }
            }
            else
            {
                try
                {
                    for (int i = 1; i < CajasDeTexto.Length - 4; i++)
                    {
                        if (CajasDeTexto[i].Text == "")
                            throw new Exception();
                        if (Metodos.NoIngresarNumeros(CajasDeTexto[i].Text))
                        {
                            if (Error == false)
                            {
                                MessageBox.Show("No ingresar numeros en los nombres");
                                Error = true;
                            }
                        }
                    }
                    long convertor = Convert.ToInt64(txt_Telefono_Celular.Text);
                    convertor = Convert.ToInt64(txt_Edad.Text);
                }
                catch (FormatException)
                {
                    Error = true;
                    MessageBox.Show("No ingresar letras en la casilla del telefono");
                }
                catch (Exception)
                {
                    Error = true;
                    MessageBox.Show("Caja de texto vacia. Por favor rellenarla");
                }
                if (Error == false)
                {
                    if (txt_Observaciones.Text != "")
                        Observaciones = txt_Observaciones.Text;
                    string Compañia = cob_Compañia.Text;
                    string Estatus = cob_Estatus.Text;
                    string ActualizarInformacion = "UPDATE Empleados SET Edad = " + Convert.ToInt32(txt_Edad.Text) + ",Tel_E = '" + txt_Telefono_Celular.Text + "'," +
                        "Dirrecion = '" + txt_Domicilio.Text + "', ID_Estatus = " + ObtenerClaveEstatus(Estatus) + ", ID_Compañia = " + ObtenerClaveCompañia(Compañia) + " " +
                        ",Observacion ='" + Observaciones + "' WHERE ID_Empleado = " + Convert.ToInt32(txt_ID_Empleado.Text) + "";
                    SqlCommand QueryActualizarInformacion = new SqlCommand(ActualizarInformacion, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    QueryActualizarInformacion.ExecuteNonQuery();
                    ConexionBD.Conexion.Close();
                    MessageBox.Show("Empleado Actualizado con exito");
                    //reinicia cuando Actualizas
                    Reiniciar();
                }
            }
        }
        public int ObtenerClaveEstatus(string Estatus)
        {
            int Bandera = 0,Contador = 0;
            do
            {
                if (ListaEstatus[Contador] == Estatus)
                {
                    return Contador+1;
                }
                else
                    Contador++;
            } while (Bandera == 0);

            return 0;
        }
        public int ObtenerClaveCompañia(String Compañia)
        {
            int Bandera = 0, Contador = 0;
            do
            {
                if (NombreEmpresas[Contador] == Compañia)
                {
                    return Contador;
                }
                else
                    Contador++;
            } while (Bandera == 0);

            return 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            

            if (Contador>Tope)
            { btn_Siguente.Enabled=false;
                btn_Ultimo.Enabled=false;   
            }
            else 
            {
                btn_Siguente.Enabled = true;
                btn_Ultimo.Enabled = true;
            }

            if(Contador==1) 
            { 
                btn_Anterior.Enabled = false;
                btn_Primero.Enabled = false;
            }
            else
            {
                btn_Anterior.Enabled = true;
                btn_Primero.Enabled = true;
            }
            if (ContadorBusqueda >= TopeBusqueda)
            {
                btn_Siguente.Enabled = false;
                btn_Ultimo.Enabled = false;
            }
            else
            {
                btn_Siguente.Enabled = true;
                btn_Ultimo.Enabled = true;
            }
            if(ContadorBusqueda==0)
            {
                btn_Anterior.Enabled = false;
                btn_Primero.Enabled = false;
            }
            else
            {
                btn_Anterior.Enabled = true;
                btn_Primero.Enabled = true;
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string[] NombresCajas = {"ID_Empleado=","Nombre=","ApellidoP=","ApellidoM=","Edad=","","","ID_Estatus=","ID_Compañia=" };
            int[] CajasActivas = new int[NombresCajas.Length];
            Contador = -1;
            if (btn_Reiniciar.Visible == false)
            {
                Busqueda = true;
                for (int i = 0; i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].Text = null;
                }
                btn_Reiniciar.Visible = true;
                btn_Agregar.Visible = false;
                btn_Seleccionar.Visible = false;
                cob_Compañia.Text = null;
                cob_Estatus.Text = null;
                txt_ID_Empleado.Enabled = true;
                txt_Nombre.ReadOnly = false;
                txt_Apellido_Paterno.ReadOnly = false;
                txt_Apellido_Materno.ReadOnly = false;
                txt_Edad.ReadOnly = false;
                cob_Compañia.Enabled = true;
                cob_Estatus.Enabled = true;
                cob_Compañia.Text = "";
                cob_Estatus.Text = "";
            }
            else
            {
                TopeBusqueda = 0;
                ContadorBusqueda = 0;
                bool ErrorNumerico = false;
                bool Cerrador=false;
                bool Vacio=false;
                string QueryDinamico = "";
                if(txt_ID_Empleado.Text == "" && txt_Nombre.Text == "" && txt_Apellido_Paterno.Text == "" && txt_Apellido_Materno.Text == "" && txt_Edad.Text == "" && cob_Compañia.Text == "" && cob_Estatus.Text == "")
                {
                    Vacio = true;
                }
                if (Vacio == false)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (CajasDeTexto[i].Text != "")
                        {
                            if (NombresCajas[i] == "ID_Empleado=")
                            {
                                Cerrador = true;
                            }
                            else
                            {
                                string aux = CajasDeTexto[i].Text;
                                string Adiccion = " AND " + NombresCajas[i] + "'" + aux + "' ";
                                QueryDinamico += Adiccion;
                            }
                        }
                    }
                    if (cob_Compañia.Text != "")
                    {
                        string queryTemporal = "Select ID_Compañia From Compañia Where Nombre_Comp='" + cob_Compañia.Text + "'";
                        SqlCommand QueryNombre = new SqlCommand(queryTemporal, ConexionBD.Conexion);
                        ConexionBD.Conexion.Open();
                        SqlDataReader Nombre = QueryNombre.ExecuteReader();
                        Nombre.Read();
                        int aux = Nombre.GetInt32(0);
                        ConexionBD.Conexion.Close();
                        string Adiccion = " AND ID_Compañia=" + Convert.ToString(aux);
                        QueryDinamico += Adiccion;
                    }
                    if (cob_Estatus.Text != "")
                    {
                        int aux = 0;
                        for (int i = 0; i < ListaEstatus.Length; i++)
                        {
                            if (ListaEstatus[i] == cob_Estatus.Text)
                                aux = i + 1;
                        }
                        string Adiccion = " AND ID_Estatus=" + Convert.ToString(aux);
                        QueryDinamico += Adiccion;
                    }
                    if (txt_Edad.Text != "")
                    {
                        try
                        {
                            int aux = Convert.ToInt32(txt_Edad.Text);
                            string Adiccion = " AND Edad=" + Convert.ToString(aux);
                            QueryDinamico += Adiccion;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("No ingresar letras en la edad");
                            ErrorNumerico = true;
                        }
                    }
                    if (ErrorNumerico == false)
                    {
                        int EspaciosVacios = 0;
                        int Registro = 1;
                        ContadorBusqueda = 0;
                        if (Cerrador == true)
                        {
                            QueryDinamico = "";
                            EspaciosVacios = 100;
                            Registro = Convert.ToInt32(CajasDeTexto[0].Text);
                        }
                        int Resultados = 0;
                        do
                        {
                            string Query = "Select ID_Empleado From Empleados Where ID_Empleado=" + Registro + QueryDinamico;
                            SqlCommand QueryCompleto = new SqlCommand(Query, ConexionBD.Conexion);
                            ConexionBD.Conexion.Open();
                            SqlDataReader Resultado = QueryCompleto.ExecuteReader();
                            if (Resultado.Read())
                            {
                                if (Cerrador == true)
                                {
                                    IDs[Resultados] = Registro;
                                    TopeBusqueda = 1;

                                }
                                else
                                {
                                    IDs[Resultados] = Resultado.GetInt32(0);
                                    Resultados++;
                                    Registro++;
                                    TopeBusqueda++;
                                    EspaciosVacios = 0;
                                }
                            }
                            else
                            {
                                EspaciosVacios++;
                                Registro++;
                            }
                            ConexionBD.Conexion.Close();
                        } while (EspaciosVacios < 100);
                        if (TopeBusqueda > 0)
                        {
                            btn_Buscar.Visible = false;
                            cob_Compañia.Enabled = false;
                            cob_Estatus.Enabled = false;
                            btn_Seleccionar.Visible = true;
                            txt_ID_Empleado.ReadOnly = true;
                            txt_Nombre.ReadOnly = true;
                            txt_Apellido_Paterno.ReadOnly = true;
                            txt_Apellido_Materno.ReadOnly = true;
                            txt_Edad.ReadOnly = true;
                            CambioDeRegistro(IDs[ContadorBusqueda]);
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron registros");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden realizar busquedas con todas las cajas de texto vacias");
                }
            }
        }

        private void Consultas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
        }
    }
}
