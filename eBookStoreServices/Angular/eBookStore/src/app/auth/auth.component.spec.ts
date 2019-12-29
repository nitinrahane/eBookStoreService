import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthComponent } from './auth.component';
import { LoadingSpinnerComponent } from '../Shared/loading-spinner/loading-spinner.component';
import { DebugElement } from '@angular/core';
import { User } from './user.model';
import { BehaviorSubject } from 'rxjs';
import { AppModule } from '../app.module';
import { AuthService } from './auth.service';
import { By } from '@angular/platform-browser';

describe('AuthComponent', () => {
  let component: AuthComponent;
  let fixture: ComponentFixture<AuthComponent>;
  let el: DebugElement;
  let authService: any;


  beforeEach(async(() => {
    let authServiceSpy = jasmine.createSpyObj('AuthService', ['login', 'signup']);
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        { provide: AuthService, useValue: authServiceSpy }
      ]
    }).compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(AuthComponent);
        component = fixture.componentInstance;
        el = fixture.debugElement;
        authService = TestBed.get(AuthService);
        fixture.detectChanges();
      });
  }));

  it('should create component', () => {
    expect(component).toBeTruthy();
  });

  it('should show the login and Switch to Sign Up button if isLoginMode = true', () => {
    component.isLoginMode = true;
    fixture.detectChanges();
    let buttons = el.queryAll(By.css('button'));
    expect(buttons).toBeTruthy();
    expect(buttons.length).toBe(2, 'Buttons length miss-match.');
    expect(buttons[0].nativeElement.textContent).toContain('Login');
    expect(buttons[1].nativeElement.textContent).toContain('Switch to Sign Up');
  });

  it('should show the Sign Up and Switch to Login button if isLoginMode = false', () => {
    component.isLoginMode = false;
    fixture.detectChanges();
    let buttons = el.queryAll(By.css('button'));
    expect(buttons).toBeTruthy();
    expect(buttons.length).toBe(2, 'Buttons length miss-match.');
    expect(buttons[0].nativeElement.textContent).toContain('Sign Up');
    expect(buttons[1].nativeElement.textContent).toContain('Switch to Login');
  })


});
