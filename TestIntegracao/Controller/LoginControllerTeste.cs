using Biblioteca.Controllers;
using Biblioteca.Interfaces;
using Biblioteca.Models;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntegracao.Controller
{
    public class LoginControllerTeste
    {
    [Fact]
    public void LoginController_UserInvalid()
        {
            //Arrange - Preparação
            //Moq -> Login -> Email, senha
            var fakeObject = new Mock<IUsuarioRepositorycs>();

            fakeObject.Setup(x => x.Login(It.IsAny<String>(), It.IsAny<String>())).Returns((Usuario)null);

            LoginViewModel dadosLogin = new LoginViewModel();

            dadosLogin.Email = "Email@email.com";
            dadosLogin.Senha = "1234";

            var controller = new LoginController(fakeObject.Object);

            // Act - Ação

            var resultado = controller.Login(dadosLogin);

            // Assert - Verificação

            Assert.IsType<UnauthorizedObjectResult>(resultado);

        }
    }
}
