export interface Region {
	id: number;
	name: string;
	nResidents: number;
	isAutonomous: boolean;
}

export const regions = [
	{
		id: 1,
		name: "Sicilia",
		nResidents: 100,
		isAutonomous: true
	},
	{
		id: 2,
		name: "Lazio",
		nResidents: 200,
		isAutonomous: true
	},
	{
		id: 3,
		name: "Lombardia",
		nResidents: 300,
		isAutonomous: true
	}
]