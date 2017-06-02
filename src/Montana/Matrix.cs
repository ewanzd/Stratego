using System;
using System.Linq;

namespace Montana
{
    /// <summary>
    /// Matrix to save values with any number of dimensions.
    /// </summary>
    /// <typeparam name="T">Type of field.</typeparam>
    public abstract class Matrix<T>
    {
        /// <summary>
        /// Get and set a grain of <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="position">Position of the grain.</param>
        /// <
        /// <returns>Target grain.</returns>
        /// <exception cref="IndexOutOfRangeException">Position is out of range.</exception>
        protected T this[params int[] position] {
            get {
                int pos = GetPosition(position);
                return matrix[pos];
            }
            set {
                int pos = GetPosition(position);
                matrix[pos] = value;
            }
        }

        private readonly T[] matrix;
        private readonly int[] dimensionsLength;

        /// <summary>
        /// Get number of dimensions.
        /// </summary>
        protected int NumberOfDimensions {
            get {
                return dimensionsLength.Length;
            }
        }

        /// <summary>
        /// Create new <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="dimensionsLength">Length of all dimensions.</param>
        /// <exception cref="OverflowException">One of dimensions length is under 0.</exception>
        public Matrix(params int[] dimensionsLength) {
            this.dimensionsLength = dimensionsLength;

            // calculate full length of array
            var fullLength = dimensionsLength.Aggregate((x1, x2) => x1 * x2);

            matrix = new T[fullLength];
        }

        /// <summary>
        /// Get position of search point.
        /// </summary>
        /// <param name="position">Position in dimensions.</param>
        /// <returns>Return position in <see cref="Montana.Matrix"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Count of parameter is false.</exception>
        /// <exception cref="IndexOutOfRangeException">One of the points is out of range.</exception>
        private int GetPosition(int[] position) {
            int length = position.Length;
            if (length != NumberOfDimensions)
                throw new ArgumentOutOfRangeException(nameof(position));

            int pos = 0;
            for (int i = 0; i < length; i++) {
                int val = position[i] - 1;

                if (val >= dimensionsLength[i] || val < 0)
                    throw new IndexOutOfRangeException();

                pos += val * GetDimensionLength(i);
            }

            return pos;
        }

        /// <summary>
        /// Get number of grains in dimension.
        /// </summary>
        /// <param name="startDeep">Start deep in <see cref="Montana.Matrix"/>.</param>
        /// <returns>Return number of grains in target dimension.</returns>
        /// <exception cref="IndexOutOfRangeException">Start deep is out of range.</exception>
        private int GetDimensionLength(int startDeep) {
            int result = 1;
            int currentDim = startDeep + 1;

            for (int i = currentDim; i < dimensionsLength.Length; i++) {
                result *= dimensionsLength[i];
            }

            return result;
        }

        /// <summary>
        /// Get length of dimension of <see cref="Montana.Matrix"/>.
        /// </summary>
        /// <param name="dimension">Get length from this dimension.</param>
        /// <returns>Return length of dimension.</returns>
        /// <exception cref="IndexOutOfRangeException">Number of dimension is out of range.</exception>
        protected int GetLength(int dimension) {
            int dim = dimension - 1;
            return dimensionsLength[dim];
        }
    }
}