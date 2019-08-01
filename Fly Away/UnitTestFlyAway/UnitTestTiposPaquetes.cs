using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestTiposPaquetes
    {
        [TestMethod]
        public void TestMethodInsertarTipoPaquete()
        {
            TiposPaquetes tiposPaquetes = new TiposPaquetes("Playas");

            Assert.IsTrue(tiposPaquetes.InsertarTipoPaquete());
        }

        [TestMethod]
        public void TestMethodCargarTiposPaquetes()
        {
            TiposPaquetes tiposPaquetes = new TiposPaquetes();

            DataTable dataTable = tiposPaquetes.CargarTiposPaquetes();

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }
    }
}
