export interface Province {
	id: number;
	name: string;
	nResidents: number;
	isCountyTown: boolean;
	idRegion: number;
}

export const provinces = [
	{
		id: 1,
		name: "Palermo",
		nResidents: 10,
		isCountyTown: true,
		idRegion: 1
	},
	{
		id: 2,
		name: "Trapani",
		nResidents: 5,
		isCountyTown: false,
		idRegion: 1
	},
	{
		id: 3,
		name: "Roma",
		nResidents: 20,
		isCountyTown: true,
		idRegion: 2
	},
	{
		id: 4,
		name: "Rieti",
		nResidents: 10,
		isCountyTown: false,
		idRegion: 2
	},
	{
		id: 5,
		name: "Milano",
		nResidents: 30,
		isCountyTown: true,
		idRegion: 3
	},
	{
		id: 6,
		name: "Cremona",
		nResidents: 15,
		isCountyTown: false,
		idRegion: 3
	},
]