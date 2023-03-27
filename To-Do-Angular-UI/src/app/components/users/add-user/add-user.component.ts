import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserProfileService } from 'src/app/services/users.service';
import { Router} from '@angular/router';

@Component({
  selector: 'app-user-profile',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class UserProfileComponent {
  userProfile: User = { id: '00000000-0000-0000-0000-000000000000', userId: '', name: '', levelId: 1, experiencePoints: 0 };
  message: string | undefined;

  constructor(private usersService: UserProfileService, private router: Router) { }

  createUserProfile(): void {
    this.usersService.createUserProfile(this.userProfile).subscribe({
      next: (userProfile) => {
        this.userProfile = userProfile;
        this.message = 'User profile created successfully!';
        this.router.navigate(['/missions']);;
      },
      error: (err: any) => {
        this.message = 'User profile creation failed.';
      }
    });
  }
}