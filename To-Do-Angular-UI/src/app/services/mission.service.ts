import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Mission } from 'src/app/models/mission.model';
import { environment } from 'src/environments/environment.development';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class MissionService {
  private baseUrl = environment.baseApiUrl;

  constructor(private http: HttpClient, private authService: AuthService) { }

  createMission(mission: Mission): Observable<Mission> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    };

    return this.http.post<Mission>(`${this.baseUrl}/mission`, mission, httpOptions);
  }

  deleteMission(id: string): Observable<any> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };

    return this.http.delete(`${this.baseUrl}/mission/${id}`, httpOptions);
  }

  getAllUserMissions(userId: string): Observable<Mission[]> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };

    return this.http.get<Mission[]>(`${this.baseUrl}/mission/profile/${userId}`, httpOptions);
  }

  getMissionById(id: string): Observable<Mission> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };

    return this.http.get<Mission>(`${this.baseUrl}/mission/${id}`, httpOptions);
  }

  updateMission(mission: Mission): Observable<any> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      })
    };

    return this.http.put(`${this.baseUrl}/mission`, mission, httpOptions);
  }
}