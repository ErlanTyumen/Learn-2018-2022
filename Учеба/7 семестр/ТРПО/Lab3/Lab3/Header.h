#include "pch.h"
#include <iostream>
using namespace std;
#pragma once

template <typename type>
class List
{
	List* next = NULL;
	type value;
	int count;
public:
	List()
	{
		count = 0;
	}
	List(type t)
	{
		value = t;
		count = 1;
	}
	List(const List& l) : next(l.next), value(l.value), count(l.count) {}
	~List() {}
	void Add(type t)
	{
		if (count != 0)
		{
			List* tmp = this;
			while (tmp->next != NULL)
			{
				(tmp->count)++;
				tmp = tmp->next;
			}
			(tmp->count)++;
			tmp->next = new List(t);
		}
		else
		{
			count = 1;
			value = t;
		}
	}
	void Input(int k, type t, ...)
	{
		if (count == 0)
		{
			type* tmp = &t;
			for (; k; k--)
				Add(*(tmp++));
		}
	}
	void Print()
	{
		List* tmp = this;
		while (tmp != NULL)
		{
			cout << tmp->value << endl;
			tmp = tmp->next;
		}
	}
	type GetValue()
	{
		return value;
	}
	void SetValue(type t)
	{
		value = t;
	}
	int GetCount()
	{
		return count;
	}
	void Show()
	{
		cout << value << endl;
	}
	List& operator= (const List& l)
	{
		value = l.value;
		return *this;
	}
	List& operator[] (const int index)
	{
		if (index < 0 || index >= count)
			throw "Error";
		int i = index;
		List* tmp = this;
		while (tmp != NULL && i != 0)
		{
			tmp = tmp->next;
			i--;
		}
		return *tmp;
	}
	bool operator!= (List& l)
	{
		bool flag = false;
		if (count != l.count) return true;
		List* tmp = this;
		List* tmpl = &l;
		while (tmp != NULL)
		{
			if (tmp->value != tmpl->value)
			{
				flag = true;
				break;
			}
			tmp = tmp->next;
			tmpl = tmpl->next;
		}
		return flag;
	}
	List& operator+ (List& l)
	{
		List* res = new List();
		List* tmp = this;
		while (tmp != NULL)
		{
			(*res).Add(tmp->value);
			tmp = tmp->next;
		}
		tmp = &l;
		while (tmp != NULL)
		{
			(*res).Add(tmp->value);
			tmp = tmp->next;
		}
		return *res;
	}
};