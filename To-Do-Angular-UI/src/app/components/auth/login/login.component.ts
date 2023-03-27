import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Login } from 'src/app/models/login.model';
import { Router} from '@angular/router';
import { UserProfileService } from 'src/app/services/users.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  login: Login = { username: '', password: '' };
  message: string | undefined;

  constructor(private authService: AuthService, private router: Router, private userProfileService: UserProfileService) { };
  checkUser(userId: string) {
    this.userProfileService.getCurrentUserProfile(userId).subscribe({
      next: (userProfile) => {
        if (!userProfile) {
          this.router.navigate(['/create-profile']);
        } else {
          this.router.navigate(['/missions']);
        }
      },
      error: (err: any) => {
        console.error('Error retrieving user profile:', err);
      }
    });
  }

  loginUser() {
    this.authService.login(this.login.username, this.login.password).subscribe({
      next: () => {
        var userId = this.authService.getUserIdFromToken();
        this.checkUser(userId);
      },
      error: (err) => {
        if (err.status === 401) {
          this.message = 'Invalid Username or Password.';
        }}
    });
  }
}