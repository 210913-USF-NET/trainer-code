import { Component, OnInit } from '@angular/core';
import { NgForm, NgModel } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { restaurant } from '../models/restaurant';
import { RRApiService } from '../service/rrapi.service';

@Component({
  selector: 'app-restaurant-form',
  templateUrl: './restaurant-form.component.html',
  styleUrls: ['./restaurant-form.component.css']
})
export class RestaurantFormComponent implements OnInit {

  constructor(private currentRoute: ActivatedRoute, private restoApi: RRApiService, private router: Router) { }

  mode: string = ''
  id: number = 0
  restaurant: restaurant = {
    name: '',
    state: '',
    city: '',
    id: 0,
    reviews: []
  }

  ngOnInit(): void {
    this.currentRoute.params.subscribe((param) => {
      this.mode = param.mode
      
      if(param.mode === 'edit')
      {
        this.id = param.id
        this.restoApi.getRestaurantById(this.id).then((res) => {
          this.restaurant = res;
        });
      }
    });
  }

  onSubmit(restaurantForm: NgForm) {
    console.log("form has been submitted", restaurantForm, this.restaurant);
    if(restaurantForm.form.valid)
    {
      if(this.mode === 'create')
      {
        //we are going to call add restaurant
        this.restoApi.addRestaurant(this.restaurant).then((res) => {
          alert('restaurant added successfully!')
          this.router.navigate(['restaurants'])
        });
      }
      else if(this.mode === 'edit')
      {
        //call edit restaurant
        this.restoApi.editRestaurant(this.restaurant).then((res) => {
          alert('restaurant updated successfully')
          this.router.navigateByUrl('restaurants')
        })
      }
    }
  }

}
