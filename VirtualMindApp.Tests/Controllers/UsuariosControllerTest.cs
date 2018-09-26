using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirtualMindApp;
using VirtualMindApp.Controllers;
using VirtualMindApp.Models;
using System.Web.Http.Results;

namespace VirtualMindApp.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            IEnumerable<Usuario> result = controller.GetUsuarios();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();
            IHttpActionResult actionResult = controller.GetUsuario(1);

            var contentResult = actionResult as OkNegotiatedContentResult<Usuario>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.ID);

        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            IHttpActionResult result = controller.PostUsuario(new Usuario());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            var result = controller.PutUsuario(1, new Usuario());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            UsuariosController controller = new UsuariosController();

            // Act
            IHttpActionResult actionResult = controller.DeleteUsuario(1);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
