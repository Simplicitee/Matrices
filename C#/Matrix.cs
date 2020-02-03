namespace MatrixSpace {
    using VectorSpace;

    public class Matrix {
        double[,] data;
        int rows, cols;

        public Matrix(int rows, int cols) {
            this.rows = rows;
            this.cols = cols;
            this.data = new double[rows, cols];
        }

        public int getRows() {
            return rows;
        }

        public int getColumns() {
            return cols;
        }

        public string getOrder() {
            return rows + "x" + cols;
        }

        public void set(int row, int col, double value) {
            if (row > rows || row < 0) {
                throw new System.Exception("Row out of bounds!");
            } else if (col > cols || col < 0) {
                throw new System.Exception("Column out of bounds!");
            }

            data[row, col] = value;
        }

        public double get(int row, int col) {
            if (row > rows || row < 0) {
                throw new System.Exception("Row out of bounds!");
            } else if (col > cols || col < 0) {
                throw new System.Exception("Column out of bounds!");
            }

            return data[row, col];
        }

        public Matrix add(Matrix other) {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < rows; j++) {
                    data[i, j] += other.get(i, j);
                }
            }

            return this;
        }

        public Matrix subtract(Matrix other) {
            other.scale(-1);
            this.add(other);
            other.scale(-1);
            return this;
        }

        public Matrix scale(double value) {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < rows; j++) {
                    data[i, j] *= value;
                }
            }

            return this;
        }

        public Matrix multiply(Matrix other) {
            if (this.cols != other.rows) {
                throw new System.Exception("Columns of the calling matrix must match rows of the other matrix!");
            }

            Matrix m = new Matrix(this.rows, other.cols);
            for (int i = 0; i < m.rows; i++) {
                Vector row = this.getRowVector(i);

                for (int j = 0; j < m.cols; j++) {
                    Vector col = other.getColumnVector(j);

                    m.set(i, j, row.dot(col));
                }
            }

            return m;
        }

        public Vector getRowVector(int row) {
            Vector v = new Vector(cols);

            for (int i = 0; i < cols; i++) {
                v.set(i, data[row, i]);
            }

            return v;
        }

        public Vector getColumnVector(int col) {
            Vector v = new Vector(rows);

            for (int i = 0; i < rows; i++) {
                v.set(i, data[i, col]);
            }

            return v;
        }
    }
    
}
