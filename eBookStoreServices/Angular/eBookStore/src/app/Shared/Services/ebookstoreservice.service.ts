import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CartItem } from '../Models/Cart';
@Injectable({
  providedIn: 'root'
})
export class EbookstoreserviceService {

  baseUrl: string = "https://localhost:44371/api/";

  constructor(private httpClient: HttpClient) { }

  get_bookDetails() {
    return this.httpClient.get(this.baseUrl + 'books');
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
}
