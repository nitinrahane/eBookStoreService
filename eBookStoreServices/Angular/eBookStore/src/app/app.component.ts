import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { EbookstoreserviceService } from './Shared/Services/ebookstoreservice.service';
import { AuthService } from './auth/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'eBookStore';
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.autoLogin();
  }
}



