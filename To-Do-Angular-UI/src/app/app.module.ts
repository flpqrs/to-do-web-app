import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router'; 
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { RegisterComponent } from 'src/app/components/auth/register/register.component';
import { LoginComponent } from 'src/app/components/auth/login/login.component';
import { UserProfileComponent } from './components/users/add-user/add-user.component';
import { MissionPageComponent } from './components/missions/mission-page/mission-page.component';
import { LogoutComponent } from './components/auth/logout/logout.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { HomePageComponent } from './components/home/home-page/home-page.component';
import { AuthGuard } from './auth.guard';
import { ProfileComponent } from './components/users/profile/profile.component';
import { MissionsColumnComponent } from './components/missions-column/missions-column.component';



@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    UserProfileComponent,
    MissionPageComponent,
    LogoutComponent,
    HomePageComponent,
    ProfileComponent,
    MissionsColumnComponent,
  ],
  imports: [
    FormsModule,
    HttpClientModule, 
    BrowserModule,
    RouterModule.forRoot([
      { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
      { path: 'create-profile', component: UserProfileComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'missions', component: MissionPageComponent},
      { path: 'logout', component: LogoutComponent},
      { path: 'home', component: HomePageComponent, canActivate: [AuthGuard] },
      { path: '', redirectTo: '/home', pathMatch: 'full' }


    ]),
    FontAwesomeModule,
    MatProgressBarModule,
    BrowserAnimationsModule,
    ReactiveFormsModule
    
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
