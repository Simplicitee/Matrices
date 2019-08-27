#include "Matrix.h"

Matrix Matrix::add(Matrix other) {
	if ((this->getRows() != other.getRows()) || (this->getColumns() != other.getColumns())) {
		throw "Cannot add matricies of different sizes";
	}
	else {
		Matrix* m = new Matrix(this->getRows(), this->getColumns());

		for (int i = 0; i < m->getRows(); i++) {
			for (int j = 0; j < m->getColumns(); j++) {
				m->set(i, j, this->get(i, j) + other.get(i, j));
			}
		}

		return (*m);
	}
}

Matrix Matrix::mult(Matrix other) {
	if (this->getColumns() != other.getRows()) {
		throw "Incompatible matricies";
	}
	else {
		Matrix* m = new Matrix(this->getRows(), other.getColumns());
			
		for (int i = 0; i < m->getRows(); i++) {
			for (int j = 0; j < m->getColumns(); j++) {
				int value = 0;

				for (int r = 0; r < this->getColumns(); r++) {
					value += this->get(i, r) * other.get(r, j);
				}
					
				m->set(i, j, value);
			}
		}


		return (*m);
	}
}
