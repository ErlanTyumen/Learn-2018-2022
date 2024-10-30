
#include "pch.h"
#include "Header.h"
#include "iostream"
using namespace std;

/////////////////////ÎÓ±_³ 1
//template <class type>
//bool MinPositive(type* mas, type& min, int n)
//{
//	int i = 0;
//	bool flag = false;
//	for (; i < n; i++)
//	{
//		if (mas[i] > 0)
//		{
//			min = mas[i];
//			flag = true;
//			break;
//		}
//	}
//	for (i = i + 1; i < n; i++)
//	{
//		if (mas[i] > 0 && mas[i] < min)
//		{
//			min = mas[i];
//		}
//	}
//	return flag;
//}


/////////////////////ÎÓ±_³ 2
//template <typename type>
//List<type>::List()
//{
//	count = 0;
//}

//template <typename type>
//List<type>::List(type t)
//{
//	value = t;
//	count = 1;
//}

//template <typename type>
//void List<type>::Input(type t)//´Ó°Õ_
//{
//	if (count != 0)
//	{
//		List *tmp = this;
//		while (tmp->next != NULL)
//		{
//			(tmp->count)++;
//			tmp = tmp->next;
//		}
//		(tmp->count)++;
//		tmp->next = new List(t);
//	}
//	else
//	{
//		count=1;
//		value = t;
//	}
//}

//template <typename type>
//void List<type>::Print()//´Ó°Õ_
//{
//	List *tmp = this;
//	while (tmp != NULL)
//	{
//		cout << tmp->value << endl;
//		tmp = tmp->next;
//	}
//}

//template <typename type>
//type List<type>::GetValue()
//{
//	return value;
//}

//template <typename type>
//void List<type>::SetValue(type t)
//{
//	value = t;
//}

//template <typename type>
//int List<type>::GetCount()
//{
//	return count;
//}

//template <typename type>
//void List<type>::Show()
//{
//	cout << value << endl;
//}
