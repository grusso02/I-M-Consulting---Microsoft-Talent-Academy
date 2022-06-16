import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { City, cities } from 'src/models/cities';
import { Province, provinces } from 'src/models/provinces';
import { Region, regions } from '../../models/regions';

@Component({
  selector: 'app-table-details',
  templateUrl: './table-details.component.html',
  styleUrls: ['./table-details.component.css']
})
export class TableDetailsComponent implements OnInit {

  city: City | undefined;
  province: Province | undefined;
  region: Region | undefined;

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const cityIdFromRoute = Number(routeParams.get('id'));
    if (isNaN(cityIdFromRoute))
      console.log("id FromRoutee NaN");
    else
      console.log("id FromRoute: " + cityIdFromRoute);
    this.city = cities.find(c => c.ID == cityIdFromRoute);
    this.province = provinces.find(p => p.ID == this.city?.IdProvincia);
    this.region = regions.find(p => p.ID == this.province?.IdRegione);
  }

}
