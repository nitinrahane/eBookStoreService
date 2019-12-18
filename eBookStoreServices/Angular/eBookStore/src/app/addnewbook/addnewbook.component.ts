import { Component, OnInit } from '@angular/core';
import { Book } from '../Shared/Models/Book';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { BookstoreComponent } from '../bookstore/bookstore.component';

@Component({
  selector: 'app-addnewbook',
  templateUrl: './addnewbook.component.html',
  styleUrls: ['./addnewbook.component.css']
})
export class AddnewbookComponent implements OnInit {

  bookDeatils:any = {};

  constructor(private ebookstoreserviceService: EbookstoreserviceService) { }

  ngOnInit() {
  }

  addBook(){
    this.ebookstoreserviceService.addBook(this.bookDeatils).subscribe((data) => {
      alert('Book added.');
      this.bookDeatils = {};
    });
  }

}
