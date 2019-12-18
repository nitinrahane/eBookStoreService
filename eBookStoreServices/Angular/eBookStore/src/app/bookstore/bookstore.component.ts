import { Component, OnInit } from '@angular/core';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { CartItem } from '../Shared/Models/Cart';

@Component({
  selector: 'app-bookstore',
  templateUrl: './bookstore.component.html',
  styleUrls: ['./bookstore.component.css']
})
export class BookstoreComponent implements OnInit {

  private bookDetails:any[];

  constructor(private ebookstoreserviceService: EbookstoreserviceService) { }

  ngOnInit() {
    this.ebookstoreserviceService.get_bookDetails().subscribe(
      (data:any[])=>{
       // console.log(data);
        this.bookDetails = data;
      }
    );
  }

  editBookInfo(book:any){

  }

  addToCart(book:any){
    var cartItem :any = {
      BookID :book.ID,
      UserID : 1
    };

    this.ebookstoreserviceService.addTocart(cartItem).subscribe((data)=>{
      alert('Book added to the cart.')
    });
  }

  deleteBookInfo(book:any){

  }

  placeOrder(){

  }
}

