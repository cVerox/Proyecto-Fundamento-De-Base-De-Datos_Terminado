using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proyecto_Fundamento_De_Base_De_Datos
{
    public static class ConexionBD
    {
        //Query para conectarse. Importante: Si se usa en otro dispositivo de momento se tienen que editar los apartados
        //Server y database por aquellos del dispositivo correspodiente, mas informacion en el manual
        static string ConexionString = @"server= LTG\MSSQLSERVER01; database= FUNDAMENTOS-BASE-DE-DATOS ; integrated security= true";
        public static SqlConnection Conexion = new SqlConnection(ConexionString);
    }
}
