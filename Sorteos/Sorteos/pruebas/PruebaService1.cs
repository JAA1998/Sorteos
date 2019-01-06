using System;
using Xunit;
using Sorteos;

namespace pruebas
{
    public class PruebaService1
    {
        [Fact]
        public void PruebaEliminarSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO=1;
            sorteo1.ID_JUEGO=2;
            sorteo1.ID_ITEM=1;
            sorteo1.HORA= 5:30;
            sorteo1.DIA=12;
            
            CrearSorteos result= new CrearSorteos(sorteo1);
            Respuesta expected= new Respuesta("Sorteo Creado Exitosamente");

            Assert.Equal(expected, result);
        }
        
         [Fact]
        public void PruebaCrearSorteo()
        {
            Sorteo sorteo1 = new Sorteo();
            sorteo1.ID_SORTEO=1;
            sorteo1.ID_JUEGO=2;
            sorteo1.ID_ITEM=1;
            sorteo1.HORA= 5:30;
            sorteo1.DIA=12;
            
            CrearSorteos result= new CrearSorteos(sorteo1);
            Respuesta expected= new Respuesta("Sorteo Creado Exitosamente");

            Assert.Equal(expected, result);
        }
    }
}