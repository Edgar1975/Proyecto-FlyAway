using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestClientes
    {
        [TestMethod]
        public void TestMethodInsertarCliente()
        {
            Clientes clientes = new Clientes(2, 3, 3, "Ramón", "Macías", "López", 21, "17084511", "SKA72YI82GS");

            Assert.IsTrue(clientes.InsertarCliente());
        }

        [TestMethod]
        public void TestMethodEditarCliente()
        {
            Clientes clientes = new Clientes(7, 1, 3, 7, "María", "Macías", "López", 21, "17084511", "SKA72YI82GS");

            Assert.IsTrue(clientes.EditarCliente());
        }

        [TestMethod]
        public void TestMethodEliminarCliente()
        {
            Clientes clientes = new Clientes(7);

            Assert.IsTrue(clientes.EliminarCliente());
        }

        [TestMethod]
        public void TestMethodCargarClientes()
        {
            Clientes clientes = new Clientes();

            DataTable dataTable = clientes.CargarClientes();

            Assert.IsTrue(dataTable.Rows.Count > 0);
        }
    }
}
