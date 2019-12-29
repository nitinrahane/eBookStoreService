import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { BookstoreComponent } from './bookstore.component';
import { HttpClient, HttpHandler, HttpClientModule, HttpResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { DebugElement } from '@angular/core';
import { AppModule } from '../app.module';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { bookData } from '../TestHelpers/TestData';
import { By } from '@angular/platform-browser';

describe('BookstoreComponent', () => {
  let component: BookstoreComponent;
  let fixture: ComponentFixture<BookstoreComponent>;
  let el: DebugElement;
  let bookService: any;

  beforeEach(async(() => {
    let bookServiceSpy = jasmine.createSpyObj('EbookstoreserviceService', ['get_bookDetails', 'addTocart']);
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        { provide: EbookstoreserviceService, useValue: bookServiceSpy }
      ]
    }).compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(BookstoreComponent);
        component = fixture.componentInstance;
        el = fixture.debugElement;
        bookService = TestBed.get(EbookstoreserviceService);
        bookService.get_bookDetails.and.returnValue(of(bookData));
        component.ngOnInit();
        fixture.detectChanges();
      });
  }));

  it('Should Create component', () => {
    expect(component).toBeTruthy();
  });

  it('Should have h2 element with title Book details', () => {
    let h2Element = el.query(By.css('h2'));
    expect(h2Element.nativeElement).toBeTruthy();
    expect(h2Element.nativeElement.textContent).toContain('Books Details');
  });

  it('Should call addTocart() if book added to cart using click event of Add to cart button', () => {
    bookService.addTocart.and.returnValue(of(new HttpResponse({status:200})));
    let buttonElements = el.queryAll(By.css('button'));
    expect(buttonElements).toBeTruthy();
    expect(buttonElements.length).toBeGreaterThan(0, 'buttons not found');
    expect(buttonElements[0].nativeElement.textContent).toContain('Add To Cart');
    buttonElements[0].nativeElement.click();
    fixture.detectChanges();
    expect(bookService.addTocart).toHaveBeenCalled();   
  });

});
