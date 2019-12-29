import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing"
import { EbookstoreserviceService } from './ebookstoreservice.service';
import { bookData } from 'src/app/TestHelpers/TestData';

describe('EbookstoreserviceService', () => {

  let bookService: EbookstoreserviceService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {

    TestBed.configureTestingModule({
      providers: [
        EbookstoreserviceService
      ],
      imports: [
        HttpClientTestingModule
      ]
    });
    bookService = TestBed.get(EbookstoreserviceService);
    httpTestingController = TestBed.get(HttpTestingController);

  });

  it('Service should be created', () => {
    expect(bookService).toBeTruthy();
  });

  it('Should return all books', () => {
    bookService.get_bookDetails().subscribe( (books) => {    
      expect(books).toBeTruthy('No books present');  
     // expect(books[0].Title).toBe('Test 1', "Title miss-match");   
    });
    const req = httpTestingController.expectOne('https://localhost:44371/api/books');
    expect(req.request.method).toEqual("GET");
    req.flush({ payload: bookData});
  });

});
