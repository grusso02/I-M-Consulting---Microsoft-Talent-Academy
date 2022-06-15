import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product, products } from '../../models/products';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {

  product: Product | undefined;
  dateofproductiondisplay: string | null = '';
  constructor(private route: ActivatedRoute, private datePipe: DatePipe) { }

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = Number(routeParams.get('id'));
    if (isNaN(productIdFromRoute))
      console.log("id FromRoutee NaN");
    else
      console.log("id FromRoute: " + productIdFromRoute);
    this.product = products.find(product => product.id === productIdFromRoute);
    this.dateofproductiondisplay = this.datePipe.transform(this.product?.dateofproduction, 'dd-MM-yyyy');
  }

}
