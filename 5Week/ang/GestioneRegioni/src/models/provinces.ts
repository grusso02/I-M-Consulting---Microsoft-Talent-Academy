export interface Province {
	ID: number;
	Name: string;
	numAbitanti: number;
	isCapoluogo: boolean;
	IdRegione: number;
}

/* export const provinces = [
	{
		ID: 1,
		Name: "Palermo",
		numAbitanti: 10,
		isCapoluogo: true,
		IdRegione: 1
	},
	{
		ID: 2,
		Name: "Trapani",
		numAbitanti: 5,
		isCapoluogo: false,
		IdRegione: 1
	},
	{
		ID: 3,
		Name: "Roma",
		numAbitanti: 20,
		isCapoluogo: true,
		IdRegione: 2
	},
	{
		ID: 4,
		Name: "Rieti",
		numAbitanti: 10,
		isCapoluogo: false,
		IdRegione: 2
	},
	{
		ID: 5,
		Name: "Milano",
		numAbitanti: 30,
		isCapoluogo: true,
		IdRegione: 3
	},
	{
		ID: 6,
		Name: "Cremona",
		numAbitanti: 15,
		isCapoluogo: false,
		IdRegione: 3
	},
] */