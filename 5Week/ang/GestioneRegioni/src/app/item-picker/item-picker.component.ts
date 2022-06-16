import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { City, cities } from 'src/models/cities';
import { Province, provinces } from 'src/models/provinces';
import { regions } from '../../models/regions';

@Component({
  selector: 'app-item-picker',
  templateUrl: './item-picker.component.html',
  styleUrls: ['./item-picker.component.css']
})

export class ItemPickerComponent implements OnInit {

  regions = regions;
  provinceDisplay: Province[] | undefined;
  cityDisplay: City[] | undefined;

  trigProv = 0;
  trigCity = 0;
  trigTable = 0;

  constructor(private router: Router) { }

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

  getIdCity(): void {
    
  } 

}
