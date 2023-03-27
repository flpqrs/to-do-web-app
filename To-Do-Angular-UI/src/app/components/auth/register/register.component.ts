import { Component } from '@angular/core';
import { Register } from 'src/app/models/register.model';
import { AuthService } from 'src/app/services/auth.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  register: Register = {username: '', email: '', password: ''};
  message: string | undefined;

  constructor(private authService: AuthService,  private router: Router) {}
ngOnInit(): void{

} 
  registerUser(): void {
    this.authService.register(this.register.username, this.register.email, this.register.password).subscribe({
      next: (register) => {
        this.router.navigate(['/login']);
      },
      error: (err) => {
        if (err.status === 500) {
          this.message = 'User with this Login or Email already exists.';
        
  }}});
  }
}
