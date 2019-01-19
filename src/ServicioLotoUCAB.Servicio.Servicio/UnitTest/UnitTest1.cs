using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServicioLotoUCAB.Servicio.Entidades;
using ServicioLotoUCAB.Servicio.Comunes;
using ServicioLotoUCAB.Servicio.Servicio;
using ServicioLotoUCAB.Servicio.Excepciones;
using ServicioLotoUCAB.Servicio.AccesoDatos;
using ServicioLotoUCAB.Servicio.AccesoDatos.Dao;

namespace PruebasUnitariasSorteos
{
    [TestClass]
    public class PruebasUnitarias
    {


        [TestMethod]
        public void PruebaCrearSorteo_Exito()
        {
            //Arrange
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item= 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";

            Service1 result = new Service1();
            try
            {
                //Act
                Respuesta expected = new Respuesta("Sorteo Creado Exitosamente");
                //Assert
                Assert.AreEqual(expected.Mensaje, result.CrearSorteo(sorteo1).Mensaje);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_IdJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";
            Exception excepcion = null;
            string respuestaEsperada = "ID_JUEGO";

            Service1 result = new Service1();
            try
            {
                result.CrearSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]

        public void PruebaCrearSorteo_Fallo_IdItem()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";
            Exception excepcion = null;
            string respuestaEsperada = "ID_ITEM";

            Service1 result = new Service1();
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_HORA()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            Exception excepcion = null;
            string respuestaEsperada = "HORA";

            Service1 result = new Service1();
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (ParameterException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_DIA()
        {
            Sorteo sorteo1 = new Sorteo();
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";
            Service1 result = new Service1();

            Exception excepcion = null;
            string respuestaEsperada = "ID_DIA";
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }

        }


        [TestMethod]
        public void PruebaEliminarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 11;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                StringAssert.Contains(result.EliminarSorteo(sorteo1).Mensaje, expected.Mensaje);

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_Fallo_IdSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            Exception ConsultarExcepcion = null;
            string respuesta = "El parámetro ID_SORTEO es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            try
            {
                Service1 result = new Service1();
                result.EliminarSorteo(sorteo1);
            }
            catch (ConsultarException e)
            {
                ConsultarExcepcion = e;
                StringAssert.Contains(ConsultarExcepcion.Message, respuesta);

            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_Fallo_Apuestas()
        {
            Sorteo sorteo1 = new Sorteo();
            Exception parametro = null;
            string excepcion = "El sorteo que intenta eliminar tiene apuestas activas asociadas";

            try
            {
                Service1 result = new Service1();
                result.EliminarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                parametro = e;
                StringAssert.Contains(parametro.Message, excepcion);
            }

        }
        [TestMethod]
        public void PruebaModificarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 1;
            sorteo1.juego.id_juego = 1;
            Item item = new Item();
            item.id_item = 1;
            sorteo1.items.Add(item);
            sorteo1.hora = "3:00:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            sorteo1.dias.Add(dia);
            Service1 result = new Service1();
            Respuesta expected = new Respuesta("Actualizado Exitosamente");

            Assert.AreEqual(expected.Mensaje, result.ModificarSorteo(sorteo1).Mensaje);
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_IdSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.hora = "05:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "ID_SORTEO";

            Service1 result = new Service1();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_IdJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "ID_JUEGO";

            Service1 result = new Service1();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_IdItem()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "ID_ITEM";

            Service1 result = new Service1();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_HORA()
        {
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;

            Exception excepcion = null;
            string respuestaEsperada = "HORA";

            Service1 result = new Service1();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_DIA()
        {
            Sorteo sorteo1 = new Sorteo();
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.id_sorteo = 1;
            sorteo1.hora = "05:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "ID_DIA";

            Service1 result = new Service1();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }


        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Exito()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.juego.id_juego = 2;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("No se encontró");

                Assert.AreNotEqual(expected, result.ConsultarSorteoxJuego(sorteo1));

            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Fallo_idJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.juego.id_juego = 0;
            Exception excepcion = null;
            string respuestaEsperada = "ID_JUEGO";
            try
            {
                Service1 result = new Service1();
                result.ConsultarSorteoxJuego(sorteo1);
            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Fallo_Excepcion()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.juego.id_juego = 0;
            Exception excepcion = null;
            string respuestaEsperada = "No se encontró";
            try
            {
                Service1 result = new Service1();
                result.ConsultarSorteoxJuego(sorteo1);
            }
            catch (Exception e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }


        [TestMethod]
        public void PruebaConsultarJuego_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idJuego = 1;
            try
            {

                Assert.AreEqual(1, result.ConsultarJuego(idJuego));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarJuego_Fallo()
        {
            DaoSorteos result = new DaoSorteos();
            int idJuego = 0;
            Exception excepcion = null;
            string respuestaEsperada = "El juego no se encuentra registrado en el sistema";
            try
            {
                result.ConsultarJuego(idJuego);
            }
            catch (ConsultarException e)
            {

                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarItem_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 1;
            int idJuego = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarItem(idItem, idJuego));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarItem_Fallo()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 0;
            int idJuego = 0;
            Exception excepcion = null;
            string respuestaEsperada = "El item  no se encuentra registrado en el sistema o no pertenece al juego";

            try
            {
                result.ConsultarItem(idItem, idJuego);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarSorteo(idSorteo));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo_Fallo()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 100;
            Exception excepcion = null;
            string respuestaEsperada = "El sorteo no se encuentra registrado en el sistema";

            try
            {
                result.ConsultarSorteo(idSorteo);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarDia_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idDia = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarDia(idDia));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDia_Fallo_idSorteo()
        {
            DaoSorteos result = new DaoSorteos();
            int idDia = 3;
            Exception ConsultarSorteo = null;
            try
            {
                result.ConsultarDia(idDia);

            }
            catch (Exception e)
            {
                ConsultarSorteo = e;
            }

            Assert.IsNotNull(ConsultarSorteo);
        }

        [TestMethod]
        public void PruebaConsultarDia_Fallo_idDia()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 1;
            Exception ConsultarSorteo = null;
            try
            {
                result.ConsultarDia(idSorteo);

            }
            catch (Exception e)
            {
                ConsultarSorteo = e;
            }

            Assert.IsNotNull(ConsultarSorteo);
        }

        [TestMethod]
        public void PruebaConsultarSJ_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 1; int idJuego = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarSJ(idSorteo, idJuego));
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSJ_Fallo_idSorteo()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 0; int idJuego = 1;
            Exception excepcion = null;
            string respuestaEsperada = "";

            try
            {
                result.ConsultarSJ(idSorteo, idJuego);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarDiaHora_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 1;
            int idDia = 1;
            Exception ConsultarException = null;

            try
            {
                result.ConsultarDiaHora(idSorteo, idDia);
            }
            catch (Exception e)
            {
                ConsultarException = e;
            }
            Assert.IsNotNull(ConsultarException);
        }


        [TestMethod]

        public void PruebaConsultarDiaHora_Fallo_idSorteo()
        {
            DaoSorteos result = new DaoSorteos();
            int idSorteo = 1;
            int idDia = 2;

            try
            {
                Assert.AreEqual(1, result.ConsultarDiaHora(idSorteo, idDia));
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [TestMethod]
        public void PruebaConsultarHora_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idJuego = 1;
            string hora = "01:00:00";

            try
            {
                List<int> lista = new List<int>();
                CollectionAssert.AreEqual(lista, result.ConsultarHora(idJuego, hora));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarHora_Fallo()
        {
            DaoSorteos result = new DaoSorteos();
            int idJuego = 1;
            string hora = "05:29:00";

            try
            {
                List<int> lista = new List<int>();
                lista.Add(1);
                CollectionAssert.AreNotEqual(lista, result.ConsultarHora(idJuego, hora));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarApuestas_Exito()
        {
            DaoSorteos dao = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 2;

            try
            {
                Assert.AreEqual(1, dao.ConsultarApuestas(idSorteo));
            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void PruebaConsultarApuestas_Fallo()
        {
            DaoSorteos dao = new DaoSorteos();
            int idSorteo = 1;
            Exception ConsultarSorteo = null;

            try
            {
                dao.ConsultarApuestas(idSorteo);

            }
            catch (Exception ex)
            {
                ConsultarSorteo = ex;
            }

            Assert.IsNotNull(ConsultarSorteo);
        }


        [TestMethod]
        public void PruebaConsultarDatosItem_Exito()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 1;
            int cupo = 1;
            float monto = 20;

            try
            {
                Assert.AreEqual(1, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDatosItem_Fallo_idItem()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 1;
            int cupo = 1;
            float monto = 20;
            Exception excepcion = null;
            string respuestaEsperada = "El item no se encuentra registrado en el sistema";
            try
            {
                result.ConsultarDatosItem(idItem, ref cupo, ref monto);

            }
            catch (ConsultarException ex)
            {
                excepcion = ex;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarDatosItem_Fallo_Cupo()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 1;
            int cupo = 0;
            float monto = 20;
            Exception excepcion = null;
            string respuestaEsperada = "El item no se encuentra registrado en el sistema";
            try
            {
                result.ConsultarDatosItem(idItem, ref cupo, ref monto);
            }
            catch (ConsultarException ex)
            {
                excepcion = ex;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarDatosItem_Fallo_Monto()
        {
            DaoSorteos result = new DaoSorteos();
            int idItem = 1;
            int cupo = 1;
            float monto = 8;
            Exception excepcion = null;
            string respuestaEsperada = "El item no se encuentra registrado en el sistema";
            try
            {
                result.ConsultarDatosItem(idItem, ref cupo, ref monto);
            }
            catch (ConsultarException ex)
            {
                excepcion = ex;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }
    }
}