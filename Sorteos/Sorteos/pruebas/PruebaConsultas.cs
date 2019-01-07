using System;
using Xunit;
using Sorteos;

namespace pruebas
{
    public class PruebaConsultas
    {
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