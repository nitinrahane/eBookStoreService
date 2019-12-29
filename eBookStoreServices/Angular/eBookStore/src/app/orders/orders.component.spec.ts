import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OrdersComponent } from './orders.component';
import { HttpClientModule } from '@angular/common/http';
import { DebugElement } from '@angular/core';
import { orderDetails } from '../TestHelpers/TestData';
import { of } from 'rxjs';
import { AppModule } from '../app.module';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { By } from '@angular/platform-browser';

describe('OrdersComponent', () => {
  let component: OrdersComponent;
  let fixture: ComponentFixture<OrdersComponent>;
  let el: DebugElement;
  let bookService: any;
  
  beforeEach(async(() => {
    let bookServiceSpy = jasmine.createSpyObj('EbookstoreserviceService', ['get_OrderHistory']);
    TestBed.configureTestingModule({     
      imports: [
        AppModule
      ],
      providers: [
        { provide: EbookstoreserviceService, useValue: bookServiceSpy }
      ]
    })
    .compileComponents()
    .then(()=>{
      fixture = TestBed.createComponent(OrdersComponent);
      component = fixture.componentInstance;
      el = fixture.debugElement;
      bookService = TestBed.get(EbookstoreserviceService);
      bookService.get_OrderHistory.and.returnValue(of(orderDetails));
      component.ngOnInit();
      fixture.detectChanges();
    });
  }));

  it('should create component', () => {
    expect(component).toBeTruthy();
  });

  it('Should have h2 element with title Order Details', () => {
    let h2Element = el.query(By.css('h2'));
    expect(h2Element.nativeElement).toBeTruthy();
    expect(h2Element.nativeElement.textContent).toContain('Order Details');
  });
});
