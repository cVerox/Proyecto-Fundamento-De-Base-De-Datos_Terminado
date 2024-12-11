using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Fundamento_De_Base_De_Datos
{
    public partial class Empresas : Form
    {
        static bool Busqueda=false;
        static int Contador = 1;
        static int Inicio = 1;
        static int Tope = 0;
        static int ContadorBusqueda = -1, TopeBusqueda = 0;
        static int ContadorIntentosFallidos = 0;
        static TextBox[] CajasDeTexto = new TextBox[6];
        static int[] IDs = new int[99];
        public Empresas()
        {
            InitializeComponent();
            Tope = Metodos.ObtencionDeTope("Compañia", "ID_Compañia");
            TextBox[] TXT = { txt_ID_Compañia, txt_Nombre, txt_Industria, txt_Contacto, txt_Telefono_Celular, txt_Domicilio };
            CajasDeTexto = TXT;
            CambioDeRegistro(Contador);
        }
        public void CambioDeRegistro(int NumRegistro)
        {
            string SacarInformacion = "Select Nombre_Comp,Industria,Contacto,Tel_C,Direccion_Comp From Compañia Where ID_Compañia =" + NumRegistro + "";
            SqlCommand QuerySacarInformacion = new SqlCommand(SacarInformacion, ConexionBD.Conexion);
            ConexionBD.Conexion.Open();
            SqlDataReader Informacion = QuerySacarInformacion.ExecuteReader();
            if (Informacion.Read())
            {
                txt_ID_Compañia.Text = Convert.ToString(NumRegistro);
                for(int i = 0; i < CajasDeTexto.Length-1; i++)
                {
                    string aux = Informacion.GetString(i);
                    CajasDeTexto[i+1].Text = aux;
                }
                ConexionBD.Conexion.Close();
            }
            else
            {
                if (ContadorIntentosFallidos <= 5)
                {
                    ConexionBD.Conexion.Close();
                    CambioDeRegistro(NumRegistro + 1);
                }
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
                if (ContadorBusqueda >= TopeBusqueda) { }
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
                CambioDeRegistro(IDs[TopeBusqueda - 1]);
                ContadorBusqueda = TopeBusqueda - 1;
            }
        }

        private void btn_Anterior_Click(object sender, EventArgs e)
        {
            if (Busqueda == false)
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

        private void btn_Primero_Click(object sender, EventArgs e)
        {
            if (Busqueda == false)
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

        private void btn_Agregar_Borrar_Click(object sender, EventArgs e)
        {
            if(btn_Agregar_Borrar.Text == "Agregar")
            {
                btn_Agregar_Borrar.Visible = false;
                for(int i = 1; i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].ReadOnly = false;
                }
                for(int i = 1;i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].Clear();
                }

                btn_Editar_Guardar.Visible = true;
                btn_Editar_Guardar.Text = "Guardar";
                int I = 1;
                string ID = String.Concat(I); int Bandera = 0;
                do
                {
                    string BuscarID = "Select * from Compañia where ID_Compañia = '" + ID + "'";
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
                txt_ID_Compañia.Text = ID;
                btn_Reiniciar.Visible = true;
            }
            else
            {
                bool Error = false;
                    string Comprobacion = "Select * From Empleados Where ID_Compañia=" + txt_ID_Compañia.Text;
                    SqlCommand QueryComprobacion = new SqlCommand(Comprobacion, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    SqlDataReader Datos = QueryComprobacion.ExecuteReader();
                    if (Datos.Read())
                    {
                        Error = true;
                    }
                ConexionBD.Conexion.Close();
               if(Error == false)
                {
                    string Eliminar = "DELETE FROM Compañia WHERE ID_Compañia = " + txt_ID_Compañia.Text;
                    SqlCommand QueryEliminar = new SqlCommand(Eliminar, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    QueryEliminar.ExecuteNonQuery();
                    ConexionBD.Conexion.Close();
                    MessageBox.Show("Registro Eliminado");
                    Tope = Metodos.ObtencionDeTope("Compañia", "ID_Compañia");
                    Reiniciar();
                }
                else
                {
                    MessageBox.Show("Empleados vinculados a la empresa");
                }
                
            }
            
        }

        private void btn_Editar_Guardar_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(txt_ID_Compañia.Text);
            bool Error = false;
            if (btn_Editar_Guardar.Text == "Guardar") 
            {
                try
                {
                    for (int i = 1; i < CajasDeTexto.Length-2; i++)
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
                    string InsertarInformacion = "INSERT INTO Compañia(ID_Compañia,Nombre_Comp,Direccion_Comp,Industria,Contacto,Tel_C) VALUES (" + ID + ",'" + txt_Nombre.Text + "" +
                                        "','" + txt_Domicilio.Text + "','" + txt_Industria.Text + "','" + txt_Contacto.Text + "','" + txt_Telefono_Celular.Text + "')";
                    SqlCommand QueryInsertarInformacion = new SqlCommand(InsertarInformacion, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    QueryInsertarInformacion.ExecuteNonQuery();
                    ConexionBD.Conexion.Close();
                    MessageBox.Show("Empresa registrada");
                    Tope = Metodos.ObtencionDeTope("Compañia", "ID_Compañia");
                    Reiniciar();
                }
            }
            else
            {
                try
                {
                    for (int i = 1; i < CajasDeTexto.Length - 2; i++)
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
                }
                catch(FormatException) 
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
                    string ActualizarInformacion = "UPDATE Compañia SET Nombre_Comp ='" + txt_Nombre.Text + "'," +
                        "Contacto = '" + txt_Contacto.Text + "', Tel_C = '" + txt_Telefono_Celular.Text + "' WHERE ID_Compañia = " + Convert.ToInt32(txt_ID_Compañia.Text);
                    SqlCommand QueryActualizar = new SqlCommand(ActualizarInformacion, ConexionBD.Conexion);
                    ConexionBD.Conexion.Open();
                    QueryActualizar.ExecuteNonQuery();
                    ConexionBD.Conexion.Close();
                    MessageBox.Show("Actualizado con exito");
                    Reiniciar();
                }
            }
        }

        private void btn_Reiniciar_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void btn_Seleccionar_Click(object sender, EventArgs e)
        {
            Busqueda = false;
            for (int i = 0; i < IDs.Length; i++)
            {
                IDs[i] = 0;
            }
            ContadorBusqueda = -1;
            TopeBusqueda = 0;
            Contador = 1;
            btn_Agregar_Borrar.Text = "Borrar";
            btn_Editar_Guardar.Text = "Editar";
            btn_Reiniciar.Visible = true;
            btn_Editar_Guardar.Visible = true;
            for(int i = 1; i < CajasDeTexto.Length; i++)
            {
                CajasDeTexto[i].ReadOnly = false;
            }

            btn_Primero.Visible = false;
            btn_Siguente.Visible = false;
            btn_Anterior.Visible = false;
            btn_Ultimo.Visible = false;
        }
        public void Reiniciar()
        {
            for (int i = 0; i < CajasDeTexto.Length; i++) 
            {
                CajasDeTexto[i].Clear();
            }
            for (int i = 1;i < CajasDeTexto.Length; i++)
            {
                CajasDeTexto[i].ReadOnly = true;
            }
            btn_Editar_Guardar.Visible = false;
            btn_Reiniciar.Visible = false;
            btn_Agregar_Borrar.Text = "Agregar";
            Contador = 1;

            txt_ID_Compañia.Enabled = false;
            btn_Buscar.Visible = true;
            btn_Agregar_Borrar.Visible = true;
            btn_Primero.Visible = true;
            btn_Siguente.Visible = true;
            btn_Anterior.Visible = true;
            btn_Ultimo.Visible = true;
            CambioDeRegistro(Contador);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (Contador > Tope)
            {
                btn_Siguente.Enabled = false;
                btn_Ultimo.Enabled = false;
            }
            else
            {
                btn_Siguente.Enabled = true;
                btn_Ultimo.Enabled = true;
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
            if (Contador == 1)
            {
                btn_Anterior.Enabled = false;
                btn_Primero.Enabled = false;
            }
            else
            {
                btn_Anterior.Enabled = true;
                btn_Primero.Enabled = true;
            }
            if (ContadorBusqueda == 0)
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

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            Principal Cambio = new Principal();
            this.Hide();
            Cambio.Show();
        }

        private void Empresas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Principal principal = new Principal();
            principal.Show();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string[] NombresCajas = { "ID_Compañia=", "Nombre_Comp=", "Industria="};
            int[] CajasActivas = new int[NombresCajas.Length];
            Contador = -1;
            if (btn_Reiniciar.Visible == false)
            {
                Busqueda = true;
                for (int i = 0; i < CajasDeTexto.Length; i++)
                {
                    CajasDeTexto[i].Text = null;
                }
                for (int i = 1; i < 3; i++)
                {
                    CajasDeTexto[i].ReadOnly = false;
                }
                txt_ID_Compañia.Enabled = true;
                btn_Reiniciar.Visible = true;
                btn_Seleccionar.Visible = false;
                btn_Agregar_Borrar.Visible = false;
                btn_Editar_Guardar.Visible = false;
            }
            else 
            {
                TopeBusqueda = 0;
                ContadorBusqueda = 0;
                bool ErrorNumerico = false;
                bool Cerrador = false;
                bool Vacio = false;
                string QueryDinamico = "";
                if (txt_ID_Compañia.Text == "" && txt_Nombre.Text == "" && txt_Industria.Text == "")
                {
                    Vacio = true;
                }
                if (Vacio == false)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (CajasDeTexto[i].Text != "")
                        {
                            if (NombresCajas[i] == "ID_Compañia=")
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
                        string Query = "Select ID_Compañia From Compañia Where ID_Compañia=" + Registro + QueryDinamico;
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
                        btn_Seleccionar.Visible = true;
                        txt_ID_Compañia.ReadOnly = true;
                        txt_Nombre.ReadOnly = true;
                        txt_Industria.ReadOnly = true;
                        CambioDeRegistro(IDs[ContadorBusqueda]);
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron registros");
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden realizar busquedas con todas las cajas de texto vacias");
                }
            }
        }
    }
}
