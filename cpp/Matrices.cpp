// Matrices.cpp : This file contains the 'main' function. Program execution begins and ends there.
// Example use of Matrix class

#include <iostream>
#include "Matrix.h"
using namespace std;

int main()
{
	int ar = 0, ac = 0, br = 0, bc = 0;
	cout << "Enter number of rows in first matrix: ";
	cin >> ar;

	cout << "Enter number of columns in first matrix: ";
	cin >> ac;

	cout << "Enter number of rows in second matrix: ";
	cin >> br;

	cout << "Enter number of columns in second matrix: ";
	cin >> bc;

	Matrix* a = new Matrix(ar, ac);
	Matrix* b = new Matrix(br, bc);

	cout << "Values for the first matrix" << endl;
	
	for (int i = 0; i < a->getRows(); i++) {
		for (int j = 0; j < a->getColumns(); j++) {
			cout << "Pos(" << i << ", " << j << ") value: ";
			int value = 0;
			cin >> value;
			a->set(i, j, value);
		}
	}

	cout << "Values for the second matrix" << endl;

	for (int i = 0; i < b->getRows(); i++) {
		for (int j = 0; j < b->getColumns(); j++) {
			cout << "Pos(" << i << ", " << j << ") value: ";
			int value = 0;
			cin >> value;
			b->set(i, j, value);
		}
	}

	cout << "Multiplied Matrix" << endl;

	Matrix m = a->mult(*b);
	for (int i = 0; i < m.getRows(); i++) {
		for (int j = 0; j < m.getColumns(); j++) {
			cout << "Pos(" << i << ", " << j << ") value: " << m.get(i, j) << endl;
		}
	}
}
