import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewbookComponent } from './addnewbook.component';
import { DebugElement } from '@angular/core';
import { AppModule } from '../app.module';
import { EbookstoreserviceService } from '../Shared/Services/ebookstoreservice.service';
import { By } from '@angular/platform-browser';

describe('AddnewbookComponent', () => {
  let component: AddnewbookComponent;
  let fixture: ComponentFixture<AddnewbookComponent>;
  let el: DebugElement;
  let bookService: any;

  beforeEach(async(() => {
    let bookServiceSpy = jasmine.createSpyObj('EbookstoreserviceService', ['addBook']);
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        { provide: EbookstoreserviceService, useValue: bookServiceSpy }
      ]
    }).compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(AddnewbookComponent);
        component = fixture.componentInstance;
        el = fixture.debugElement;
        bookService = TestBed.get(EbookstoreserviceService);   
        fixture.detectChanges();
      });
  }));

  it('should create component', () => {
    expect(component).toBeTruthy();
  });

  it('Should have h2 element with title Add book', () => {
    let h2Element = el.query(By.css('h2'));
    expect(h2Element.nativeElement).toBeTruthy();
    expect(h2Element.nativeElement.textContent).toContain('Add book');
  });

});
