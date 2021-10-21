import { Component, OnInit } from '@angular/core';
import { restaurant } from '../models/restaurant';
import { RRApiService } from '../service/rrapi.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnInit {

  constructor(private currRoute: ActivatedRoute, private rrService: RRApiService, private router: Router, private auth: AuthService) { }

  restaurants: restaurant[] = [];
  isLoggedIn: boolean = false;
  //lifecycle hooks, there're others like onDestory to dispose resources when this components gets destroyed
  ngOnInit(): void {
    this.rrService.getAllRestaurants().then(result => {
      this.restaurants = result;
    });
    this.auth.isAuthenticated$.subscribe((isAuthenticated) =>{
      this.isLoggedIn = isAuthenticated;
    })
  }

  goToRestaurant(restaurantId: number): void
  {
    //navigate by absolute path
    this.router.navigateByUrl(`restaurants/${restaurantId}`);
  }

  createRestaurant(): void
  {
    //navigate with relative path
    this.router.navigate(['create', 'new'], {relativeTo: this.currRoute})
  }

  editRestaurant(event: Event, restaurant: restaurant): void
  {
    //stop the event from bubbling up to tr and triggering its event
    event.stopPropagation();

    this.router.navigate(['restaurants', 'edit', restaurant.id])
  }

  deleteRestaurant(event: Event, restaurant: restaurant): void
  {
    event.stopPropagation();
    //string interpolation in js
    let response = confirm(`do you really want to delete ${restaurant.name}?`).valueOf()

    if(response)
    {
      this.rrService.deleteRestaurant(restaurant.id).then((res) => {
        //success
        alert(`${restaurant.name} has been deleted successfully`)
        this.rrService.getAllRestaurants().then((allResto) => {
          this.restaurants = allResto;
        });
      }, (res) => alert('something went wrong'));
    }
  }

}
