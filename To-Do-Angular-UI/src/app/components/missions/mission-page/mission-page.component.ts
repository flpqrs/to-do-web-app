import { Component, ViewChild } from '@angular/core';
import { UserProfileService } from 'src/app/services/users.service';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user.model';
import { Mission } from 'src/app/models/mission.model';
import { MissionService } from 'src/app/services/mission.service';


@Component({
  selector: 'app-mission-page',
  templateUrl: './mission-page.component.html',
  styleUrls: ['./mission-page.component.css']
})
export class MissionPageComponent {
  message: string | undefined;
  currentUserProfile: User = { id: '00000000-0000-0000-0000-000000000000', userId: '00000000-0000-0000-0000-000000000000', name: '', levelId: 1, experiencePoints: 0 };
  missions: Mission[] = [];
  dailyMissions: Mission[] = [];
  weeklyMissions: Mission[] = [];
  monthlyMissions: Mission[] = [];
  longTermMissions: Mission[] = [];
  newMission: Mission = { id: '00000000-0000-0000-0000-000000000000', profileId: '', title: '', categoryId: 1, isCompleted: false };
  public editingMission: Mission = { id: '00000000-0000-0000-0000-000000000000', profileId: '', title: '', categoryId: 1, isCompleted: false };;

  constructor(private authService: AuthService,
    private userProfileService: UserProfileService,
    private missionService: MissionService,
  ) { }

  public ngOnInit(): void {
    var userId = this.authService.getUserIdFromToken();
    this.userProfileService.getCurrentUserProfile(userId).subscribe({
      next: (userProfile: User) => {
        this.currentUserProfile = userProfile;
        if (userProfile) {
          this.missionService.getAllUserMissions(userProfile.id).subscribe(missions => {
            if (missions) {
              this.dailyMissions = missions.filter(mission => mission.categoryId === 1);
              this.weeklyMissions = missions.filter(mission => mission.categoryId === 2);
              this.monthlyMissions = missions.filter(mission => mission.categoryId === 3);
              this.longTermMissions = missions.filter(mission => mission.categoryId === 4);
            }
          });
        }
      },
      error: (err: any) => {
        console.error('Error retrieving user profile:', err);
      }
    });
  }


  createMission(): void {
    this.newMission.profileId = this.currentUserProfile.id;
    this.missionService.createMission(this.newMission).subscribe({
      next: (newMission) => {
        this.newMission = { id: '00000000-0000-0000-0000-000000000000', profileId: '', categoryId: 1, title: '', isCompleted: false };

        this.ngOnInit();
      },
      error: (err: any) => {
        console.log(err);
      },
    });
  }

  loadMissions(userId: any): void {
    this.missionService.getAllUserMissions(userId).subscribe({
      next: (missions: Mission[]) => {
        this.missions = missions;
      },
      error: (err: any) => {
        console.log(err);
      },
      complete: () => {
        console.log('Missions loaded');
      }
    });
  }



  filterMissionsByCategory(missions: Mission[], categoryId: number): Mission[] {
    return missions.filter(mission => mission.categoryId === categoryId);
  }

  calculateProgressBarWidth(): number {
    const remainder = this.currentUserProfile.experiencePoints % 100;

    if (remainder === 0) {
      return 0;
    } else {
      return (remainder);
    }
  }

  updateMission(): void {

    this.missionService.updateMission(this.editingMission).subscribe({
      next: (updatedMission) => {
        console.log('Mission updated:', updatedMission);
        this.ngOnInit();
      },
      error: (err: any) => {
        console.error('Error updating mission:', err);
      }
    });
  }
}

