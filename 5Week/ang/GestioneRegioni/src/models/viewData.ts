export interface ViewData {
	IdComune: number;
	Comune: string;
	DataFondazioneComune: Date;
	numAbitantiComune: number;
	IdProvincia: number;
	Provincia: string;
	isCapoluogo: boolean;
	DataFondazioneProvincia: Date;
	numAbitantiProvincia: number;
	IdRegione: number;
	Regione: number;
	isAutonoma: boolean;
	DataFondazioneRegione: Date;
	numAbitantiRegione: number;
}
