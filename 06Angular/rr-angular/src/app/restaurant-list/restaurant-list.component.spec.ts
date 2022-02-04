import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterModule, ActivatedRoute, Router } from '@angular/router';
import { AuthModule, Auth0ClientFactory, Auth0ClientService, AuthClientConfig } from '@auth0/auth0-angular';
import { ActivatedRouteStub } from '../testing/activatedRouteStub';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { RestaurantListComponent } from './restaurant-list.component';
import { RouterTestingModule } from '@angular/router/testing';
describe('RestaurantListComponent', () => {
  let component: RestaurantListComponent;
  let fixture: ComponentFixture<RestaurantListComponent>;
  let activatedRoute: ActivatedRouteStub = new ActivatedRouteStub();

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantListComponent ],
      imports:
      [ AuthModule.forRoot({
        domain: '123',
        clientId: '123'
      }), RouterTestingModule, HttpClientTestingModule ],
      providers: [{
        //for this, we're using stubbed out activated route
        provide: ActivatedRoute,
        useValue: activatedRoute
        },
        // {
        //   provide: Auth0ClientService,
        //   useFactory: Auth0ClientFactory.createClient,
        //   deps: [AuthClientConfig],
        // },
      ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
