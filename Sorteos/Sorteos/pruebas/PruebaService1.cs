using System;
using Xunit;
using Sorteos;

namespace pruebas
{
    public class PruebaService1
    {
         [Fact]
        public void PruebaCrearSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO=1;
            sorteo1.ID_JUEGO=2;
            sorteo1.ID_ITEM=1;
            sorteo1.HORA= "5:30";
            sorteo1.DIA="Lunes";
            try
            {
                Service1 result= new Service1();
                Respuesta expected= new Respuesta("Sorteo Creado Exitosamente");

                Assert.Equals(expected, result.CrearSorteo(sorteo1));
                
            }
            catch (Exception e)
            {
                
               return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        [Fact]
        public void PruebaEliminarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO=1;
            
            try
            {
                Service1 result= new Service1();
                Respuesta expected= new Respuesta("Eliminado exitosamente");

                Assert.Equals(expected, result.EliminarSorteo(sorteo1));
                
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        
        [Fact]
        public void PruebaModificarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO=1;
            sorteo1.ID_JUEGO=2;
            sorteo1.ID_ITEM=1;
            sorteo1.HORA= "3:00";
            sorteo1.DIA="Viernes";
            
            try
            {
                Service1 result= new Service1();
                Respuesta expected= new Respuesta("Actualizado Exitosamente");

                Assert.Equals(expected, result.ModificarSorteo(sorteo1));
                
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Fact]
        public void PruebaConsultarSorteoxJuego()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_JUEGO=2;
            
            try
            {
                Service1 result= new Service1();
                Respuesta expected= new Respuesta("No se encontró");

                Assert.AreNotEqual(expected, result.ConsultarSorteoxJuego(sorteo1));
                
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
         [Theory]
        [InlineData(2)]
        public void PruebaConsultarJuego(int idJuego)
        {
            Consultas result = new Consultas();

            try
            {
                
                Assert.Equals(1,result.ConsultarJuego(idJuego));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        [Theory]
        [InlineData(3)]
        public void PruebaConsultarItem(int idItem)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(1,result.ConsultarItem(idItem));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Theory]
        [InlineData(1)]
        public void PruebaConsultarSorteo(int idSorteo)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(1,result.ConsultarItem(idSorteo));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Theory]
        [InlineData(1,4)]
        public void PruebaConsultarSJ(int idSorteo, int idJuego)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(1,result.ConsultarSJ(idSorteo, idSorteo));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Theory]
        [InlineData(1,"Martes")]
        public void PruebaConsultarDia(int idSorteo, string dia)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(0,result.ConsultarDia(idSorteo, dia));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Theory]
        [InlineData(1,"Martes", "4:30")]
        public void PruebaConsultarHora(int idSorteo, string dia, string hora)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(0,result.ConsultarHora(idSorteo, hora, dia));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        [Theory]
        [InlineData(4)]
        public void PruebaConsultarApuestas(int idSorteo)
        {
            Consultas result = new Consultas();

            try
            {
                
                Assert.Equals(1,result.ConsultarApuestas(idSorteo));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
// Nose si esta prueba es asi por ser un void
        [Theory]
        [InlineData(1, 4, 200)]
        public void PruebaConsultarDatosItem(int idItem, ref int cupo, ref float monto)
        {
            Consultas result = new Consultas();

            try
            {
                Assert.Equals(0,result.ConsultarDatosItem(idItem, cupo, monto));
            }
            catch (Exception e)
            {
                
                return new Respuesta("Error: " + e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}