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

    [TestClass]
    public class Ao_alterar_senha
    {
        private User user = new User("Christian", "christian.eds@hotmail.com", "123456");

        [TestCategory("User - Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void O_email_deve_ser_valido()
        {
            user.ChangePassword("", "123456", "456789", "456789");
        }

        [TestMethod]
        [TestCategory("User - Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void A_nova_senha_deve_ser_valida()
        {
            user.ChangePassword("christian.eds@hotmail.com", "123456", "456", "456");
        }

        [TestMethod]
        [TestCategory("User - Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void Usuario_e_senha_devem_ser_validos()
        {
            user.ChangePassword("christian.eds@hotmail.com", "123", "456789", "456789");
        }

        [TestMethod]
        [TestCategory("User - Alterar Senha")]
        [ExpectedException(typeof(Exception))]
        public void A_confirmacao_de_senha_deve_ser_igual_a_nova_senha()
        {
            user.ChangePassword("christian.eds@hotmail.com", "123456", "456789", "456780");
        }

        [TestMethod]
        [TestCategory("User - Alterar Senha")]
        public void A_senha_deve_ser_encriptada()
        {
            var password = "minhasenhasegura";
            user.ChangePassword("christian.eds@hotmail.com", "123456", password, password);
            Assert.AreNotEqual(password, user.Password);
        }
    }
}
