import { Component, OnInit } from '@angular/core';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  private cartItemDetails: any[];
  constructor(private ebookstoreserviceService: EbookstoreserviceService) { }

  ngOnInit() {
    this.ebookstoreserviceService.get_CartDetails().subscribe(
      (data: any[]) => {
        console.log(data);
        this.cartItemDetails = data;
      }
    );
  }

  calPrice(qnt, price) {
    return qnt * price;
  }

  // shouldShowButton(){
  //   return this.cartItemDetails && this.cartItemDetails.length > 0;
  // }
  grandTotal() {
    let garndTotal: number = 0;
    if (this.cartItemDetails != null && this.cartItemDetails != undefined) {
      this.cartItemDetails.forEach(element => {
        garndTotal = garndTotal + (element.Quantity * element.Price)
      });
    }
    return garndTotal;
  }

  removeFromCart(book) {
    var cartItem: any = {
      BookID: book.ID,
      UserID: 1
    };

    this.ebookstoreserviceService.removeFromCart(cartItem).subscribe((data) => {
      this.cartItemDetails = this.cartItemDetails.filter(obj => obj !== book);
      alert('Book removed from the cart.');
    });
  }

  placeOrder() {
    this.ebookstoreserviceService.placeOrder(1, this.cartItemDetails).subscribe((data) => {
      alert('Order Placed');
      this.cartItemDetails = [];
    });
  }
}
