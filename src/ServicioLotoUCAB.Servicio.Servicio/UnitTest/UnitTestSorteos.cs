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
            item.id_item= 2;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 2;
            sorteo1.juego = juego;
            sorteo1.hora = "05:00:00";

            ServicioSorteos result = new ServicioSorteos();
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
            sorteo1.hora = "06:00:00";
            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_JUEGO es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
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
            sorteo1.hora = "07:00:00";
            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_ITEM es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
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
            Exception excepcion = null;
            string respuestaEsperada = "El parámetro HORA es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
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
            sorteo1.hora = "08:00:00";
            ServicioSorteos result = new ServicioSorteos();

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_DIA es un parámetro obligatorio. Por favor verifique e intente de nuevo.";
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
        public void PruebaCrearSorteo_Fallo_Juego()
        {
            //Arrange
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
            juego.id_juego = 100;
            sorteo1.juego = juego;
            sorteo1.hora = "09:00:00";

            ServicioSorteos result = new ServicioSorteos();
            Exception excepcion = null;
            string respuestaEsperada = "El juego 100 no se encuentra registrado en el sistema";
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_Item()
        {
            //Arrange
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            Item item = new Item();
            item.id_item = 100;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            sorteo1.hora = "10:00:00";

            ServicioSorteos result = new ServicioSorteos();
            Exception excepcion = null;
            string respuestaEsperada = "El item 100 no se encuentra registrado en el sistema";
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_Dia()
        {
            //Arrange
            Sorteo sorteo1 = new Sorteo();
            Dia dia = new Dia();
            dia.id_dia = 100;
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
            sorteo1.hora = "11:00:00";

            ServicioSorteos result = new ServicioSorteos();
            Exception excepcion = null;
            string respuestaEsperada = "El dia 100 no se encuentra registrado en el sistema";
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaCrearSorteo_Fallo_DiaHora(
            )
        {
            //Arrange
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
            sorteo1.hora = "01:00:00";

            ServicioSorteos result = new ServicioSorteos();
            Exception excepcion = null;
            string respuestaEsperada = "El sorteo de hora 01:00:00 para el día 1 del juego 1 ya se encuentra registrado en el sistema";
            try
            {
                result.CrearSorteo(sorteo1);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 4;

            try
            {
                ServicioSorteos result = new ServicioSorteos();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                StringAssert.Contains(result.EliminarSorteo(sorteo1).Mensaje, expected.Mensaje);

            }
            catch (Exception e)
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
                ServicioSorteos result = new ServicioSorteos();
                result.EliminarSorteo(sorteo1);
            }
            catch (ParameterException e)
            {
                ConsultarExcepcion = e;
                StringAssert.Contains(ConsultarExcepcion.Message, respuesta);

            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_Fallo_Sorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 100;
            Exception parametro = null;
            string excepcion = "El sorteo 100 no se encuentra registrado en el sistema";

            try
            {
                ServicioSorteos result = new ServicioSorteos();
                result.EliminarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                parametro = e;
                StringAssert.Contains(parametro.Message, excepcion);
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_Fallo_Apuestas()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 3;
            Exception parametro = null;
            string excepcion = "El sorteo que intenta eliminar tiene apuestas activas asociadas";

            try
            {
                ServicioSorteos result = new ServicioSorteos();
                result.EliminarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                parametro = e;
                StringAssert.Contains(parametro.Message, excepcion);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            Respuesta expected = new Respuesta("Actualizado Exitosamente");

            try
            {

                StringAssert.Contains(expected.Mensaje, result.ModificarSorteo(sorteo1).Mensaje);

            }
            catch (Exception e)
            {
                throw e;
            }
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
            sorteo1.hora = "02:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_SORTEO es un parámetro obligatorio.Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ParameterException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_FALLO_IdJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
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
            sorteo1.hora = "02:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_JUEGO es un parámetro obligatorio.Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ParameterException e)
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
            sorteo1.id_sorteo = 2;
            sorteo1.hora = "02:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_ITEM es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ParameterException e)
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
            sorteo1.id_sorteo = 2;

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro HORA es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ParameterException e)
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
            sorteo1.id_sorteo = 2;
            sorteo1.hora = "02:30:00";

            Exception excepcion = null;
            string respuestaEsperada = "El parámetro DIA es un parámetro obligatorio. Por favor verifique e intente de nuevo.";

            ServicioSorteos result = new ServicioSorteos();
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ParameterException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_Sorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 100;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El sorteo 100 no se encuentra registrado en el sistema";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_Juego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 100;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El juego 100 no se encuentra registrado en el sistema";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_Item()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 100;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El item 100 no se encuentra registrado en el sistema";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_SJ()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 2;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El sorteo que intenta actualizar no se encuentra registrado o no pertenece al juego";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_Dia()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 100;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El dia 100 no se encuentra registrado en el sistema";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteo_Fallo_DiaHora()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 2;
            Juego juego = new Juego();
            juego.id_juego = 1;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "01:00:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El sorteo de hora para el día del juego ya se encuentra registrado en el sistema";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        public void PruebaModificarSorteo_Fallo_Apuestas()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.id_sorteo = 3;
            Juego juego = new Juego();
            juego.id_juego = 2;
            sorteo1.juego = juego;
            Item item = new Item();
            item.id_item = 1;
            List<Item> i = new List<Item>();
            i.Add(item);
            sorteo1.items = i;
            sorteo1.hora = "02:30:00";
            Dia dia = new Dia();
            dia.id_dia = 1;
            List<Dia> d = new List<Dia>();
            d.Add(dia);
            sorteo1.dias = d;
            ServicioSorteos result = new ServicioSorteos();
            string respuestaEsperada = "El sorteo que intenta modificar tiene apuestas activas asociadas";
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(sorteo1);

            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Exito()
        {
            Sorteo sorteo1 = new Sorteo();
            Juego j = new Juego();
            j.id_juego = 1;
            sorteo1.juego = j;

            try
            {
                ServicioSorteos result = new ServicioSorteos();
                Respuesta expected = new Respuesta("No se encontraron sorteos");

                Assert.AreNotEqual(expected, result.ConsultarSorteoxJuego(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Fallo_idJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            Exception excepcion = null;
            string respuestaEsperada = "El parámetro ID_JUEGO es un parámetro obligatorio.Por favor verifique e intente de nuevo.";
            try
            {
                ServicioSorteos result = new ServicioSorteos();
                result.ConsultarSorteoxJuego(sorteo1);
            }
            catch (ParameterException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Fallo_Juego()
        {
            Sorteo sorteo1 = new Sorteo();
            Juego j = new Juego();
            j.id_juego = 100;
            sorteo1.juego = j;
            Exception excepcion = null;
            string respuestaEsperada = "El juego 100 no se encuentra registrado en el sistema";
            try
            {
                ServicioSorteos result = new ServicioSorteos();
                result.ConsultarSorteoxJuego(sorteo1);
            }
            catch (ParameterException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Fallo()
        {
            Sorteo sorteo1 = new Sorteo();
            Juego j = new Juego();
            j.id_juego = 3;
            sorteo1.juego = j;
            Exception excepcion = null;
            string respuestaEsperada = "No se encontraron sorteos";
            try
            {
                ServicioSorteos result = new ServicioSorteos();
                result.ConsultarSorteoxJuego(sorteo1);
            }
            catch (ConsultarException e)
            {
                excepcion = e;
                StringAssert.Contains(excepcion.Message, respuestaEsperada);
            }
        }


        [TestMethod]
        public void PruebaConsultarJuego_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idJuego = 1;
            try
            {
                Assert.AreEqual(1, result.ConsultarJuego(idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarJuego_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idJuego = 100;
            try
            {
                Assert.AreNotEqual(1, result.ConsultarJuego(idJuego));
            }
            catch (Exception e)
            {
                throw e; 
            }
        }

        [TestMethod]
        public void PruebaConsultarItem_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idItem = 1;
            int idJuego = 1;
            try
            {
                Assert.AreEqual(1, result.ConsultarItem(idItem, idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarItem_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idItem = 100;
            int idJuego = 100;
            try
            {
                Assert.AreEqual(0, result.ConsultarItem(idItem, idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarSorteo(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 100;
            try
            {
                Assert.AreNotEqual(1, result.ConsultarSorteo(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDia_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idDia = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarDia(idDia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDia_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idDia = 100;

            try
            {
                Assert.AreNotEqual(1, result.ConsultarDia(idDia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSJ_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 1; int idJuego = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarSJ(idSorteo, idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSJ_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 1; int idJuego = 2;

            try
            {
                Assert.AreEqual(0, result.ConsultarSJ(idSorteo, idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDiaHora_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 1;
            int idDia = 2;

            try
            {
                Assert.AreNotEqual(idDia, result.ConsultarDiaHora(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }


        [TestMethod]

        public void PruebaConsultarDiaHora_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 1;
            int idDia = 1;

            try
            {
                Assert.AreEqual(idDia, result.ConsultarDiaHora(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        [TestMethod]
        public void PruebaConsultarHora_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idJuego = 1;
            string hora = "03:30:00";

            try
            {
                List<int> lista = new List<int>();
                CollectionAssert.AreEqual(lista, result.ConsultarHora(idJuego, hora));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarHora_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idJuego = 1;
            string hora = "01:00:00";

            try
            {
                List<int> lista = new List<int>();
                lista.Add(1);
                CollectionAssert.AreEqual(lista, result.ConsultarHora(idJuego, hora));
            }
            catch (Exception e)
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
                Assert.AreNotEqual(1, dao.ConsultarApuestas(idSorteo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        public void PruebaConsultarApuestas_Fallo()
        {
            DaoSorteos dao = FabricaDao.FabricarDaoSorteos();
            int idSorteo = 3;

            try
            {
                Assert.AreEqual(1, dao.ConsultarApuestas(idSorteo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [TestMethod]
        public void PruebaConsultarDatosItem_Exito()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idItem = 1;
            int cupo = 0;
            float monto = 0;

            try
            {
                Assert.AreEqual(1, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDatosItem_Fallo()
        {
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int idItem = 100;
            int cupo = 0;
            float monto = 0;

            try
            {
                Assert.AreEqual(0, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteo_Exito(){
            int idJuego = 2;
            string hora = "05:30:00";
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 7;
            try{
                Assert.AreEqual(respuestaEsperada,result.InsertarSorteo(idJuego,hora));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteo_Fallo_idJuego(){
            int idJuego = 100;
            string hora = "05:30:00";
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try
            {
                result.InsertarSorteo(idJuego, hora);
            }
            catch (Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoItem_Exito(){
            int idSorteo = 2;
            int idItem = 1;
            float monto = 70;
            int cupo = 4;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1; 
            try{
                Assert.AreEqual(respuestaEsperada,result.InsertarSorteoItem(idItem, idSorteo, cupo, monto));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoItem_Fallo_idItem(){
            int idItem = 100;
            int idSorteo = 2;
            float monto = 70;
            int cupo = 4;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.InsertarSorteoItem(idItem, idSorteo, cupo, monto);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoItem_Fallo_idSorteo(){
            int idItem = 1;
            int idSorteo = 100;
            float monto = 70;
            int cupo = 4;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.InsertarSorteoItem(idItem, idSorteo, cupo, monto);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoInsertarSorteoDia_Exito(){
            int idSorteo = 2;
            int idDia = 4;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1; 
            try{
                Assert.AreEqual(respuestaEsperada,result.InsertarSorteoDia(idDia, idSorteo));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoDia_Fallo_idDia(){
            int idSorteo = 2;
            int idDia = 100; 
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.InsertarSorteoDia(idDia, idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaInsertarSorteoDia_Fallo_idSorteo(){
            int idDia = 4;
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.InsertarSorteoDia(idDia, idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoDao_Exito()
        {
            int idSorteo = 5;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1;
            try
            {
                Assert.AreEqual(respuestaEsperada, result.EliminarSorteo(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoDao_Fallo()
        {
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try
            {
                result.EliminarSorteo(idSorteo);
            }
            catch (Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoItem_Exito(){
            int idSorteo = 5;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1; 
            try{
                Assert.AreEqual(respuestaEsperada,result.EliminarSorteoItem(idSorteo));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoItem_Fallo(){
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.EliminarSorteoItem(idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoDia_Exito(){
            int idSorteo = 5;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1; 
            try{
                Assert.AreEqual(respuestaEsperada,result.EliminarSorteoDia(idSorteo));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteoDia_Fallo(){
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;            
            try{
                result.EliminarSorteoDia(idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteoDao_Exito()
        {
            int idJuego = 1;
            int idSorteo = 2;
            string hora = "12:30:00";
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            int respuestaEsperada = 1;
            try
            {
                Assert.AreEqual(respuestaEsperada, result.ModificarSorteo(idSorteo, idJuego, hora));
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaModificarSorteoDao_Fallo_idSorteo()
        {
            int idSorteo = 100;
            int idJuego = 1;
            string hora = "12:30:00";
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(idSorteo, idJuego, hora);
            }
            catch (Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaModificarSorteoDao_Fallo_idJuego()
        {
            int idSorteo = 2;
            int idJuego = 100;
            string hora = "12:30:00";
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try
            {
                result.ModificarSorteo(idSorteo, idJuego, hora);
            }
            catch (Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteosdeJuego_Exito()
        {
            int idJuego = 1;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            List<int> respuestaEsperada = new List<int>();
            respuestaEsperada.Add(1);
            respuestaEsperada.Add(2);
            try
            {
                CollectionAssert.AreEqual(respuestaEsperada,result.ConsultarSorteosdeJuego(idJuego));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteosdeJuego_Fallo()
        {
            int idJuego = 3;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            try
            {
                List<int> lista = new List<int>();
                CollectionAssert.AreEqual(lista, result.ConsultarSorteosdeJuego(idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteosdeJuego_Fallo_idJuego(){
            int idJuego = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            List<int> respuestaEsperada = new List<int>();
            Exception excepcion = null;
            try{
                result.ConsultarSorteosdeJuego(idJuego);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuegoDao_Exito(){
            int idSorteo = 1;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            string respuestaEsperada = "1-1-01:00:00-1"; // Colocar el string de sorteos esperados
            try{
                StringAssert.Contains(respuestaEsperada,result.ConsultarSorteoxJuego(idSorteo));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuegoDao_Fallo() {
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try
            {
                result.ConsultarSorteoxJuego(idSorteo);
            }
            catch (Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoItemxJuego_Exito()
        {
            int idSorteo = 1;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            string respuestaEsperada = "1-1-1-20,0000-1|"; // Colocar el string de sorteos esperados
            try
            {
                StringAssert.Contains(respuestaEsperada, result.ConsultarSorteoItemxJuego(idSorteo));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoItemxJuego_Fallo(){
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try{
                result.ConsultarSorteoItemxJuego(idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoDiaxJuego_Exito(){
            int idSorteo = 1;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            string respuestaEsperada = "1-1-LUNES-1|"; // Colocar el string de sorteos esperados
            try{
                StringAssert.Contains(respuestaEsperada,result.ConsultarSorteoDiaxJuego(idSorteo));
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoDiaxJuego_Fallo(){
            int idSorteo = 100;
            DaoSorteos result = FabricaDao.FabricarDaoSorteos();
            Exception excepcion = null;
            try{
                result.ConsultarSorteoDiaxJuego(idSorteo);
            }
            catch(Exception e)
            {
                excepcion = e;
                Assert.IsNotNull(excepcion);
            }
        }
    }
}