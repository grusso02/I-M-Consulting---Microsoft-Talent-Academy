export interface Product {
	id: number;
	name: string;
	price: number;
	description: string;
	dateofproduction: Date;
	madeby: string;
}

export const products = [
	{
	  id: 1,
	  name: 'Phone XL',
	  price: 799,
	  description: 'A large phone with one of the best screens',
	  dateofproduction: new Date("12-22-2012"),
	  madeby: "constoso.com",
	},
	{
	  id: 2,
	  name: 'Phone Mini',
	  price: 699,
	  description: 'A great phone with one of the best cameras',
	  dateofproduction: new Date("01-01-2000"),
	  madeby: "constoso.com"
	},
	{
	  id: 3,
	  name: 'Phone Standard',
	  price: 299,
	  description: '',
	  dateofproduction: new Date("01-01-2000"),
	  madeby: "constoso.com"
	},
	{
	  id: 4,
	  name: 'Ferrari',
	  price: 30492.45,
	  description: 'It is very fast!',
	  dateofproduction: new Date("01-01-2000"),
	  madeby: "constoso.com"
	}
  ];