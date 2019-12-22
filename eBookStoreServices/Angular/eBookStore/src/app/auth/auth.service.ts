import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { catchError, tap } from 'rxjs/operators';
import { throwError, BehaviorSubject } from 'rxjs';

import { User } from './user.model';


export interface ResiterResponseData {
  Message: string;
  ModelState: any;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  user = new BehaviorSubject<User>(null);
  private tokenExpirationTimer: any;

  constructor(private http: HttpClient, private router: Router) { }

  //signup user with valid email id and password.
  signup(email: string, password: string) {
    return this.http
      .post<any>('https://localhost:44371/api/account/register', { email: email, password: password, ConfirmPassword: password })
      .pipe(
        //Handle error.
        catchError(this.handleError),
        tap(resData => {         
          alert('Account Created.');
        })
      );
  }

  login(email: string, password: string) {
    var headers = new HttpHeaders();
    headers.append('Content-Type', 'application/x-www-form-urlencoded');
    let urlSearchParams = new URLSearchParams();
    urlSearchParams.set('grant_type', 'password');
    urlSearchParams.set('username', email);
    urlSearchParams.set('password', password);
    let body = urlSearchParams.toString();
    return this.http
      .post<any>('https://localhost:44371/token', body, { headers: headers })
      .pipe(catchError(this.handleError),
        tap(resData => {
          //Handle login response and store the details to the local storage.
          this.handleAuthentication(resData.userName, resData.token_type, resData.access_token, +resData.expires_in);
        })
      );
  }


  autoLogin() {
    const userData: {
      email: string;
      tokenType: string;
      _token: string;
      _tokenExpirationDate: string;
    } = JSON.parse(localStorage.getItem('userData'));

    if (!userData) {
      return;
    }

    const loadedUser = new User(
      userData.email,
      userData.tokenType,
      userData._token,
      new Date(userData._tokenExpirationDate)
    );

    if (loadedUser.token) {
      this.user.next(loadedUser);
      const expirationDuration = new Date(userData._tokenExpirationDate).getTime() - new Date().getTime();
      this.autoLogout(expirationDuration);
    }
  }

  logout() {
    this.user.next(null);
    this.router.navigate(['/auth']);
    localStorage.removeItem('userData');
    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
  }

  autoLogout(expirationDuration: number) {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }

  private handleAuthentication(
    email: string,
    tokenType: string,
    token: string,
    expiresIn: number
  ) {
    const expirationDate = new Date(new Date().getTime() + expiresIn * 1000);
    const user = new User(email, tokenType, token, expirationDate);
    this.user.next(user);
    this.autoLogout(expiresIn * 1000);
    localStorage.setItem('userData', JSON.stringify(user));
  }

  private handleError(errorRes: HttpErrorResponse) {
    let errorMessage = 'An unknown error occurred!';
    console.log(errorRes);
    if (errorRes.error && errorRes.error.error_description) {
      errorMessage = errorRes.error.error_description;
    } else {
      if (errorRes.error && errorRes.error.ModelState) {
        errorMessage = errorRes.error.ModelState[""][0];
      }
    }
    return throwError(errorMessage);
  }
}
