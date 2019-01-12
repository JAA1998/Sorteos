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
            sorteo1.ID_SORTEO = 0;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                Assert.AreEqual(expected, result.EliminarSorteo(sorteo1));

            }
            catch (ConsultarException e)
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
        public void PruebaConsultarJuego_Fallo() {
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

            try
            {
                Assert.AreEqual(1, result.ConsultarItem(idItem));
            }
            catch (ConsultarException e)
            {

                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El item no se encuentra registrado en el sistema")]
        public void PruebaConsultarItem_Fallo() {
            Service1 result = new Service1();
            int idItem = 0;

            try
            {
                result.ConsultarItem(idItem);
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
                Assert.AreEqual(1, result.ConsultarItem(idSorteo));
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
        public void PruebaConsultarSJ_Fallo_idSorteo() {
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
        public void PruebaConsultarDia_Exito()
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

        /*[TestMethod]
        public void PruebaConsultarDia_Fallo_idSorteo() {
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
        }*/

        [TestMethod]
        public void PruebaConsultarHora_Exito()
        {
            Service1 result = new Service1();
            int idSorteo = 1;
            string dia = "Martes";
            string hora = "7:29";

            try
            {
                Assert.AreEqual(0, result.ConsultarHora(idSorteo, hora, dia));
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
            int idSorteo = 1;

            try
            {
                Assert.AreEqual(1, result.ConsultarApuestas(idSorteo));
            }
            catch (ConsultarException ex)
            {
                throw ex;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El sorteo que intenta eliminar tiene apuestas activas asociadas")]
        public void PruebaConsultarApuestas_Fallo() {
            Service1 result = new Service1();
            int idSorteo = 2;
            try
            {
                result.ConsultarApuestas(idSorteo);
                Assert.Fail();
            }
            catch (ConsultarException ex) {
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

            try{
                Assert.AreEqual(1, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
            }
            catch (ConsultarException e){
                throw e;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ConsultarException), "El item no se encuentra registrado en el sistema")]
        public void PruebaConsultarDatosItem_Fallo_idItem() {
            Service1 result = new Service1();
            int idItem = 8;
            int cupo = 1;
            float monto = 20;
            try {
                result.ConsultarDatosItem(idItem,ref cupo,ref monto);
                Assert.Fail("El item " + idItem + "no se encuentra registrado en el sistema");

            }
            catch(ConsultarException ex){
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
