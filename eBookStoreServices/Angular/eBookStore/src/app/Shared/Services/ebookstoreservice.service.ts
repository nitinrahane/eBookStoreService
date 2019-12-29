import { Injectable } from '@angular/core';
import { CartItem } from '../Models/Cart';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from 'src/app/message.service';
import { AuthService } from 'src/app/auth/auth.service';
@Injectable({
  providedIn: 'root'
})
export class EbookstoreserviceService {

  baseUrl: string = "https://localhost:44371/api/";

  constructor(private httpClient: HttpClient) { }

  get_bookDetails() {
    return this.httpClient.get(this.baseUrl + 'books').pipe(
      catchError(this.handleError<any[]>('getBooks', [])));
  }

  addBook(bookDetails) {
    return this.httpClient.post(this.baseUrl + 'books', bookDetails).pipe(
      catchError(this.handleError<any[]>('add book', [])));
  }

  get_CartDetails() {
    return this.httpClient.get(this.baseUrl + 'cart').pipe(
      catchError(this.handleError<any[]>('get cart details', [])));
  }

  addTocart(cartItem) {
    return this.httpClient.post(this.baseUrl + 'cart', cartItem).pipe(
      catchError(this.handleError<any[]>('add book to cart', [])));
  }

  removeFromCart(cartDetails) {
    let deleteUrl: string = this.baseUrl + 'cart/' + cartDetails.BookID;
    return this.httpClient.delete(deleteUrl).pipe(
      catchError(this.handleError<any[]>('Remove book from cart', [])));
  }

  placeOrder(cartItems) {
    let placeOrderUrl: string = this.baseUrl + 'order';
    return this.httpClient.post(placeOrderUrl, cartItems).pipe(
      catchError(this.handleError<any[]>('place order', [])));
  }

  get_OrderHistory() {
    return this.httpClient.get(this.baseUrl + 'order').pipe(
      catchError(this.handleError<any[]>('Get Order history', [])));
  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); 
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
