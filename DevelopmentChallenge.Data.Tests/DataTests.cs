using System;
using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> { new Cuadrado(5) };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Castellano);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Cuadrado (1),
                new Cuadrado (3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, FormaGeometrica.Ingles);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Ingles);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13.01 | Perimeter 18.06 <br/>3 Triangles | Area 49.64 | Perimeter 51.6 <br/>TOTAL:<br/>7 shapes Perimeter 97.66 Area 91.65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado (5),
                new Circulo (3),
                new TrianguloEquilatero (4),
                new Cuadrado (2),
                new TrianguloEquilatero (9),
                new Circulo (2.75m),
                new TrianguloEquilatero (4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13.01 | Perímetro 18.06 <br/>3 Triángulos | Área 49.64 | Perímetro 51.6 <br/>TOTAL:<br/>7 formas Perímetro 97.66 Área 91.65",
                resumen);

        }

        [Test]
        public void TestResumenListaConTrapecioYRectangulo()
        {
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new Trapecio(5, 3, 4, 4, 2),
                new Rectangulo(5, 3)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>1 Círculo | Área 7.07 | Perímetro 9.42 <br/>1 Trapecio | Área 16 | Perímetro 14 <br/>1 Rectángulo | Área 15 | Perímetro 16 <br/>TOTAL:<br/>4 formas Perímetro 59.42 Área 63.07",
                resumen);
        }


        //Caso de prueba para Trapecio en Italiano
        [TestCase]
        public void TestResumenListaConTrapecioEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(5, 3, 4, 4, 2)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>1 Trapezio | Area 16 | Perimetro 14 <br/>TOTALE:<br/>1 forme Perimetro 14 Area 16",
                resumen);
        }

        //Caso de prueba para rectangulo en Italiano
        [TestCase]
        public void TestResumenListaConRectanguloEnItaliano()
        {
            var formas = new List<FormaGeometrica>
            {
                new Rectangulo(4, 6)
            };

            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>1 Rettangolo | Area 24 | Perimetro 20 <br/>TOTALE:<br/>1 forme Perimetro 20 Area 24",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConCirculoEnItaliano()
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Circulo(7)
            };

            // Act
            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Italiano);

            // Assert
            Assert.AreEqual(
                "<h1>Rapporto sui moduli</h1>1 Cerchio | Area 38.48 | Perimetro 21.99 <br/>TOTALE:<br/>1 forme Perimetro 21.99 Area 38.48",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConTrapecioEnCastellano()
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(5, 3, 4, 4, 2)
            };

            // Act
            var resumen = FormaGeometrica.Imprimir(formas, FormaGeometrica.Castellano);

            // Assert
            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>1 Trapecio | Área 16 | Perímetro 14 <br/>TOTAL:<br/>1 formas Perímetro 14 Área 16",
                resumen);
        }


    }
}
