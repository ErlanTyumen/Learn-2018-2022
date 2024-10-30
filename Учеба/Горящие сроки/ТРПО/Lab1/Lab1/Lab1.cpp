#include <iostream>
#include <math.h>
#include <cstdio>
#include <stdlib.h>
#include <iomanip>
#include <map>
#include <queue>
#include <string>
#include <list>
#include <stack>

using namespace std;
class Date {
	int d, m, y;
public:
	Date(int _d = 0, int _m = 0, int _y = 0) : d(0), m(0), y(0) {
		setDay(_d);
		setMonth(_m + m);
		setYear(_y + y);
	}

	int getDay() { return d; }

	int getMonth() { return m; }

	int getYear() { return y; }

	void setDay(int day) {
		d = (day % 31) ? day % 31 : 1;
		setMonth(m + day / 31);
	}

	void setMonth(int month) {
		m = d = (month % 12) ? month % 12 : 1;
		setYear(month / 12 + y);
	}

	void setYear(int year) {
		y = year;
	}

	void show() const {
		cout << d << "." << m << "." << y;
	}
};
class Product {
public:
	int id, price;
	Date supply, shipment;
	string nameFirm;
	Product() {
		id = 0;
		nameFirm = "none";
		price = 0;
		Date d1 = Date(rand() % 31 + 1, rand() % 12 + 1, rand() % 3 + 2013);
		Date d2 = Date((d1.getDay() + rand() % 15), (d1.getMonth() + rand() % 6), d1.getYear());
		supply = d1;
		shipment = d2;
	}
	Product(int id, string nameFirm, int price, Date supply, Date shipment) : id(id), nameFirm(nameFirm), price(price), supply(supply), shipment(shipment) { }

	Product(const Product& obj)
	{	}

	int getID() {
		return id;
	}

	int getPrice() {
		return price;
	}
	string getFirmName() {
		return nameFirm;
	}
	Date getSupply() {
		return supply;
	}

	Date getShipment() {
		return shipment;
	}

	void setID(int a) {
		id = a;
	}

	void setPrice(int a) {
		price = a;
	}

	void setFirmName(string a) {
		nameFirm = a;
	}

	void setSupply(Date a) {
		supply = a;
	}

	void setShipment(Date a) {
		shipment = a;
	}

	void friend show(Product p);
	~Product() { }
};

void show(Product p)
{
	cout << "ID            = " << p.id << endl;
	cout << "Firm name     = " << p.nameFirm << endl;
	cout << "Price         = " << p.price << endl;
	cout << "Supply        = "; p.supply.show(); cout << endl;
	cout << "Shipment      = "; p.shipment.show(); cout << endl;
	cout << "________________________________________________________________" << endl;
}


struct minPrice {
	string firName;
	int minPrice;
};

bool compare(minPrice& first, minPrice& second)
{
	if (first.firName == second.firName)
	{
		if (first.minPrice > second.minPrice)
			first.minPrice = second.minPrice;
		return true;
	}
	else
		return false;
}

int main()
{
	stack<Product> products;
	Date d5 = Date(rand() % 31 + 1, rand() % 12 + 1, rand() % 3 + 2013);
	Date d6 = Date((d5.getDay() + rand() % 15), (d5.getMonth() + rand() % 6), d5.getYear());
	Product p = Product(1000, "Bundei", 1500, d5, d6);
	show(p);
	for (int j = 0; j < 10; j++)
	{
		string firm = "firm" + std::to_string(rand() % 20);
		int price = rand() % 60;
		Date d3 = Date(rand() % 31 + 1, rand() % 12 + 1, rand() % 3 + 2013);
		Date d4 = Date((d3.getDay() + rand() % 15), (d3.getMonth() + rand() % 6), d3.getYear());
		products.push(Product(j, firm, price, d3, d4));
	}
	int i = products.size();
	stack<Product> temp(products);
	temp = products;
	list<minPrice> mfrs;
	while (!products.empty())
	{
		Product prod = temp.top();
		temp.push_back({ prod.getFirmName(), prod.getPrice() });
		temp.unique(compare);
		temp.pop();
	}

	return 0;
}