using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Fundamento_De_Base_De_Datos
{
    internal class Metodos
    {
        public static string[] ObtenerNombresDeEmpresas()
        {
            int aux =0;
            string[] NombreEmpresas = new string[50];
            for (int i = 0; i < 50; i++)
            {
                
                string ID = String.Concat(i);
                string ObtenerTope = "Select Nombre_Comp from Compañia where ID_Compañia = '" + ID + "'";
                SqlCommand QueryObtenerTope = new SqlCommand(ObtenerTope, ConexionBD.Conexion);
                ConexionBD.Conexion.Open();
                SqlDataReader RD = QueryObtenerTope.ExecuteReader();
                if (RD.Read())
                {
                    NombreEmpresas[aux] = RD.GetString(0);
                }
                aux++;
                ConexionBD.Conexion.Close();
            }
            return NombreEmpresas;
        }
        public static int ObtencionDeTope(string Tabla, string Columna)
        {
            int EspaciosVacios = 0;
            int Tope = 0;
            for (int i = 1; i < 999; i++)
            {
                string ID = String.Concat(i);
                string ObtenerTope = "Select * from " + Tabla + " where " + Columna + " = '" + ID + "'";
                SqlCommand QueryObtenerTope = new SqlCommand(ObtenerTope, ConexionBD.Conexion);
                ConexionBD.Conexion.Open();
                SqlDataReader RD = QueryObtenerTope.ExecuteReader();
                if (RD.Read())
                {
                    Tope++;
                    EspaciosVacios = 0;
                }
                else
                {
                    if(EspaciosVacios < 5)
                    {
                        Tope++;
                        EspaciosVacios++;
                    }
                    else
                    {
                        ConexionBD.Conexion.Close();
                        Tope -= 5;
                        return Tope;
                    }
                }
                ConexionBD.Conexion.Close();
            }
            return Tope;
        }
        public static bool NoIngresarNumeros(String Texto)
        {
            bool Error = false;
            char[] Numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for(int i = 0; i < Texto.Length; i++)
            {
                for(int j = 0; j < Numeros.Length; j++)
                {
                    if (Texto[i] == Numeros[j])
                    {
                        Error = true;
                    }
                }
            }
            return Error;
        }
    }
}
