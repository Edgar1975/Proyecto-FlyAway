using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestEscuelas
    {
        [TestMethod]
        public void TestMethodInsertarEscuela()
        {
            Escuelas escuelas = new Escuelas("IGP");

            Assert.IsTrue(escuelas.InsertarEscuela());
        }

        [TestMethod]
        public void TestMethodCargarEscuelas()
        {
            Escuelas escuelas = new Escuelas();

            DataTable dataTable = escuelas.CargarEscuelas();

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }

        [TestMethod]
        public void TestMethodCargarReportes()
        {
            Escuelas escuelas = new Escuelas();

            escuelas.Nombre = "UPGOP";

            DataTable dataTable = escuelas.CargarReportes();

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }
    }
}
