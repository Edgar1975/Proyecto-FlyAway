using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlassCarLaguna.CapaDatos;
using System.Data;

namespace UnitTestFlyAway
{
    [TestClass]
    public class UnitTestUsuarios
    {
        [TestMethod]
        public void TestMethodIniciarSesion()
        {
            Usuarios usuarios = new Usuarios();

            usuarios.Usuario = "asesor";
            usuarios.Contraseña = "asesor";

            DataTable table = usuarios.IniciarSesion();

            Assert.IsTrue(table.Rows.Count > 0);
        }
    }
}
