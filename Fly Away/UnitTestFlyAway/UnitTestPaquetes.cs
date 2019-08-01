using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestPaquetes
    {
        [TestMethod]
        public void TestMethodInsertarPaquete()
        {
            Paquetes paquetes = new Paquetes(3, "CDMX", 1672, "Holliday Inn", 2, 3999);

            Assert.IsTrue(paquetes.InsertarPaquete());
        }

        [TestMethod]
        public void TestMethodEditarPaquete()
        {
            Paquetes paquetes = new Paquetes(12, 2, "Chapala", 1672, "Holliday Inn", 2, 3999);

            Assert.IsTrue(paquetes.EditarPaquete());
        }

        [TestMethod]
        public void TestMethodEliminarPaquete()
        {
            Paquetes paquetes = new Paquetes(12);

            Assert.IsTrue(paquetes.EliminarPaquete());
        }

        [TestMethod]
        public void TestMethodCargarPaquetes()
        {
            Paquetes paquetes = new Paquetes();

            DataTable dataTable = paquetes.CargarPaquetes();

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }
    }
}
