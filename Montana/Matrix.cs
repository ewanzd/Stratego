using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montana
{
    /// <summary>
    /// Matrix to save values with any number of dimensions.
    /// </summary>
    /// <typeparam name="T">Type of field.</typeparam>
    public abstract class Matrix<T>
    {
        // Das Objekt verwaltet Daten in beliebigen Anzahl und Länge der Dimensionen.
        // Beispiel ein 2D-Spielbrett mit einem Spielfeld von der Länge 20 und der Breit 10
        // besitzt zwei Dimensionen, eine mit der Länge 20 und eine zweite mit der Länge 10.

        /// <summary>
        /// Get and set a grain of <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="position">Position of the grain.</param>
        /// <
        /// <returns>Target grain.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        protected T this[params int[] position]
        {
            get
            {
                // Position ermitteln
                int pos = GetPosition(position);

                // Position zurückgeben
                return matrix[pos];
            }
            set
            {
                // Position ermitteln
                int pos = GetPosition(position);

                // Wert an der Position abspeichern
                matrix[pos] = value;
            }
        }

        private readonly T[] matrix;
        private readonly int[] dimensionsLength;

        /// <summary>
        /// Get number of dimensions.
        /// </summary>
        protected int NumberOfDimensions
        {
            get
            {
                // Anzahl Dimensionen abrufen
                return dimensionsLength.Length;
            }
        }

        /// <summary>
        /// Create new <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="dimensionsLength">Length of all dimensions.</param>
        /// <exception cref="OverflowException">One of dimensions length is under 0.</exception>
        public Matrix(params int[] dimensionsLength)
        {
            // Die einzelnen Dimesionslängen abspeichern
            this.dimensionsLength = dimensionsLength;

            // Die benötigte Arraylänge herausfinden 
            var fullLength = dimensionsLength.Aggregate((x1, x2) => x1 * x2);

            // Matrix erstellen
            matrix = new T[fullLength];
        }

        /// <summary>
        /// Get position of search point.
        /// </summary>
        /// <param name="point">Position in dimensions.</param>
        /// <returns>Return position in <see cref="Montana.Matrix"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">One of point is out of range.</exception>
        private int GetPosition(params int[] point)
        {
            // Anzahl Dimensionen der Übergabe abrufen
            int length = point.Length;

            // Anzahl Dimensionen müssen gleich dem aktuellen Matrix sein
            if(length != NumberOfDimensions)
                throw new ArgumentOutOfRangeException("point");

            // Position des gesuchten Wertes erstellen
            int pos = 0;

            // Position ermitteln
            for(int i = 0; i < length; i++)
            {
                // Position in der aktuellen Dimension abrufen
                int val = point[i] - 1;

                // Prüfen, ob die Position innerhalb des möglichen Bereichs liegt
                if(val >= dimensionsLength[i] || val < 0)
                    throw new IndexOutOfRangeException();

                // Zu der gesuchten Dimension springen
                pos += val * GetDimensionLength(i);
            }

            // Position zurückgeben
            return pos;
        }

        /// <summary>
        /// Get number of grains in dimension.
        /// </summary>
        /// <param name="startDeep">Start deep in <see cref="Montana.Matrix"/>.</param>
        /// <returns>Return number of grains in target dimension.</returns>
        /// <exception cref="IndexOutOfRangeException">Start deep is out of range.</exception>
        private int GetDimensionLength(int startDeep)
        {
            // Eine Dimension besitzt mindestens einen Wert
            int result = 1;

            // Starttiefe abrufen
            int currentDim = startDeep + 1;

            // Anzahl Werte in der Dimension abrufen
            for(int i = currentDim; i < dimensionsLength.Length; i++)
                result *= dimensionsLength[i];

            // Wert zurückgeben
            return result;
        }

        /// <summary>
        /// Get length of dimension of <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="dimension">Get length from this dimension.</param>
        /// <returns>Return length of dimension.</returns>
        /// <exception cref="IndexOutOfRangeException">Number of dimension is out of range.</exception>
        protected int GetLength(int dimension)
        {
            // Array fängt von 0 an, deshalb wird 1 abgezählt
            int dim = dimension - 1;

            // Länge der Dimension zurückgeben
            return dimensionsLength[dim];
        }
    }
}
