using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data.SqlClient;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestConexionBD
    {
        [TestMethod]
        public void TestMethodAbrirConexion()
        {
            Conexion conexion = new Conexion();

            Assert.IsTrue(conexion.OpenConection() is SqlConnection);
        }

        [TestMethod]
        public void TestMethodCerrarConexion()
        {
            Conexion conexion = new Conexion();

            Assert.IsTrue(conexion.CloseConection() is SqlConnection);
        }
    }
}
