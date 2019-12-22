import { Injectable } from '@angular/core';
import {
    HttpInterceptor,
    HttpRequest,
    HttpHandler,
    HttpParams,
    HttpHeaders
} from '@angular/common/http';
import { take, exhaustMap } from 'rxjs/operators';
import { AuthService } from './auth.service';

//Interceptor is required for manipulate the request or responce.
@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
    constructor(private authService: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        return this.authService.user.pipe(
            take(1),
            exhaustMap(user => {
                //If user data not present then do not add the authorization header.
                if (!user) {
                    return next.handle(req);
                }
                //Original request can not be modified. That's why making a clone.
                const modifiedReq = req.clone({
                    //Add authorization header with bearer + token so that back end can verify and allow access.
                    headers: new HttpHeaders({ 'Authorization': user.tokenType + ' ' + user.token })
                });

                return next.handle(modifiedReq);
            })
        );
    }
}
