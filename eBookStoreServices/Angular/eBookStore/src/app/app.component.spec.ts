import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { AuthService } from './auth/auth.service';
import { DebugElement } from '@angular/core';
import { AppModule } from './app.module';
import { User } from './auth/user.model';
import { BehaviorSubject } from 'rxjs';

describe('AppComponent', () => {
 
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let el: DebugElement;
  let authService: any;
   let userInfo:User = new User('', '', '', new Date());
   const userMock = new BehaviorSubject<User>(userInfo);


  beforeEach(async(() => {
    let authServiceSpy = jasmine.createSpyObj('AuthService', ['autoLogin']);
    TestBed.configureTestingModule({
      imports: [
        AppModule
      ],
      providers: [
        { provide: AuthService, useValue: authServiceSpy }
      ]
    }).compileComponents()
      .then(() => {
        fixture = TestBed.createComponent(AppComponent);
        component = fixture.componentInstance;
        el = fixture.debugElement;
        authService = TestBed.get(AuthService);
        authService.user = userMock.asObservable();
        fixture.detectChanges();
      });
  }));

  it('should create the app', () => {       
    expect(component).toBeTruthy();
  });
});
