import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { City } from 'src/models/cities';
import { Province } from 'src/models/provinces';
import { Region } from '../../models/regions';
import { RestApiService } from 'src/services/rest-api.service';

@Component({
  selector: 'app-item-picker',
  templateUrl: './item-picker.component.html',
  styleUrls: ['./item-picker.component.css']
})

export class ItemPickerComponent implements OnInit {

  constructor(private router: Router, private callApiServices: RestApiService) { }

  reg = {} as Region[];

  regions = this.callApiServices.getAllRegionsFromApi();
  provinceDisplay: Province[] | undefined;
  cityDisplay: City[] | undefined;
  idCity: Number = 0;

  trigProv = 0;
  trigCity = 0;
  trigTable = 0;

  ngOnInit(): void {
  }

  onRegionSelected(event: any): void {
    let idRegion = event.target.value;
    this.provinceDisplay = provinces.filter(p => p.IdRegione == Number(idRegion));
    this.trigProv = 1;
    this.trigCity = 0;
  }

  onProvinceSelected(event: any): void {
    let idProv = event.target.value;
    this.cityDisplay = cities.filter(p => p.IdProvincia == Number(idProv));
    this.trigCity = 1;
  }

  onCitySelected(event: any): void {
    this.idCity = event.target.value;
  }

}
