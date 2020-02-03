namespace VectorSpace {

    public class Vector {

        double[] data;
        int size;

        public Vector(int size) {
            this.size = size;
            this.data = new double[size];
        }

        public int getSize() {
            return size;
        }

        public void set(int i, double value) {
            if (i > size || i < 0) {
                throw new System.Exception("Index " + i + " out of bounds!");
            }

            data[i] = value;
        }

        public double get(int i) {
            if (i > size || i < 0) {
                throw new System.Exception("Index " + i + " out of bounds!");
            }

            return data[i];
        }

        public double dot(Vector other) {
            if (this.size != other.size) {
                throw new System.Exception("Vector sizes must be equal to dot!");
            }

            double dot = 0;

            for (int i = 0; i < this.size; i++) {
                dot += data[i] * other.data[i];
            }

            return dot;
        }
    }
    
}
