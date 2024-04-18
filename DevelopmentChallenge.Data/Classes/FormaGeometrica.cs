/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data.Classes
{

    //Clase base que genera la forma geometrica
    public abstract class FormaGeometrica
    {
        //Agregue rectangulo
        #region Formas

        public const int Cuadrado = 1;
        public const int TrianguloEquilatero = 2;
        public const int Circulo = 3;
        public const int Trapecio = 4;
        public const int Rectangulo = 5;

        #endregion

        //Agregue el idioma italiano
        #region Idiomas

        public const int Castellano = 1;
        public const int Ingles = 2;
        public const int Italiano = 3;

        #endregion
        private readonly decimal[] _lados;

        public int Tipo { get; }

        protected FormaGeometrica(int tipo, params decimal[] lados)
        {
            Tipo = tipo;
            _lados = lados;
        }
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerNombre(int cantidad, int idioma);

        //Agregue traducciones al Italiano
        public static string Imprimir(List<FormaGeometrica> formas, int idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Lista vacía de formas!</h1>");
                        break;
                    case Ingles:
                        sb.Append("<h1>Empty list of shapes!</h1>");
                        break;
                    case Italiano:
                        sb.Append("<h1>Elenco vuoto di forme!</h1>");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
                }
            }
            else
            {
                switch (idioma)
                {
                    case Castellano:
                        sb.Append("<h1>Reporte de Formas</h1>");
                        break;
                    case Ingles:
                        sb.Append("<h1>Shapes report</h1>");
                        break;
                    case Italiano:
                        sb.Append("<h1>Rapporto sui moduli</h1>");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
                }

                var diccionarioFormas = new Dictionary<int, FormaGeometrica>();
                var diccionarioTotales = new Dictionary<int, Tuple<int, decimal, decimal>>();

                foreach (var forma in formas)
                {
                    if (!diccionarioFormas.ContainsKey(forma.Tipo))
                    {
                        diccionarioFormas.Add(forma.Tipo, forma);
                        diccionarioTotales.Add(forma.Tipo, Tuple.Create(0, 0m, 0m));
                    }

                    var (cantidad, areaTotal, perimetroTotal) = diccionarioTotales[forma.Tipo];

                    cantidad++;
                    areaTotal += forma.CalcularArea();
                    perimetroTotal += forma.CalcularPerimetro();

                    diccionarioTotales[forma.Tipo] = Tuple.Create(cantidad, areaTotal, perimetroTotal);
                }

                foreach (var kvp in diccionarioFormas)
                {
                    var (cantidad, areaTotal, perimetroTotal) = diccionarioTotales[kvp.Key];
                    var forma = kvp.Value;

                    sb.Append($"{cantidad} {forma.ObtenerNombre(cantidad, idioma)} | {(idioma == Castellano ? "Área" : (idioma == Ingles ? "Area" : "Area"))} {areaTotal:#.##} | ");
                    sb.Append($"{(idioma == Castellano ? "Perímetro" : (idioma == Ingles ? "Perimeter" : "Perimetro"))} {perimetroTotal:#.##} <br/>");
                }

                switch (idioma)
                {
                    case Castellano:
                        sb.Append("TOTAL:<br/>");
                        break;
                    case Ingles:
                        sb.Append("TOTAL:<br/>");
                        break;
                    case Italiano:
                        sb.Append("TOTALE:<br/>");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
                }

                sb.Append($"{diccionarioTotales.Values.Sum(t => t.Item1)} {(idioma == Castellano ? "formas" : (idioma == Ingles ? "shapes" : "forme"))} ");
                sb.Append($"{(idioma == Castellano ? "Perímetro" : (idioma == Ingles ? "Perimeter" : "Perimetro"))} {diccionarioTotales.Values.Sum(t => t.Item3):#.##} ");
                sb.Append($"{(idioma == Castellano ? "Área" : (idioma == Ingles ? "Area" : "Area"))} {diccionarioTotales.Values.Sum(t => t.Item2).ToString("#.##")}");
            }

            return sb.ToString();
        }
    }

    //Separe las formas geometricas segun su funcionalidad y agregue Trapecio y Rectangulo.
    //Cada nueva forma geometrica hereda de FormaGeometrica e implementa sus metodos segun su funcionalidad.
    public class Cuadrado : FormaGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado) : base(Cuadrado, lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
        }

        public override string ObtenerNombre(int cantidad, int idioma)
        {
            string nombreSingular;
            string nombrePlural;

            switch (idioma)
            {
                case Castellano:
                    nombreSingular = "Cuadrado";
                    nombrePlural = "Cuadrados";
                    break;
                case Ingles:
                    nombreSingular = "Square";
                    nombrePlural = "Squares";
                    break;
                case Italiano:
                    nombreSingular = "Piazza";
                    nombrePlural = "Piazzi";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
            }

            return cantidad == 1 ? nombreSingular : nombrePlural;
        }
    }

    public class TrianguloEquilatero : FormaGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado) : base(TrianguloEquilatero, lado)
        {
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
        }

        public override string ObtenerNombre(int cantidad, int idioma)
        {
            string nombreSingular;
            string nombrePlural;

            switch (idioma)
            {
                case Castellano:
                    nombreSingular = "Triángulo";
                    nombrePlural = "Triángulos";
                    break;
                case Ingles:
                    nombreSingular = "Triangle";
                    nombrePlural = "Triangles";
                    break;
                case Italiano:
                    nombreSingular = "Triangolo";
                    nombrePlural = "Triangoli";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
            }

            return cantidad == 1 ? nombreSingular : nombrePlural;
        }
    }
    public class Circulo : FormaGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro) : base(Circulo,diametro)
        {
            _diametro = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
        }

        public override string ObtenerNombre(int cantidad, int idioma)
        {
            string nombreSingular;
            string nombrePlural;

            switch (idioma)
            {
                case Castellano:
                    nombreSingular = "Círculo";
                    nombrePlural = "Círculos";
                    break;
                case Ingles:
                    nombreSingular = "Circle";
                    nombrePlural = "Circles";
                    break;
                case Italiano:
                    nombreSingular = "Cerchio";
                    nombrePlural = "Cerchi";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
            }

            return cantidad == 1 ? nombreSingular : nombrePlural;
        }

    }

    public class Trapecio : FormaGeometrica
    {
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _altura;
        private readonly decimal _lado1;
        private readonly decimal _lado2;


        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal lado1, decimal lado2) : base(Trapecio, baseMayor, baseMenor, altura, lado1, lado2)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
            _lado1 = lado1;
            _lado2 = lado2;
        }

        public override decimal CalcularArea()
        {
            return ((_baseMayor + _baseMenor) / 2) * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return _baseMayor + _baseMenor + _lado1 + _lado2;
        }

        public override string ObtenerNombre(int cantidad, int idioma)
        {
            string nombreSingular;
            string nombrePlural;

            switch (idioma)
            {
                case Castellano:
                    nombreSingular = "Trapecio";
                    nombrePlural = "Trapecios";
                    break;
                case Ingles:
                    nombreSingular = "Trapezoid";
                    nombrePlural = "Trapezoids";
                    break;
                case Italiano:
                    nombreSingular = "Trapezio";
                    nombrePlural = "Trapezi";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
            }

            return cantidad == 1 ? nombreSingular : nombrePlural;
        }

    }

    public class Rectangulo : FormaGeometrica
    {
        private readonly decimal _base;
        private readonly decimal _altura;

        public Rectangulo(decimal @base, decimal altura) : base(Rectangulo, @base, altura)
        {
            _base = @base;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return _base * _altura;
        }

        public override decimal CalcularPerimetro()
        {
            return 2 * (_base + _altura);
        }

        public override string ObtenerNombre(int cantidad, int idioma)
        {
            string nombreSingular;
            string nombrePlural;

            switch (idioma)
            {
                case Castellano:
                    nombreSingular = "Rectángulo";
                    nombrePlural = "Rectángulos";
                    break;
                case Ingles:
                    nombreSingular = "Rectangle";
                    nombrePlural = "Rectangles";
                    break;
                case Italiano:
                    nombreSingular = "Rettangolo";
                    nombrePlural = "Rettangoli";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(idioma), "Idioma no soportado");
            }

            return cantidad == 1 ? nombreSingular : nombrePlural;
        }
    }

}


