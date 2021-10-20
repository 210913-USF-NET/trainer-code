import { Component, OnInit } from '@angular/core';
import { restaurant } from '../models/restaurant';
import { RRApiService } from '../service/rrapi.service';
import { Router } from '@angular/router';

@Component({
  selector: 'restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {

  constructor(private rrService: RRApiService, private router: Router) { }

  restaurants: restaurant[] = [];
  //lifecycle hooks, there're others like onDestory to dispose resources when this components gets destroyed
  ngOnInit(): void {
    this.rrService.getAllRestaurants().then(result => {
      this.restaurants = result;
    });
  }

  goToRestaurant(restaurantId: number)
  {
    this.router.navigate(['restaurants/'+ restaurantId]);
  }

}
