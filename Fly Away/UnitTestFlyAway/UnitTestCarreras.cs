using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestCarreras
    {
        [TestMethod]
        public void TestMethodInsertarCarrera()
        {
            Carreras carreras = new Carreras(1, "Administración");

            Assert.IsTrue(carreras.InsertarCarrera());
        }

        [TestMethod]
        public void TestMethodCargarCarreras()
        {
            Carreras carreras = new Carreras();

            carreras.Nombre_escuela = "UPGOP";

            DataTable dataTable = carreras.CargarCarreras();

            Assert.IsTrue(dataTable.Rows.Count > 0);
            DataRow row = dataTable.Rows[0];
            Assert.IsNotNull(row["nombre"]);
        }
    }
}
