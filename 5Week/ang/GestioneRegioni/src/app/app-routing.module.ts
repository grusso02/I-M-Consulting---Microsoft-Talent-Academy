import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemPickerComponent } from './item-picker/item-picker.component';
import { TableDetailsComponent } from './table-details/table-details.component';

const routes: Routes = [
  { path: '', component: ItemPickerComponent },
  { path: 'table/:id', component: TableDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
