import { TestBed } from '@angular/core/testing';

import { EbookstoreserviceService } from './ebookstoreservice.service';

describe('EbookstoreserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EbookstoreserviceService = TestBed.get(EbookstoreserviceService);
    expect(service).toBeTruthy();
  });
});
