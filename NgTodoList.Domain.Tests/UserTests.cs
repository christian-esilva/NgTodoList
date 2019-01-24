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
        public void O_email_nao_pode_ser_vazio()
        {
            var user = new User("Christian", "", "123456");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void O_email_deve_ser_valido()
        {
            var user = new User("Christian", "teste", "123456");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        [ExpectedException(typeof(Exception))]
        public void A_senha_deve_ser_valida()
        {
            var user = new User("Christian", "christian.eds@hotmail.com", "123");
        }

        [TestMethod]
        [TestCategory("User - Novo Usuário")]
        public void O_usuario_e_valido()
        {
            var user = new User("Christian", "christian.eds@hotmail.com", "123456");
            Assert.AreNotEqual(null, user);
        }
    }
}
