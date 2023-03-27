import { Component, HostBinding, Input } from '@angular/core';
import { Mission } from 'src/app/models/mission.model';
import { MissionService } from 'src/app/services/mission.service';
import { MissionPageComponent } from '../missions/mission-page/mission-page.component';
import { faTrash,faPenToSquare, faCheck } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-missions-column',
  templateUrl: './missions-column.component.html',
  styleUrls: ['./missions-column.component.css']
})
export class MissionsColumnComponent {
  faTrash = faTrash;
  faCheck = faCheck;
  faPenToSquare = faPenToSquare;
  editingMission: Mission = {id: '00000000-0000-0000-0000-000000000000', profileId: '', title: '', categoryId: 1, isCompleted: false };
  constructor(
     private missionService: MissionService,
     private pageComponent: MissionPageComponent
     ){}

  @Input('title') title?: string;
  @Input('missions') missions?: Mission[];
  @HostBinding('class') class = 'col-sm';


  deleteMission(mission: Mission): void{
    this.missionService.deleteMission(mission.id).subscribe({
      next: () => {
        console.log('Mission deleted!');
        this.pageComponent.ngOnInit();
      }})}

  completeMission(mission: Mission): void {
    mission.isCompleted = true;
    this.missionService.updateMission(mission).subscribe({
      next: () => {
        console.log('Mission completed!');
        this.pageComponent.ngOnInit();
      },
      error: (err) => {
        console.error('Error completing mission:', err);
      }
    });
  }

  editMission(mission: Mission): void {
    this.pageComponent.editingMission = mission;
  }
}
