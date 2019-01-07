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
            sorteo1.HORA= 5:30;
            sorteo1.DIA=12;
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
            sorteo1.HORA= 5:30;
            sorteo1.DIA=12;
            
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
    }
}