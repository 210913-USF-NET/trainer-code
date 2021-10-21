import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { restaurant } from '../models/restaurant';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class RRApiService {

  private rootUrl: string = environment.rrAPIUrl;

  //this is how dep injection work in angular
  constructor(private http: HttpClient) { }

  getAllRestaurants(): Promise<restaurant[]>
  {
    //by default, httpClient returns observables
    //they are similar to promises, but instead of promise resolving once it receives the data, observables keeps the line open
    return this.http.get<restaurant[]>(this.rootUrl).toPromise();
  }

  getRestaurantById(id: number): Promise<restaurant>
  {
    return this.http.get<restaurant>(this.rootUrl + "/" + id).toPromise();
  }

  deleteRestaurant(id: number): Promise<void>
  {
    return this.http.delete<void>(this.rootUrl + '/' + id).toPromise();
  }

  addRestaurant(restaurant: restaurant): Promise<restaurant>
  {
    return this.http.post<restaurant>(this.rootUrl, restaurant).toPromise();
  }

  editRestaurant(restaurant: restaurant): Promise<restaurant>
  {
    return this.http.put<restaurant>(this.rootUrl + '/' + restaurant.id, restaurant).toPromise();
  }
}