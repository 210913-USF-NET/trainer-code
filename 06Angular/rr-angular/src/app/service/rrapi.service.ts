import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { restaurant } from '../models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class RRApiService {

  rootUrl: string = 'https://restoreviewsapi.azurewebsites.net/api/restaurant';

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
}