#include "pch.h"
#include "Header.h"
#include <iostream>
using namespace std;

template <class array_type>
array_type ariMean(array_type* a, const int N)
{
	array_type m = a[0];
	for (int i = 1; i < N; i++)
		m += a[i];
	return m / N;
}

int main()
{
	double a[] = { 2.5 , 8.3 , 6 };
	int b[] = { 3, 5, -1, 2 };
	float c[] = { 2.5 , 8.3 , 6 };

	cout << ariMean(a, sizeof(a) / sizeof(a[0])) << endl;
	cout << ariMean(b, sizeof(b) / sizeof(b[0])) << endl;
	cout << ariMean(c, sizeof(c) / sizeof(c[0])) << endl;
	
	int n = 5;
	int* masint = new int[n] {0, 1, -8, 10, 5};
	int minint = 0;
	double* masdouble = new double[n] {-5, -7, -8, -1, -6};
	double mindouble = 0;
	float* masfloat = new float[n] {9, -7, 0, -2, -6};
	float minfloat = 0;

	cout << endl;
	List<int> l1 = List<int>(); 
	l1.Input(4, 2, 9, 4, 7);
	/*List<int> l1 = List<int>(2);
	l1.Add(9);
	l1.Add(4);
	l1.Add(7);*/
	cout << "Count: " << l1.GetCount() << endl;
	l1.Print();

	cout << endl;
	l1[2].Show();
	(l1[2] = 5).Show();

	List<int> l2 = List<int>(2);
	l2.Add(9);
	l2.Add(5);
	l2.Add(7);

	cout << endl;
	cout << (l1 != l2) << endl;
	List<int> l3 = List<int>(2);
	l3.Add(1);
	cout << (l1 != l3) << endl;

	List<double> l4 = List<double>(5);
	l4.Add(1);
	l4.Add(8);

	List<double> l5 = List<double>(2);
	l5.Add(4);

	cout << endl;
	cout << "List<double>" << endl;
	List<double> l6 = l4 + l5;
	l6.Print();

}