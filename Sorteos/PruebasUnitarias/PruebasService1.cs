using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;
using Xunit;
using Sorteos;

namespace PruebasUnitarias
{
    public class PruebasService1
    {
        [Fact]
        public void PruebaCrearSorteo()
        {
            //Arrange
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;
            sorteo1.ID_JUEGO = 2;
            sorteo1.ID_ITEM = 1;
            sorteo1.HORA = "5:30";
            sorteo1.DIA = "Lunes";
            try
            {
                //Act
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Sorteo Creado Exitosamente");
                //Assert
                Assert.Equal(expected, result.CrearSorteo(sorteo1));

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Fact]
        public void PruebaEliminarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO = 1;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("Eliminado exitosamente");

                Assert.Equal(expected, result.EliminarSorteo(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [Fact]
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

                Assert.Equal(expected, result.ModificarSorteo(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Fact]
        public void PruebaConsultarSorteoxJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO = 2;

            try
            {
                Service1 result = new Service1();
                Respuesta expected = new Respuesta("No se encontró");

                Assert.NotEqual(expected, result.ConsultarSorteoxJuego(sorteo1));

            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Theory]
        [InlineData(2)]
        public void PruebaConsultarJuego(int idJuego)
        {
            Service1 result = new Service1();

            try
            {

                Assert.Equal(1, result.ConsultarJuego(idJuego));
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        [Theory]
        [InlineData(3)]
        public void PruebaConsultarItem(int idItem)
        {
            Service1 result = new Service1();

            try
            {
                Assert.Equal(1, result.ConsultarItem(idItem));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Theory]
        [InlineData(1)]
        public void PruebaConsultarSorteo(int idSorteo)
        {
            Service1 result = new Service1();

            try
            {
                Assert.Equal(1, result.ConsultarItem(idSorteo));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Theory]
        [InlineData(1, 4)]
        public void PruebaConsultarSJ(int idSorteo, int idJuego)
        {
            Service1 result = new Service1();

            try
            {
<<<<<<< HEAD
                Assert.Equal(1, result.ConsultarSJ(idSorteo, idSorteo));
=======
                Assert.Equal(1, result.ConsultarSJ(idSorteo, idJuego));
>>>>>>> 162e35f5f6f1c5fa343c38004d4554cee058f06e
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Theory]
        [InlineData(1, "Martes")]
        public void PruebaConsultarDia(int idSorteo, string dia)
        {
            Service1 result = new Service1();

            try
            {
                Assert.Equal(0, result.ConsultarDia(idSorteo, dia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Theory]
        [InlineData(1, "Martes", "4:30")]
        public void PruebaConsultarHora(int idSorteo, string dia, string hora)
        {
            Service1 result = new Service1();

            try
            {
                Assert.Equal(0, result.ConsultarHora(idSorteo, hora, dia));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Theory]
        [InlineData(4)]
        public void PruebaConsultarApuestas(int idSorteo)
        {
            Service1 result = new Service1();

            try
            {

                Assert.Equal(1, result.ConsultarApuestas(idSorteo));
            }
            catch (Exception e)
            {

<<<<<<< HEAD
                throw new Respuesta("Error: " + e.Message);
=======
                throw e;
>>>>>>> 162e35f5f6f1c5fa343c38004d4554cee058f06e
            }
        }
        // Nose si esta prueba es asi por ser un void
        [Theory]
        [InlineData(1, 4, 200)]
        public void PruebaConsultarDatosItem(int idItem, ref int cupo, ref float monto)
        {
            Service1 result = new Service1();

            try
            {
<<<<<<< HEAD
                Assert.Equals(0, result.ConsultarDatosItem(idItem,cupo,monto));
=======
                Assert.Equal(0, result.ConsultarDatosItem(idItem, ref cupo, ref monto));
>>>>>>> 162e35f5f6f1c5fa343c38004d4554cee058f06e
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
