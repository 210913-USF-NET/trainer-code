import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AuthModule, AuthService, AuthGuard, Auth0ClientService, Auth0ClientFactory, AuthClientConfig } from '@auth0/auth0-angular';
import { AuthComponent } from './auth.component';
import { environment } from 'src/environments/environment'

describe('AuthComponent', () => {
  let component: AuthComponent;
  let fixture: ComponentFixture<AuthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AuthComponent ],
      imports: [AuthModule.forRoot({
        domain: '123',
        clientId: '123'
      })
      ],
      providers: [
        // AuthService,
        // AuthGuard,
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
    fixture = TestBed.createComponent(AuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
