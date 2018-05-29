using System;
using System.Collections.Generic;
using NUnit.Framework;
using WebAPI.Models;
using WebAPI.Controllers;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace WebApiPruebas.M4
{
    class M4_PruebaUnitaria
    {
        [TestFixture]
        public class M4_PruebaUnitaria
        {
            M4_GestionEquipoController _controller;
            Equipo _equipo;
            Pais _pais;
            I18nEquipo _i18n;
            List<Pais> _listaPaises;
            EstructuraRespuesta er;

            [SetUp]
            public void Init()
            {
                _controller = new M4_GestionEquipoController();
                _controller.Request = new HttpRequestMessage();
                _controller.Configuration = new HttpConfiguration();
                _equipo = new Equipo();
                _pais = new Pais();
                _i18n = new I18nEquipo();

                _listaPaises = new List<Pais>();
                _listaPaises.Add(new Pais("arg", new I18nEquipo(1, "es", "argentina")));
                _listaPaises.Add(new Pais("aus", new I18nEquipo(2, "es", "australia")));
                _listaPaises.Add(new Pais("bel", new I18nEquipo(3, "es", "belgica")));
            }

            [Test]
            public void GetPaisesTest()
            {
                string idioma = "es";

                er = new EstructuraRespuesta();
                er.codigo = 200;
                er.mensaje = _listaPaises;
                HttpResponseMessage a = _controller.getPaises(idioma);


                Assert.AreEqual(_controller.getPaises(idioma).Content, er.codigo);
            }

            [Test]
            public void ObtenerPaisesTest()
            {
                string idioma = "es";
                List<Pais> respuesta = _controller.ObtenerPaises(idioma);

                for (int i = 0; i < 3; i++)
                {
                    Assert.AreEqual(respuesta[i].nombre.mensaje.ToString(), _listaPaises[i].nombre.mensaje.ToString());
                    Assert.AreEqual(respuesta[i].iso.ToString(), _listaPaises[i].iso.ToString());
                    Assert.AreEqual(respuesta[i].nombre.id.ToString(), _listaPaises[i].nombre.id.ToString());
                    Assert.AreEqual(respuesta[i].nombre.idioma.ToString(), _listaPaises[i].nombre.idioma.ToString());

                }
            }

            [TearDown]
            public void End()
            {
                _controller = null;
                _equipo = null;
                _pais = null;
                _i18n = null;
            }
        }
    }
}