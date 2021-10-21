import { DOCUMENT } from '@angular/common';
import { Component, OnInit, Inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { User } from '@auth0/auth0-spa-js';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  constructor(public auth: AuthService, @Inject(DOCUMENT) public document: Document) { }

  rootUrl: string = 'http://localhost:4200';

  ngOnInit(): void {
    this.auth.isAuthenticated$.subscribe((isLoggedIn) => {
      console.log('is auth?', isLoggedIn);
    })
  }

}
