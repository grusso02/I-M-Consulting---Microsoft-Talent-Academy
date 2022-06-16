import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ItemPickerComponent } from './item-picker/item-picker.component';
import { TableDetailsComponent } from './table-details/table-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ItemPickerComponent,
    TableDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
