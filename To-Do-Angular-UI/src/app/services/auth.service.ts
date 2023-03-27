import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment.development';
import jwtDecode from 'jwt-decode';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/auth/login`, {username, password}).pipe(
      map((response: any) => {
        localStorage.setItem('token', response.token);
      })
    );
  }

  register(username: string, email: string, password: string): Observable<any> {
    return this.http.post(`${this.baseUrl}/auth/register`, {username, email, password});
  }

  logout(): void {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getUserIdFromToken(): string {
    const token = localStorage.getItem('token');
    const decoded: any = jwtDecode(token!);
    return decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  }
}
