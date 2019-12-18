import { Injectable } from '@angular/core';
import { CartItem } from '../Models/Cart';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from 'src/app/message.service';
@Injectable({
  providedIn: 'root'
})
export class EbookstoreserviceService {

  baseUrl: string = "https://localhost:44371/api/";

  constructor(private httpClient: HttpClient,
    private messageService: MessageService) { }

  get_bookDetails() {
    return this.httpClient.get(this.baseUrl + 'books').pipe(
      catchError(this.handleError<any[]>('getBooks', []))
    );;
  }

  addBook(bookDetails) {
    return this.httpClient.post(this.baseUrl + 'books', bookDetails);
  }

  get_CartDetails() {
    return this.httpClient.get(this.baseUrl + 'cart/1');
  }

  addTocart(cartDetails) {
    return this.httpClient.post(this.baseUrl + 'cart', cartDetails);
  }

  removeFromCart(cartDetails) {
    let deleteUrl: string = this.baseUrl + 'cart/user/' + cartDetails.UserID + '/book/' + cartDetails.BookID;
    return this.httpClient.delete(deleteUrl);
  }

  placeOrder(userId, cartItems) {
    let deleteUrl: string = this.baseUrl + 'order/user/' + userId;
    return this.httpClient.post(deleteUrl, cartItems);
  }

  get_OrderHistory(userID) {
    return this.httpClient.get(this.baseUrl + 'order/' + + userID);
  }

  private log(message: string) {
    this.messageService.add(`ApiService: ${message}`);
  }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

}
