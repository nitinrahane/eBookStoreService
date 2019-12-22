import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

import { AuthService } from './auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html'
})
export class AuthComponent {
  //isLoginMode is used for to switch between login and signup mode
  isLoginMode = true;

  //isLoading is used for to show the speener while we loading the details.
  isLoading = false;

  //To show error
  error: string = null;

  constructor(private authService: AuthService, private router: Router) { }

  //Switch between Login and signup
  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  //Submit the login/signup data
  onSubmit(form: NgForm) {
    if (!form.valid) {
      return;
    }

    const email = form.value.email;
    const password = form.value.password;

    let authObs: Observable<any>;

    this.isLoading = true;
    this.error = null;
    if (this.isLoginMode) {
      //Login user (https://localhost:44371/token)
      authObs = this.authService.login(email, password);
    } else {
      //Signup user (https://localhost:44371/api/account/register)
      authObs = this.authService.signup(email, password);
    }

    authObs.subscribe(
      resData => {
        console.log(resData);
        this.isLoading = false;
        this.router.navigate(['/home']);
      },
      errorMessage => {
        console.log(errorMessage);
        this.error = errorMessage;
        this.isLoading = false;
      }
    );

    form.reset();
  }
}
