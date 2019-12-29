import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';

import { CartComponent } from './cart.component';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';
import { BrowserModule, By } from '@angular/platform-browser';
import { AppModule } from '../app.module';
import { DebugElement } from '@angular/core';
import { cartData } from '../TestHelpers/TestData';

describe('CartComponent', () => {
  let component: CartComponent;
  let fixture: ComponentFixture<CartComponent>;
  let el: DebugElement;
  let bookService: any;

  beforeEach(async(() => {
    let bookServiceSpy = jasmine.createSpyObj('EbookstoreserviceService', ['get_CartDetails', 'removeFromCart','placeOrder']);
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
      fixture = TestBed.createComponent(CartComponent);
      component = fixture.componentInstance;
      el = fixture.debugElement;
      bookService = TestBed.get(EbookstoreserviceService);
      bookService.get_CartDetails.and.returnValue(of(cartData));
      component.ngOnInit();
      fixture.detectChanges();
    });
  }));

  it('Should create component', () => {
    expect(component).toBeTruthy();
  });

  it('Should have h2 element with title Cart Details', () => {
    let h2Element = el.query(By.css('h2'));
    expect(h2Element.nativeElement).toBeTruthy();
    expect(h2Element.nativeElement.textContent).toContain('Cart Details');
  });
});
