import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: FormGroup;
  errorMessage: string = '';

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      // Use this.loginForm instead of loginForm
      this.http.post(`${environment.apiUrl}/Auth/login`, this.loginForm.value)
      .subscribe({
        next: (response: any) => {
          if (response.token) {
            localStorage.setItem('token', response.token);
            this.router.navigate(['./home']);
          } else {
            this.errorMessage = 'Invalid login response.';
          }
        },
        error: (error) => {
          if (error.status === 401) {
            this.errorMessage = 'Invalid username or password.';
          } else {
            this.errorMessage = 'Login failed. Please try again.';
            console.error('Login failed:', error);
          }
        }
      });
    }
  }
}
