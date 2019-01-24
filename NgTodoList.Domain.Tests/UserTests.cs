using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NgTodoList.Domain.Tests
{
    [TestClass]
    public class Dado_um_novo_usuario
    {
        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_nome_deve_ser_valido()
        {
            var user = new User("", "christian.eds@hotmail.com", "123");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_email_deve_ser_valido()
        {

        }
    }
}
