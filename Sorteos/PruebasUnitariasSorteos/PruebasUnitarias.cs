using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorteos;



namespace PruebasUnitariasSorteos
{
    [TestClass]
    public class PruebasUnitarias
    {
        [TestMethod]
        public void PruebaCrearSorteo()
        {
            //Arrange
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 2;
            sorteo1.ID_JUEGO = 1;
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "5:30";
            sorteo1.DIA = "Lunes";
            try
            {
                //Act
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Sorteo Creado Exitosamente");
                //Assert
                Assert.AreEqual(expected, result.CrearSorteo(sorteo1));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [TestMethod]
        public void PruebaEliminarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                Assert.AreEqual(expected, result.EliminarSorteo(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [TestMethod]
        public void PruebaModificarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_JUEGO = 2;
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "3:00";
            sorteo1.DIA = "Viernes";

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Actualizado Exitosamente");

                Assert.AreEqual(expected, result.ModificarSorteo(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteoxJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 2;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("No se encontró");

                Assert.AreNotEqual(expected, result.ConsultarSorteoxJuego(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [TestMethod]
        public void PruebaConsultarJuego()
        {
            Service1 result = new Service1();
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
        public void PruebaConsultarItem()
        {
            Service1 result = new Service1();
            int idItem = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarItem(idItem));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSorteo()
        {
            Service1 result = new Service1();
            int idSorteo = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarItem(idSorteo));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarSJ()
        {
            Service1 result = new Service1();
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
        public void PruebaConsultarDia()
        {
            Service1 result = new Service1();
            int idSorteo = 1;
            string dia = "Martes";

            try
            {
                Assert.AreEqual(1, result.ConsultarDia(idSorteo, dia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarHora()
        {
            Service1 result = new Service1();
            int idSorteo = 1;
            string dia = "Martes";
            string hora = "7:29";

            try
            {
                Assert.AreEqual(0, result.ConsultarHora(idSorteo, hora, dia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [TestMethod]
        public void PruebaConsultarApuestas()
        {
            Service1 result = new Service1();
            int idSorteo = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarApuestas(idSorteo));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Nose si esta prueba es asi por ser un void
        [TestMethod]
        public void PruebaConsultarDatosItem()
        {
            Service1 result = new Service1();
            int idItem = 1;
            int cupo = 1;
            float monto = 20;

            try
            {
                Assert.AreEqual(1, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
