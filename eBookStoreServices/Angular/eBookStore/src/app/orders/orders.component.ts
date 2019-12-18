import { Component, OnInit } from '@angular/core';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orderHistory:any[];
  constructor(private ebookstoreserviceService: EbookstoreserviceService) { }

  ngOnInit() {
    this.ebookstoreserviceService.get_OrderHistory(1).subscribe(
      (data: any[]) => {
        console.log(data);
        this.orderHistory = data;
      }
    );
  }


}
