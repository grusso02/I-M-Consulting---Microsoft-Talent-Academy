import { Component, OnInit } from '@angular/core';
import { ViewData } from 'src/models/viewData';

@Component({
  selector: 'app-view-data',
  templateUrl: './view-data.component.html',
  styleUrls: ['./view-data.component.css']
})
export class ViewDataComponent implements OnInit {
  
  itemView: ViewData | undefined;

  constructor() { }

  ngOnInit(): void {
  }

}
