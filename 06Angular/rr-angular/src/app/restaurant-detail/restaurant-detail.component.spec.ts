import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, Params, RouterModule } from '@angular/router';
import { RRApiService } from '../service/rrapi.service';
import { RestaurantDetailComponent } from './restaurant-detail.component';
import { ActivatedRouteStub } from '../testing/activatedRouteStub';

describe('RestaurantDetailComponent', () => {
  let component: RestaurantDetailComponent;
  let fixture: ComponentFixture<RestaurantDetailComponent>;
  let service: RRApiService;
  let activatedRoute: ActivatedRouteStub = new ActivatedRouteStub();

  beforeEach(async () => {
    //configuring our testbed so we can have all our dependencies needed for this component
    await TestBed.configureTestingModule({
      declarations: [ RestaurantDetailComponent ],
      imports: [ RouterModule, HttpClientTestingModule ],
      providers: [
        {
          //for this, we're using stubbed out activated route
          provide: ActivatedRoute,
          useValue: activatedRoute
        }
      ]
    })
    .compileComponents();
    //we're injecting the real service here with http testing mock
    service = TestBed.inject(RRApiService);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantDetailComponent);
    component = fixture.componentInstance;
    //manually setting the route param to 5 with our stubbed out activatedRoute
    activatedRoute.setParams({id: 5});
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have id of 5', () => {
    expect(component.id).toEqual(5);
  })

  it('should be getting a restaurant', async() => {
    let fakeResto = {
      id: 5,
      name: 'Salt and Straw',
      city: 'Portland',
      state: 'OR',
      reviews: [] 
    }
    //spying on service's getRestaurantById method and returning a promise with fake value
    spyOn(service, 'getRestaurantById').and.returnValue(Promise.resolve(fakeResto));

    //now, call the ngOnInit, and make sure that the service method has been called and it has assigned the received value to this.restaurant
    await component.ngOnInit();

    expect(service.getRestaurantById).toHaveBeenCalledWith(5);
    expect(component.restaurant).toEqual(fakeResto);
  })
});
