import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemPickerComponent } from './item-picker/item-picker.component';

const routes: Routes = [
  {path: '', component: ItemPickerComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
