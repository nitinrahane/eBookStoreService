import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BookstoreComponent } from './bookstore/bookstore.component';
import { CartComponent } from './cart/cart.component';
import { OrdersComponent } from './orders/orders.component';
import { AddnewbookComponent } from './addnewbook/addnewbook.component';
import { AuthComponent } from './auth/auth.component';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "home" },
  { path: "home", component: BookstoreComponent, canActivate: [AuthGuard] },
  { path: "cart", component: CartComponent, canActivate: [AuthGuard] },
  { path: "orders", component: OrdersComponent, canActivate: [AuthGuard] },
  { path: "addbook", component: AddnewbookComponent, canActivate: [AuthGuard] },
  { path: 'auth', component: AuthComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
