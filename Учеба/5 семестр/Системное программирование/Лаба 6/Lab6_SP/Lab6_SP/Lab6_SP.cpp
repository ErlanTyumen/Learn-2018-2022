// Lab6_SP.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <math.h> 
double Zadanie1(double* x);
double Zadanie2(double&, double&, double&);
using namespace std;
double Zadanie1(double* x)
{
    return pow(*x, 5) - pow(*x, 5) + fabs(pow(*x, 3));
}
double Zadanie2(double& x1, double& x2, double& x3)
{
    return pow(x1, 2) + pow(x2, 2) - 2 * x1 * x2 * cos(x3) * 1.34 / 180;
}
//Создает массив
int* create_arr(int size)
{
    int* arr = new int[size];
    return arr;
}
//Заполняет массив
void fill_arr(int* arr, int size)
{
    for (int i = 0; i < size; i++)
    {
        *(arr + i) = rand() % 100;
        cout << *(arr + i) << " ";
    }
    cout << endl;
}
//Находит максимальный элемент
int find_max_el(int* arr, int size) {
    int max = *(arr);
    for (int i = 0; i < size; i++)
    {
        if (*(arr + i) > max)
            max = *(arr + i);
    }
    return max;
}
//Выводит отрицательные элементы
void negative_elements(int* arr, int size)
{
    for (int i = 0; i < size; i++)
        if (*(arr + i) < 0)
            cout << *(arr + i);
    cout << endl;
}
//Находит среднеарифметическое
int average_arithmetic(int* arr, int size)
{
    int k = 0, sum = 0;
    for (int i = 0; i < size; i += 2)
    {
        sum += *(arr + i);
        k++;
    }
    return (double)sum / (double)k;
}
double function1(double x)
{
    return sin(pow(x,2));
}
bool function2(double x, double& result)
{
    if (x <= 0)
    {
        result = acos(exp(x));
        return true;
    }
    return false;
}
bool function3(double x, double& result)
{
    if (x >= 1)
    {
        result = log10(log(x));
        return true;
    }
    return false;
}
double function4(double x)
{
    return pow(x, 2) + pow(x, 3);
}
int main()
{
    //Задание 1 Вычислить корень квадратный от (x^5-x^4+|x^3|)
    double x;
    cin >> x;
    cout << Zadanie1(&x);
    //Задание 2 Вычислить сторону треугольника, зная две другие стороны и угол между ними.
    double a, b, angle;
    cin >> a >> b >> angle;
    double& y1 = a, & y2 = b, & y3 = angle;
    cout << Zadanie2(y1, y2, y3);
    //Задание 3 
    //Дан одномерный массив, состоящий из N целочисленных элементов.
    //14.1.Заполнить массив случайными числами.
    //14.2.Найти максимальный элемент.
    //14.3.Вычислить среднее арифметическое нечетных элементов массива.
    //14.4.Вывести отрицательные элементы на экран.
    int size;
    cin >> size;
    int* arr = create_arr(size);
    fill_arr(arr, size);
    cout << find_max_el(arr, size) << endl;
    negative_elements(arr, size);
    cout << average_arithmetic(arr, size) << endl;
    delete[] arr;
    //Задание 4 Используя указатели на функцию вычислить значение функции в точке х в 
    //соответствии с выбором функции пользователем.При невозможности вычисления функции в
    //точке x выдать соответствующее сообщение.
    //1 sin(x)
    //2 arccos(e^x)
    //3 lgln(x)
    //4 x^2+x^3
    int choice = 0;
    double x = 0.0, result = 0;
    cout << "1. sim(x^2) 2. arrcos(e^x) 3. lglnx 4. x^2+x^3"<< endl;
    cout << "select function: "; cin >> choice;
    cout << "Enter x: "; cin >> x;
    cout << "Result: ";
    switch (choice)
    {
    case 1:
        double (*Fun1) (double);
        Fun1 = function1;
        cout << (*Fun1)(x) << endl; break;
    case 2:
        bool (*Fun2) (double, double&);
        Fun2 = function2;
        (*Fun2)(x, result) ?
            cout << result << endl :
            cout << "Error, Impossible X";
        break;
    case 3:
        bool (*Fun3) (double, double&);
        Fun3 = function3;
        (*Fun3)(x, result) ?
            cout << result << endl :
            cout << "Error, Impossible X";
        break;
    case 4:
        double (*Fun4) (double);
        Fun4 = function4;
        cout << (*Fun4)(x) << endl; break;
    }
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.
