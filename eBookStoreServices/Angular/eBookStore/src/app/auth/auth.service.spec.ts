import { TestBed } from '@angular/core/testing';

import { AuthService } from './auth.service';
import { HttpClientModule, HttpClient, HttpHandler } from '@angular/common/http';
import { Router } from '@angular/router';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { AppModule } from '../app.module';

describe('AuthService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports:[HttpClientTestingModule, AppModule],
    providers:[AuthService]
  }));

  it('should be created', () => {
    const service: AuthService = TestBed.get(AuthService);
    expect(service).toBeTruthy();
  });
});
