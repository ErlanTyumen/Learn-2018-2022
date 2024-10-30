#include <iostream>
#include <stdio.h>
#include <locale.h>
#include <fstream>
#include <omp.h>
#include <string>
#include <list>

using namespace std;

double times = 0;

int Sum(int start, int end)
{
	int sum = 0;
	for (int i = start; i <= end; i++)
		sum += i;
	return sum;
}
double math(int start, int end)
{
	double sum = 0, dt;
	for (int i = start; i < end; i++)
		sum += (1 + cos(i + 3.14 * i)) / (5 + sin(i + 3.14 * i));
	return sum;
}
void Task0(int n, int k)
{
	double sum = 0;
	clock_t start = clock(), end;
	printf("_______k = %d n = %d_______\n", k, n);
#pragma omp parallel num_threads(k) reduction(+ : sum)
	{
		int current = omp_get_thread_num();
		if (k >= n)
			if (current < n)
				sum += current + 1;
			else
			{
				if (current + 1 != k)
					sum += math(n / k * current + 1, n / k * (current + 1));
				else 
					sum += math(n / k * current + 1, n);
			}
	}
	end = clock();
	double dt = (start - end) / CLOCKS_PER_SEC;
	times += dt;
}
void Task1(int n)
{
	int result = 0;
	printf("N = %d  _________________________\n", n);
#pragma omp parallel num_threads(2) reduction (+ : result)
	{
		int currentThread = omp_get_thread_num();
		if (currentThread == 0)
		{
			result = Sum(0, n / 2);
			printf("[0]: Sum = %d\n", result);
		}
		if (currentThread == 1)
		{
			result = Sum(n / 2 + 1, n);
			printf("[1]: Sum = %d\n", result);
		}
	}
	printf("Sum = %d\n", result);
}
void Task2(int n, int k)
{
	int sum = 0;
	printf("_______k = %d n = %d_______\n", k, n);
#pragma omp parallel num_threads(k) reduction(+ : sum)
	{
		int current = omp_get_thread_num();
		if (k >= n)
			if (current < n) 
				sum += current + 1;
		else 
		{
			if (current + 1 != k)
				sum += Sum(n / k * current + 1, n / k * (current + 1));
			else sum += Sum(n / k * current + 1, n);

		}
		printf("[%d]: Sum = %d\n", current, sum);
	}
	printf("Sum = %d\n", sum);
}
void Task3(int k, int n) 
{
	int sum = 0;
	printf("_______k = %d n = %d_______\n", k, n);
#pragma omp parallel num_threads(k) reduction(+ : sum)
	{
		int current = omp_get_thread_num();
#pragma omp for
		for (int j = 1; j <= n; j++) sum += j;
		printf("[%d]: Sum = %d\n", current, sum);
	}
	printf("Sum = %d\n", sum);
}
void Task4()
{
	int sum = 0,  i;
#pragma omp parallel num_threads(4) reduction(+ : sum)
	{
#pragma omp for schedule(guided)
		for (i = 1; i <= 10; i++) {
			int currentThread = omp_get_thread_num();
			sum += i;
			printf("[%d]: Sum = %d\n", currentThread, sum);
			printf("[%d]: calculation of the iteration number %d\n", currentThread, i);
		}
	}
	printf("Sum = %d\n", sum);
}
double f(double x)
{
	return 4 / (1 + pow(x, 2));
}
double LeftRectangle(int a, int b, double n)
{
	double h = (double)(b - a) / n;
	double sum = 0;
	double x;
	for (int i = 0; i < n; i++)
	{
		x = a + i * h;
		sum += f(x);
	}
	return sum * h;
}

void Task5()
{
	double eps = 0.001;
	double prev = 0;
	double curr = 1;
	double dt;
	int n = 1;
	int k = 1;
	string out;
	clock_t start, end;
	do
	{
		do
		{
			start = clock();
			do
			{
#pragma omp parallel for num_threads(k) schedule(dynamic)
				for (int i = 0; i < k; i++)
				{
					int ThCurr = omp_get_thread_num();
					prev = curr;
					curr = LeftRectangle(0, 1, n);
					n *= 2;
					//printf("[%d] accuracy:%f. Needed eps=%f, Current K=%d, Current N=%d\n", ThCurr, abs(curr - prev), eps, k, n);
				}
			} while (abs(curr - prev) > eps);
			end = clock();
			n = 1;
			dt = (double)(end - start) / CLOCKS_PER_SEC;
			k++;
			printf("Значение интеграла с точностью %f = %f; Затрачено %f сек.\n", eps, curr, dt);
			out += "" + to_string(eps) + ";" + to_string(k) + ";" + to_string(dt) + "" + "\n";
		} while (k <= 20 && dt < 120);
		k = 1;
		eps /= 10;
	} while (dt < 120);
	ofstream F;
	F.open("C:/Users/Grost/Desktop/ATPP/ConsoleApplication5/Task5.csv", ios::out);
	F << out;
	F.close();
}
int main()
{
	setlocale(LC_ALL, "Russian");
	int* n0 = new int[14]{ 1,2,3,4,5,6,7,8,9,10,11,12,13,14 };
	int n = 10000000;
	for (int j = 0; j < sizeof(n0) < j++)
	{
		for (int i = 0; i < 10; i++)
		{
			Task0(n, n0[j]);
		}
	}

	//Task1
	/*int* n1 = new int[6]{ 1,2,5,10,100,1000 };
	for (int i = 0; i < 6; i++)
		Task1(n1[i]);*/
	//Task2
	/*int* n2 = new int[4]{ 2,10,100,1000 };
	int* k2 = new int[4]{ 2,4,8,16 };
	for (int i = 0; i < 4; i++)
		for (int j = 0; j < 4; j++)
			Task2(n2[i], k2[j]);*/
	//Task3
	/*int* n = new int[4] { 2, 10, 100, 1000 };
	int* k = new int[4]{ 2, 4, 8, 16 };
	for (int i = 0; i < 4; i++) {
		for (int j = 0; j < 4; j++) {
			Task3(k[i], n[j]);
		}
	}*/
	//Task5();
	//Task4();
}