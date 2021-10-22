import { TestBed } from '@angular/core/testing';
import { RRApiService } from './rrapi.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { restaurant } from '../models/restaurant';


describe('RRApiService', () => {
  let service: RRApiService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    //TestBed is angular's dep injection simulator
    //this is where we configure all our dependencies for this particular
    //service/component/etc.
    //HttpClientTestingModule is a mock for HttpClientModule
    //we'll use this instead of the real thing
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(RRApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getAllRestaurants should get an array of restaurants', async() => {
    //arrange, act, assert
    let fakeData: restaurant[] = [
      {
        id: 1,
        name: 'Salt and Straw',
        city: 'Portland',
        state: 'OR',
        reviews: [] 
      },
      {
        id: 2,
        name: 'Pita House',
        city: 'Battle Ground',
        state: 'WA',
        reviews: []
      }
    ];

    //we're going to use spy, to spy on the service's methods and respond with a fake data
    //This is spying on the api service's getAllRestaurants method, and returning a fake value
    spyOn(service, 'getAllRestaurants').and.returnValue(Promise.resolve(fakeData));

    //next, act on the method
    await service.getAllRestaurants().then((res) => {
      //assert here, that we're getting what we're expecting
      expect(service.getAllRestaurants).toHaveBeenCalled();
      expect(res.length).toEqual(2);
    });
  });

  //testing post call
  it('createRestaurant should create a restaurant', async () => {
    let fakeResto = {
      id: 1,
      name: 'Salt and Straw',
      city: 'Portland',
      state: 'OR',
      reviews: [] 
    }

    spyOn(service, 'addRestaurant').and.returnValue(Promise.resolve(fakeResto));

    await service.addRestaurant(fakeResto).then((res) => {
      //assert here, that we're getting what we're expecting
      expect(service.addRestaurant).toHaveBeenCalled();
      expect(res).toEqual(fakeResto);
    });
  });
});
