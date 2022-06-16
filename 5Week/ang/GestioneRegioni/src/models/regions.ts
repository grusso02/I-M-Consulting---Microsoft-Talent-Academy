export interface Region {
	ID: number;
	Name: string;
	numAbitanti: number;
	isAutonoma: boolean;
}

export const regions = [
	{
		ID: 1,
		Name: "Sicilia",
		numAbitanti: 100,
		isAutonoma: true
	},
	{
		ID: 2,
		Name: "Lazio",
		numAbitanti: 200,
		isAutonoma: true
	},
	{
		ID: 3,
		Name: "Lombardia",
		numAbitanti: 300,
		isAutonoma: true
	}
]