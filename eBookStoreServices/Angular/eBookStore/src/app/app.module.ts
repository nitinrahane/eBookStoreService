import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookstoreComponent } from './bookstore/bookstore.component';
import { CartComponent } from './cart/cart.component';
import { OrdersComponent } from './orders/orders.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AddnewbookComponent } from './addnewbook/addnewbook.component';
import { FormsModule } from '@angular/forms';
import { AuthComponent } from './auth/auth.component';
import { LoadingSpinnerComponent } from './Shared/loading-spinner/loading-spinner.component';
import { AuthInterceptorService } from './auth/auth-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    BookstoreComponent,
    CartComponent,
    OrdersComponent,
    HeaderComponent,
    FooterComponent,
    AddnewbookComponent,
    AuthComponent,
    LoadingSpinnerComponent    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
