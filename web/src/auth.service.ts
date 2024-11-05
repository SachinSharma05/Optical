// auth.service.ts
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private loggedIn = false; // or use localStorage/sessionStorage to persist login status

  constructor(private router: Router) {}

  login() {
    this.loggedIn = true;
    localStorage.setItem('loggedIn', 'true');
  }

  logout() {
    this.loggedIn = false;
    localStorage.removeItem('loggedIn');
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('loggedIn') === 'true';
  }
}
