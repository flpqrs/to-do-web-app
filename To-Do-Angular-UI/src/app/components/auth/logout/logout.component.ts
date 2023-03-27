import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router} from '@angular/router';
@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {
constructor(private authService: AuthService, private router: Router) { };

  logoutUser(): void {
    this.authService.logout()
    this.router.navigate(['/']);
    };

  dontLogout(): void{
    this.router.navigate(['missions']);
  }
  }
