namespace MathMatrix
{
    internal class Matrix
    {
        private int _rows, _cols;
        private double[,] _data;    // Matrix values

        // Constructor to create a matrix from 1D array
        public Matrix(int n, int m, double[] values)
        {
            _rows = n;
            _cols = m;

            _data = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    _data[i, j] = values[_cols * i + j];
                }
            }
        }

        // Constructor to create a matrix from 2D array
        public Matrix(int n, int m, double[,] values)
        {
            _rows = n;
            _cols = m;
            _data = values;
        }

        // Method to calculate determinant of the matrix
        public double det()
        {
            if (_rows != _cols)
                return double.NaN; // Return NaN if matrix is not square. Determinant undefined

            if (_rows == 1)
            {
                return _data[0, 0]; // Base case: determinant of 1x1 matrix
            }

            double res = 0;
            for (int i = 0; i < _cols; i++)
            {
                int n = _rows - 1, m = _cols - 1;
                double[] temp = new double[n * m];
                int p = 0;
                for (int x = 0; x < _rows; x++)     // Loop through rows (?)
                {
                    if (x != i)
                    {
                        for (int y = 1; y < _cols; y++) // Loop through columns, starting from 1
                        {
                            temp[p] = _data[x, y];
                            p += 1;
                        }
                    }
                }

                Matrix t_matr = new Matrix(n, m, temp);
                res += Math.Pow(-1, i) * _data[i, 0] * t_matr.det();
            }

            return res;
        }

        // Method to calculate transposed matrix
        public Matrix transp()
        {
            double[,] temp = new double[_rows, _cols];

            for (int i = 0; i < _cols; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    temp[i, j] = _data[j, i];
                }
            }

            return new Matrix(_rows, _cols, temp);
        }

        // Method to calculate adjugate of the matrix
        public Matrix adj()
        {
            double[,] temp = new double[_rows, _cols];
            double deter = det();

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    temp[i, j] = Math.Pow(-1, i + j) * getMinor(i, j).det() / deter;
                }
            }

            return new Matrix(_rows, _cols, temp);
        }

        // Method to get the minor of the element
        private Matrix getMinor(int row, int col)
        {
            int n = _rows, m = _cols;
            double[,] minor = new double[n - 1, m - 1];

            int x = 0;
            for (int i = 0; i < n; i++)
            {
                int y = 0;
                if (i == row)
                    continue;
                for (int j = 0; j < m; j++)
                {
                    if (j == col)
                        continue;

                    minor[x, y++] = _data[i, j];
                }
                x += 1;
            }

            return new Matrix(n - 1, m - 1, minor);
        }

        // Methods to calculate inverse matrix
        public Matrix inv()
        {
            return adj().transp();
        }

        public Matrix inv_gauss()
        {
            Matrix augmentedMatrix = new Matrix(_rows, _cols * 2, new double[_rows, 2 * _cols]);
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    augmentedMatrix._data[i, j] = _data[i, j];
                }
                augmentedMatrix._data[i, _cols + i] = 1;
            }

            for (int i = 0; i < _rows; i++)
            {
                double pivot = augmentedMatrix._data[i, i];
                for (int j = 0; j < 2 * _cols; j++)
                {
                    augmentedMatrix._data[i, j] /= pivot;
                }

                for (int j = 0; j < _cols; j++)
                {
                    if (i == j) continue;

                    double factor = augmentedMatrix._data[j, i];
                    for (int k = 0; k < 2 * _cols; k++)
                    {
                        augmentedMatrix._data[j, k] -= factor * augmentedMatrix._data[i, k];
                    }
                }
            }

            Matrix result = new Matrix(_rows, _cols, new double[_rows, _cols]);

            for (int i = 0; i < _rows; i++)
            {
                for (int j = _cols; j < _cols * 2; j++)
                {
                    result._data[i, j - _cols] = augmentedMatrix._data[i, j];
                }
            }

            return result;
        }

        // Method to get the 2D array representing the matrix
        public double[,] getMatrix()
        {
            return _data;
        }

        // Operator overloading to multiply a matrix by a scalar
        public static double[,] operator *(Matrix matrxA, double num)
        {
            for (int i = 0; i < matrxA._cols; i++)
            {
                for (int j = 0; j < matrxA._rows; j++)
                {
                    matrxA._data[i, j] *= num;
                }
            }

            return matrxA.getMatrix();
        }

        // Operator overloading to multiply two matrices
        public static double[,] operator *(Matrix matrxA, Matrix matrxB)
        {
            if (matrxA._cols != matrxB._rows)
                return new double[2, 1] { { double.NaN }, { double.NaN } };

            int n = matrxB._rows, m = matrxB._cols;
            double[,] res = new double[n, m];

            for (int i = 0; i < matrxA._rows; i++)
            {
                for (int j = 0; j < matrxB._cols; j++)
                {
                    for (int k = 0; k < matrxA._cols; k++)
                    {
                        res[i, j] += matrxA._data[i, k] * matrxB._data[k, j];
                    }
                }
            }

            return res;
        }
    }
}