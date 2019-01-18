using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteos;



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
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "05:30:00";
            sorteo1.ID_DIA = new List<int> { 1 };

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
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaCrearSorteo_Fallo_IdJuego(){
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "05:30:00";
            sorteo1.ID_DIA = new List<int> { 1 };

            Service1 result = new Service1();
            try
            {
                //Act
                result.CrearSorteo(sorteo1);
                //Assert
                Assert.Fail("El parámetro ID_JUEGO es un parámetro obligatorio. Por favor verifique e intente de nuevo.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaCrearSorteo_Fallo_IdItem(){
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 1;
            sorteo1.HORA = "05:30:00";
            sorteo1.ID_DIA = new List<int> { 1 };

            Service1 result = new Service1();
            try
            {
                //Act
                result.CrearSorteo(sorteo1);
                //Assert
                Assert.Fail("El parámetro ID_ITEM es un parámetro obligatorio. Por favor verifique e intente de nuevo.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaCrearSorteo_Fallo_HORA(){
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 1;
            sorteo1.ID_DIA = new List<int> { 1 };

            Service1 result = new Service1();
            try
            {
                //Act
                result.CrearSorteo(sorteo1);
                //Assert
            Assert.Fail("El parámetro HORA es un parámetro obligatorio. Por favor verifique e intente de nuevo.");            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaCrearSorteo_Fallo_DIA()){
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "05:30:00";

            Service1 result = new Service1();
            try
            {
                //Act
                result.CrearSorteo(sorteo1);
                //Assert
                Assert.Fail("El parámetro ID_DIA es un parámetro obligatorio. Por favor verifique e intente de nuevo.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaEliminarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 3;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                Assert.AreEqual(expected.Mensaje, result.EliminarSorteo(sorteo1).Mensaje);

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaEliminarSorteo_Fallo_IdSorteo(){
            Sorteo sorteo1 = new Sorteo();

            try
            {
                Service1 result = new Service1();
                result.EliminarSorteo(sorteo1)
                Assert.Fail("El parámetro ID_SORTEO es un parámetro obligatorio. Por favor verifique e intente de nuevo.");
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El sorteo que intenta eliminar tiene apuestas activas asociadas")]
        public void PruebaEliminarSorteo_Fallo_Apuestas(){
            int idSorteo = 1;

            try
            {
                Service1 result = new Service1();
                result.EliminarSorteo(sorteo1)
                Assert.Fail("El parámetro ID_SORTEO es un parámetro obligatorio. Por favor verifique e intente de nuevo.");
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }
        [TestMethod]
        public void PruebaModificarSorteo_EXITO()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 3;
            sorteo1.HORA = "3:00";
            sorteo1.ID_DIA = new List<int> { 2 };

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Actualizado Exitosamente");

                Assert.AreEqual(expected.Mensaje, result.ModificarSorteo(sorteo1).Mensaje);

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaModificarSorteo_FALLO_IdSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 3;
            sorteo1.HORA = "3:00";
            sorteo1.ID_DIA = new List<int> { 2 };

            try
            {
                Service1 result = new Service1();

                result.ModificarSorteo(sorteo1);
                Assert.Fail("El parámetro ID_SORTEO es un parámetro obligatorio. Por favor verifique e intente de nuevo.");

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaModificarSorteo_FALLO_IdJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_ITEM = 3;
            sorteo1.HORA = "3:00";
            sorteo1.ID_DIA = new List<int> { 2 };

            try
            {
                Service1 result = new Service1();

                result.ModificarSorteo(sorteo1);
                Assert.Fail("El parámetro ID_JUEGO es un parámetro obligatorio. Por favor verifique e intente de nuevo.");

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaModificarSorteo_FALLO_IdItem()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 3;
            sorteo1.ID_JUEGO = 1;
            sorteo1.HORA = "3:00";
            sorteo1.ID_DIA = new List<int> { 2 };

            try
            {
                Service1 result = new Service1();

                result.ModificarSorteo(sorteo1);
                Assert.Fail("El parámetro ID_ITEM es un parámetro obligatorio. Por favor verifique e intente de nuevo.");

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaModificarSorteo_FALLO_HORA()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 3;
            sorteo1.ID_DIA = new List<int> { 2 };

            try
            {
                Service1 result = new Service1();

                result.ModificarSorteo(sorteo1);
                Assert.Fail("El parámetro HORA es un parámetro obligatorio. Por favor verifique e intente de nuevo.");

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ParameterException), "El parámetro  es un parámetro obligatorio. Por favor verifique e intente de nuevo.")]
        public void PruebaModificarSorteo_FALLO_DIA()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 3;
            sorteo1.HORA = "3:00";

            try
            {
                Service1 result = new Service1();

                result.ModificarSorteo(sorteo1);
                Assert.Fail("El parámetro DIA es un parámetro obligatorio. Por favor verifique e intente de nuevo.");

            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }


        [TestMethod]
        public void PruebaConsultarSorteoxJuego_Exito()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 2;

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
        public void PruebaConsultarJuego_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El juego no se encuentra registrado en el sistema")]
        public void PruebaConsultarJuego_Fallo()
        {
            Service1 result = new Service1();
            int idJuego = 0;
            try
            {
                result.ConsultarJuego(idJuego);
                Assert.Fail();
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarItem_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El item no se encuentra registrado en el sistema")]
        public void PruebaConsultarItem_Fallo()
        {
            Service1 result = new Service1();
            int idItem = 0;
            int idJuego = 0;

            try
            {
                result.ConsultarItem(idItem, idJuego);
                Assert.Fail();
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El sorteo no se encuentra registrado en el sistema")]
        public void PruebaConsultarSorteo_Fallo()
        {
            Service1 result = new Service1();
            int idSorteo = 100;

            try
            {
                result.ConsultarSorteo(idSorteo);
                Assert.Fail();
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDia_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El dia no se encuentra registrado en el sistema")]
        public void PruebaConsultarDia_Fallo()
        {
            Service1 result = new Service1();
            int idDia = 3;

            try
            {
                result.ConsultarDia(idDia);
                Assert.Fail();
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSJ_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El sorteo que intenta actualizar no se encuentra registrado o no pertenece al juego ")]
        public void PruebaConsultarSJ_Fallo_idSorteo()
        {
            Service1 result = new Service1();
            int idSorteo = 0; int idJuego = 1;

            try
            {
                result.ConsultarSJ(idSorteo, idJuego);
                Assert.Fail();
            }
            catch (ConsultarException e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarDiaHora_Exito()
        {
            Service1 result = new Service1();
            int idSorteo = 1;
            int idDia = 1;
            int idJuego = 1;
            string hora = "02:30:00";

            try
            {
                Assert.AreEqual(1, result.ConsultarDiaHora(idSorteo, idDia, hora, idJuego));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El sorteo de hora especificada para el día especificado del juego especificado ya se encuentra registrado en el sistema")]
        public void PruebaConsultarDiaHora_Fallo_idSorteo() {
            Service1 result = new Service1();
            int idSorteo = 1;
            int idDia = 2;
            int idJuego = 1;
            string hora = "02:30:00";

            try
            {
                result.ConsultarDiaHora(idSorteo, idDia, hora, idJuego);
                Assert.Fail();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarHora_Exito()
        {
            Service1 result = new Service1();
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
            Service1 result = new Service1();
            int idJuego = 1;
            string hora = "02:00:00";

            try
            {
                List<int> lista = new List<int>();
                lista.Add(2);
                CollectionAssert.AreEqual(lista, result.ConsultarHora(idJuego, hora));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarApuestas_Exito()
        {
            Service1 result = new Service1();
            int idSorteo = 2;

            try
            {
                Assert.AreEqual(0, result.ConsultarApuestas(idSorteo));
            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El sorteo que intenta eliminar tiene apuestas activas asociadas")]
        public void PruebaConsultarApuestas_Fallo()
        {
            Service1 result = new Service1();
            int idSorteo = 1;
            try
            {
                result.ConsultarApuestas(idSorteo);
                Assert.Fail();
            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }


        [TestMethod]
        public void PruebaConsultarDatosItem_Exito()
        {
            Service1 result = new Service1();
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
        [ExpectedException(typeof(ConsultarException), "El item no se encuentra registrado en el sistema")]
        public void PruebaConsultarDatosItem_Fallo_idItem()
        {
            Service1 result = new Service1();
            int idItem = 8;
            int cupo = 1;
            float monto = 20;
            try
            {
                result.ConsultarDatosItem(idItem, ref cupo, ref monto);
                Assert.Fail("El item " + idItem + "no se encuentra registrado en el sistema");

            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }

        /*[TestMethod]
        [ExpectedException(typeof(ConsultarException), "El item no se encuentra registrado en el sistema")]
        public void PruebaConsultarDatosItem_Fallo_Cupo() {
            Service1 result = new Service1();
            int idItem = 1;
            int cupo = 0;
            float monto = 20;
            try
            {
                result.ConsultarDatosItem(idItem, ref cupo, ref monto);
                Assert.Fail("El item "+idItem+" no se encuentra registrado en el sistema");
            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }*/
    }
}