import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent {
  authService: any;
  userProfileService: any;
  currentUserProfile?: User;

  ngOnInit(): void {
    var userId = this.authService.getUserIdFromToken();
    this.userProfileService.getCurrentUserProfile(userId).subscribe({
      next: (userProfile: User) => {
        this.currentUserProfile = userProfile;
      }
    })}


    updateUserProfile(): void {
      this.userProfileService.updateUserProfile(this.currentUserProfile).subscribe({
        next: (currentUserProfile: User) => {
          this.currentUserProfile = currentUserProfile;

        error: (err: any) => {
          'User profile creation failed.';
        }
    }
  })}}