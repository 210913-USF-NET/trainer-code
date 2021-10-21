import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantDetailComponent } from './restaurant-detail/restaurant-detail.component';
import { RestaurantFormComponent } from './restaurant-form/restaurant-form.component';
import { RestaurantListComponent } from './restaurant-list/restaurant-list.component';

const routes: Routes = [
  {
    path: 'restaurants/:mode/:id',
    component: RestaurantFormComponent
  },
  {
    path: 'restaurants/:id',
    component: RestaurantDetailComponent
  },
  {
    path: 'restaurants',
    component: RestaurantListComponent
  },
  {
    path: '',
    redirectTo: 'restaurants',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
