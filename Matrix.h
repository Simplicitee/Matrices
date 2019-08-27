#pragma once
class Matrix
{
private:
	int rows, columns;
	int matrix[100][100];

public:
	Matrix(int rows, int columns) {
		this->rows = rows;
		this->columns = columns;
		
		for (int i = 0; i < rows; i++) {
			for (int j = 0; j < columns; j++) {
				matrix[i][j] = 0;
			}
		}
	}
	~Matrix() {}
	
	Matrix add(Matrix);
	Matrix mult(Matrix);

	void set(int row, int column, int value) {
		matrix[row][column] = value;
	}

	int get(int row, int column) {
		return matrix[row][column];
	}

	int getRows() {
		return rows;
	}

	int getColumns() {
		return columns;
	}

	int getSize() {
		return rows * columns;
	}
};