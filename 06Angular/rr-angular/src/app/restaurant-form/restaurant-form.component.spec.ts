import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { RRApiService } from '../service/rrapi.service';
// import { ActivatedRouteStub } from '../testing/activatedRouteStub';
import { RestaurantFormComponent } from './restaurant-form.component';
import { ActivatedRouteStub } from '../testing/activatedRouteStub';
import { Injectable } from '@angular/core';
import { By } from '@angular/platform-browser';

describe('RestaurantFormComponent', () => {
  let component: RestaurantFormComponent;
  let fixture: ComponentFixture<RestaurantFormComponent>;
  let service: RRApiService;
  let activatedRoute: ActivatedRouteStub = new ActivatedRouteStub();
  let router: Router;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RestaurantFormComponent ],
      imports: [ FormsModule, RouterTestingModule, HttpClientTestingModule ],
      providers: [
        {
          //faking with a stub
          provide: ActivatedRoute,
          useValue: activatedRoute
        }
      ]
    })
    .compileComponents();

    //injecting deps as is
    service = TestBed.inject(RRApiService);
    router = TestBed.inject(Router);

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RestaurantFormComponent);
    component = fixture.componentInstance;

    activatedRoute.setParams({mode: 'create', id: 'new'})
    fixture.detectChanges();
  });

  it('should create', async () => {
    await fixture.whenRenderingDone()
    expect(component).toBeTruthy();
  });

  it('should have mode of create', () => {
    expect(component.mode).toEqual('create');
  })

  it('should call onSubmit when the form is submitted', () => {
    //spy on the component's onSubmit method, and ... do nothing
    spyOn(component, 'onSubmit').and.returnValue();

    //grab our form element from the fixture
    let form = fixture.debugElement.query(By.css('form'));

    //once we have the form element, trigger ngSubmit event
    form.triggerEventHandler('ngSubmit', null)

    expect(component.onSubmit).toHaveBeenCalled();
  })
});
