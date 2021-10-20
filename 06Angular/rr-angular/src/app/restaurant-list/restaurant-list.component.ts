import { Component, OnInit } from '@angular/core';
import { RRApiService } from '../service/rrapi.service';

@Component({
  selector: 'restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {

  constructor(private rrService: RRApiService) { }

  //lifecycle hooks, there're others like onDestory to dispose resources when this components gets destroyed
  ngOnInit(): void {
    this.rrService.getAllRestaurants().then(result => {
      console.log(result);
    })
  }

}
