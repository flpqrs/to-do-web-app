import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { environment } from 'src/environments/environment.development';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserProfileService {
  private currentUserId!: string;

  
  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient, private authService: AuthService) { }

  setCurrentUserId(id: string): void {
    this.currentUserId = id;
  }

  getCurrentUserId(): string {
    return this.currentUserId;
  }


  getUserProfile(id: string): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/${id}`);
  }

  createUserProfile(userProfile: User): Observable<User> {
    
    const token = localStorage.getItem('token');
    const userId = this.authService.getUserIdFromToken();
    userProfile.userId = userId;
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
    return this.http.post<User>(`${this.baseUrl}/profile`, userProfile, httpOptions);
  }

  updateUserProfile(userProfile: User): Observable<User> {
    const token = localStorage.getItem('token');
    const userId = this.authService.getUserIdFromToken();

    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
    return this.http.put<User>(`${this.baseUrl}/profile`, userProfile, httpOptions);
  }

  deleteUserProfile(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }

  getCurrentUserProfile(userId: string): Observable<User> {
    const token = localStorage.getItem('token');
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${token}`
      })
    };
    return this.http.get<User>(`${this.baseUrl}/profile/user/${userId}`, httpOptions);
  }


}

