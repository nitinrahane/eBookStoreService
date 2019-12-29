import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HeaderComponent } from './header.component';
import { AuthService } from '../auth/auth.service';
import { DebugElement } from '@angular/core';
import { AppModule } from '../app.module';
import { of, BehaviorSubject } from 'rxjs';
import { User } from '../auth/user.model';
import { By } from '@angular/platform-browser';


describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;
  let el: DebugElement;
  let authService: any;
  let userInfo:User = new User('', '', '', new Date());
  const userMock = new BehaviorSubject<User>(userInfo);

  

  beforeEach(async(() => {
    let authServiceSpy = jasmine.createSpyObj('AuthService', ['logout', 'user']);
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        { provide: AuthService, useValue: authServiceSpy }
      ]
    }).compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(HeaderComponent);
        component = fixture.componentInstance;
        el = fixture.debugElement;
        authService = TestBed.get(AuthService);
        authService.user = userMock.asObservable();
        fixture.detectChanges();
      });
  }));

  it('should create component', () => {
    expect(component).toBeTruthy();
  });

  it('should show only Authentication nav option if user is logged out', () => {  
    component.isAuthenticated = false;
    fixture.detectChanges();   
    let navBarOption = el.query(By.css('.nav-link'));
    expect(navBarOption.nativeElement.textContent).toContain('Authenticate')
  });

  it('should show only Other nav option if user is logged in', () => {  
    component.isAuthenticated = true;
    fixture.detectChanges();   
    let navBarOptions = el.queryAll(By.css('.nav-link'));
    expect(navBarOptions.length).toBe(5, 'Nav option lenth is matching.')
  });


});
