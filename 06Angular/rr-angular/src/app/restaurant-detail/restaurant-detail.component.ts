import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { restaurant } from '../models/restaurant';
import { RRApiService } from '../service/rrapi.service';

@Component({
  selector: 'app-restaurant-detail',
  templateUrl: './restaurant-detail.component.html',
  styleUrls: ['./restaurant-detail.component.css']
})
export class RestaurantDetailComponent implements OnInit {

  constructor(private currentRoute: ActivatedRoute, private rrApi: RRApiService) { }

  id = 0;
  restaurant: restaurant = {
    id: 0,
    name: '',
    city: '',
    state: '',
    reviews: []
  };
  ngOnInit(): void {
    this.currentRoute.params.subscribe(params => {
      this.id = params['id'];
      this.rrApi.getRestaurantById(this.id).then(resto => {
        this.restaurant = resto;
      });
    });
  }
}
